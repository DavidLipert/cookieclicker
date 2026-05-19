using System.Windows;

namespace cookieclicker
{
    public partial class cookieshop : Window
    {
        private MainWindow mainWindow;

        private static readonly int[,] betterCursorPricesAndPowers =
        {
            { 10, 1 },   // Level 1: Price 10, Power +1
            { 50, 2 },   // Level 2: Price 50, Power +2
            { 200, 5 },  // Level 3: Price 200, Power +5
            { 1000, 10 }, // Level 4: Price 1000, Power +10
            { 5000, 25 }, // Level 5: Price 5000, Power +25
        };

        private static readonly int[,] doubleClickPricesAndPowers = 
        {
            { 100, 5 },   // Level 1: Price 100, Power +5
            { 750, 10 },   // Level 2: Price 750, Power +10
            { 3500, 20 },  // Level 3: Price 3500, Power +20
            { 10000, 40 }, // Level 4: Price 10000, Power +40
            { 40000, 80 }, // Level 5: Price 40000, Power +80
        };

        public cookieshop(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private bool tryBuyForPrice(int price)
        {
            int balance = mainWindow.getCislo();

            if (balance >= price)
            {
                return mainWindow.decreaseCislo(price);
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

            if (currentLevel >= betterCursorPricesAndPowers.GetLength(0)) { return; }

            int price = betterCursorPricesAndPowers[currentLevel, 0];
            int powerIncrease = betterCursorPricesAndPowers[currentLevel, 1];

            if (!tryBuyForPrice(price)) { return; }

            int nextLevel = currentLevel + 1;
            
            if (nextLevel >= betterCursorPricesAndPowers.GetLength(0))
            {
                betterCursorPrice.Text = "MAX!";
            }
            else
            {
                int nextPrice = betterCursorPricesAndPowers[nextLevel, 0];
                int nextPower = betterCursorPricesAndPowers[nextLevel, 1];

                betterCursorDescription.Text = $"Zvyšuje počet sušenek za kliknutí o {nextPower}.";
                betterCursorPrice.Text = $"{nextPrice}P";
            }

            mainWindow.pridatZaKlik(powerIncrease);
            mainWindow.levelUpZaKlik();
        }

        private void buyDoubleClick_Click(object sender, RoutedEventArgs e)
        {
            int currentLevel = mainWindow.getDoubleClickLevel();

            if (currentLevel >= doubleClickPricesAndPowers.GetLength(0)) { return; }

            int price = doubleClickPricesAndPowers[currentLevel, 0];
            int powerIncrease = doubleClickPricesAndPowers[currentLevel, 1];

            if (!tryBuyForPrice(price)) { return; }

            int nextLevel = currentLevel + 1;

            if (nextLevel >= doubleClickPricesAndPowers.GetLength(0))
            {
                doubleClickPrice.Text = "MAX!";
            }
            else
            {
                int nextPrice = doubleClickPricesAndPowers[nextLevel, 0];
                int nextPower = doubleClickPricesAndPowers[nextLevel, 1];

                doubleClickPrice.Text = $"{nextPrice}P";
                doubleClickDescription.Text = $"Zvyšuje počet sušenek za kliknutí o {nextPower}.";
            }

            mainWindow.pridatZaKlik(powerIncrease);
            mainWindow.levelUpZaKlik();
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
