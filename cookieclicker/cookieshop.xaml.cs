using System.Windows;

namespace cookieclicker
{
    public partial class cookieshop : Window
    {
        private MainWindow mainWindow;

        private static readonly int[,] betterCursorPricesAndPowers =
        {
            { 10, 1 },       // Level 1: Price 10, Power +1
            { 50, 2 },       // Level 2: Price 50, Power +2
            { 200, 5 },      // Level 3: Price 200, Power +5
            { 1000, 10 },    // Level 4: Price 1000, Power +10
            { 5000, 25 },    // Level 5: Price 5000, Power +25
        };

        private static readonly int[,] doubleClickPricesAndPowers = 
        {
            { 100, 5 },      // Level 1: Price 100, Power +5
            { 750, 10 },     // Level 2: Price 750, Power +10
            { 3500, 20 },    // Level 3: Price 3500, Power +20
            { 10000, 40 },   // Level 4: Price 10000, Power +40
            { 40000, 80 },   // Level 5: Price 40000, Power +80
        };

        private static readonly int[,] grandmaPricesAndPowers =
        {
            { 100, 1 },       // Level 1: Price 100, Power +1
            { 2500, 5 },      // Level 2: Price 2500, Power +5
            { 10000, 20 },    // Level 3: Price 10000, Power +20
            { 50000, 100 },   // Level 4: Price 50000, Power +100
            { 200000, 500 },  // Level 5: Price 200000, Power +500
        };
        
        private static readonly int[,] bakeryPricesAndPowers =
        {
            { 500, 5 },       // Level 1: Price 500, Power +5
            { 10000, 25 },    // Level 2: Price 10000, Power +25
            { 50000, 125 },   // Level 3: Price 50000, Power +125
            { 250000, 625 },  // Level 4: Price 250000, Power +625
            { 1000000, 3125 },// Level 5: Price 1000000, Power +3125
        };

        private static readonly int[,] factoryPricesAndPowers =
        {
            { 2500, 20 },   // Level 1: Price 2500, Power +20
            { 50000, 100 },   // Level 2: Price 50000, Power +100
            { 250000, 1000 },  // Level 3: Price 250000, Power +1000
            { 1250000, 5000 }, // Level 4: Price 1250000, Power +5000
            { 5000000, 25000 }, // Level 5: Price 5000000, Power +25000
        };

        public cookieshop(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            updateBetterCursorUI();
            updateDoubleClickUI();
        }
        private void updateBetterCursorUI()
        {
            int currentLevel = mainWindow.getZaKlikLevel();
            if (currentLevel >= betterCursorPricesAndPowers.GetLength(0))
            {
                betterCursorDescription.Text = "Zvyšuje počet sušenek za kliknutí!";
                betterCursorPrice.Text = "MAX!";
            }
            else
            {
                int nextPrice = betterCursorPricesAndPowers[currentLevel, 0];
                int nextPower = betterCursorPricesAndPowers[currentLevel, 1];
                betterCursorDescription.Text = $"Zvyšuje počet sušenek za kliknutí o {nextPower}.";
                betterCursorPrice.Text = $"{nextPrice}P";
            }
        }

        private void updateDoubleClickUI()
        {
            int currentLevel = mainWindow.getDoubleClickLevel();
            if (currentLevel >= doubleClickPricesAndPowers.GetLength(0))
            {
                doubleClickDescription.Text = "Zvyšuje počet sušenek za kliknutí!";
                doubleClickPrice.Text = "MAX!";
            }
            else
            {
                int nextPrice = doubleClickPricesAndPowers[currentLevel, 0];
                int nextPower = doubleClickPricesAndPowers[currentLevel, 1];
                doubleClickDescription.Text = $"Zvyšuje počet sušenek za kliknutí o {nextPower}.";
                doubleClickPrice.Text = $"{nextPrice}P";
            }
        }

