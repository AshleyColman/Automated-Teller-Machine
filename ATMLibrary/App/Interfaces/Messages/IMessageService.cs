

namespace ATMLibrary.Classes
{
    public interface IMessageService
    {
        void WelcomeMessage();
        void PromptConfigMessage();
        void ConfigMenuMessage();
        void PromptConfigureBalanceMessage();
        void BalanceConfiguredMessage(decimal _balance);
        void DecimalInputFormatErrorMessage();
        void PromptFirstNameMessage();
        void PromptLastNameMessage();
        void PromptAccountPinMessage();
        void PromptAccountBalanceMessage();
        void CreatedAccountMessage();
        void EnterPinMessage();
        void ErrorPinMessage();
        void MenuMessage();
        void OptionDoesNotExistMessage();
        void LoggedInMessage(string _firstName, string _lastName);
        void LogoutMessage(string _firstName, string _lastName);
        void CloseApplicationMessage();
        void LoadingMessage();
        void MaxLoginAttemptsMessage();
        void ViewBalanceMessage(decimal _balance);
        void ViewAutomatedTellerMachineBalanceMessage(decimal _balance);
        void AutomatedTellerMachineNotEnoughFundsMessage();
        void AccountNotEnoughFundsMessage();
        void SelectWithdrawOptionMessage();
        void WithdrawBalanceMessage(decimal _amount);
        void DepositMessage();
        void PromptWithdrawAmountMessage();
        void NewLineFormatting();
    }
}