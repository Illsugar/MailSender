using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Servicies.InMemory
{
    class InMemoryLetterRepository : InMemoryRepository<Letter>
    {
        private static IEnumerable<Letter> GetTestData(int Count = 100) => Enumerable.Range(1, Count)
           .Select(i => new Letter
           {
               Id = i,
               Title = $"Сообщение {i}",
               Body = $"Текст сообщения {i}",
           });

        public InMemoryLetterRepository() : base(GetTestData()) { }

        public override void Update(Letter item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(item.Id);
            if (db_item is null || ReferenceEquals(db_item, item)) return;

            db_item.Title = item.Title;
            db_item.Body = item.Body;
        }
    }
}
