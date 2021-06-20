using System.Windows;
using System.Windows.Input;
using MailSender.Commands;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get => _Title;
            set
            {
                Set(ref _Title, value);
            }
        }

        private string _Status = "Готово!";

        public string Status
        {
            get => _Status;
            set 
            {
                Set(ref _Status, value);
            }
        }

        private ICommand _ExitCommand;
        public ICommand ExitCommand => _ExitCommand ??= new LambdaCommand(OnExitCommandExecute);
        
        private void OnExitCommandExecute(object Obj)
        {
            Application.Current.Shutdown();
        }

        private ICommand _AboutCommand;
        public ICommand AboutCommad => _AboutCommand ??= new LambdaCommand(OnAboutExecute);

        private void OnAboutExecute(object Obj)
        {
            MessageBox.Show("Рассыльщик почты", "О прграмме");
        }
    }
}
