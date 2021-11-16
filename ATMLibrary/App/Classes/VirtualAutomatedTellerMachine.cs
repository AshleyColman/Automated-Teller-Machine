using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.Classes
{
    public sealed class VirtualAutomatedTellerMachine : IAutomatedTellerMachine
    {
        private readonly IMessageService messageService;
        private decimal balance = 10000m;
        public IAccount Account { get; init; }

        public VirtualAutomatedTellerMachine(IMessageService _messageService, IAccount _account)
        {
            messageService = _messageService;
            Account = _account;
        }
        public void Deposit()
        {
            throw new NotImplementedException();
        }
        public void ViewBalance()
        {
            throw new NotImplementedException();
        }
        public void Withdraw()
        {

        }
        public void Login()
        {
            // Prompt login.
        }
        public void Logout()
        {
            messageService?.LogoutMessage();
        }
    }
}
