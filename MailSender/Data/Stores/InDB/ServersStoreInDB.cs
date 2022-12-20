using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSender.Data.Stores.InDB
{
    class ServersStoreInDB : IStore<Server>
    {
        private readonly MailSenderDB _db;

        public ServersStoreInDB(MailSenderDB db) => _db = db;



        public IEnumerable<Server> GetAll() => _db.Servers.ToArray();

        //public Recipient GetById(int Id) => _db.Recipients.Find(Id);
        //public Recipient GetById(int Id) => _db.Recipients.FirstOrDefault(r => r.Id == Id);
        public Server GetById(int Id) => _db.Servers.SingleOrDefault(r => r.Id == Id);

        public Server Add(Server Item)
        {
            _db.Entry(Item).State = EntityState.Added;
            //_db.Recipients.Add(item);
            _db.SaveChanges();
            return Item;
        }

        public void Update(Server Item)
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
