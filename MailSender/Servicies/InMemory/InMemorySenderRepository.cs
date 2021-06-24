using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Servicies.InMemory
{
    public class InMemorySenderRepository : InMemoryPersonRepository <Sender>
    {
        private static IEnumerable<Sender> GetTestData(int Count = 10) => Enumerable.Range(1, Count)
           .Select(i => new Sender
           {
               Id = i,
               Name = $"Отправитель {i}",
               Address = $"sender-{i}@server.ru",
               Discription = $"Описание отправителя {i}"
           });

        public InMemorySenderRepository() : base(GetTestData()) { }
    }
}
