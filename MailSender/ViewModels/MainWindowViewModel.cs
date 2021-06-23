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
            foreach (var item in _ServersRepository.GetAll())
                Servers.Add(item);
            foreach (var item in _SendersRepository.GetAll())
                Senders.Add(item);
            foreach (var item in _RecipientsRepository.GetAll())
                Recipients.Add(item);
            foreach (var item in _LettersRepository.GetAll())
                Letters.Add(item);
        }

        private LambdaCommand _SendMessageCommand;

        //Отправка почты
        public ICommand SendMessageCommand => _SendMessageCommand
            ??= new(OnSendMessageCommandExecuted);

        //Логика выполнения - Отправка почты
        private void OnSendMessageCommandExecuted(object p)
        {
            _MailService.SendEmail("Отправитель", "Получатель", "Тема", "Тело письма");
        }

        private Recipient _SelectedRecipient;

        //Выбранный получатель
        public Recipient SelectedRecipient { get => _SelectedRecipient; set => Set(ref _SelectedRecipient, value); }
    }
}
