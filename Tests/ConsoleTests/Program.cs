using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ConsoleTests
{
    internal class Program
    {
        static void  Main(string[] args)
        {
            #region MyRegion
            //const string connection_str =
            //        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Student.DB;Integrated Security=True";

            ////var servce_collection = new ServiceCollection();
            ////servce_collection.AddDbContext<StudentsDB>(opt => opt.UseSqlServer(connection_str));

            ////var services = servce_collection.BuildServiceProvider();

            ////using (var db = services.GetRequiredService<StudentsDB>()) 
            ////{
            ////}

            //using (var db = new StudentsDB(new DbContextOptionsBuilder<StudentsDB>().UseSqlServer(connection_str).Options))
            //{
            //    //await db.Database.EnsureCreatedAsync();

            //    await db.Database.MigrateAsync();
            //    var students_count = await db.Students.CountAsync();

            //    Console.WriteLine($"Число студентов в БД = {students_count}");
            //}

            //using (var db = new StudentsDB(new DbContextOptionsBuilder<StudentsDB>().UseSqlServer(connection_str)
            //           .Options))
            //{
            //    var k = 0;
            //    if (await db.Students.CountAsync() == 0)
            //    {


            //        for (int i = 0; i < 10; i++)
            //        {
            //            var group = new Group
            //            {
            //                Name = $"Группа {i}",
            //                Description = $"Описание группы {i}",
            //                Students = new List<Student>()
            //            };
            //            for (int j = 0; j < 10; j++)
            //            {
            //                var student = new Student
            //                {
            //                    Name = $"Студент {k}",
            //                    Surname = $"Surname {k}",
            //                    Patronymic = $"Patronymic {k}"
            //                };
            //                k++;
            //                group.Students.Add(student);
            //            }

            //            await db.Groups.AddAsync(group);
            //        }
            //    }

            //    await db.SaveChangesAsync();
            //}

            //using (var db = new StudentsDB(new DbContextOptionsBuilder<StudentsDB>().UseSqlServer(connection_str)
            //           .Options))
            //{
            //    var students = await db.Students
            //        .Include(s => s.Group)
            //        .Where(s => s.Group.Name == "Группа 5")
            //        .ToArrayAsync();

            //    foreach (var student in students)
            //    {
            //        Console.WriteLine($"{student.Id} {student.Name} - {student.Group.Name}");


            //    }
            //} 
            #endregion

            Assembly asm = Assembly.GetExecutingAssembly();
            Type type = asm.GetType("ConsoleTests.Program");

            var test_lib_file = new FileInfo("TestLib.dll");
var test_lib_assembly = Assembly.LoadFile(test_lib_file.FullName);

var printer_type = test_lib_assembly.GetType("TestLib.Printer");

foreach (var method in printer_type.GetMethods())
{
    var return_type = method.ReturnType;
    var parameters = method.GetParameters();
    Console.WriteLine(
        $"{return_type.Name} {method.Name} ({string.Join(", ", parameters.Select(p => $"{p.ParameterType.Name} {p.Name}"))})");
}

object printer = Activator.CreateInstance(printer_type, ">>>>");

var printer_constructor = printer_type.GetConstructor( new[] {typeof(string) });
var printer2 = printer_constructor.Invoke(new object[] { "<<<<" });

var print_method_info = printer_type.GetMethod("Print");

print_method_info.Invoke(printer, new object[] { "Hello World" });

var prefix_field_info = printer_type.GetField("_Prefix", BindingFlags.NonPublic | BindingFlags.Instance);

object prefix_field_object = prefix_field_info.GetValue(printer);

var prefix_value_info = (string)prefix_field_info.GetValue(printer);

prefix_field_info.SetValue(printer, "123");

//var admin_process_info = new ProcessStartInfo(Assembly.GetEntryAssembly().Location, "/RegistryWrite")
//{

//};
//Process process = Process.Start(admin_process_info);
dynamic dynamic_printer = printer;
dynamic_printer.Print("123");

            Console.ReadLine();
        }
    }
}
