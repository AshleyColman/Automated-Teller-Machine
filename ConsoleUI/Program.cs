using ATMLibrary.Classes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Setup the application and run.
Setup();

static void Setup()
{
    IConfigurationBuilder builder = new ConfigurationBuilder();

    BuildConfig(builder);

    IHost host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddTransient<IApplication, ConsoleApplication>();
            services.AddTransient<IMessageService, ConsoleMessageService>();
            services.AddTransient<IAutomatedTellerMachine, VirtualAutomatedTellerMachine>();
            services.AddTransient<IAccount, Account>();
        })
        .Build();

    var applicationService = ActivatorUtilities.CreateInstance<ConsoleApplication>(host.Services);
    var messageService = ActivatorUtilities.CreateInstance<ConsoleMessageService>(host.Services);
    var automatedTellerMachineService = ActivatorUtilities.CreateInstance<VirtualAutomatedTellerMachine>(host.Services);
    var accountService = ActivatorUtilities.CreateInstance<Account>(host.Services);

    applicationService.Run();
}
static void BuildConfig(IConfigurationBuilder _builder)
{
    _builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_EVIRONMENT") ?? "Production"}.json",
        true)
        .AddEnvironmentVariables();
    _builder.Build();
}