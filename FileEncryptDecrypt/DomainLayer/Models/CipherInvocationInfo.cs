using FileEncryptDecrypt.Utils.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FileEncryptor.Form1;

namespace FileEncryptDecrypt.DomainLayer.Models
{
    public class CipherInvocationInfo
    {
        public CipherState CipherState { get; set; }

        public string Password { get; set; } 
        
        public ReportCallBack ReportCallBack { get; set; }
        
        public ProgressCallback ProgressCallback { get; set; }
    }
}
