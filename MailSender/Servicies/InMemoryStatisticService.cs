using MailSender.Data;
using MailSender.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Servicies
{
    class InMemoryStatisticService : IStatistic
    {
        private int _SendedMailsCount;

        public int SendedMailsCount => _SendedMailsCount;
        public event EventHandler SendedMailsCountChanged;

        public int SendersCount => TestData.Senders.Count;

        public int RecipientsCount => TestData.Recipients.Count;

        private readonly Stopwatch _Timer = Stopwatch.StartNew();
        public TimeSpan UpTime => _Timer.Elapsed;

        public void MessageSended()
        {
            _SendedMailsCount++;
            SendedMailsCountChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
