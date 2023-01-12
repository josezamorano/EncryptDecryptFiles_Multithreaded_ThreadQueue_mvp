using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static FileEncryptor.Form1;

namespace FileEncryptDecrypt.DomainLayer
{
    public class Cipher
    {

		// Tag to make sure this file is readable/decryptable by this class
		private const ulong FC_TAG = 0xFC010203040506CF;
        
		// Crypto Random number generator for use in EncryptFile		
		private static RandomNumberGenerator CryptoRandomNumber = new RNGCryptoServiceProvider();
        // Now will will initialize a buffer and will be processing the input file in chunks. 
        // This is done to avoid reading the whole file (which can be huge) into memory. 
        private static int bufferLen = 4096;
        private static string HASH_NAME = "SHA256";

        private static byte[] GenerateRandomBytes(int count)
        {
            byte[] bytes = new byte[count];
            CryptoRandomNumber.GetBytes(bytes);
            return bytes;
        }

        /// <summary>
		/// Checks to see if two byte array are equal
		/// </summary>
		/// <param name="b1">the first byte array</param>
		/// <param name="b2">the second byte array</param>
		/// <returns>true if b1.Length == b2.Length and each byte in b1 is
		/// equal to the corresponding byte in b2</returns>
		private static bool CheckByteArrays(byte[] b1, byte[] b2)
        {
            if (b1.Length == b2.Length)
            {
                for (int i = 0; i < b1.Length; ++i)
                {
                    if (b1[i] != b2[i])
                        return false;
                }
                return true;
            }
            return false;
        }

        private static SymmetricAlgorithm CreateRijndaelEncryptor(string password, byte[] salt)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt, HASH_NAME, 1000);

            SymmetricAlgorithm sma = Rijndael.Create();
            sma.KeySize = 256;
            sma.Key = pdb.GetBytes(32);
            sma.Padding = PaddingMode.PKCS7;
            return sma;
        }

        public string EncryptFile(string inFile, string outFile, string password , ProgressCallback callback)
        {
            FileStream fileStreamIn = File.OpenRead(inFile);
            FileStream fileStreamOut = File.OpenWrite(outFile);

            // generate IV and Salt
            byte[] IV = GenerateRandomBytes(16);
            byte[] salt = GenerateRandomBytes(16);

            SymmetricAlgorithm sma = CreateRijndaelEncryptor(password, salt);
            sma.IV = IV;

            // write the IV and salt to the beginning of the file
            fileStreamOut.Write(IV, 0, IV.Length);
            fileStreamOut.Write(salt, 0, salt.Length);

            string fileEncryptionInfo = ResolveEncryption(fileStreamIn, fileStreamOut, sma , callback);
            return (fileEncryptionInfo.Length == 0) ? inFile : inFile + "|" + fileEncryptionInfo;
        }

        private string ResolveEncryption(FileStream fileStreamIn, FileStream fileStreamOut, SymmetricAlgorithm sma , ProgressCallback callback)
        {
            try
            {
                long lSize = fileStreamIn.Length;  // the size of the input file for storing
                // create the hashing and crypto streams
                HashAlgorithm hasher = SHA256.Create();

                byte[] bytes = new byte[bufferLen];

                int read = -1; // the amount of bytes read from the input file
                CryptoStream cout = new CryptoStream(fileStreamOut, sma.CreateEncryptor(), CryptoStreamMode.Write);
                CryptoStream chash = new CryptoStream(Stream.Null, hasher, CryptoStreamMode.Write);

                // write the size of the file to the output file
                BinaryWriter bw = new BinaryWriter(cout);
                bw.Write(lSize);

                // write the file cryptor tag to the file
                bw.Write(FC_TAG);

                // read and the write the bytes to the crypto stream in BUFFER_SIZEd chunks
                while ((read = fileStreamIn.Read(bytes, 0, bytes.Length)) != 0)
                {
                    cout.Write(bytes, 0, read);
                    chash.Write(bytes, 0, read);
                    callback(read);
                }
                // flush and close the hashing object
                chash.Flush();
                chash.Close();

                // read the hash
                byte[] hash = hasher.Hash;

                // write the hash to the end of the file
                cout.Write(hash, 0, hash.Length);

                // flush and close the cryptostream
                cout.Flush();
                cout.Close();
                fileStreamIn.Close();
                fileStreamOut.Close();
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DecryptFile(string inFile, string outFile, string password, ProgressCallback decryptionProgressCallback)
        {
            // create and open the file streams
            FileStream fileStreamIn = File.OpenRead(inFile);
            FileStream fileStreamOut = File.OpenWrite(outFile);           

            // read off the IV and Salt
            byte[] IV = new byte[16];
            fileStreamIn.Read(IV, 0, 16);
            byte[] salt = new byte[16];
            fileStreamIn.Read(salt, 0, 16);

            // create the crypting stream
            SymmetricAlgorithm sma = CreateRijndaelEncryptor(password, salt);
            sma.IV = IV;

            var fileEncryptionInfo = ResolveDecryption(fileStreamIn, fileStreamOut,sma , decryptionProgressCallback);
            return (fileEncryptionInfo.Length == 0) ? inFile : inFile + "|" + fileEncryptionInfo;
        }

        private string ResolveDecryption(FileStream fileStreamIn, FileStream fileStreamOut, SymmetricAlgorithm sma , ProgressCallback callback)
        {            
            byte[] bytes = new byte[bufferLen]; // byte buffer
            int read = -1; // the amount of bytes read from the stream       
            long lSize = -1; // the size stored in the input stream

            // create the hashing object, so that we can verify the file
            HashAlgorithm hasher = SHA256.Create();

            // create the cryptostreams that will process the file
            try
            {
                using (CryptoStream cin = new CryptoStream(fileStreamIn, sma.CreateDecryptor(), CryptoStreamMode.Read),
                     chash = new CryptoStream(Stream.Null, hasher, CryptoStreamMode.Write))
                {
                    // read size from file
                    BinaryReader br = new BinaryReader(cin);
                    lSize = br.ReadInt64();
                    ulong tag = br.ReadUInt64();

                    if (FC_TAG != tag)
                        throw new Exception("File Corrupted!");

                    //determine number of reads to process on the file
                    long numReads = lSize / bufferLen;

                    // determine what is left of the file, after numReads
                    long slack = (long)lSize % bufferLen;

                    // read the buffer_sized chunks
                    for (int i = 0; i < numReads; ++i)
                    {
                        read = cin.Read(bytes, 0, bytes.Length);
                        fileStreamOut.Write(bytes, 0, read);
                        chash.Write(bytes, 0, read);
                        callback(read);
                    }

                    // now read the slack
                    if (slack > 0)
                    {
                        read = cin.Read(bytes, 0, (int)slack);
                        fileStreamOut.Write(bytes, 0, read);
                        chash.Write(bytes, 0, read);
                        callback(read);
                    }
                    // flush and close the hashing stream
                    chash.Flush();                   
                    chash.Close();

                    // flush and close the output file
                    fileStreamOut.Flush();                   
                    fileStreamOut.Close();

                    // read the current hash value
                    byte[] curHash = hasher.Hash;

                    // get and compare the current and old hash values
                    byte[] oldHash = new byte[hasher.HashSize / 8];
                    read = cin.Read(oldHash, 0, oldHash.Length);
                    if ((oldHash.Length != read) || (!CheckByteArrays(oldHash, curHash)))
                        throw new Exception("File Corrupted!");
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
