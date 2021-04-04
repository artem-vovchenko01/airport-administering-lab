namespace WpfApp3.Services
{
    public interface IUserDialogService
    {
        bool Edit(object item);
        bool Add(object item);
        void ShowInformation(string information, string caption);
        void ShowWarning(string message, string caption);
        void ShowError(string message, string caption);
        bool Confirm(string message, string caption, bool exclamation = false);
        
        
    }
}