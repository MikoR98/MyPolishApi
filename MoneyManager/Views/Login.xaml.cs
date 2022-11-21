using MoneyManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoneyManager.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void PasswordBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(((PasswordBox)sender).Password))
            {
                if (((PasswordBox)sender).DataContext is LoginViewModel loginViewModel)
                {
                    var tmpPassword = SecureStringToString(PasswordBox1.SecurePassword);
                    var passwordArray = Encoding.UTF8.GetBytes(tmpPassword);

                    var sha512 = SHA512.Create();
                    var hashedPassword = sha512.ComputeHash(passwordArray);

                    var sBuilder = new StringBuilder();

                    for (int i = 0; i < hashedPassword.Length; i++)
                    {
                        sBuilder.Append(hashedPassword[i].ToString("x2"));
                    }

                    loginViewModel.Password = sBuilder.ToString();
                }
            }
        }

        private String SecureStringToString(SecureString password)
        {
            IntPtr passwordPtr = IntPtr.Zero;

            try
            {
                passwordPtr = Marshal.SecureStringToGlobalAllocUnicode(password);
                return Marshal.PtrToStringUni(passwordPtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(passwordPtr);
            }
        }
    }
}
