using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Service
{
public class SmtpMailService:IMailService
{
    public SmtpMailService()
    {

    }
    public IMailSender GetSender(string Server, int Port, bool SSL, string Login, string Password)
    {
        return new SmtpMailSender(Server, Port, SSL, Login, Password);
    }
}
internal class SmtpMailSender:IMailSender
{
    private readonly string _Address;
    private readonly int _Port;
    private readonly bool _Ssl;
    private readonly string _Login;
    private readonly string _Password;

    public SmtpMailSender(string Address, int Port, bool SSL, string Login,string Password)
    {
        _Address = Address;
        _Port = Port;
        _Ssl = SSL;
        _Login = Login;
        _Password = Password;
    }

    public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
    {
        var from = new MailAddress(SenderAddress);
        var to = new MailAddress(RecipientAddress);

        using (var messege = new MailMessage(from, to))
        {
            messege.Subject = Subject;
            messege.Body = Body;

            var client = new SmtpClient(_Address, _Port);
            client.EnableSsl = _Ssl;

            client.Credentials = new NetworkCredential
            {
                UserName = _Login,
                Password = _Password
            };
            try
            {
                client.Send(messege);
            }
            catch (SmtpException e)
            {
                Trace.TraceError(e.ToString());
                throw;
            }

        }
        }

    public void Send(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body)
    {
        foreach (var recipient_address in RecipientsAddresses)
        {
            Send(SenderAddress, recipient_address, Subject, Body);
        }
        }

    public void SendParallel(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body)
    {
        foreach (var recipient_address in RecipientsAddresses)
        {
            ThreadPool.QueueUserWorkItem(o => Send(SenderAddress, recipient_address, Subject, Body));
        }
        }

    public async Task SendAsync(string SenderAddress, string RecipientAddress, string Subject, string Body,
        CancellationToken Cancel = default)
    {
        var from = new MailAddress(SenderAddress);
        var to = new MailAddress(RecipientAddress);

        using (var messege = new MailMessage(from, to))
        {
            messege.Subject = Subject;
            messege.Body = Body;

            using (var client = new SmtpClient(_Address, _Port))
            {
                client.EnableSsl = _Ssl;

                client.Credentials = new NetworkCredential
                {
                    UserName = _Login,
                    Password = _Password
                };
                try
                {
                    Cancel.ThrowIfCancellationRequested();
                    //client.Send(messege);
                    await client.SendMailAsync(messege).ConfigureAwait(false);
                }
                catch (SmtpException e)
                {
                    Trace.TraceError(e.ToString());
                    throw;
                }
                }

            

        }
        }

    public async Task SendAsync(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body,
        IProgress<(string Recipient, double Percent)> Progress = null, CancellationToken Cancel = default)
    {
        var recipient = RecipientsAddresses.ToArray();

        for (int i = 0, count = recipient.Length; i < count ; i++)
        {
            Cancel.ThrowIfCancellationRequested();
            await SendAsync(SenderAddress, recipient[i], Subject, Body, Cancel).ConfigureAwait(false);
                Progress?.Report((recipient[i],i/(double)count)); 
            }
        
        }

    public async Task SendParallelAsync(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body,
         CancellationToken Cancel = default)
    {
        var tasks = RecipientsAddresses.Select(recipient_adress =>
            SendAsync(SenderAddress, recipient_adress, Subject, Body, Cancel));

        await Task.WhenAll(tasks).ConfigureAwait(false);
    }
}
}
