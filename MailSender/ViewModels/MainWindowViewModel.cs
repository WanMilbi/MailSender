﻿using System.Collections.ObjectModel;
using System.Configuration.Internal;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Windows;
using System.Windows.Input;
using MailSender.Data;
using MailSender.Infrastructure.Commands;
using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using MailSender.ViewModels.Base;
using Microsoft.Extensions.Configuration;

namespace MailSender.ViewModels
{
partial class MainWindowViewModel : ViewModel
    {
        private readonly IMailService _MailService;
        private readonly IStore<Recipient> _RecipientStore;
        private string _Title = "Test window";
        private ObservableCollection<Server> _Servers;
        private ObservableCollection<Sender> _Senders;
        private ObservableCollection<Recipient> _Recipients;
        private ObservableCollection<Message> _Messages;
        private Server _SelectedServer;
        private Sender _SelectedSender;
        private Recipient _SelectedRecipient;
        private Message _SelectedMessage;
        public StatisticViewModel Statistic { get; } = new StatisticViewModel();

        #region Property
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            set => Set(ref _Servers, value);
        }

        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            set => Set(ref _Senders, value);
        }

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set => Set(ref _Recipients, value);
        }
        public ObservableCollection<Message> Messages
        {
            get => _Messages;
            set => Set(ref _Messages, value);
        }

        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }

        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);

        }
        
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);

        }

        public Message SelectedMessage
        {
            get => _SelectedMessage;
            set => Set(ref _SelectedMessage, value);

        }

        #endregion

        
        public MainWindowViewModel(IMailService MailService,MailSenderDB db,IStore<Recipient> RecipientStore )
        {
            _MailService = MailService;
            _RecipientStore = RecipientStore;
            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(RecipientStore.GetAll());
Messages = new ObservableCollection<Message>(TestData.Messages);


        }
    }
}
