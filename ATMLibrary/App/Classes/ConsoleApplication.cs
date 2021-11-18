namespace ATMLibrary.Classes
{
    using ATMLibrary.DataAccess;

    public sealed class ConsoleApplication : IApplication
    {
        private readonly IMessageService messageService;
        private readonly IAutomatedTellerMachine automatedTellerMachine;
        private const int MaxLoginAttempts = 3;
        public ConsoleApplication(IMessageService _messageService, IAutomatedTellerMachine _automatedTellerMachine)
        {
            messageService = _messageService;
            automatedTellerMachine = _automatedTellerMachine;
        }
        public async Task Run()
        {
            Config();
            Welcome();
            await LoopReadPin();
            LoopMenu();
        }
        private void Config() => Console.Title = "Automated Teller Machine C#10 .NET6 Dapper SQLServer - Ashley Colman 2021";
        private void Pause() => Console.ReadLine();
        private void Welcome() => messageService?.WelcomeMessage();
        private async Task LoopReadPin()
        {
            int loginAttempts = 0;
            do
            {
                messageService?.EnterPinMessage();
                int input = ReadInputInt();
                await automatedTellerMachine.Login(input);
                CheckLoginAttempts(ref loginAttempts);
            } while (automatedTellerMachine?.IsLoggedIn() == false);
        }
        private void LoopMenu()
        {
            do
            {
                messageService?.MenuMessage();
                int input = ReadInputInt();
                SelectMenuOption(input);
            } while (true != false);
        }
        private void SelectMenuOption(int _option)
        {
            switch (_option)
            {
                case 1:
                    automatedTellerMachine?.ViewBalance();
                    break;
                case 2:
                    LoopWithdrawMenu();
                    break;
                case 3:
                    automatedTellerMachine?.Deposit();
                    break;
                case 4:
                    automatedTellerMachine?.Logout();
                    CloseApplication();
                    break;
                default:
                    messageService?.OptionDoesNotExistMessage();
                    break;
            }
        }
        private void LoopWithdrawMenu()
        {
            do
            {
                messageService?.SelectWithdrawOptionMessage();
                int input = ReadInputInt();
                SelectWithdrawOption(input);
            } while (true != false);
        }
        private void SelectWithdrawOption(int _option)
        {
            decimal withdrawAmount = 0m;
            switch (_option)
            {
                case 1:
                    withdrawAmount = 10m;
                    break;
                case 2:
                    withdrawAmount = 25m;
                    break;
                case 3:
                    withdrawAmount = 50m;
                    break;
                case 4:
                    withdrawAmount = 75m;
                    break;
                case 5:
                    withdrawAmount = 100m;
                    break;
                default:
                    messageService?.OptionDoesNotExistMessage();
                    break;
            }
            automatedTellerMachine?.Withdraw(withdrawAmount);
        }
        private string ReadInput() => Console.ReadLine() ?? string.Empty;
        private int ReadInputInt()
        {
            int input = 0;
            bool success = int.TryParse(Console.ReadLine(), out input);
            if (success == true) 
            { 
                return input;
            }
            else 
            { 
                return -1;
            }
        }
        private void CheckLoginAttempts(ref int _loginAttempts)
        {
            _loginAttempts++;
            if (_loginAttempts >= MaxLoginAttempts)
            {
                messageService?.MaxLoginAttemptsMessage();
                CloseApplication();
            }
        }
        private void CloseApplication()
        {
            messageService?.CloseApplicationMessage();
            Pause();
            Environment.Exit(0);
        }
    }
}