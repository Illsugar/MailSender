using System;
using System.Net;
using System.Net.Mail;
using System.Windows;


namespace TestWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var pass = Password.SecurePassword;

            WpfTestSender.TestSender(login, pass);
        }
    }
}
