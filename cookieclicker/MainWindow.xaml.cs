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
        cookieshop shop;
        private int cislo = 0;
        private int zaklik = 10;
        private int zasekundu = 1;

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += casTik;
            timer.Start();

        }

        public void pridatZaKlik(int pocet)
        {
            zaklik += pocet;
            TxtZaKlik.Text = "Počet za kliknuti: " + zaklik.ToString();
        }

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

        public void ZaSekunduLabel
        
        private void shopButon_Click(object sender, RoutedEventArgs e)
        {
            if (shop == null)

            {

                shop = new cookieshop();

                shop.Closed += (s, args) => shop = null;

            }

            if (shop.IsVisible)

            {

                shop.Activate();

            }

            else

            {

                shop.Show();

            }

        }
    }
}