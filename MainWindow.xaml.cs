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

namespace Beencrypted
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int secretKey;






        public static string EncodeDecrypt(string str, int secretKey)
        {
            var ch = str.ToArray();
            string newStr = "";
            foreach (var c in ch)
                newStr += TopSecret(c, secretKey);
            return newStr;
        }

        public static char TopSecret(char character, int secretKey)
        {
            character = (char)(character ^ secretKey);
            return character;
        }

        private void ExitBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = TextIn.Text;
            try
            {
                secretKey = Convert.ToInt32(TextKey.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введите цифровые значения!\n" + ex.Message, "Ключ шифрования", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            str = EncodeDecrypt(str, secretKey);
            TextOut.Text = str;
        }

        private void copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(TextOut.Text);
        }

        private void paste_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextIn.Text = Clipboard.GetText();
            Clipboard.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextIn.Text = string.Empty;
            TextOut.Text = string.Empty;
            TextKey.Text = string.Empty;
        }
    }
}