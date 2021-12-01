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
    public sealed class DepositMenu : IDepositMenu
    {
        private readonly IStandardMessages standardMessages;
        private readonly IDepositMenuMessages depositMenuMessages;
        private readonly IAutomatedTellerMachine automatedTellerMachine;

        public DepositMenu(IStandardMessages _standardMessages, IDepositMenuMessages _depositMenuMessages,
            IAutomatedTellerMachine _automatedTellerMachine)
        {
            standardMessages = _standardMessages;
            depositMenuMessages = _depositMenuMessages;
            automatedTellerMachine = _automatedTellerMachine;
        }
        public void DisplayDepositMenu()
        {
            bool loop = true;
            int input = 0;
            do
            {
                standardMessages?.NewLine();
                depositMenuMessages?.PromptWithdrawAmountMessage();
                input = InputReader.ReadInputInt();
                loop = CheckDepositMenuOption(input);

            } while (loop == true);
            automatedTellerMachine?.Deposit();
        }
        public bool CheckDepositMenuOption(int _input)
        {
            return false;
        }
    }
}
