namespace ATMLibrary.App.Classes.Messages
{
    public interface IDepositMenuMessages
    {
        void DepositMessage(decimal _amount);
        void PromptWithdrawAmountMessage();
        void InputErrorMessage();
    }
}