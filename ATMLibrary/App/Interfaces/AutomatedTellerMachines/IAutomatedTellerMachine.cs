namespace ATMLibrary.Classes
{
    public interface IAutomatedTellerMachine
    {
        IAccount Account { get; }
        Task Withdraw(decimal _amount);
        Task Deposit(decimal _amount);
        void ViewBalance();
        Task Login(int _pin);
        void Logout();
        bool IsLoggedIn();
        void ConfigureBalance(decimal _amount);
    }
}