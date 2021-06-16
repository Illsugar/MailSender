using System;
using System.Net;
using System.Net.Mail; //пространтво имён для работы с почтой 

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using var massege = new MailMessage("irinasamylovskaya@mail.ru", "super.zebra-king@yandex.ru"); //сообщение от кого и кому
            massege.Subject = "Какой-то текст";
            massege.Body = "Всё ещё какое-то сообщение. \nДата и время отправки: " + DateTime.Now.ToString("dd.mm.yy hh:mm");

            using var client = new SmtpClient("smtp.mail.ru", 465); //для клиента указываем адрес сервера и порт
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential
            {
                UserName = "irinasamylovskaya",
                Password = "123"
            };

            client.Send(massege);
        }
    }
}
