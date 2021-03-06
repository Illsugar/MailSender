using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Models.Base
{
    public class Person : Entity
    {
        private string _Name;

        public virtual string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                NameChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public string Address { get; set; }
        public string Discription { get; set; }

        public event EventHandler NameChanged;
    }
}
