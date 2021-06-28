using System;
using System.Windows.Input;
using MailSender.Commands;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    class ServerEditorDialogViewModel : ViewModel
    {
        public event EventHandler EditCompleted;
        public event EventHandler EditCanceled;


        private LambdaCommand _OkCommand;

        public ICommand OkCommand => _OkCommand ??= new(OnOkCommandExecuted);

        private void OnOkCommandExecuted(object p)
        {
            EditCompleted?.Invoke(this, EventArgs.Empty);
        }


        private LambdaCommand _CancelCommand;

        public ICommand CancelCommand => _CancelCommand ??= new(OnCancelCommandExecuted);

        private void OnCancelCommandExecuted(object p)
        {
            EditCanceled?.Invoke(this, EventArgs.Empty);
        }


        private string _Name;

        public string Name { get => _Name; set => Set(ref _Name, value); }


        private string _Address;

        public string Address { get => _Address; set => Set(ref _Address, value); }


        private int _Port;

        public int Port { get => _Port; set => Set(ref _Port, value); }


        private bool _UseSSL;

        public bool UseSSL { get => _UseSSL; set => Set(ref _UseSSL, value); }


        private string _Login;


        public string Login { get => _Login; set => Set(ref _Login, value); }


        private string _Password;

        public string Password { get => _Password; set => Set(ref _Password, value); }
    }
}
