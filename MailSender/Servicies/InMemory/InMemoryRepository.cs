using MailSender.Interfaces;
using MailSender.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Servicies.InMemory
{
    public abstract class InMemoryRepository<T> : IRepository<T> where T : Entity
    {
        private readonly List<T> _Items;
        private int _MaxId;

        protected InMemoryRepository(IEnumerable<T> items)
        {
            _Items = items.ToList();
            _MaxId = _Items.Count == 0 ? 1 : _Items.Max(i => i.Id) + 1;
        }

        public int Add(T item)
        {
            if (item is null) throw new ArgumentException(nameof(item));
            if (_Items.Contains(item)) return item.Id;

            item.Id = _MaxId++;
            _Items.Add(item);
            return item.Id;
        }

        public IEnumerable<T> GetAll() => _Items;

        public T GetById(int Id) => _Items.FirstOrDefault(item => item.Id == Id);

        public abstract void Update(T item);

        public bool Remove(int id) => _Items.RemoveAll(item => item.Id == id) > 0;
    }
}
