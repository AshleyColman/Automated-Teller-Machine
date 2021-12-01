using ATMLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.App.Interfaces.Menus
{
    public interface IConfigureMenu
    {
        Task LoopConfigPrompt();
        bool CheckConfigPromptOption(int _input);
        Task LoopConfigMenu(int _input);
        Task<bool> SelectConfigMenuOption(int _input);
        Task AddNewAccount();
        void SetFirstName(IAccount _account);
        void SetLastName(IAccount _account);
        void SetPin(IAccount _account);
        void SetBalance(IAccount _account);
    }
}
