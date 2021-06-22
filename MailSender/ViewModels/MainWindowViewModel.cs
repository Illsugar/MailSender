using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MailSender.Commands;
using MailSender.Data;
using MailSender.Interfaces;
using MailSender.Models;
using MailSender.Servicies;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Server> _ServersRepository;
        private readonly IRepository<Sender> _SendersRepository;
        private readonly IRepository<Recipient> _RecipientsRepository;
        private readonly IRepository<Letter> _LettersRepository;
        private readonly IMailService _MailService;
        private readonly IStatistic _Statistic;

        public MainWindowViewModel(IRepository<Server> ServersRepository, IRepository<Sender> SendersRepository, IRepository<Recipient> RecipientsRepository,
            IRepository<Letter> LettersRepository, IMailService MailService, IStatistic Statistic)
        {
            _ServersRepository = ServersRepository;
            _SendersRepository = SendersRepository;
            _RecipientsRepository = RecipientsRepository;
            _LettersRepository = LettersRepository;
            _MailService = MailService;
            _Statistic = Statistic;
        }

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

        public ObservableCollection<Server> Servers { get; } = new ObservableCollection<Server>();

        private LambdaCommand _LoadServersCommand;

        /// <summary>Загрузка серверов</summary>
        public ICommand LoadServersCommand => _LoadServersCommand
            ??= new(OnLoadServersCommandExecuted);

        /// <summary>Логика выполнения - Загрузка серверов</summary>
        private void OnLoadServersCommandExecuted(object p)
        {
            Servers.Clear();
            foreach (var server in _ServersRepository.GetAll())
                Servers.Add(server);
        }

        private LambdaCommand _SendMessageCommand;

        /// <summary>Отправка почты</summary>
        public ICommand SendMessageCommand => _SendMessageCommand
            ??= new(OnSendMessageCommandExecuted);

        /// <summary>Логика выполнения - Отправка почты</summary>
        private void OnSendMessageCommandExecuted(object p)
        {
            _MailService.SendEmail("Отправитель", "Получатель", "Тема", "Тело письма");
        }
    }
}
