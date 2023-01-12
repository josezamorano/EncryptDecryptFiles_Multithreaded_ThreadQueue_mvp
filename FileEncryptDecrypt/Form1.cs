using FileEncryptDecrypt.DomainLayer;
using FileEncryptDecrypt.DomainLayer.Models;
using FileEncryptDecrypt.Utils.Messages;
using FileEncryptDecrypt.Utils.Validator;
using System.Globalization;
using System.Web;
using System.Windows.Forms;

namespace FileEncryptor
{
    public partial class Form1 : Form
    {
        private FolderBrowserDialog folderBrowserDialog;
        private CryptographyManager cryptographyManager;
        private PasswordValidator passwordValidator;
        private static int ONE_HUNDRED = 100;
        private static double ONE_BYTE_AS_ONE_KILOBYTE = 0.001;
        private double _fileEncryptionReadSize = 0;
        private double _fileDecryptionReadSize = 0;
        private double _totalEncryptedFilesSizeBytes = 0;
        private double _totalDecryptedFilesSizeBytes = 0;

        public delegate void ReportCallBack(string encryptionReport);        
        public delegate void ProgressCallback(int progressValue);

        public Form1()
        {
            InitializeComponent();
            folderBrowserDialog = new FolderBrowserDialog();
            cryptographyManager = new CryptographyManager();
            passwordValidator = new PasswordValidator();
            SetLabelWarning();
            SetFolderBrowserDialog();
        }

        private void SetFolderBrowserDialog()
        {
            folderBrowserDialog.ShowHiddenFiles = false;
            folderBrowserDialog.Description = Notification.SELECT_A_FOLDER;
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.UseDescriptionForTitle = true;
            folderBrowserDialog.ShowHiddenFiles = true;
        }

        private void SetLabelWarning() 
        {
            lblWarningEncryptEmptyFolder.Text = string.Empty;
            lblWarningDecryptEmptyFolder.Text = string.Empty;
            
        }
        private void SetTextBoxesAndLabelsToEmpty()
        {
            txtEncryptFolderName.Text = string.Empty;
            txtDecryptFolderName.Text = string.Empty;

            lblTotalEncryptedFilesCount.Text = "0";
            lblTotalEncryptedFilesSize.Text = "0 kb";

            txtEncryptionPwd.Text = string.Empty;
            txtEncryptionConfirmPwd.Text = string.Empty;
            progressBarEncryption.Value = 0;

            lblTotalDecryptedFilesCount.Text = "0";
            lblTotalDecryptedFilesSize.Text = "0 kb";
            
            txtDecryptionPwd.Text = string.Empty;
            txtDecryptionConfirmPwd.Text = string.Empty;
            progressBarDecryption.Value = 0;
        }

