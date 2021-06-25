using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Interfaces
{
    public interface IUserDialog
    {
        bool EditServer(Server server);
    }
}
