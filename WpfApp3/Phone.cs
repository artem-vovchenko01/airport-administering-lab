using System.Windows;

namespace WpfApp3
{
    public class Phone : DependencyObject
    {
        public static readonly DependencyProperty PriceProperty;
        public static readonly DependencyProperty NameProperty;

        static Phone()
        {
            PriceProperty = DependencyProperty.Register("Price", typeof(int), typeof(Phone));
            NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Phone));
            
        }

        public int Price
        {
            get => (int) GetValue(PriceProperty);
            set => SetValue(PriceProperty, value);
        }

        public string Name
        {
            get => (string) GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }
    }
}
