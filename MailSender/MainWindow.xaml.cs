using System.Windows;
using MailSender.lib;
using MailSender.Models;
using System.Net.Mail;

namespace MailSender
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
    }

        private void OnSendButtonClick(object Sender, RoutedEventArgs e)
        {
            var sender = SendersList.SelectedItem as Sender;
            if (sender is null) return;

            if(!(RecipientsList.SelectedItem is Recipient recipient)) return;
            if (!(ServerList.SelectedItem is Server server)) return;
            if (!(MessagesList.SelectedItem is Message message))
            {
                MessageBox.Show("Вы пытаетесь отправить пустое письмо", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                myTab.SelectedIndex = 2;
                return;
            }

            var send_service = new MailSenderService
            {
                ServerAddress = server.Address,
                ServerPort = server.Port,
                UseSSL = server.UseSSL,
                Login = server.Login,
                Password = server.Password,
            };

            try
            {
                send_service.SendMessage(sender.Address,recipient.Address,message.Subject,message.Body);
            }
            catch (SmtpException error)
            {
                MessageBox.Show("Ошибка при отправлении почты" + error.Message, 
                    "Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
                throw;
            }
        }
        private void ScheduleClick(object sender, RoutedEventArgs e)
        {
            myTab.SelectedIndex = 1;
        }

        
    }
}
