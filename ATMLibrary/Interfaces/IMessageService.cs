

namespace ATMLibrary.Classes
{
    public interface IMessageService
    {
        void WelcomeMessage();
        void LoginMessage();
        void MenuMessage();
        void OptionDoesNotExistMessage()
        void LogoutMessage();
        void ExitMessage();
    }
}