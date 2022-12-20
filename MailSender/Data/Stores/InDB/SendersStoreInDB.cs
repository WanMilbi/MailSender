using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSender.Data.Stores.InDB
{
    internal class SendersStoreInDB : IStore<Sender>
    {
        private readonly MailSenderDB _db;

        public SendersStoreInDB(MailSenderDB db) => _db = db;



        public IEnumerable<Sender> GetAll() => _db.Senders.ToArray();

        //public Recipient GetById(int Id) => _db.Recipients.Find(Id);
        //public Recipient GetById(int Id) => _db.Recipients.FirstOrDefault(r => r.Id == Id);
        public Sender GetById(int Id) => _db.Senders.SingleOrDefault(r => r.Id == Id);

        public Sender Add(Sender Item)
        {
            _db.Entry(Item).State = EntityState.Added;
            //_db.Recipients.Add(item);
            _db.SaveChanges();
            return Item;
        }

        public void Update(Sender Item)
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
