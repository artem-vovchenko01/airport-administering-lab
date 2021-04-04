using System.Windows;

namespace WpfApp3.Commands
{
    public class CloseWindowCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            return parameter is Window;
        }

        public override void Execute(object parameter)
        {
            if (! CanExecute(parameter)) return;
            var window = (Window) parameter;
            window.Close();
        }
    }
}