

namespace ATMLibrary.Classes
{
    public interface IMessageService
    {
        void WelcomeMessage();
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
        void AutomatedTellerMachineNotEnoughFundsMessage();
        void AccountNotEnoughFundsMessage();
        void SelectWithdrawOptionMessage();
        void WithdrawBalanceMessage(decimal _amount);
        void DepositMessage();
    }
}