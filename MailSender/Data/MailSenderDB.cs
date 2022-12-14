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
        public  DbSet<SchedulerTask> SchedulerTasks { get; set; }
        public MailSenderDB(DbContextOptions<MailSenderDB> opt):base(opt) { }

        //Каскадное удаление
        //protected override void OnModelCreating(ModelBuilder db)
        //{
        //    db.Entity<ShedulerTask>()
        //        .HasMany(t => t.Recipients)
        //        .WithOne("Task")
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
