using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Models.Base
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Discription { get; set; }
    }
}
