namespace ATMLibrary.Classes
{
    using ATMLibrary.App.Classes;
    using ATMLibrary.App.Interfaces.Menus;
    using ATMLibrary.DataAccess;

    public sealed class ConsoleApplication : IApplication
    {
        private readonly IStandardMessages standardMessages;
        private readonly ILoginMenu loginMenu;
        private readonly IConfigureMenu configureMenu;
        private readonly IAccountMenu accountMenu;

        public ConsoleApplication(IStandardMessages _standardMessages, ILoginMenu _loginMenu, IConfigureMenu _configureMenu,
            IAccountMenu _accountMenu)
        {
            standardMessages = _standardMessages;
            loginMenu = _loginMenu;
            configureMenu = _configureMenu;
            accountMenu = _accountMenu;
        }
        public async Task Run()
        {
            Welcome();
            await configureMenu.LoopConfigPrompt();
            await loginMenu.LoopReadPin();
            await accountMenu.LoopMenu();
            Close();
        }
        private void Pause() => Console.ReadLine();
        private void Welcome() => standardMessages?.WelcomeMessage();
        public void Close()
        {
            standardMessages?.CloseMessage();
            Pause();
            Environment.Exit(0);
        }
    }
}