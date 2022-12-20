using MailSender.lib.Models;

namespace MailSender.Data.Stores.InDB
{
    internal class SendersStoreInDB : StoreInDB<Sender>
    {
        public SendersStoreInDB(MailSenderDB db) : base(db) { }
    }
}
