using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.App.Classes.Messages
{
    public sealed class AutomatedTellerMachineMessages : IAutomatedTellerMachineMessages
    {
        public void ViewAutomatedTellerMachineBalanceMessage(decimal _balance) => Console.WriteLine($"Machine balance is £{_balance}");
        public void AutomatedTellerMachineNotEnoughFundsMessage() => Console.WriteLine("Withdraw too large, not enough cash in machine");
    }
}
