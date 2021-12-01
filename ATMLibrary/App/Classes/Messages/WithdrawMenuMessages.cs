using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.App.Classes.Messages
{
    public sealed class WithdrawMenuMessages : IWithdrawMenuMessages
    {
        public void SelectWithdrawOptionMessage()
        {
            Console.WriteLine("1: Withdraw £10");
            Console.WriteLine("2: Withdraw £25");
            Console.WriteLine("3: Withdraw £50");
            Console.WriteLine("4: Withdraw £75");
            Console.WriteLine("5: Withdraw £100");
            Console.WriteLine("6: Go back");
        }
        public void WithdrawBalanceMessage(decimal _amount) => Console.WriteLine($"Successfully withdrawed £{_amount} from your account");
    }
}