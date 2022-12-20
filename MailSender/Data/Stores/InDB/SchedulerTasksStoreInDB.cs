using MailSender.lib.Models;

namespace MailSender.Data.Stores.InDB
{
    internal class SchedulerTasksStoreInDB : StoreInDB<SchedulerTask>
    {
        public SchedulerTasksStoreInDB(MailSenderDB db) : base(db)  { }
    }
}

