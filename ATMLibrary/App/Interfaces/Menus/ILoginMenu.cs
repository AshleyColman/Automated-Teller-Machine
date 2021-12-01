using ATMLibrary.App.Classes;
using ATMLibrary.App.Classes.Messages;
using ATMLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.App.Interfaces.Menus
{
    public interface ILoginMenu
    {
        private const int MaxLoginAttempts = 3;

        Task LoopReadPin();
        void CheckLoginAttempts(ref int _loginAttempts);
    }
}
