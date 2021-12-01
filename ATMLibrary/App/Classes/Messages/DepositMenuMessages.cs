using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.App.Classes.Messages
{
    public sealed class DepositMenuMessages : IDepositMenuMessages
    {
        public void DepositMessage(decimal _amount) => Console.WriteLine($"Successfully deposited {_amount} into your account");
        public void PromptWithdrawAmountMessage() => Console.WriteLine("Please enter the amount you want to withdraw from your account:");
        public void InputErrorMessage() => Console.WriteLine("Input must be a decimal and greater than £0");
    }
}
