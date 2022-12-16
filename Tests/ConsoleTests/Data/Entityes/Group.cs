using System.Collections.Generic;

namespace ConsoleTests.Data.Entityes
{
    public class Group : NameEntity
    {
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}