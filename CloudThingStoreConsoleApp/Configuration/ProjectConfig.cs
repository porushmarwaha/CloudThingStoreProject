using CloudThingStore.Services.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
using System.Reflection;

namespace CloudThingStoreConsoleApp.Configuration
{
    public static class ProjectConfig
    {
        static readonly IConfigurationRoot config = Initialise();

        static IConfigurationRoot Initialise()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appsettings.json").Build();

            return builder;
        }
        public static CloudThingConsole CloudThingInstance()
        {
            Log.Logger = new LoggerConfiguration()
               .ReadFrom
               .Configuration(config)
               .Enrich
               .FromLogContext()
               .WriteTo.File(_GetLogFilePath().path)
               .CreateLogger();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ICloudThingConsole, CloudThingConsole>();
                    services.AddSingleton<IProductCategoryService, ProductCategoryService>();
                    services.AddSingleton<IProductSubCategoryService, ProductSubCategoryService>();
                    services.AddSingleton<IProductService, ProductService>();

                })
                .UseSerilog()
                .Build();

            return ActivatorUtilities.CreateInstance<CloudThingConsole>(host.Services);
        }
        public static FilePath GetFilePath() => config.GetSection("filepath").Get<FilePath>();
        private static FilePath _GetLogFilePath() => config.GetSection("logfilepath").Get<FilePath>();

    }
}
