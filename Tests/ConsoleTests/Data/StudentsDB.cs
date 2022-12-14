using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTests.Data.Entityes;
using Microsoft.EntityFrameworkCore;

namespace ConsoleTests.Data
{
    internal class StudentsDB:DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Group>  Groups { get; set; } 
        public StudentsDB(DbContextOptions<StudentsDB> options) : base(options) { }
    }
}
