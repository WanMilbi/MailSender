using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;
using MailSender.Data;
using MailSender.Data.Stores.InDB;
using MailSender.Data.Stores.InMemory;
using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using MailSender.lib.Service;
using MailSender.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace MailSender
{
    
    public partial class App
    {
        private static IHost _Hosting;
        public static IHost Hosting => _Hosting
        ??= Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
            .ConfigureAppConfiguration(cfg=>cfg
                .AddJsonFile("appconfig.json",true,true)
                .AddXmlFile("appsetting.xml", true, true)
            )
            .ConfigureLogging(log=>log
                .AddConsole()
                .AddDebug()
            )
                .ConfigureServices(ConfigureServices)
                .Build();

        public static IServiceProvider Services => Hosting.Services;
        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
#if DEBUG
            services.AddTransient<IMailService, DebugMailService>();
#else
            services.AddTransient<IMailService, SmtpMailService>();
#endif
            services.AddSingleton<IEncryptorService, Rfc2898Encryptor>();
            services.AddDbContext<MailSenderDB>(opt =>
                opt.UseSqlServer(host.Configuration.GetConnectionString("Default")));
            services.AddTransient<MailSenderDbInitializer>();
            //services.AddSingleton<IStore<Recipient>, RecipientStoreInMemory>();
            //на выбор либо верхний или нижний
            services.AddSingleton<IStore<Recipient>, RecipientsStoreInDB>();

        }


        protected override void OnStartup(StartupEventArgs e)
        {
            Services.GetRequiredService<MailSenderDbInitializer>().Initialize() ;
            base.OnStartup(e);

            //Удаление записей из  таблицы
            //using (var db = Services.GetRequiredService<MailSenderDB>())
            //{
            //    var to_remove = db.ShedulerTasks.Where(task => task.Time < DateAndTime.Now);
            //    if (to_remove.Any())
            //    {
            //        db.ShedulerTasks.RemoveRange(to_remove);
            //        db.SaveChanges();
            //    }
            //}
        }

        
    }

}
    