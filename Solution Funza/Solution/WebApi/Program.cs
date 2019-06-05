using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureLog4Net();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var logger = Framework.Logging.Log4Net.LoggerFactory.Create(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Info("Initializing application configuration");
                IHostingEnvironment env = hostingContext.HostingEnvironment;

                config.SetBasePath(Directory.GetCurrentDirectory());
                config
                .AddJsonFile("filestorage.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"filestorage.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                config.AddCommandLine(args);
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                var logger = Framework.Logging.Log4Net.LoggerFactory.Create(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Info("Initializing application logging");
            })
                .UseStartup<Startup>();



        /// <summary>
        /// Configures the log4 net.
        /// </summary>
        public static void ConfigureLog4Net()
        {
            // var logRepository = log4net.LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            ////Load configuration from log4net.config file
            //log4net.Config.XmlConfigurator.Configure(logRepository,
            //                                         new System.IO.FileInfo("log4net.config"));
        }
    }


}
