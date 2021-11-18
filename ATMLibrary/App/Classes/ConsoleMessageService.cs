

namespace ATMLibrary.Classes
{
    public sealed class ConsoleMessageService : IMessageService
    {
        public void WelcomeMessage() => Console.WriteLine("Welcome to the Automated Teller Machine\n");
        public void EnterPinMessage() => Console.WriteLine("Please enter your PIN");
        public void ErrorPinMessage() => Console.WriteLine("Error: pin does not exist\n");
        public void MenuMessage()
        {
            Console.WriteLine("1: View balance");
            Console.WriteLine("2: Withdraw");
            Console.WriteLine("3: Deposit");
            Console.WriteLine("4: Logout");
        }
        public void OptionDoesNotExistMessage() => Console.WriteLine("Option does not exist");
        public void CloseApplicationMessage() => Console.WriteLine("Press any key to close the application...");
        public void LoggedInMessage(string _firstName, string _lastName)
        {
            Console.WriteLine($"Logged in as {_firstName} {_lastName}\n");
        }
        public void LogoutMessage(string _firstName, string _lastName)
        {
            Console.WriteLine($"Successfully logged out {_firstName} {_lastName}");
        }
        public void LoadingMessage() => Console.WriteLine("Please wait...");
        public void MaxLoginAttemptsMessage() => Console.WriteLine("Max login attemps reached");
        public void ViewBalanceMessage(decimal _balance) => Console.WriteLine($"Your balance is £{_balance}\n");
        public void SelectWithdrawOptionMessage()
        {
            Console.WriteLine("1: Withdraw £10");
            Console.WriteLine("2: Withdraw £25");
            Console.WriteLine("3: Withdraw £50");
            Console.WriteLine("4: Withdraw £75");
            Console.WriteLine("5: Withdraw £100");
            Console.WriteLine("6: Go back");
        }
        public void WithdrawBalanceMessage(decimal _amount)
        {
            Console.WriteLine($"Successfully withdrawed £{_amount} from your account");
        }
        public void DepositMessage()
        {
            throw new NotImplementedException();
        }
        public void AutomatedTellerMachineNotEnoughFundsMessage()
        {
            Console.WriteLine("Cannot withdraw from machine - Out of funds");
        }
        public void AccountNotEnoughFundsMessage()
        {
            Console.WriteLine("Cannot withdraw from account - Out of funds");
        }
    }
}