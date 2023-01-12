namespace FileEncryptor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFolderBrowserEncrypt = new System.Windows.Forms.Button();
            this.txtEncryptFolderName = new System.Windows.Forms.TextBox();
            this.lblEncryptionFolderName = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tbpEncryptFilesInFolder = new System.Windows.Forms.TabPage();
            this.progressBarEncryption = new System.Windows.Forms.ProgressBar();
            this.lblProgressEncrypt = new System.Windows.Forms.Label();
            this.lblTotalEncryptedFilesSize = new System.Windows.Forms.Label();
            this.lblEncryptionPwdDiscrepancy = new System.Windows.Forms.Label();
            this.btnEncryptFiles = new System.Windows.Forms.Button();
            this.txtEncryptionConfirmPwd = new System.Windows.Forms.TextBox();
            this.lblConfirmEncryptiondPwd = new System.Windows.Forms.Label();
            this.txtEncryptionPwd = new System.Windows.Forms.TextBox();
            this.lblEncryptionPwdName = new System.Windows.Forms.Label();
            this.lblWarningEncryptEmptyFolder = new System.Windows.Forms.Label();
            this.lblTotalEncryptedFilesCount = new System.Windows.Forms.Label();
            this.lblEncryptFilesInFolder = new System.Windows.Forms.Label();
            this.tbpDecryptFilesInFolder = new System.Windows.Forms.TabPage();
            this.lblProgressDecrypt = new System.Windows.Forms.Label();
            this.progressBarDecryption = new System.Windows.Forms.ProgressBar();
            this.lblTotalDecryptedFilesSize = new System.Windows.Forms.Label();
            this.lblDecryptionPwdDiscrepancy = new System.Windows.Forms.Label();
            this.btnDecryptFiles = new System.Windows.Forms.Button();
            this.txtDecryptionConfirmPwd = new System.Windows.Forms.TextBox();
            this.lblConfirmDecryptionPwd = new System.Windows.Forms.Label();
            this.txtDecryptionPwd = new System.Windows.Forms.TextBox();
            this.lblDecryptionPwdName = new System.Windows.Forms.Label();
            this.lblWarningDecryptEmptyFolder = new System.Windows.Forms.Label();
            this.lblTotalDecryptedFilesCount = new System.Windows.Forms.Label();
            this.lblDecryptFilesInFolder = new System.Windows.Forms.Label();
            this.txtDecryptFolderName = new System.Windows.Forms.TextBox();
            this.lblDecryptionFolderName = new System.Windows.Forms.Label();
            this.btnFolderBrowserDecrypt = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tbpEncryptFilesInFolder.SuspendLayout();
            this.tbpDecryptFilesInFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFolderBrowserEncrypt
            // 
            this.btnFolderBrowserEncrypt.Location = new System.Drawing.Point(19, 40);
            this.btnFolderBrowserEncrypt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFolderBrowserEncrypt.Name = "btnFolderBrowserEncrypt";
            this.btnFolderBrowserEncrypt.Size = new System.Drawing.Size(117, 37);
            this.btnFolderBrowserEncrypt.TabIndex = 0;
            this.btnFolderBrowserEncrypt.Text = "Select Folder";
            this.btnFolderBrowserEncrypt.UseVisualStyleBackColor = true;
            this.btnFolderBrowserEncrypt.Click += new System.EventHandler(this.btnFolderBrowserEncrypt_Click);
            // 
            // txtEncryptFolderName
            // 
            this.txtEncryptFolderName.Location = new System.Drawing.Point(142, 41);
            this.txtEncryptFolderName.Multiline = true;
            this.txtEncryptFolderName.Name = "txtEncryptFolderName";
            this.txtEncryptFolderName.ReadOnly = true;
            this.txtEncryptFolderName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEncryptFolderName.Size = new System.Drawing.Size(380, 35);
            this.txtEncryptFolderName.TabIndex = 1;
            // 
            // lblEncryptionFolderName
            // 
            this.lblEncryptionFolderName.AutoSize = true;
            this.lblEncryptionFolderName.Location = new System.Drawing.Point(142, 18);
            this.lblEncryptionFolderName.Name = "lblEncryptionFolderName";
            this.lblEncryptionFolderName.Size = new System.Drawing.Size(209, 20);
            this.lblEncryptionFolderName.TabIndex = 2;
            this.lblEncryptionFolderName.Text = "Selected Folder for Encryption";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tbpEncryptFilesInFolder);
            this.tabControl.Controls.Add(this.tbpDecryptFilesInFolder);
            this.tabControl.Location = new System.Drawing.Point(0, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(710, 278);
            this.tabControl.TabIndex = 3;
            // 
            // tbpEncryptFilesInFolder
            // 
            this.tbpEncryptFilesInFolder.Controls.Add(this.progressBarEncryption);
            this.tbpEncryptFilesInFolder.Controls.Add(this.lblProgressEncrypt);
            this.tbpEncryptFilesInFolder.Controls.Add(this.lblTotalEncryptedFilesSize);
            this.tbpEncryptFilesInFolder.Controls.Add(this.lblEncryptionPwdDiscrepancy);
            this.tbpEncryptFilesInFolder.Controls.Add(this.btnEncryptFiles);
            this.tbpEncryptFilesInFolder.Controls.Add(this.txtEncryptionConfirmPwd);
            this.tbpEncryptFilesInFolder.Controls.Add(this.lblConfirmEncryptiondPwd);
            this.tbpEncryptFilesInFolder.Controls.Add(this.txtEncryptionPwd);
            this.tbpEncryptFilesInFolder.Controls.Add(this.lblEncryptionPwdName);
            this.tbpEncryptFilesInFolder.Controls.Add(this.lblWarningEncryptEmptyFolder);
            this.tbpEncryptFilesInFolder.Controls.Add(this.lblTotalEncryptedFilesCount);
            this.tbpEncryptFilesInFolder.Controls.Add(this.lblEncryptFilesInFolder);
            this.tbpEncryptFilesInFolder.Controls.Add(this.txtEncryptFolderName);
            this.tbpEncryptFilesInFolder.Controls.Add(this.lblEncryptionFolderName);
            this.tbpEncryptFilesInFolder.Controls.Add(this.btnFolderBrowserEncrypt);
            this.tbpEncryptFilesInFolder.Location = new System.Drawing.Point(4, 29);
            this.tbpEncryptFilesInFolder.Name = "tbpEncryptFilesInFolder";
            this.tbpEncryptFilesInFolder.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEncryptFilesInFolder.Size = new System.Drawing.Size(702, 245);
            this.tbpEncryptFilesInFolder.TabIndex = 1;
            this.tbpEncryptFilesInFolder.Text = "EncryptFiles In Folder";
            this.tbpEncryptFilesInFolder.UseVisualStyleBackColor = true;
            // 
            // progressBarEncryption
            // 
            this.progressBarEncryption.Location = new System.Drawing.Point(207, 209);
            this.progressBarEncryption.Name = "progressBarEncryption";
            this.progressBarEncryption.Size = new System.Drawing.Size(315, 10);
            this.progressBarEncryption.TabIndex = 14;
            // 
            // lblProgressEncrypt
            // 
            this.lblProgressEncrypt.AutoSize = true;
            this.lblProgressEncrypt.Location = new System.Drawing.Point(19, 199);
            this.lblProgressEncrypt.Name = "lblProgressEncrypt";
            this.lblProgressEncrypt.Size = new System.Drawing.Size(139, 20);
            this.lblProgressEncrypt.TabIndex = 13;
            this.lblProgressEncrypt.Text = "Encryption Progress";
            // 
            // lblTotalEncryptedFilesSize
            // 
            this.lblTotalEncryptedFilesSize.AutoSize = true;
            this.lblTotalEncryptedFilesSize.Location = new System.Drawing.Point(526, 56);
            this.lblTotalEncryptedFilesSize.Name = "lblTotalEncryptedFilesSize";
            this.lblTotalEncryptedFilesSize.Size = new System.Drawing.Size(37, 20);
            this.lblTotalEncryptedFilesSize.TabIndex = 12;
            this.lblTotalEncryptedFilesSize.Text = "0 kb";
            // 
            // lblEncryptionPwdDiscrepancy
            // 
            this.lblEncryptionPwdDiscrepancy.AutoSize = true;
            this.lblEncryptionPwdDiscrepancy.Location = new System.Drawing.Point(207, 193);
            this.lblEncryptionPwdDiscrepancy.Name = "lblEncryptionPwdDiscrepancy";
            this.lblEncryptionPwdDiscrepancy.Size = new System.Drawing.Size(0, 20);
            this.lblEncryptionPwdDiscrepancy.TabIndex = 11;
            // 
            // btnEncryptFiles
            // 
            this.btnEncryptFiles.Location = new System.Drawing.Point(547, 132);
            this.btnEncryptFiles.Name = "btnEncryptFiles";
            this.btnEncryptFiles.Size = new System.Drawing.Size(117, 36);
            this.btnEncryptFiles.TabIndex = 10;
            this.btnEncryptFiles.Text = "Encrypt Files";
            this.btnEncryptFiles.UseVisualStyleBackColor = true;
            this.btnEncryptFiles.Click += new System.EventHandler(this.btnEncryptFiles_Click);
            // 
            // txtEncryptionConfirmPwd
            // 
            this.txtEncryptionConfirmPwd.Location = new System.Drawing.Point(205, 153);
            this.txtEncryptionConfirmPwd.Multiline = true;
            this.txtEncryptionConfirmPwd.Name = "txtEncryptionConfirmPwd";
            this.txtEncryptionConfirmPwd.PasswordChar = '*';
            this.txtEncryptionConfirmPwd.Size = new System.Drawing.Size(317, 34);
            this.txtEncryptionConfirmPwd.TabIndex = 9;
            this.txtEncryptionConfirmPwd.TextChanged += new System.EventHandler(this.txtConfirmEncryptionPwd_TextChanged);
            // 
            // lblConfirmEncryptiondPwd
            // 
            this.lblConfirmEncryptiondPwd.AutoSize = true;
            this.lblConfirmEncryptiondPwd.Location = new System.Drawing.Point(19, 167);
            this.lblConfirmEncryptiondPwd.Name = "lblConfirmEncryptiondPwd";
            this.lblConfirmEncryptiondPwd.Size = new System.Drawing.Size(127, 20);
            this.lblConfirmEncryptiondPwd.TabIndex = 8;
            this.lblConfirmEncryptiondPwd.Text = "Confirm Password";
            // 
            // txtEncryptionPwd
            // 
            this.txtEncryptionPwd.Location = new System.Drawing.Point(205, 118);
            this.txtEncryptionPwd.Multiline = true;
            this.txtEncryptionPwd.Name = "txtEncryptionPwd";
            this.txtEncryptionPwd.PasswordChar = '*';
            this.txtEncryptionPwd.Size = new System.Drawing.Size(317, 34);
            this.txtEncryptionPwd.TabIndex = 7;
            this.txtEncryptionPwd.TextChanged += new System.EventHandler(this.txtEncryptionPwd_TextChanged);
            // 
            // lblEncryptionPwdName
            // 
            this.lblEncryptionPwdName.AutoSize = true;
            this.lblEncryptionPwdName.Location = new System.Drawing.Point(19, 132);
            this.lblEncryptionPwdName.Name = "lblEncryptionPwdName";
            this.lblEncryptionPwdName.Size = new System.Drawing.Size(179, 20);
            this.lblEncryptionPwdName.TabIndex = 6;
            this.lblEncryptionPwdName.Text = "Type Encryption Password";
            // 
            // lblWarningEncryptEmptyFolder
            // 
            this.lblWarningEncryptEmptyFolder.AutoSize = true;
            this.lblWarningEncryptEmptyFolder.ForeColor = System.Drawing.Color.Red;
            this.lblWarningEncryptEmptyFolder.Location = new System.Drawing.Point(147, 82);
            this.lblWarningEncryptEmptyFolder.Name = "lblWarningEncryptEmptyFolder";
            this.lblWarningEncryptEmptyFolder.Size = new System.Drawing.Size(0, 20);
            this.lblWarningEncryptEmptyFolder.TabIndex = 5;
            // 
            // lblTotalEncryptedFilesCount
            // 
            this.lblTotalEncryptedFilesCount.AutoSize = true;
            this.lblTotalEncryptedFilesCount.Location = new System.Drawing.Point(527, 38);
            this.lblTotalEncryptedFilesCount.Name = "lblTotalEncryptedFilesCount";
            this.lblTotalEncryptedFilesCount.Size = new System.Drawing.Size(17, 20);
            this.lblTotalEncryptedFilesCount.TabIndex = 4;
            this.lblTotalEncryptedFilesCount.Text = "0";
            // 
            // lblEncryptFilesInFolder
            // 
            this.lblEncryptFilesInFolder.AutoSize = true;
            this.lblEncryptFilesInFolder.Location = new System.Drawing.Point(527, 18);
            this.lblEncryptFilesInFolder.Name = "lblEncryptFilesInFolder";
            this.lblEncryptFilesInFolder.Size = new System.Drawing.Size(171, 20);
            this.lblEncryptFilesInFolder.TabIndex = 3;
            this.lblEncryptFilesInFolder.Text = "Files in Folder to Encrypt";
            // 
            // tbpDecryptFilesInFolder
            // 
            this.tbpDecryptFilesInFolder.Controls.Add(this.lblProgressDecrypt);
            this.tbpDecryptFilesInFolder.Controls.Add(this.progressBarDecryption);
            this.tbpDecryptFilesInFolder.Controls.Add(this.lblTotalDecryptedFilesSize);
            this.tbpDecryptFilesInFolder.Controls.Add(this.lblDecryptionPwdDiscrepancy);
            this.tbpDecryptFilesInFolder.Controls.Add(this.btnDecryptFiles);
            this.tbpDecryptFilesInFolder.Controls.Add(this.txtDecryptionConfirmPwd);
            this.tbpDecryptFilesInFolder.Controls.Add(this.lblConfirmDecryptionPwd);
            this.tbpDecryptFilesInFolder.Controls.Add(this.txtDecryptionPwd);
            this.tbpDecryptFilesInFolder.Controls.Add(this.lblDecryptionPwdName);
            this.tbpDecryptFilesInFolder.Controls.Add(this.lblWarningDecryptEmptyFolder);
            this.tbpDecryptFilesInFolder.Controls.Add(this.lblTotalDecryptedFilesCount);
            this.tbpDecryptFilesInFolder.Controls.Add(this.lblDecryptFilesInFolder);
            this.tbpDecryptFilesInFolder.Controls.Add(this.txtDecryptFolderName);
            this.tbpDecryptFilesInFolder.Controls.Add(this.lblDecryptionFolderName);
            this.tbpDecryptFilesInFolder.Controls.Add(this.btnFolderBrowserDecrypt);
            this.tbpDecryptFilesInFolder.Location = new System.Drawing.Point(4, 29);
            this.tbpDecryptFilesInFolder.Name = "tbpDecryptFilesInFolder";
            this.tbpDecryptFilesInFolder.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDecryptFilesInFolder.Size = new System.Drawing.Size(702, 245);
            this.tbpDecryptFilesInFolder.TabIndex = 2;
            this.tbpDecryptFilesInFolder.Text = "Decrypt Files In Folder";
            this.tbpDecryptFilesInFolder.UseVisualStyleBackColor = true;
            // 
            // lblProgressDecrypt
            // 
            this.lblProgressDecrypt.AutoSize = true;
            this.lblProgressDecrypt.Location = new System.Drawing.Point(19, 199);
            this.lblProgressDecrypt.Name = "lblProgressDecrypt";
            this.lblProgressDecrypt.Size = new System.Drawing.Size(142, 20);
            this.lblProgressDecrypt.TabIndex = 26;
            this.lblProgressDecrypt.Text = "Decryption Progress";
            // 
            // progressBarDecryption
            // 
            this.progressBarDecryption.Location = new System.Drawing.Point(206, 209);
            this.progressBarDecryption.Name = "progressBarDecryption";
            this.progressBarDecryption.Size = new System.Drawing.Size(316, 10);
            this.progressBarDecryption.TabIndex = 25;
            // 
            // lblTotalDecryptedFilesSize
            // 
            this.lblTotalDecryptedFilesSize.AutoSize = true;
            this.lblTotalDecryptedFilesSize.Location = new System.Drawing.Point(526, 56);
            this.lblTotalDecryptedFilesSize.Name = "lblTotalDecryptedFilesSize";
            this.lblTotalDecryptedFilesSize.Size = new System.Drawing.Size(37, 20);
            this.lblTotalDecryptedFilesSize.TabIndex = 24;
            this.lblTotalDecryptedFilesSize.Text = "0 kb";
            // 
            // lblDecryptionPwdDiscrepancy
            // 
            this.lblDecryptionPwdDiscrepancy.AutoSize = true;
            this.lblDecryptionPwdDiscrepancy.Location = new System.Drawing.Point(207, 193);
            this.lblDecryptionPwdDiscrepancy.Name = "lblDecryptionPwdDiscrepancy";
            this.lblDecryptionPwdDiscrepancy.Size = new System.Drawing.Size(0, 20);
            this.lblDecryptionPwdDiscrepancy.TabIndex = 23;
            // 
            // btnDecryptFiles
            // 
            this.btnDecryptFiles.Location = new System.Drawing.Point(547, 132);
            this.btnDecryptFiles.Name = "btnDecryptFiles";
            this.btnDecryptFiles.Size = new System.Drawing.Size(117, 36);
            this.btnDecryptFiles.TabIndex = 22;
            this.btnDecryptFiles.Text = "Decrypt Files";
            this.btnDecryptFiles.UseVisualStyleBackColor = true;
            this.btnDecryptFiles.Click += new System.EventHandler(this.btnDecryptFiles_Click);
            // 
            // txtDecryptionConfirmPwd
            // 
            this.txtDecryptionConfirmPwd.Location = new System.Drawing.Point(205, 153);
            this.txtDecryptionConfirmPwd.Multiline = true;
            this.txtDecryptionConfirmPwd.Name = "txtDecryptionConfirmPwd";
            this.txtDecryptionConfirmPwd.PasswordChar = '*';
            this.txtDecryptionConfirmPwd.Size = new System.Drawing.Size(317, 34);
            this.txtDecryptionConfirmPwd.TabIndex = 21;
            this.txtDecryptionConfirmPwd.TextChanged += new System.EventHandler(this.txtDecryptionConfirmPwd_TextChanged);
            // 
            // lblConfirmDecryptionPwd
            // 
            this.lblConfirmDecryptionPwd.AutoSize = true;
            this.lblConfirmDecryptionPwd.Location = new System.Drawing.Point(19, 167);
            this.lblConfirmDecryptionPwd.Name = "lblConfirmDecryptionPwd";
            this.lblConfirmDecryptionPwd.Size = new System.Drawing.Size(127, 20);
            this.lblConfirmDecryptionPwd.TabIndex = 20;
            this.lblConfirmDecryptionPwd.Text = "Confirm Password";
            // 
            // txtDecryptionPwd
            // 
            this.txtDecryptionPwd.Location = new System.Drawing.Point(205, 118);
            this.txtDecryptionPwd.Multiline = true;
            this.txtDecryptionPwd.Name = "txtDecryptionPwd";
            this.txtDecryptionPwd.PasswordChar = '*';
            this.txtDecryptionPwd.Size = new System.Drawing.Size(317, 34);
            this.txtDecryptionPwd.TabIndex = 19;
            this.txtDecryptionPwd.TextChanged += new System.EventHandler(this.txtDecryptionPwd_TextChanged);
            // 
            // lblDecryptionPwdName
            // 
            this.lblDecryptionPwdName.AutoSize = true;
            this.lblDecryptionPwdName.Location = new System.Drawing.Point(19, 132);
            this.lblDecryptionPwdName.Name = "lblDecryptionPwdName";
            this.lblDecryptionPwdName.Size = new System.Drawing.Size(182, 20);
            this.lblDecryptionPwdName.TabIndex = 18;
            this.lblDecryptionPwdName.Text = "Type Decryption Password";
            // 
            // lblWarningDecryptEmptyFolder
            // 
            this.lblWarningDecryptEmptyFolder.AutoSize = true;
            this.lblWarningDecryptEmptyFolder.ForeColor = System.Drawing.Color.Red;
            this.lblWarningDecryptEmptyFolder.Location = new System.Drawing.Point(147, 89);
            this.lblWarningDecryptEmptyFolder.Name = "lblWarningDecryptEmptyFolder";
            this.lblWarningDecryptEmptyFolder.Size = new System.Drawing.Size(0, 20);
            this.lblWarningDecryptEmptyFolder.TabIndex = 17;
            // 
            // lblTotalDecryptedFilesCount
            // 
            this.lblTotalDecryptedFilesCount.AutoSize = true;
            this.lblTotalDecryptedFilesCount.Location = new System.Drawing.Point(527, 38);
            this.lblTotalDecryptedFilesCount.Name = "lblTotalDecryptedFilesCount";
            this.lblTotalDecryptedFilesCount.Size = new System.Drawing.Size(17, 20);
            this.lblTotalDecryptedFilesCount.TabIndex = 16;
            this.lblTotalDecryptedFilesCount.Text = "0";
            // 
            // lblDecryptFilesInFolder
            // 
            this.lblDecryptFilesInFolder.AutoSize = true;
            this.lblDecryptFilesInFolder.Location = new System.Drawing.Point(527, 18);
            this.lblDecryptFilesInFolder.Name = "lblDecryptFilesInFolder";
            this.lblDecryptFilesInFolder.Size = new System.Drawing.Size(174, 20);
            this.lblDecryptFilesInFolder.TabIndex = 15;
            this.lblDecryptFilesInFolder.Text = "Files in Folder to Decrypt";
            // 
            // txtDecryptFolderName
            // 
            this.txtDecryptFolderName.Location = new System.Drawing.Point(142, 41);
            this.txtDecryptFolderName.Multiline = true;
            this.txtDecryptFolderName.Name = "txtDecryptFolderName";
            this.txtDecryptFolderName.ReadOnly = true;
            this.txtDecryptFolderName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDecryptFolderName.Size = new System.Drawing.Size(380, 35);
            this.txtDecryptFolderName.TabIndex = 13;
            // 
            // lblDecryptionFolderName
            // 
            this.lblDecryptionFolderName.AutoSize = true;
            this.lblDecryptionFolderName.Location = new System.Drawing.Point(142, 18);
            this.lblDecryptionFolderName.Name = "lblDecryptionFolderName";
            this.lblDecryptionFolderName.Size = new System.Drawing.Size(212, 20);
            this.lblDecryptionFolderName.TabIndex = 14;
            this.lblDecryptionFolderName.Text = "Selected Folder for Decryption";
            // 
            // btnFolderBrowserDecrypt
            // 
            this.btnFolderBrowserDecrypt.Location = new System.Drawing.Point(19, 40);
            this.btnFolderBrowserDecrypt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFolderBrowserDecrypt.Name = "btnFolderBrowserDecrypt";
            this.btnFolderBrowserDecrypt.Size = new System.Drawing.Size(117, 37);
            this.btnFolderBrowserDecrypt.TabIndex = 12;
            this.btnFolderBrowserDecrypt.Text = "Select Folder";
            this.btnFolderBrowserDecrypt.UseVisualStyleBackColor = true;
            this.btnFolderBrowserDecrypt.Click += new System.EventHandler(this.btnFolderBrowserDecrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 281);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.tbpEncryptFilesInFolder.ResumeLayout(false);
            this.tbpEncryptFilesInFolder.PerformLayout();
            this.tbpDecryptFilesInFolder.ResumeLayout(false);
            this.tbpDecryptFilesInFolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnFolderBrowserEncrypt;
        private TextBox txtEncryptFolderName;
        private Label lblEncryptionFolderName;
        private TabControl tabControl;
        private TabPage tbpEncryptFilesInFolder;
        private TabPage tbpDecryptFilesInFolder;
        private Label lblTotalEncryptedFilesCount;
        private Label lblEncryptFilesInFolder;
        private Label lblWarningEncryptEmptyFolder;
        private TextBox txtEncryptionPwd;
        private Label lblEncryptionPwdName;
        private TextBox txtEncryptionConfirmPwd;
        private Label lblConfirmEncryptiondPwd;
        private Button btnEncryptFiles;
        private Label lblEncryptionPwdDiscrepancy;
        private Label lblDecryptionPwdDiscrepancy;
        private Button btnDecryptFiles;
        private TextBox txtDecryptionConfirmPwd;
        private Label lblConfirmDecryptionPwd;
        private TextBox txtDecryptionPwd;
        private Label lblDecryptionPwdName;
        private Label lblWarningDecryptEmptyFolder;
        private Label lblTotalDecryptedFilesCount;
        private Label lblDecryptFilesInFolder;
        private TextBox txtDecryptFolderName;
        private Label lblDecryptionFolderName;
        private Button btnFolderBrowserDecrypt;
        private Label lblTotalEncryptedFilesSize;
        private Label lblTotalDecryptedFilesSize;
        private Label lblProgressDecrypt;
        private ProgressBar progressBarDecryption;
        private Label lblProgressEncrypt;
        private ProgressBar progressBarEncryption;
    }
}