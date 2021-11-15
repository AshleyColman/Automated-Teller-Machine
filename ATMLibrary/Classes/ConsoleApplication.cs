

namespace ATMLibrary.Classes
{
    public sealed class ConsoleApplication : IApplication
    {
        private readonly IMessageService messageService;
        private readonly IAutomatedTellerMachine automatedTellerMachine;
        public ConsoleApplication(IMessageService _messageService, IAutomatedTellerMachine _automatedTellerMachine)
        {
            messageService = _messageService;
            automatedTellerMachine = _automatedTellerMachine;
        }
        public void Run()
        {
            messageService.WelcomeMessage();
            messageService.LoginMessage();
            Pause();
            LoopMenu();
            messageService.ExitMessage();
            Pause();
        }
        private void Pause() => Console.ReadLine();
        private void LoopMenu()
        {
            int input = 0;
            do
            {
                messageService.MenuMessage();
                input = ReadInputInt();
               
            } while (true != false);
        }
        private void SelectMenuOption(int _option)
        {
            switch (_option)
            {
                case 1:
                    automatedTellerMachine.ViewBalance();
                    break;
                case 2:
                    automatedTellerMachine.Withdraw();
                    break;
                case 3:
                    automatedTellerMachine.Deposit();
                    break;
                case 4:
                    automatedTellerMachine.Logout();
                    break;
                default:
                    messageService.OptionDoesNotExistMessage();
                    break;
            }
        }
        private string ReadInput() => Console.ReadLine() ?? string.Empty;
        private int ReadInputInt()
        {
            int input = 0;
            bool success = int.TryParse(Console.ReadLine(), out input);
            if (success == true) { return input; }
            else { return -1; }
        }
    }
}
