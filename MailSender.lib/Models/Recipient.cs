using MailSender.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Models
{
    public class Recipient : Person
    {
        public override string Name 
        { 
            get => base.Name;
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Задана пустая строка имени", nameof(value));
                base.Name = value;
            }
        }
    }
}
