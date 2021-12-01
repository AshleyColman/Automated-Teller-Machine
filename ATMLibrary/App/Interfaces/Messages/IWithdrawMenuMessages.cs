namespace ATMLibrary.App.Classes.Messages
{
    public interface IWithdrawMenuMessages
    {
        void SelectWithdrawOptionMessage();
        void WithdrawBalanceMessage(decimal _amount);
    }
}