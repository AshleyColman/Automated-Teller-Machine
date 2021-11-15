

namespace ATMLibrary.Classes
{
    public sealed class ConsoleMessageService : IMessageService
    {
        public void WelcomeMessage() => Console.WriteLine("Welcome to the Automated Teller Machine");
        public void LoginMessage() => Console.WriteLine("Please enter your PIN");
        public void MenuMessage()
        {
            Console.WriteLine("1: View balance");
            Console.WriteLine("2: Withdraw");
            Console.WriteLine("3: Deposit");
            Console.WriteLine("4: Logout");
        }
        public void OptionDoesNotExistMessage() => Console.WriteLine("Option does not exist");
        public void ExitMessage() => Console.WriteLine("Thank you for using the application");
    }
}
