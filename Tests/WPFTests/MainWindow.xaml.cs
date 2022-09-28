 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            //var from = new MailAddress("WanMilBi@yandex.ru", "WanMilBi"); /*Fa753LVassLost_Vur*/

            //var to = new MailAddress("lostvan.fan@gmail.com", "WanMilBi");


            var from = new MailAddress("miloslav92@yandex.ru", "miloslav92"); /*Fa753LVassLost_Vur*/   /*FoxPlayAllYear364*/

            var to = new MailAddress("miloslav92@yandex.ru");

            var messege = new MailMessage(from, to);

            messege.Subject = "Заголовок письма от " + DateTime.Now;
            messege.Body = "Текст тестового письма" + DateTime.Now;

            var client = new SmtpClient("smtp.yandex.ru", 25);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;

            //var pass = PasswordEdit.Password;

            client.Credentials = new NetworkCredential
            {
                UserName = LoginEdit.Text,
                SecurePassword = PasswordEdit.SecurePassword
            };

            client.Send(messege);
        }
    }
}
