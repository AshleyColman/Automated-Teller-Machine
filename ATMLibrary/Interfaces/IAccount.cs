namespace ATMLibrary.Classes
{
    public interface IAccount
    {
        decimal Balance { get; set; }
        string FirstName { get; set; }
        int Pin { get; set; }

        void Deposit();
        void ViewBalance();
        void Withdraw();
    }
}