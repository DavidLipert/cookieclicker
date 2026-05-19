using System.Windows;

namespace cookieclicker
{
    /// <summary>
    /// Interakční logika pro cookieshop.xaml
    /// </summary>
    public partial class cookieshop : Window
    {
        private MainWindow mainWindow;

        public cookieshop(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
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
            int currentLevel = mainWindow.getZaKlikLevel();

            switch (currentLevel)
            {
                case 0:
                    mainWindow.pridatZaKlik(1);
                    break;
                case 1:
                    mainWindow.pridatZaKlik(2);
                    break;
                case 2:
                    mainWindow.pridatZaKlik(5); 
                    break;
                case 3:
                    mainWindow.pridatZaKlik(10);
                    break;
                default:
                    break;
            }

            mainWindow.levelUpZaKlik();
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
