namespace ATMLibrary.App.Classes.Messages
{
    public interface ILoginMenuMessages
    {
        void EnterPinMessage();
        void ErrorPinMessage();
        void LoggedInMessage(string _firstName, string _lastName);
        void LogoutMessage(string _firstName, string _lastName);
        void MaxLoginAttemptsMessage();
    }
}