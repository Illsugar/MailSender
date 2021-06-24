using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Servicies.InMemory
{
    public class InMemoryRecipientRepository : InMemoryPersonRepository<Recipient>
    {
        private static IEnumerable<Recipient> GetTestData(int Count = 10) => Enumerable.Range(1, Count)
           .Select(i => new Recipient
           {
               Id = i,
               Name = $"Получатель {i}",
               Address = $"recipient-{i}@server.ru",
               Discription = $"Описание получателя {i}"
           });

        public InMemoryRecipientRepository() : base(GetTestData()) { }
    }
}
