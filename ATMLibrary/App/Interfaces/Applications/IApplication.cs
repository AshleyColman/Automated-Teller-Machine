namespace ATMLibrary.Classes
{
    public interface IApplication
    {
        Task Run();
        void Close();
    }
}