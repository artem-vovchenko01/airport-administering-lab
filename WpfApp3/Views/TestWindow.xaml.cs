using System;
using System.Windows;
using Data.Repositories.Abstract;
using WpfApp3.ViewModels;

namespace WpfApp3.Views
{
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
            // DataContext = new FlightsViewModel();
        }
    }
}
