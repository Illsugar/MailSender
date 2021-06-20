using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get { return _Title; }
            set
            {
                Set(ref _Title, value);
            }
        }

        private string _Status = "Готово!";

        public string Status
        {
            get { return _Status; }
            set 
            {
                Set(ref _Status, value);
            }
        }
    }
}
