using MailSender.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Models
{
    public class Recipient : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Discription { get; set; }
    }
}
