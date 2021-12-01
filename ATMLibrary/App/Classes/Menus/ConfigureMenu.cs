using ATMLibrary.App.Interfaces.Menus;
using ATMLibrary.Classes;
using ATMLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.App.Classes
{
    public sealed class ConfigureMenu : IConfigureMenu
    {
        private readonly IConfigureMessages configureMessages;
        private readonly IStandardMessages standardMessages;
        private readonly IAutomatedTellerMachine automatedTellerMachine;
        private readonly IDataAccess dataAccess;

        public ConfigureMenu(IConfigureMessages _configureMessages, IStandardMessages _standardMessages,
            IAutomatedTellerMachine _automatedTellerMachine, IDataAccess _dataAccess)
        {
            configureMessages = _configureMessages;
            standardMessages = _standardMessages;
            automatedTellerMachine = _automatedTellerMachine;
            dataAccess = _dataAccess;
        }
        public async Task LoopConfigPrompt()
        {
            bool loop = true;
            int input = 0;
            do
            {
                standardMessages?.NewLine();
                configureMessages?.PromptConfigMessage();
                input = InputReader.ReadInputInt();
                loop = CheckConfigPromptOption(input);
            } while (loop == true);
            await LoopConfigMenu(input);
        }
        public bool CheckConfigPromptOption(int _input)
        {
            if (_input == 1 || _input == 2)
            {
                return false;
            }
            standardMessages?.NoOptionMessage();
            return true;
        }
        public async Task LoopConfigMenu(int _input)
        {
            if (_input == 1)
            {
                bool loop = true;
                do
                {
                    standardMessages?.NewLine();
                    configureMessages?.ConfigMenuMessage();
                    loop = await SelectConfigMenuOption(InputReader.ReadInputInt());
                } while (loop == true);
            }
        }
        public async Task<bool> SelectConfigMenuOption(int _input)
        {
            switch (_input)
            {
                case 1:
                    standardMessages?.NewLine();
                    configureMessages?.PromptConfigureBalanceMessage();
                    automatedTellerMachine?.ConfigureBalance(InputReader.ReadInputDecimal());
                    return true;
                case 2:
                    await AddNewAccount();
                    return true;
                case 3:
                    return false;
                default:
                    standardMessages?.NoOptionMessage();
                    return true;
            }
        }
        public async Task AddNewAccount()
        {
            IAccount account = new Account();
            standardMessages?.NewLine();
            SetFirstName(account);
            SetLastName(account);
            SetPin(account);
            SetBalance(account);
            await dataAccess.InsertNewAccountAsync(account);
            configureMessages?.CreatedAccountMessage();
        }
        public void SetFirstName(IAccount _account)
        {
            configureMessages?.PromptFirstNameMessage();
            _account.FirstName = InputReader.ReadInputString();
        }
        public void SetLastName(IAccount _account)
        {
            configureMessages?.PromptLastNameMessage();
            _account.LastName = InputReader.ReadInputString();
        }
        public void SetPin(IAccount _account)
        {
            configureMessages?.PromptAccountPinMessage();
            _account.Pin = InputReader.ReadInputInt();
        }
        public void SetBalance(IAccount _account)
        {
            configureMessages?.PromptAccountBalanceMessage();
            _account.Balance = InputReader.ReadInputDecimal();
        }
    }
}
