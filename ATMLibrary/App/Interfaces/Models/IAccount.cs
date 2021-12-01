namespace ATMLibrary.Classes
{
    public interface IAccount
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int Pin { get; set; }
        decimal Balance { get; set; }

        void Deposit(decimal _amount);
        void Withdraw(decimal _amount);
        bool CheckIfCanWithdraw(decimal _amount);
    }
}