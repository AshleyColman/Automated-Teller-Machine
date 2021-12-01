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

    IApplication application = CreateInstances(host);
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
static IApplication CreateInstances(IHost _host)
{
    // Applications.
    var application = ActivatorUtilities.CreateInstance<ConsoleApplication>(_host.Services);
    // AutomatedTellerMachines.
    var automatedTellerMachine = ActivatorUtilities.CreateInstance<VirtualAutomatedTellerMachine>(_host.Services);
    // DataAccess.
    var dataAccess = ActivatorUtilities.CreateInstance<SqlDataAccess>(_host.Services);
    // Menus.
    var accountMenu = ActivatorUtilities.CreateInstance<AccountMenu>(_host.Services);
    var configureMenu = ActivatorUtilities.CreateInstance<ConfigureMenu>(_host.Services);
    var depositMenu = ActivatorUtilities.CreateInstance<DepositMenu>(_host.Services);
    var loginMenu = ActivatorUtilities.CreateInstance<LoginMenu>(_host.Services);
    var withdrawMenu = ActivatorUtilities.CreateInstance<WithdrawMenu>(_host.Services);
    // Messages.
    var accountMessages = ActivatorUtilities.CreateInstance<AccountMessages>(_host.Services);
    var automatedTellerMachineMessages = ActivatorUtilities.CreateInstance<AutomatedTellerMachineMessages>(_host.Services);
    var configureMessages = ActivatorUtilities.CreateInstance<ConfigureMessages>(_host.Services);
    var depositMenuMessages = ActivatorUtilities.CreateInstance<DepositMenuMessages>(_host.Services);
    var loginMenuMessages = ActivatorUtilities.CreateInstance<LoginMenuMessages>(_host.Services);
    var standardMessages = ActivatorUtilities.CreateInstance<StandardMessages>(_host.Services);
    var withdrawMenuMessages = ActivatorUtilities.CreateInstance<WithdrawMenuMessages>(_host.Services);
    // Models.
    var account = ActivatorUtilities.CreateInstance<Account>(_host.Services);
    return application;
}