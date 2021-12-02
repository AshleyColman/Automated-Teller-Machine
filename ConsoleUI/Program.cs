using ATMLibrary.App.Classes;
using ATMLibrary.App.Classes.Messages;
using ATMLibrary.App.Interfaces.Menus;
using ATMLibrary.Classes;
using ATMLibrary.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Setup the application and run.
await Setup();

static async Task Setup()
{
    IConfigurationBuilder builder = new ConfigurationBuilder();

    BuildConfig(builder);

    IHost host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            // Applications.
            services.AddSingleton<IApplication, ConsoleApplication>();
            //AutomatedTellerMachines.
           services.AddSingleton<IAutomatedTellerMachine, VirtualAutomatedTellerMachine>();
            // DataAccess.
            services.AddSingleton<IDataAccess, SqlDataAccess>();
            // Menus.
            services.AddTransient<IAccountMenu, AccountMenu>();
            services.AddTransient<IConfigureMenu, ConfigureMenu>();
            services.AddTransient<IDepositMenu, DepositMenu>();
            services.AddTransient<ILoginMenu, LoginMenu>();
            services.AddTransient<IWithdrawMenu, WithdrawMenu>();
            // Messages.
            services.AddSingleton<IAccountMessages, AccountMessages>();
            services.AddSingleton<IAutomatedTellerMachineMessages, AutomatedTellerMachineMessages>();
            services.AddSingleton<IConfigureMessages, ConfigureMessages>();
            services.AddSingleton<IDepositMenuMessages, DepositMenuMessages>();
            services.AddSingleton<ILoginMenuMessages, LoginMenuMessages>();
            services.AddSingleton<IStandardMessages, StandardMessages>();
            services.AddSingleton<IWithdrawMenuMessages, WithdrawMenuMessages>();
            // Models.
            services.AddTransient<IAccount, Account>();
        })
        .Build();

    var application = ActivatorUtilities.CreateInstance<ConsoleApplication>(host.Services);
    await application.Run();
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