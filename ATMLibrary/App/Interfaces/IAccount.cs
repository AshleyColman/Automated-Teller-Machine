namespace ATMLibrary.Classes
{
    public interface IAccount
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        int Pin { get; }
        decimal Balance { get; }

        void Deposit();
        void Withdraw(decimal _amount);
        bool CheckIfCanWithdraw(decimal _amount);
    }
}