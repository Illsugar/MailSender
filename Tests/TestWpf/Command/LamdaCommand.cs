using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MailSender.Command.Base
{
    public class LamdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LamdaCommand(Action<object> Execute, Func<object,bool> CanExecute)
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }
        public override bool CanExecute(object parameter)
        {
            return _CanExecute.Invoke(parameter);
        }

        public override void Execute(object parameter)
        {
            _CanExecute.Invoke(parameter);
        }
    }
}
