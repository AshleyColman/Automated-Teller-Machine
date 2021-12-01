namespace ATMLibrary.App.Classes.Messages
{
    public interface IAccountMessages
    {
        void MenuMessage();
        void AccountNotEnoughFundsMessage();
        void ViewBalanceMessage(decimal _balance);
    }
}