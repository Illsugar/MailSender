using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestWpf
{
    public class WpfTestSender
    {
        public static void TestSender(string login, System.Security.SecureString pass)
        {
            
            using var massege = new MailMessage(WpfTestSrc.FromLetter, WpfTestSrc.ToLetter); //сообщение от кого и кому
            massege.Subject = "Какой-то текст";
            massege.Body = "Всё ещё какое-то сообщение. \nДата и время отправки: " + DateTime.Now.ToString("dd.mm.yy hh:mm");

            //порты для ьфшд 25, 587 или 2525
            using var client = new SmtpClient(WpfTestSrc.SmtpAdress, WpfTestSrc.Host); //для клиента указываем адрес сервера и порт

            client.EnableSsl = true;
            client.Credentials = new NetworkCredential
            {
                UserName = login, //= Login.Text,
                SecurePassword = pass //= Password.SecurePassword
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
