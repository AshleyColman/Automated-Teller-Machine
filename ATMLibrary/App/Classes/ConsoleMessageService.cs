

namespace ATMLibrary.Classes
{
    public sealed class ConsoleMessageService : IMessageService
    {
        public void WelcomeMessage() => Console.WriteLine("Welcome to the Automated Teller Machine");
        public void PromptConfigMessage() 
        {
            Console.WriteLine("Would you like to configure the application?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");
        }
        public void ConfigMenuMessage()
        {
            Console.WriteLine("1: Set machine cash");
            Console.WriteLine("2: Add new account");
            Console.WriteLine("3: Stop configuring");
        }
        public void PromptConfigureBalanceMessage() => Console.WriteLine("Please enter the machines initial cash amount 0.00:");
        public void BalanceConfiguredMessage(decimal _balance) => Console.WriteLine($"Balance configured: £{_balance}");
        public void DecimalInputFormatErrorMessage() => Console.WriteLine("Input not accepted");
        public void PromptFirstNameMessage() => Console.WriteLine("Please enter account first name:");
        public void PromptLastNameMessage() => Console.WriteLine("Please enter account last name:");
        public void PromptAccountPinMessage() => Console.WriteLine("Please enter account pin:");
        public void PromptAccountBalanceMessage() => Console.WriteLine("Please enter account balance:");
        public void CreatedAccountMessage() => Console.WriteLine("New account created");
        public void EnterPinMessage() => Console.WriteLine("Please enter your PIN");
        public void ErrorPinMessage() => Console.WriteLine("Error: pin does not exist");
        public void MenuMessage()
        {
            Console.WriteLine("1: View balance");
            Console.WriteLine("2: Withdraw");
            Console.WriteLine("3: Deposit");
            Console.WriteLine("4: Logout");
        }
        public void OptionDoesNotExistMessage() => Console.WriteLine("Option does not exist");
        public void CloseApplicationMessage() => Console.WriteLine("Press any key to close the application...");
        public void LoggedInMessage(string _firstName, string _lastName) => Console.WriteLine($"Logged in as {_firstName} {_lastName}");
        public void LogoutMessage(string _firstName, string _lastName)
        {
            Console.WriteLine($"Successfully logged out {_firstName} {_lastName}");
        }
        public void LoadingMessage() => Console.WriteLine("Please wait...");
        public void MaxLoginAttemptsMessage() => Console.WriteLine("Max login attemps reached");
        public void ViewBalanceMessage(decimal _balance) => Console.WriteLine($"Your balance is £{_balance}");
        public void ViewAutomatedTellerMachineBalanceMessage(decimal _balance) => Console.WriteLine($"Machine balance is £{_balance}");
        public void SelectWithdrawOptionMessage()
        {
            Console.WriteLine("1: Withdraw £10");
            Console.WriteLine("2: Withdraw £25");
            Console.WriteLine("3: Withdraw £50");
            Console.WriteLine("4: Withdraw £75");
            Console.WriteLine("5: Withdraw £100");
            Console.WriteLine("6: Go back");
        }
        public void WithdrawBalanceMessage(decimal _amount) => Console.WriteLine($"Successfully withdrawed £{_amount} from your account");
        public void DepositMessage() => throw new NotImplementedException();
        public void AutomatedTellerMachineNotEnoughFundsMessage() => Console.WriteLine("Withdraw too large, not enough cash in machine");
        public void AccountNotEnoughFundsMessage() => Console.WriteLine("Withdraw too large, not enough cash in account");
        public void NewLineFormatting() => Console.WriteLine();
        public void PromptWithdrawAmountMessage() => Console.WriteLine("Please enter the amount you would like to withdraw from your account:");
    }
}