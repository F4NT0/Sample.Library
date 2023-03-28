using Microsoft.AspNetCore;
using SampleAPI;

internal class Program
{
    private static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddCommandLine(args)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false, reloadOnChange: false)
            .AddEnvironmentVariables()
            .Build();

        var builder = CreateWebHostBuilder(args, configuration);
        builder.Run();
        builder.WaitForShutdown();

    }

    private static IWebHost CreateWebHostBuilder(string[] args, IConfiguration configuration)
    {
        var builder = WebHost.CreateDefaultBuilder()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration(config =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                .AddCommandLine(args)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();
            })
            .ConfigureLogging((context, logging) =>
            {
                logging.ClearProviders()
                .AddConfiguration(configuration)
                .AddDebug()
                .AddConsole();
            })
            .UseStartup<Startup>();
        return builder.Build();
    }
}