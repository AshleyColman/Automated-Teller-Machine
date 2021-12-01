using System;
using System.Collections.Generic;
using System.Linq;
namespace ATMLibrary.Classes
{
    using ATMLibrary.App.Classes;
    using ATMLibrary.App.Classes.Messages;
    using ATMLibrary.DataAccess;

    public sealed class VirtualAutomatedTellerMachine : IAutomatedTellerMachine
    {
        private readonly IStandardMessages standardMessages;
        private readonly ILoginMenuMessages loginMenuMessages;
        private readonly IAccountMessages accountMessages;
        private readonly IWithdrawMenuMessages withdrawMenuMessages;
        private readonly IDepositMenuMessages depositMenuMessages;
        private readonly IAutomatedTellerMachineMessages automatedTellerMachineMessages;
        private readonly IConfigureMessages configureMessages;
        private readonly IDataAccess dataAccess;
        private decimal balance = 10000m;
        public IAccount Account { get; private set; }

        public VirtualAutomatedTellerMachine(IStandardMessages _standardMessages, ILoginMenuMessages _loginMenuMessages,
            IAccountMessages _accountMessages, IWithdrawMenuMessages _withdrawMenuMessages, IDepositMenuMessages _depositMenuMessages,
            IAutomatedTellerMachineMessages _automatedTellerMachineMessages, IConfigureMessages _configureMessages, IDataAccess _dataAccess,
            IAccount _account)
        {
            standardMessages = _standardMessages;
            loginMenuMessages = _loginMenuMessages;
            accountMessages = _accountMessages;
            withdrawMenuMessages = _withdrawMenuMessages;
            depositMenuMessages = _depositMenuMessages;
            automatedTellerMachineMessages = _automatedTellerMachineMessages;
            configureMessages = _configureMessages;
            dataAccess = _dataAccess;
            Account = _account;
        }
        public void Deposit(decimal _amount) 
        { 
            Account?.Deposit(_amount);
            depositMenuMessages?.DepositMessage(_amount);
            ViewBalance();
        }
        public void ViewBalance()
        {
            standardMessages?.NewLine();
            accountMessages?.ViewBalanceMessage(Account.Balance);
        }
        public void Withdraw(decimal _amount)
        {
            bool canWithdrawFromATM = CheckIfCanWithdraw(_amount);
            bool canWithdrawFromAccount = Account.CheckIfCanWithdraw(_amount);
            if (canWithdrawFromATM == true && canWithdrawFromAccount == true)
            {
                WithdrawFromATM(_amount);
                Account.Withdraw(_amount);
                withdrawMenuMessages?.WithdrawBalanceMessage(_amount);
                ViewBalance();
            }
            else if (canWithdrawFromATM == false)
            {
                automatedTellerMachineMessages?.AutomatedTellerMachineNotEnoughFundsMessage();
            }
            else if (canWithdrawFromAccount == false)
            {
                accountMessages?.AccountNotEnoughFundsMessage();
            }
            automatedTellerMachineMessages?.ViewAutomatedTellerMachineBalanceMessage(this.balance);
        }
        private void WithdrawFromATM(decimal _amount) => this.balance -= _amount;
        private bool CheckIfCanWithdraw(decimal _amount) => ((this.balance - _amount) >= 0m);
        public async Task Login(int _pin)
        {
            standardMessages?.LoadingMessage();
            Account = await dataAccess.GetAccountByPinAsync(_pin);
            if (Account == null)
            {
                loginMenuMessages?.ErrorPinMessage();
            }
            else
            {
                loginMenuMessages?.LoggedInMessage(Account.FirstName, Account.LastName);
            }
        }
        public void Logout() => loginMenuMessages?.LogoutMessage(Account.FirstName, Account.LastName);
        public bool IsLoggedIn() => (Account != null);
        public void ConfigureBalance(decimal _balance)
        {
            if (_balance == decimal.MinValue)
            {
                standardMessages?.DecimalInputFormatErrorMessage();
            }
            else
            {
                this.balance = _balance;
                configureMessages?.BalanceConfiguredMessage(this.balance);
            }
        }
    }
}
