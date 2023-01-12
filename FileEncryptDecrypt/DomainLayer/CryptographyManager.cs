using FileEncryptDecrypt.DataAccessLayer.IOFiles;
using FileEncryptDecrypt.DomainLayer.Models;
using FileEncryptDecrypt.Utils.Enumerations;
using FileEncryptDecrypt.Utils.MultithreadingHelper;
using System.Diagnostics;
using System.Text;
using static FileEncryptor.Form1;

namespace FileEncryptDecrypt.DomainLayer
{
    public class CryptographyManager
    {
        private FileService _fileService;
        private Cipher _cryptographer;
        private ThreadQueue _threadQueue;
        private List<string> _allSelectedFiles;
        private double _allSelectedFilesTotalSize;
        private string _originalFolderName;
        List<string> _cipherFilesStateReport;
        private FolderContentInfo _folderContentInfo;
        public delegate void PartialReportCallback(string report);
        public delegate void PartialDecryptReportCallback(string report);
        private static double ONE_BYTE_IN_KILOBYTE = 0.001;

        public CryptographyManager()
        {
            _fileService = new FileService();
            _cryptographer = new Cipher();
            _threadQueue = new ThreadQueue();
            _allSelectedFiles = new List<string>();
            _cipherFilesStateReport = new List<string>();
            _originalFolderName = string.Empty;
            _folderContentInfo = new FolderContentInfo();
        }


        public FolderContentInfo GetAllFiles(string folder)
        {
            _originalFolderName = folder;
            _allSelectedFiles = _fileService.GetAllFilesInDirectory(folder);
            _allSelectedFilesTotalSize = GetAllSelectedFilesTotalSizeInKb(_allSelectedFiles);
            _folderContentInfo.TotalFiles = _allSelectedFiles.Count;
            _folderContentInfo.TotalFilesSize = _allSelectedFilesTotalSize;

            return _folderContentInfo;
        }

        private double GetAllSelectedFilesTotalSizeInKb(List<string> allFiles)
        {
            //1000 bytes = 1     kiloByte
            //1    byte  = 0.001 KiloByte           
            double totalSizeKb = 0.0;
            foreach (string file in allFiles)
            {
                var infoLengthBytes = new FileInfo(file).Length;
                totalSizeKb += (infoLengthBytes * ONE_BYTE_IN_KILOBYTE);
            }

            return totalSizeKb;
        }

   
        public void CipherProcessAllFilesThread(CipherInvocationInfo cipherInvocationInfo)
        {            
            _cipherFilesStateReport.Clear();
            Thread newThread = new Thread(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                List<string> encryptedFilesReport = ResolveCipherThreads(cipherInvocationInfo.CipherState, cipherInvocationInfo.Password, cipherInvocationInfo.ProgressCallback);
                long timeInMilliseconds = stopwatch.ElapsedMilliseconds;
                string consolidatedReport = createReport(timeInMilliseconds, encryptedFilesReport, CipherState.Encrypted);
                stopwatch.Stop();
                cipherInvocationInfo.ReportCallBack(consolidatedReport);

            });
            newThread.IsBackground = true;
            newThread.Name = "Cipher_Thread";
            newThread.Start();
        }

        private List<string> ResolveCipherThreads(CipherState cipherState, string cipherPassword, ProgressCallback progressCallback)
        {
            PartialReportCallback partialReportCallback = new PartialReportCallback(CompileReportCallback);

            foreach (string file in _allSelectedFiles)
            {
                string outputFile = _fileService.CreateCipherFileName(_originalFolderName, file, cipherState);

                _threadQueue.EnqueueTask(() => {
                    CipherActionInfo cipherActionInfo = new CipherActionInfo();
                    cipherActionInfo.CipherState = cipherState;
                    cipherActionInfo.InFile= file;
                    cipherActionInfo.OutFile = outputFile;
                    cipherActionInfo.Password= cipherPassword;
                    cipherActionInfo.ProgressCallback= progressCallback;

                    string cipherFileInfo = SelectCipherAction(cipherActionInfo);
                    partialReportCallback(cipherFileInfo);
                });
            }

            InspectTasksAreRunning();

            return _cipherFilesStateReport;
        }

        private string SelectCipherAction(CipherActionInfo cipherActionInfo )
        {
            string cipherFileInfo = string.Empty;
            switch (cipherActionInfo.CipherState)
            {
                case CipherState.Encrypted:
                    cipherFileInfo = _cryptographer.EncryptFile(cipherActionInfo.InFile, cipherActionInfo.OutFile, cipherActionInfo.Password, cipherActionInfo.ProgressCallback);
                    break;

                case CipherState.Decrypted:
                    cipherFileInfo = _cryptographer.DecryptFile(cipherActionInfo.InFile, cipherActionInfo.OutFile, cipherActionInfo.Password, cipherActionInfo.ProgressCallback);
                    break;
            }

            return cipherFileInfo;
        } 

        private void CompileReportCallback(string partialReport)
        {    
            _cipherFilesStateReport.Add(partialReport);
        }

        private void InspectTasksAreRunning()
        {
            bool tasksAreRunning = true;
            while (tasksAreRunning)
            {
                if (_allSelectedFiles.Count == _cipherFilesStateReport.Count)
                {
                    tasksAreRunning = false;
                }
            }
        }

        private string createReport(long elapsedMilliseconds , List<string> encryptionReport, CipherState cipherState)
        {
            int totalFilesOk = 0;
            int totalFilesWithErrors = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var report in encryptionReport)
            {
                string[] info = report.Split('|');
                if (info.Length == 1)
                {
                    totalFilesOk++;
                }
                else
                {
                    totalFilesWithErrors++;
                    sb.AppendLine(report + Environment.NewLine);
                }
            }
            var reportType = Enum.GetName(typeof(CipherState), cipherState);
            string messageFilesWithErrors = (totalFilesWithErrors > 0) ? Environment.NewLine + sb.ToString() : string.Empty;
            string consolidatedReport = "Execution time:" + elapsedMilliseconds/1000 + " seconds."+ Environment.NewLine +
                                        $"Total {reportType} Files: " + totalFilesOk + Environment.NewLine +
                                        "Total Failed Files: " + totalFilesWithErrors +
                                        messageFilesWithErrors;

            return consolidatedReport;
        }
    }
}