        private void btnFolderBrowserEncrypt_Click(object sender, EventArgs e)
        {            
            SetLabelWarning();
            SetTextBoxesAndLabelsToEmpty();
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                string selectedEncryptFolderPath = folderBrowserDialog.SelectedPath;
                FolderContentInfo folderContentInfo = cryptographyManager.GetAllFiles(selectedEncryptFolderPath);
                txtEncryptFolderName.Text = selectedEncryptFolderPath;
                lblTotalEncryptedFilesCount.Text = folderContentInfo.TotalFiles.ToString();
                lblWarningEncryptEmptyFolder.Text = (folderContentInfo.TotalFiles == 0) ? Notification.WARNING_MESSAGE : string.Empty;
                lblTotalEncryptedFilesSize.Text= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00} kb", folderContentInfo.TotalFilesSize);
                _totalEncryptedFilesSizeBytes = folderContentInfo.TotalFilesSize / ONE_BYTE_AS_ONE_KILOBYTE;
            }
            folderBrowserDialog.Dispose();
        
        }

        private void btnFolderBrowserDecrypt_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = string.Empty;
            SetLabelWarning();
            SetTextBoxesAndLabelsToEmpty();
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selecteddecryptFolderPath = folderBrowserDialog.SelectedPath;
                FolderContentInfo folderContentInfo = cryptographyManager.GetAllFiles(selecteddecryptFolderPath);
                txtDecryptFolderName .Text = selecteddecryptFolderPath;
                lblTotalDecryptedFilesCount.Text = folderContentInfo.TotalFiles.ToString();
                lblWarningDecryptEmptyFolder.Text = (folderContentInfo.TotalFiles == 0) ? Notification.WARNING_MESSAGE : string.Empty;
                lblTotalDecryptedFilesSize.Text = String.Format(CultureInfo.InvariantCulture,"{0:0,0.00} kb", folderContentInfo.TotalFilesSize);
                _totalDecryptedFilesSizeBytes = folderContentInfo.TotalFilesSize / ONE_BYTE_AS_ONE_KILOBYTE;
            }
            folderBrowserDialog.Dispose();
        }

        private void txtEncryptionPwd_TextChanged(object sender, EventArgs e)
        {
            lblEncryptionPwdDiscrepancy.Text = string.Empty;
        }

        private void txtConfirmEncryptionPwd_TextChanged(object sender, EventArgs e)
        {
            lblEncryptionPwdDiscrepancy.Text += string.Empty;
        }

        private void txtDecryptionPwd_TextChanged(object sender, EventArgs e)
        {
            lblDecryptionPwdDiscrepancy.Text += string.Empty;
        }

        private void txtDecryptionConfirmPwd_TextChanged(object sender, EventArgs e)
        {
            lblDecryptionPwdDiscrepancy.Text += string.Empty;
        }
               
        private void btnEncryptFiles_Click(object sender, EventArgs e)
        {
            var notification = passwordValidator.ComparePasswords(txtEncryptionPwd.Text, txtEncryptionConfirmPwd.Text);
            if(notification != string.Empty)
            {
                lblEncryptionPwdDiscrepancy.Text = notification;
                return;
            }            
            ProgressCallback progressCallback = new ProgressCallback(ProgressBarEncryptionCallback);
            ReportCallBack reportCallback = new ReportCallBack(Report);
            CipherInvocationInfo cipherInvocationInfo = new CipherInvocationInfo();
            cipherInvocationInfo.CipherState = FileEncryptDecrypt.Utils.Enumerations.CipherState.Encrypted;
            cipherInvocationInfo.Password = txtEncryptionPwd.Text;
            cipherInvocationInfo.ReportCallBack = reportCallback;
            cipherInvocationInfo.ProgressCallback= progressCallback;
            cryptographyManager.CipherProcessAllFilesThread(cipherInvocationInfo);           
        }
        
        private void btnDecryptFiles_Click(object sender, EventArgs e)
        {
            var notification = passwordValidator.ComparePasswords(txtDecryptionPwd.Text , txtDecryptionConfirmPwd.Text);
            if(notification != string.Empty)
            {
                lblDecryptionPwdDiscrepancy.Text = Notification.WARNING_PWDS_DISCREPANCY;
                return;
            }
            ProgressCallback progressCallback = new ProgressCallback(ProgressBarDecryptionCallback);
            ReportCallBack reportCallback = new ReportCallBack(Report);
            CipherInvocationInfo cipherInvocationInfo = new CipherInvocationInfo();
            cipherInvocationInfo.CipherState = FileEncryptDecrypt.Utils.Enumerations.CipherState.Decrypted;
            cipherInvocationInfo.Password = txtDecryptionPwd.Text;
            cipherInvocationInfo.ReportCallBack = reportCallback;
            cipherInvocationInfo.ProgressCallback = progressCallback;
            cryptographyManager.CipherProcessAllFilesThread(cipherInvocationInfo);     
           
        } 

        private void Report(string report)
        {
            MessageBox.Show(report);
        }        

        private void ProgressBarEncryptionCallback(int value)
        {            

            Action action = () => {
                _fileEncryptionReadSize = _fileEncryptionReadSize + value;
                double currentRead = ((_fileEncryptionReadSize / _totalEncryptedFilesSizeBytes) * 100);
                double safeCurrentRead = (currentRead > ONE_HUNDRED) ? ONE_HUNDRED : currentRead;
                progressBarEncryption.Minimum = 0;
                progressBarEncryption.Maximum = ONE_HUNDRED;
                progressBarEncryption.Value = (int)safeCurrentRead;
            };
            progressBarEncryption.BeginInvoke(action);
        }
        
        private void ProgressBarDecryptionCallback(int value)
        {
            Action action = () => {
                _fileDecryptionReadSize = _fileDecryptionReadSize + value;
                double currentRead = ((_fileDecryptionReadSize / _totalDecryptedFilesSizeBytes) * 100);
                double safeCurrentRead = (currentRead > ONE_HUNDRED) ? ONE_HUNDRED : currentRead;
                progressBarDecryption.Minimum = 0;
                progressBarDecryption.Maximum = ONE_HUNDRED;
                progressBarDecryption.Value = (int)safeCurrentRead;
            };
            progressBarDecryption.BeginInvoke(action);
        }
    }
}