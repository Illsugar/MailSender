using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Data
{
    public class TestData
    {
        public static List<Server> Servers { get; } = Enumerable.Range(1, 10)
            .Select(i => new Server 
            { 
                Name = $"Сервер {i}",
                Address = $"smtp.server-{i}.ru",
                Login = $"User-{i}",
                Password = $"Password-{i}",
                UseSSL = i % 2 == 0
            })
            .ToList();

        public static List<Sender> Senders { get; } = Enumerable.Range(1, 10)
            .Select(i => new Sender
            {
                //ID = i,
                Name = $"Отправитель - {i}",
                Address = $"sender-{i}.server.ru",
                Discription = $"Описание отправителя{i}"
            })
            .ToList();

        public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 10)
            .Select(i => new Recipient
            {
                //ID = i,
                Name = $"Получатель - {i}",
                Address = $"recipient-{i}.server.ru",
                Discription = $"Описание получателя {i}"
            })
            .ToList();

        public static List<Letter> Letters { get; } = Enumerable.Range(1, 100)
            .Select(i => new Letter
            {
                Title = $"Тема письма {i}",
                Body = $"Какое-то письмо - {i}"
            })
            .ToList();
    }
}
