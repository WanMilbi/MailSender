using System.Linq;
using System.Collections.Generic;
using MailSender.lib.Models;
using MailSender.lib.Service;

namespace MailSender.Data
{
    static class TestData
    {
public static List<Sender> Senders { get; } = Enumerable.Range(1,10)
    .Select(i=>new Sender
    {
Name = $"Отправитель{i}",
Address = $"sender_{i}@server.ru"
    }).ToList();
public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 10)
    .Select(i => new Recipient
    {
        Name = $"Получатель{i}",
        Address = $"sender_{i}@server.ru"
    }).ToList();
public static List<Server> Servers { get; } = Enumerable.Range(1, 10)
    .Select(i => new Server
    {
        //Name =$"Server {i}",
        Address = $"smtp.server{i}.ru",
        Login = $"Login-{i}",
        Password = TextEncoder.Encode($"Password-{i}"),
        UseSSL = i%2==0

    }).ToList();
public static List<Message> Messages { get; } = Enumerable.Range(1,20).Select(i=>new Message
{
Subject = $"Сообщение {i}",
Body = $"Текст сообщения{i}"

}).ToList();
    }
}
