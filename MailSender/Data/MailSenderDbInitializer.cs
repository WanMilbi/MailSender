using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MailSender.Data
{
     class MailSenderDbInitializer
    {
        private readonly MailSenderDB _db;
        public MailSenderDbInitializer(MailSenderDB db) => _db=db;
        public void Initialize() 
        {
                _db.Database.Migrate();
                InitializeMessages();
                InitializeRecipient();
                InitializeSenders();
                InitializeServers();

        }

        private void InitializeRecipient()
        {
            if(_db.Recipients.Any())return;
            _db.Recipients.AddRange(TestData.Recipients);
            _db.SaveChanges();
        }

        private void InitializeSenders()
        {
            if (_db.Senders.Any()) return;
            _db.Senders.AddRange(TestData.Senders);
            _db.SaveChanges();
        }
        private void InitializeMessages()
        {
            if (_db.Messages.Any()) return;
            _db.Messages.AddRange(TestData.Messages);
            _db.SaveChanges();
        }

        private void InitializeServers()
        {
            if (_db.Servers.Any()) return;
            _db.Servers.AddRange(TestData.Servers);
            _db.SaveChanges();
        }
    }
}
