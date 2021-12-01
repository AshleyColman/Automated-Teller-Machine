using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.App.Classes
{
    public sealed class StandardMessages : IStandardMessages
    {
        public void WelcomeMessage() => Console.WriteLine("Welcome to the Automated Teller Machine");
        public void LoadingMessage() => Console.WriteLine("Please wait...");
        public void NewLine() => Console.WriteLine();
        public void DecimalInputFormatErrorMessage() => Console.WriteLine("Only decimal inputs are accepted");
        public void NoOptionMessage() => Console.WriteLine("Option does not exist");
        public void CloseMessage() => Console.WriteLine("Press any key to close the application");
    }
}