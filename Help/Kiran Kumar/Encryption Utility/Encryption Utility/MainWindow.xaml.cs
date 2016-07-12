using System;
using System.Collections.Generic;
using System.Linq;
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
using TMS.Utility;

namespace Encryption_Utility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string salt = "L3$Mm0C+3n0f!r3V&LCOI";
        public MainWindow()
        {
            InitializeComponent();
        }
        private CryptographyManager CryptoGraphyInstance
        {
            get { return CryptographyManager.GetInstance(); }
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Please provide the input for encryption", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                txtInput.Focus();
            }
            string encryptedData = CryptoGraphyInstance.Encrypt(txtInput.Text, CryptoGraphyInstance.ComputeHash(salt, CryptographyManager.HashName.SHA256));
            txtOutput.Text = encryptedData;
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOutput.Text))
            {
                MessageBox.Show("Please provide the input for decryption", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                txtInput.Focus();
            }
            string decryptData = CryptoGraphyInstance.Decrypt(txtInput.Text, CryptoGraphyInstance.ComputeHash(salt, CryptographyManager.HashName.SHA256));
            txtOutput.Text = decryptData;
        }
    }
}
