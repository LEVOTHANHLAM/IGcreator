using InstargramCreator.Entities;
using InstargramCreator.Models;
using InstargramCreator.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace InstargramCreator.Mains
{
    internal static class Program
    {
        private static readonly IHost _host = CreateHostBuilder();
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logsapp/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            try
            {
                _host.Start();
                Log.Information("Application start");         
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);            
                try
                {
                    var form1 = _host.Services.GetRequiredService<frmLicenseKey>();              
                    Application.Run(form1);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    Log.Error(ex.ToString());
                    if (ex.InnerException != null)
                    {
                        Log.Error(ex.ToString());
                        Log.Error(ex.InnerException.Message);
                    }
                }      
                _host.StopAsync().GetAwaiter().GetResult();             
                _host.Dispose();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                if (ex.InnerException != null)
                {
                    Log.Error(ex.ToString());
                    Log.Error(ex.InnerException.Message);
                }
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        static IHost CreateHostBuilder()
        {
            GlobalModel.DataPath = Path.Combine(Environment.CurrentDirectory, "DataAccount.mdf");
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<frmLicenseKey>();
                    services.AddSingleton<frmMail>();
                    services.AddSingleton<frmProxy>();
                    services.AddSingleton<frmData>();
                    services.AddSingleton<frmProxy>();
                    services.AddSingleton<frmAuto>();
                    services.AddTransient<IAccountRepository, AccountRepository>();
                    services.AddDbContext<ApplicationDbContext>(s => s.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + GlobalModel.DataPath + ";Integrated Security=True"));
                }).Build();
        }
    }
}