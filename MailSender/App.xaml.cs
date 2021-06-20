using MailSender.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using Microsoft.Extensions.Logging;
using MailSender.Servicies;
using MailSender.Interfaces;
using MailSender.Services;

namespace MailSender
{
    public partial class App
    {
        private static IHost _Hosting;

        public static IHost Hosting 
        {
            get 
            { 
                return _Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build(); 
            }
        }

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] Args) => Host
           .CreateDefaultBuilder(Args)
           .ConfigureAppConfiguration(opt => opt.AddJsonFile("settings.json", true, true))
           .ConfigureLogging(opt => opt.AddDebug())
           .ConfigureServices(ConfigureServices)
        ;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection service)
        {
            service.AddTransient<MainWindowViewModel>();
            service.AddSingleton<ServersRepository>();
            service.AddSingleton<IStatistic, InMemoryStatisticService>();
            service.AddSingleton<IMailService, DebugMailService>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Hosting.Start();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Hosting.Dispose();
        }
    }
}
