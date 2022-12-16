using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTests.Data
{

    public class StudentDbContextFactory : IDesignTimeDbContextFactory<StudentsDB>
    {
        public StudentsDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentsDB>();
            const string connection_str =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Student.DB;Integrated Security=True";
            optionsBuilder.UseSqlServer(connection_str);

            return new StudentsDB(optionsBuilder.Options);
        }
    }
    
}
