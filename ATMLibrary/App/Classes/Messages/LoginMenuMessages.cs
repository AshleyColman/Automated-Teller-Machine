using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.App.Classes.Messages
{
    public sealed class LoginMenuMessages : ILoginMenuMessages
    {
        public void EnterPinMessage() => Console.WriteLine("Please enter your PIN");
        public void ErrorPinMessage() => Console.WriteLine("Error: pin does not exist");
        public void LoggedInMessage(string _firstName, string _lastName) => Console.WriteLine($"Logged in as {_firstName} {_lastName}");
        public void LogoutMessage(string _firstName, string _lastName) => Console.WriteLine($"Successfully logged out {_firstName} {_lastName}\n");
        public void MaxLoginAttemptsMessage() => Console.WriteLine("Max login attemps reached");
    }
}