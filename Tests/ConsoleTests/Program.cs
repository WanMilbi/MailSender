using System;
using System.Net.Mail;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;

namespace ConsoleTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            var from = new MailAddress("WanMilBi@yandex.ru", "WanMilBi");
            
            var to = new MailAddress("lostvan.fan@gmail.com", "WanMilBi");

            var messege = new MailMessage(from, to);
            //var msg = new MailAddress("user@server.ru", "qwe@ASD.ru");

            messege.Subject = "Заголовок письма от " + DateTime.Now;
            messege.Body = "Текст тестового письма" + DateTime.Now;

            var client = new SmtpClient("smtp.yandex.ru", 587);

            client.Credentials = new NetworkCredential
            {
                UserName = "user_name",
                Password = "Password"
            };

            client.Send(messege);

        }
    }
}
