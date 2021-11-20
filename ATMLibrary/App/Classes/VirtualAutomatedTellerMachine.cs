using System;
using System.Collections.Generic;
using System.Linq;
namespace ATMLibrary.Classes
{
    using ATMLibrary.DataAccess;

    public sealed class VirtualAutomatedTellerMachine : IAutomatedTellerMachine
    {
        private readonly IMessageService messageService;
        private readonly IDataAccess dataAccess;
        private decimal balance = 10000m;
        public IAccount Account { get; private set; }

        public VirtualAutomatedTellerMachine(IMessageService _messageService, IDataAccess _dataAccess, IAccount _account)
        {
            messageService = _messageService;
            dataAccess = _dataAccess;
            Account = _account;
        }
        public void Deposit() => Account?.Deposit();
        public void ViewBalance()
        {
            messageService?.NewLineFormatting();
            messageService?.ViewBalanceMessage(Account.Balance);
        }
        public void Withdraw(decimal _amount)
        {
            bool canWithdrawFromATM = CheckIfCanWithdraw(_amount);
            bool canWithdrawFromAccount = Account.CheckIfCanWithdraw(_amount);
            if (canWithdrawFromATM == true && canWithdrawFromAccount == true)
            {
                WithdrawFromATM(_amount);
                Account.Withdraw(_amount);
                messageService?.WithdrawBalanceMessage(_amount);
                ViewBalance();
            }
            else if (canWithdrawFromATM == false)
            {
                messageService?.AutomatedTellerMachineNotEnoughFundsMessage();
            }
            else if (canWithdrawFromAccount == false)
            {
                messageService?.AccountNotEnoughFundsMessage();
            }
            messageService?.ViewAutomatedTellerMachineBalanceMessage(this.balance);
        }
        private void WithdrawFromATM(decimal _amount) => this.balance -= _amount;
        private bool CheckIfCanWithdraw(decimal _amount) => ((this.balance - _amount) >= 0m);
        public async Task Login(int _pin)
        {
            messageService?.LoadingMessage();
            Account = await dataAccess.GetAccountByPinAsync(_pin);
            if (Account == null)
            {
                messageService?.ErrorPinMessage();
            }
            else
            {
                messageService?.LoggedInMessage(Account.FirstName, Account.LastName);
            }
        }
        public void Logout() => messageService?.LogoutMessage(Account.FirstName, Account.LastName);
        public bool IsLoggedIn() => (Account != null);
        public void ConfigureBalance(decimal _balance)
        {
            if (_balance == decimal.MinValue)
            {
                messageService?.DecimalInputFormatErrorMessage();
            }
            else
            {
                this.balance = _balance;
                messageService?.BalanceConfiguredMessage(this.balance);
            }
        }
    }
}
