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
    public sealed class AccountMenu : IAccountMenu
    {
        private readonly IStandardMessages standardMessages;
        private readonly IAccountMessages accountMessages;
        private readonly IAutomatedTellerMachine automatedTellerMachine;
        private readonly IDepositMenu depositMenu;
        private readonly IWithdrawMenu withdrawMenu;

        public AccountMenu(IStandardMessages _standardMessages, IAccountMessages _accountMessages,
            IAutomatedTellerMachine _automatedTellerMachine, IDepositMenu _depositMenu, IWithdrawMenu _withdrawMenu)
        {
            standardMessages = _standardMessages;
            accountMessages = _accountMessages;
            automatedTellerMachine = _automatedTellerMachine;
            depositMenu = _depositMenu;
            withdrawMenu = _withdrawMenu;
        }
        public void LoopMenu()
        {
            bool loop = true;
            do
            {
                standardMessages?.NewLine();
                accountMessages?.MenuMessage();
                loop = SelectMenuOption(InputReader.ReadInputInt());
            } while (loop == true);
        }
        public bool SelectMenuOption(int _option)
        {
            switch (_option)
            {
                case 1:
                    automatedTellerMachine?.ViewBalance();
                    return true;
                case 2:
                    withdrawMenu.DisplayWithdrawMenu();
                    return true;
                case 3:
                    depositMenu.DisplayDepositMenu();
                    return true;
                case 4:
                    automatedTellerMachine?.Logout();
                    return false;
                default:
                    standardMessages?.NoOptionMessage();
                    return true;
            }
        }
    }
}
