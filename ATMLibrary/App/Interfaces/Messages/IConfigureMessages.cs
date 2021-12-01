namespace ATMLibrary.App.Classes
{
    public interface IConfigureMessages
    {
        void BalanceConfiguredMessage(decimal _balance);
        void ConfigMenuMessage();
        void CreatedAccountMessage();
        void PromptAccountBalanceMessage();
        void PromptAccountPinMessage();
        void PromptConfigMessage();
        void PromptConfigureBalanceMessage();
        void PromptFirstNameMessage();
        void PromptLastNameMessage();
    }
}