        private void updateGrandmaUI()
        {
            int currentLevel = mainWindow.getGrandmaLevel();
            if (currentLevel >= grandmaPricesAndPowers.GetLength(0))
            {
                grandmaDescription.Text = "Zvyšuje počet sušenek za kliknutí!";
                grandmaPrice.Text = "MAX!";
            }
            else
            {
                int nextPrice = grandmaPricesAndPowers[currentLevel, 0];
                int nextPower = grandmaPricesAndPowers[currentLevel, 1];
                grandmaDescription.Text = $"Zvyšuje počet sušenek za sekundu o {nextPower}.";
                grandmaPrice.Text = $"{nextPrice}P";
            }
        }

        private void updateBakeryUI()
        {
            int currentLevel = mainWindow.getBakeryLevel();
            if (currentLevel >= bakeryPricesAndPowers.GetLength(0))
            {
                bakeryDescription.Text = "Zvyšuje počet sušenek za kliknutí!";
                bakeryPrice.Text = "MAX!";
            }
            else
            {
                int nextPrice = bakeryPricesAndPowers[currentLevel, 0];
                int nextPower = bakeryPricesAndPowers[currentLevel, 1];
                bakeryDescription.Text = $"Zvyšuje počet sušenek za sekundu o {nextPower}.";
                bakeryPrice.Text = $"{nextPrice}P";
            }
        }

        private void updateFactoryUI()
        {
            int currentLevel = mainWindow.getFactoryLevel();
            if (currentLevel >= factoryPricesAndPowers.GetLength(0))
            {
                factoryDescription.Text = "Zvyšuje počet sušenek za kliknutí!";
                factoryPrice.Text = "MAX!";
            }
            else
            {
                int nextPrice = factoryPricesAndPowers[currentLevel, 0];
                int nextPower = factoryPricesAndPowers[currentLevel, 1];
                factoryDescription.Text = $"Zvyšuje počet sušenek za sekundu o {nextPower}.";
                factoryPrice.Text = $"{nextPrice}P";
            }
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

            mainWindow.pridatZaKlik(powerIncrease);
            mainWindow.levelUpZaKlik();
            updateBetterCursorUI();
        }

        private void buyDoubleClick_Click(object sender, RoutedEventArgs e)
        {
            int currentLevel = mainWindow.getDoubleClickLevel();

            if (currentLevel >= doubleClickPricesAndPowers.GetLength(0)) { return; }

            int price = doubleClickPricesAndPowers[currentLevel, 0];
            int powerIncrease = doubleClickPricesAndPowers[currentLevel, 1];

            if (!tryBuyForPrice(price)) { return; }

            mainWindow.pridatZaKlik(powerIncrease);
            mainWindow.levelUpDoubleClick();
            updateDoubleClickUI();
        }

        private void buyGrandma_Click(object sender, RoutedEventArgs e)
        {
            int currentLevel = mainWindow.getGrandmaLevel();
        
            if (currentLevel >= grandmaPricesAndPowers.GetLength(0)) { return; }

            int price = grandmaPricesAndPowers[currentLevel, 0];
            int powerIncrease = grandmaPricesAndPowers[currentLevel, 1];

            if (!tryBuyForPrice(price)) { return; }

            mainWindow.pridatZaSekundu(powerIncrease);
            mainWindow.levelUpGrandma();
            updateGrandmaUI();
        }

        private void buySmallFactory_Click(object sender, RoutedEventArgs e)
        {
            int currentLevel = mainWindow.getBakeryLevel();
            
            if (currentLevel >= bakeryPricesAndPowers.GetLength(0)) { return; }

            int price = bakeryPricesAndPowers[currentLevel, 0];
            int powerIncrease = bakeryPricesAndPowers[currentLevel, 1];

            if (!tryBuyForPrice(price)) { return; }

            mainWindow.pridatZaSekundu(powerIncrease);
            mainWindow.levelUpBakery();
            updateBakeryUI();
        }

        private void buyFactory_Click(object sender, RoutedEventArgs e)
        {
            int currentLevel = mainWindow.getFactoryLevel();

            if (currentLevel >= factoryPricesAndPowers.GetLength(0)) { return; }

            int price = factoryPricesAndPowers[currentLevel, 0];
            int powerIncrease = factoryPricesAndPowers[currentLevel, 1];

            if (!tryBuyForPrice(price)) { return; }

            mainWindow.pridatZaSekundu(powerIncrease);
            mainWindow.levelUpFactory();
            updateFactoryUI();
        }
    }
}
