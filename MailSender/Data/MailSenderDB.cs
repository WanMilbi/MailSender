using MailSender.lib.Models;
using Microsoft.EntityFrameworkCore;

namespace MailSender.Data
{
    internal class MailSenderDB: DbContext
    {
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Message> Messages { get; set; }    
        public  DbSet<ShedulerTask> ShedulerTasks { get; set; }
        public MailSenderDB(DbContextOptions<MailSenderDB> opt):base(opt) { }
    }
}
