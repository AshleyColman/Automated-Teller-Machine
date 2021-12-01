using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.Classes
{
    public sealed class Account : IAccount
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Pin { get; set; }
        public decimal Balance { get; set; }

        public void Withdraw(decimal _amount) => this.Balance -= _amount;
        public bool CheckIfCanWithdraw(decimal _amount) => (this.Balance - _amount) >= 0;
        public void Deposit(decimal _amount) => this.Balance += _amount;
    }
}
