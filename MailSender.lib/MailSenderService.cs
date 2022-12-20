using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace MailSender.lib
{
     public class MailSenderService
    {
        public string ServerAddress { get; set; }
        public int ServerPort { get; set; }
        public bool UseSSL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public void SendMessage(string SenderAddress, string RecipientAddress,string Subject, string Body)
        {
            var from = new MailAddress(SenderAddress);
            var to = new MailAddress(RecipientAddress);

        using (var messege = new MailMessage(from, to))
        {
            messege.Subject = Subject;
            messege.Body = Body;

            var client = new SmtpClient(ServerAddress, ServerPort);
            client.EnableSsl = UseSSL;

            client.Credentials = new NetworkCredential
            {
                UserName = Login,
                Password = Password
            };
            try
            {
                client.Send(messege);
                }
            catch(SmtpException e)
            {
Trace.TraceError(e.ToString());
throw; 
            }
            
            }
                //var msg = new MailAddress("user@server.ru", "qwe@ASD.ru");

                
        }
    }
}
