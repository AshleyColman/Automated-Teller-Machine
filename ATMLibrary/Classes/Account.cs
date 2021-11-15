using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.Classes
{
    public sealed class Account : IAccount
    {
        public string FirstName { get; set; }
        public int Pin { get; set; }
        public decimal Balance { get; set; }

        public void Withdraw()
        {

        }
        public void Deposit()
        {

        }
        public void ViewBalance()
        {

        }
    }
}
