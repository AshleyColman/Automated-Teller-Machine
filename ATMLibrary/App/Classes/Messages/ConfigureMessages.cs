using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.App.Classes
{
    public sealed class ConfigureMessages : IConfigureMessages
    {
        public void PromptConfigMessage()
        {
            Console.WriteLine("Would you like to configure the application?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");
        }
        public void ConfigMenuMessage()
        {
            Console.WriteLine("1: Set machine cash");
            Console.WriteLine("2: Add new account");
            Console.WriteLine("3: Stop configuring");
        }
        public void PromptFirstNameMessage() => Console.WriteLine("Please enter account first name:");
        public void PromptLastNameMessage() => Console.WriteLine("Please enter account last name:");
        public void PromptAccountPinMessage() => Console.WriteLine("Please enter account pin:");
        public void PromptAccountBalanceMessage() => Console.WriteLine("Please enter account balance:");
        public void PromptConfigureBalanceMessage() => Console.WriteLine("Please enter the machines initial cash amount 0.00:");
        public void BalanceConfiguredMessage(decimal _balance) => Console.WriteLine($"Balance configured: £{_balance}");
        public void CreatedAccountMessage() => Console.WriteLine("New account created");
    }
}
