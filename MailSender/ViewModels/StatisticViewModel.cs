using System;
using System.Collections.Generic;
using System.Text;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    internal class StatisticViewModel:ViewModel
    {
        private int _SendMessageCount;

        public int SendMessageCount
        {
            get => _SendMessageCount;
            private set => Set( ref _SendMessageCount,value);
        }

        public void MessageSended() => SendMessageCount++;
    }
}
