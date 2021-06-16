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
            using var massege = new MailMessage("irinasamylovskaya@mail.ru", "irinasamylovskaya@mail.ru"); //сообщение от кого и кому
            massege.Subject = "Какой-то текст";
            massege.Body = "Всё ещё какое-то сообщение. \nДата и время отправки: " + DateTime.Now.ToString("dd.mm.yy hh:mm");

            //порты для ьфшд 25, 587 или 2525
            using var client = new SmtpClient("smtp.mail.ru", 25); //для клиента указываем адрес сервера и порт

            client.EnableSsl = true;
            client.Credentials = new NetworkCredential
            {
                UserName = Login.Text,
                SecurePassword = Password.SecurePassword
            };
            
            try 
            {
                client.Send(massege);
                MessageBox.Show("Почта успешно отправлена", "Сообщение об отправке", MessageBoxButton.OK);
            }
            catch (SmtpException) 
            {
                MessageBox.Show("Что-то введено неверно:(\nПожалуйста, попробуйте снова", "Ошибка отправки!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
