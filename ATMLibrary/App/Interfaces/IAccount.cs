namespace ATMLibrary.Classes
{
    public interface IAccount
    {
        public int Id { get; set; }
        string FirstName { get; set; }
        int Pin { get; set; }
        decimal Balance { get; set; }

        void Deposit();
        void ViewBalance();
        void Withdraw();
    }
}