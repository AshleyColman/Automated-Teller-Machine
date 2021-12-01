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
    public sealed class LoginMenu : ILoginMenu
    {
        private readonly IStandardMessages standardMessages;
        private readonly ILoginMenuMessages loginMenuMessages;
        private readonly IAutomatedTellerMachine automatedTellerMachine;
        private const int MaxLoginAttempts = 3;

        public LoginMenu(IStandardMessages _standardMessages, ILoginMenuMessages _loginMenuMessages,
            IAutomatedTellerMachine _automatedTellerMachine)
        {
            standardMessages = _standardMessages;
            loginMenuMessages = _loginMenuMessages;
            automatedTellerMachine = _automatedTellerMachine;
        }
        public async Task LoopReadPin()
        {
            int loginAttempts = 0;
            do
            {
                standardMessages?.NewLine();
                loginMenuMessages?.EnterPinMessage();
                await automatedTellerMachine.Login(InputReader.ReadInputInt());
                CheckLoginAttempts(ref loginAttempts);
            } while (automatedTellerMachine?.IsLoggedIn() == false);
        }
        public void CheckLoginAttempts(ref int _loginAttempts)
        {
            if (automatedTellerMachine?.IsLoggedIn() == false)
            {
                _loginAttempts++;
                if (_loginAttempts >= MaxLoginAttempts)
                {
                    loginMenuMessages?.MaxLoginAttemptsMessage();
                }
            }
        }
    }
}