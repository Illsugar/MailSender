using MailSender.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Models
{
    public class Letter : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
