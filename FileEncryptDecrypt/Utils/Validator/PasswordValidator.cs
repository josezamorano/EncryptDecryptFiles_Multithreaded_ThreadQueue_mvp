using FileEncryptDecrypt.Utils.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptDecrypt.Utils.Validator
{
    public class PasswordValidator
    {
        public string ComparePasswords(string password ,string confirmPassword)
        {
            if (password.Trim() == string.Empty)
            {
                return Notification.WARNING_PWD_EMPTY;                
            }
            if (confirmPassword.Trim() == string.Empty)
            {
                return Notification.WARNING_CONFIRM_PWD_EMPTY;              
            }
            if ( password.Trim() != confirmPassword.Trim())
            {
                return Notification.WARNING_PWDS_DISCREPANCY;
                
            }
            return string.Empty;
        }
    }
}
