namespace ATMLibrary.Classes
{
    using ATMLibrary.DataAccess;

    public sealed class ConsoleApplication : IApplication
    {
        private readonly IMessageService messageService;
        private readonly IAutomatedTellerMachine automatedTellerMachine;
        private readonly IDataAccess dataAccess;
        private const int MaxLoginAttempts = 3;
        public ConsoleApplication(IMessageService _messageService, IAutomatedTellerMachine _automatedTellerMachine,
            IDataAccess _dataAccess)
        {
            this.messageService = _messageService;
            this.automatedTellerMachine = _automatedTellerMachine;
            this.dataAccess = _dataAccess;
        }
        public async Task Run()
        {
            Welcome();
            await PromptConfig();
            await LoopReadPin();
            LoopMenu();
            CloseApplication();
        }
        private void Pause() => Console.ReadLine();
        private void Welcome() => messageService?.WelcomeMessage();
        private async Task PromptConfig()
        {
            bool loopPromptConfig = true;
            int input = 0;
            do
            {
                messageService?.NewLineFormatting();
                messageService?.PromptConfigMessage();
                input = ReadInputInt();
                CheckPromptConfigOption(input, ref loopPromptConfig);
            } while (loopPromptConfig == true);
            await LoopConfigMenuIfSelected(input);
        }
        private void CheckPromptConfigOption(int _input, ref bool _loopPromptConfig)
        {
            if (_input == 1 || _input == 2)
            {
                _loopPromptConfig = false;
            }
            else
            {
                messageService?.OptionDoesNotExistMessage();
            }
        }
        private async Task LoopConfigMenuIfSelected(int _input)
        {
            if (_input == 1)
            {
                int input = int.MinValue;
                do
                {
                    messageService?.NewLineFormatting();
                    messageService?.ConfigMenuMessage();
                    input = ReadInputInt();
                    await SelectConfigMenuOption(input);
                } while (input == int.MinValue);
            }
        }
        private async Task SelectConfigMenuOption(int _input)
        {
            switch (_input)
            {
                case 1:
                    messageService?.NewLineFormatting();
                    messageService?.PromptConfigureBalanceMessage();
                    decimal input = ReadInputDecimal();
                    automatedTellerMachine?.ConfigureBalance(input);
                    break;
                case 2:
                    await AddNewAccount();
                    break;
                case 3:
                    break;
                default:
                    messageService?.OptionDoesNotExistMessage();
                    break;
            }
        }
        private async Task AddNewAccount()
        {
            Account account = new();
            messageService?.NewLineFormatting();
            messageService?.PromptFirstNameMessage();
            account.FirstName = ReadInputString();
            messageService?.PromptLastNameMessage();
            account.LastName = ReadInputString();
            messageService?.PromptAccountPinMessage();
            account.Pin = ReadInputInt();
            messageService?.PromptAccountBalanceMessage();
            account.Balance = ReadInputDecimal();
            await dataAccess.InsertNewAccountAsync(account);
            messageService?.CreatedAccountMessage();
        }
        private async Task LoopReadPin()
        {
            int loginAttempts = 0;
            do
            {
                messageService?.NewLineFormatting();
                messageService?.EnterPinMessage();
                int input = ReadInputInt();
                await automatedTellerMachine.Login(input);
                CheckLoginAttempts(ref loginAttempts);
            } while (automatedTellerMachine?.IsLoggedIn() == false);
        }
        private void LoopMenu()
        {
            bool loopMenu = true;
            do
            {
                messageService?.NewLineFormatting();
                messageService?.MenuMessage();
                int input = ReadInputInt();
                SelectMenuOption(input, ref loopMenu);
            } while (loopMenu == true);
        }
        private void SelectMenuOption(int _option, ref bool _loopMenu)
        {
            switch (_option)
            {
                case 1:
                    automatedTellerMachine?.ViewBalance();
                    break;
                case 2:
                    DisplayWithdrawMenu();
                    break;
                case 3:
                    break;
                case 4:
                    automatedTellerMachine?.Logout();
                    break;
                default:
                    messageService?.OptionDoesNotExistMessage();
                    break;
            }
        }
        private void DisplayDepositMenu()
        {
            bool loopMenu = true;
            int input = 0;
            do
            {
                messageService?.NewLineFormatting();
                messageService?.PromptWithdrawAmountMessage();
                input = ReadInputInt();

            } while (loopMenu == true);
            automatedTellerMachine?.Deposit();
        }
        private void CheckDepositMenuOption(int _input, ref bool _loopMenu)
        {
            
        }
        private void DisplayWithdrawMenu()
        {
            messageService?.NewLineFormatting();
            messageService?.SelectWithdrawOptionMessage();
            int input = ReadInputInt();
            SelectWithdrawOption(input);
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
                case 6:
                    break;
                default:
                    messageService?.OptionDoesNotExistMessage();
                    break;
            }
            if (withdrawAmount != 0m)
            {
                automatedTellerMachine?.Withdraw(withdrawAmount);
            }
        }
        private string ReadInputString() => Console.ReadLine() ?? string.Empty;
        private int ReadInputInt()
        {
            int input = 0;
            int.TryParse(Console.ReadLine(), out input);
            return input;
        }
        private decimal ReadInputDecimal()
        {
            decimal input = 0m;
            bool success = decimal.TryParse(Console.ReadLine(), out input);
            if (success == true)
            {
                return input;
            }
            else
            {
                return decimal.MinValue;
            }
        }
        private void CheckLoginAttempts(ref int _loginAttempts)
        {
            if (automatedTellerMachine?.IsLoggedIn() == false)
            {
                _loginAttempts++;
                if (_loginAttempts >= MaxLoginAttempts)
                {
                    messageService?.MaxLoginAttemptsMessage();
                    CloseApplication();
                }
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