using MailSender.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Interfaces
{
    interface IRepository <T> where T : Entity
    {
        IEnumerable<T> GetAll();

        T GetById(int Id);

        int Add(T item);

        void Update(T item);

        bool Remove(int id);
    }
}
