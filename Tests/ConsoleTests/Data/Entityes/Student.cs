using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleTests.Data.Entityes
{
    abstract class Entity
    {
        public int Id { get; set; }
    }

    abstract class NameEntity : Entity
    {
        public string Name { get; set; }
    }
    class Student : NameEntity
    {
        [Required,MaxLength(120)]
        public string Surname { get; set; }
        [MaxLength(120)]
        public string Patronymic { get; set; }

        public virtual Group Group { get; set; }
    }

 class Group : NameEntity
    {
     public string Description { get; set; }

     public virtual ICollection<Student> Students { get; set; }
 }
}
