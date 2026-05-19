using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cookieclicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private cookieshop? shop;

        private int cislo = 0;
        public int getCislo() => cislo;

        private int zaklik = 1;
        private int zasekundu = 0;

        private int zaKlikLevel = 0;
        private int doubleClickLevel = 0;

        private int grandmaLevel = 0;
        private int bakeryLevel = 0;
        private int factoryLevel = 0;

        public int getZaKlikLevel() => zaKlikLevel;
        public int getDoubleClickLevel() => doubleClickLevel;
        public int getGrandmaLevel() => grandmaLevel;
        public int getBakeryLevel() => bakeryLevel;
        public int getFactoryLevel() => factoryLevel;

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += casTik;
            timer.Start();

        }

        public bool decreaseCislo(int amount)
        {
            if (cislo >= amount)
            {
                cislo -= amount;
                TxtCislo.Text = cislo.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void pridatZaKlik(int pocet)
        {
            zaklik += pocet;
            TxtZaKlik.Text = "Počet za kliknutí: " + zaklik.ToString();
        }

        public void pridatZaSekundu(int pocet)
        {
            zasekundu += pocet;
            ZaSekunduLabel.Content = "Počet za sekundu: " + zasekundu.ToString();
        }

        public void levelUpZaKlik() { zaKlikLevel++; }
        public void levelUpGrandma() { grandmaLevel++; }
        public void levelUpBakery() { bakeryLevel++; }
        public void levelUpFactory() { factoryLevel++; }

        private void casTik(object? sender, EventArgs e)
        {
            cislo += zasekundu;
            TxtCislo.Text = cislo.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            cislo+= zaklik;
            TxtCislo.Text = cislo.ToString();
            

        }
        
        private void shopButon_Click(object sender, RoutedEventArgs e)
        {
            if (shop == null)
            {
                shop = new cookieshop(this);
                shop.Closed += (s, args) => shop = null;
            }

            if (shop.IsVisible) { shop.Activate(); }
            else { shop.Show(); }
        }
    }
}