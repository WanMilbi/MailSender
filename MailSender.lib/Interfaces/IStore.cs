using System.Collections.Generic;
using MailSender.lib.Models;

namespace MailSender.lib.Interfaces
{ 
    public interface IStore <T> where T : Entity
    {
        IEnumerable<T> GetAll();

        T GetById(int Id);
        T Add(T Item);
        void Update(T Item);
        void Delete(int Id );
    }
}
