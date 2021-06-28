using System.Collections.ObjectModel;
using System.Linq;
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
        private readonly IUserDialog _UserDialog;

        public MainWindowViewModel(IRepository<Server> ServersRepository, IRepository<Sender> SendersRepository, IRepository<Recipient> RecipientsRepository,
            IRepository<Letter> LettersRepository, IMailService MailService, IStatistic Statistic, IUserDialog UserDialog)
        {
            _ServersRepository = ServersRepository;
            _SendersRepository = SendersRepository;
            _RecipientsRepository = RecipientsRepository;
            _LettersRepository = LettersRepository;
            _MailService = MailService;
            _Statistic = Statistic;
            _UserDialog = UserDialog;

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
            MessageBox.Show("Рассыльщик почты", "О программе");
        }

        public ObservableCollection<Server> Servers { get; } = new ObservableCollection<Server>();
        public ObservableCollection<Sender> Senders { get; } = new ObservableCollection<Sender>();
        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();
        public ObservableCollection<Letter> Letters { get; } = new ObservableCollection<Letter>();


        private LambdaCommand _LoadDataCommand;

        /// <summary>Загрузка серверов</summary>
        public ICommand LoadDataCommand => _LoadDataCommand
            ??= new(OnLoadDataCommandExecuted);

        /// <summary>Логика выполнения - Загрузка серверов</summary>
        private void OnLoadDataCommandExecuted(object p)
        {
            Servers.Clear();
            Senders.Clear();
            Recipients.Clear();
            Letters.Clear();
            foreach (var item in _ServersRepository.GetAll()) Servers.Add(item);
            SelectedServer = Servers.FirstOrDefault();

            foreach (var item in _RecipientsRepository.GetAll()) Recipients.Add(item);
            SelectedRecipient = Recipients.FirstOrDefault();

            foreach (var item in _SendersRepository.GetAll()) Senders.Add(item);
            SelectedSender = Senders.FirstOrDefault();

            foreach (var item in _LettersRepository.GetAll()) Letters.Add(item);
            SelectedLetter = Letters.FirstOrDefault();
        }

        private LambdaCommand _SendMessageCommand;

        //Отправка почты
        public ICommand SendMessageCommand => _SendMessageCommand
            ??= new(OnSendMessageCommandExecuted);

        //Логика выполнения - Отправка почты
        private void OnSendMessageCommandExecuted(object p)
        {
            var server = SelectedServer;

            //_MailService.SendEmail("Отправитель", "Получатель", "Тема", "Тело письма");
            var mail_sender = _MailService.GetSender(server.Address, server.Port, server.UseSSL, server.Login, server.Password);

            var sender = SelectedSender;
            var recipient = SelectedRecipient;
            var letter = SelectedLetter;

            mail_sender.Send(sender.Address, recipient.Address, letter.Title, letter.Body);
        }

        //Выбранный получатель
        private Recipient _SelectedRecipient;

        public Recipient SelectedRecipient { get => _SelectedRecipient; set => Set(ref _SelectedRecipient, value); }


        //Редактирование сервиса
        private LambdaCommand _EditServerCommand;

        public ICommand EditServerCommand => _EditServerCommand
            ??= new(OnEditServerCommandExecuted, p => p is Server);

        private void OnEditServerCommandExecuted(object p)
        {
            if (p is not Server server) return;
            if (_UserDialog.EditServer(server))
                _ServersRepository.Update(server);
        }

        //Выбранный сервер
        private Server _SelectedServer;

        public Server SelectedServer { get => _SelectedServer; set => Set(ref _SelectedServer, value); }

        //Выбранное сообщение
        private Letter _SelectedLetter;
        
        public Letter SelectedLetter { get => _SelectedLetter; set => Set(ref _SelectedLetter, value); }

        //Выбранный отправитель
        private Sender _SelectedSender;

        public Sender SelectedSender { get => _SelectedSender; set => Set(ref _SelectedSender, value); }
    }
}
