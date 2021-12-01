using ATMLibrary.App.Classes.Messages;
using ATMLibrary.App.Interfaces.Menus;
using ATMLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.App.Classes
{
    public sealed class WithdrawMenu : IWithdrawMenu
    {
        private readonly IStandardMessages standardMessages;
        private readonly IWithdrawMenuMessages withdrawMenuMessages;
        private readonly IAutomatedTellerMachine automatedTellerMachine;

        public WithdrawMenu(IStandardMessages _standardMessages, IWithdrawMenuMessages _withdrawMenuMessages, 
            IAutomatedTellerMachine _automatedTellerMachine)
        {
            standardMessages = _standardMessages;
            withdrawMenuMessages = _withdrawMenuMessages;
            automatedTellerMachine = _automatedTellerMachine;
        }
        public async Task DisplayWithdrawMenu()
        {
            standardMessages?.NewLine();
            withdrawMenuMessages?.SelectWithdrawOptionMessage();
            await SelectWithdrawOption(InputReader.ReadInputInt());
        }
        public async Task SelectWithdrawOption(int _option)
        {
            decimal withdrawAmount = 0m;
            switch (_option)
            {
                case 1:
                    withdrawAmount = 10m;
                    break;
                case 2:
                    withdrawAmount = 25m;
                    break;
                case 3:
                    withdrawAmount = 50m;
                    break;
                case 4:
                    withdrawAmount = 75m;
                    break;
                case 5:
                    withdrawAmount = 100m;
                    break;
                case 6:
                    break;
                default:
                    standardMessages?.NoOptionMessage();
                    break;
            }
            if (withdrawAmount != 0m)
            {
                await automatedTellerMachine.Withdraw(withdrawAmount);
            }
        }
    }
}