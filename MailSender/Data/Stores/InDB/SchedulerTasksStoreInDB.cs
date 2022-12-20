using MailSender.Data.Migrations;
using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSender.Data.Stores.InDB
{
    internal class SchedulerTasksStoreInDB : IStore<SchedulerTask>
    {
        private readonly MailSenderDB _db;

        public SchedulerTasksStoreInDB(MailSenderDB db) => _db = db;



        public IEnumerable<SchedulerTask> GetAll() => _db.SchedulerTasks.ToArray();

        //public Recipient GetById(int Id) => _db.Recipients.Find(Id);
        //public Recipient GetById(int Id) => _db.Recipients.FirstOrDefault(r => r.Id == Id);
        public SchedulerTask GetById(int Id) => _db.SchedulerTasks.SingleOrDefault(r => r.Id == Id);

        public SchedulerTask Add(SchedulerTask Item)
        {
            _db.Entry(Item).State = EntityState.Added;
            //_db.Recipients.Add(item);
            _db.SaveChanges();
            return Item;
        }

        public void Update(SchedulerTask Item)
        {
            _db.Entry(Item).State = EntityState.Modified;
            //_db.Recipients.Update(item);
            _db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var item = GetById(Id);

            if (item != null) return;
            //_db.Recipients.Remove(item);
            _db.Entry(item).State = EntityState.Deleted;
            _db.SaveChanges();
        }
    }
}
