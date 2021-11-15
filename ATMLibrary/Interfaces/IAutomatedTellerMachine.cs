namespace ATMLibrary.Classes
{
    public interface IAutomatedTellerMachine
    {
        IAccount Account { get; init; }
        void Withdraw();
        void Deposit();
        void ViewBalance();
        void Login();
        void Logout();
    }
}