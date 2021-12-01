namespace ATMLibrary.App.Classes.Messages
{
    public interface IAutomatedTellerMachineMessages
    {
        void AutomatedTellerMachineNotEnoughFundsMessage();
        void ViewAutomatedTellerMachineBalanceMessage(decimal _balance);
    }
}