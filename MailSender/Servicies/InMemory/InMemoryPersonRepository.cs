using MailSender.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Servicies.InMemory
{
    public abstract class InMemoryPersonRepository <T> : InMemoryRepository<T> where T : Person
    {
        protected InMemoryPersonRepository(IEnumerable<T> items) : base(items) { }

        public override void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(item.Id);
            if (db_item is null || ReferenceEquals(db_item, item)) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Discription = item.Discription;
        }
    }
}
