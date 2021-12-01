using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.App.Classes.Messages
{
    public sealed class AccountMessages : IAccountMessages
    {
        public void MenuMessage()
        {
            Console.WriteLine("1: View balance");
            Console.WriteLine("2: Withdraw");
            Console.WriteLine("3: Deposit");
            Console.WriteLine("4: Logout");
        }
        public void ViewBalanceMessage(decimal _balance) => Console.WriteLine($"Your balance is £{_balance}");
        public void AccountNotEnoughFundsMessage() => Console.WriteLine("Withdraw too large, not enough cash in account");
    }
}
