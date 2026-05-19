using System.Windows;

namespace cookieclicker
{
    /// <summary>
    /// Interakční logika pro cookieshop.xaml
    /// </summary>
    public partial class cookieshop : Window
    {
        public cookieshop()
        {
            InitializeComponent();
        }

        private bool checkPrice(int balance, int price)
        {
            if (balance >= price)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Nemáte dostatek paws!");
                return false;
            }
        }

        private void buyBetterCursor_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void buyDoubleClick_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buyGrandma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buySmallFactory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buyFactory_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
