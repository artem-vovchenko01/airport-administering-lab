﻿using System.Windows;

namespace WpfApp3.Commands
{
    public class CloseApplicationCommand : BaseCommand
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
