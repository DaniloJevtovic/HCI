using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Projekat.Etiketa;
using System.Timers;
using System.Windows.Threading;

namespace Projekat.DEMO
{
    public partial class NovaEtiketaDEMO : Window
    {
        private ViewModel vm;
        DataGrid dg;

        public class ViewModel
        {
            public EtiketaA Etiketa { get; set; }
        }

        DispatcherTimer t2;
        public List<String> listaOznaka = new List<string>{"o", "oz", "ozn", "ozna", "oznak", "oznaka", "oznak", "ozna", "ozn", "oz", "o",
            "", "O", "OZ", "OZN", "OZN1"};

        public List<String> listaOpis = new List<string>{ "o", "", "", "", "", "o", "ov", "ovo", "ovo j", "ovo je", "ovo je n", "ovo je ne", "ovo je nek",
            "ovo je neki", "ovo je neki o", "ovo je neki op", "ovo je neki opi", "ovo je neki opis", "ovo je neki opis e",
            "ovo je neki opis et", "ovo je neki opis eti", "ovo je neki opis etik", "ovo je neki opis etike", "ovo je neki opis etiket",
            "ovo je neki opis etikete"};

        public NovaEtiketaDEMO()
        {
            InitializeComponent();

            this.dg = new DataGrid();
            vm = new ViewModel();
            vm.Etiketa = new EtiketaA();
            this.DataContext = vm;

            t2 = new DispatcherTimer();
            t2.Tick += t_Tick1;
            t2.Interval = new TimeSpan(0, 0, 0, 0, 700);
            t2.Start();
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            t2.Stop();
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            t2.Stop();
            this.Close();
        }


        public int i = 0;
        void t_Tick1(object sender, EventArgs e)    //za unos oznake
        {
            txtOznaka.Text = listaOznaka[i];
            i++;
            if (i == listaOznaka.Count())
            {
                t2.Stop();

                t2 = new DispatcherTimer();
                t2.Tick += t_Tick2;
                t2.Interval = new TimeSpan(0, 0, 0, 1, 300);
                t2.Start();
            }
        }

        void t_Tick2(object sender, EventArgs e)    //odabir boje
        {
            cmBoja.IsDropDownOpen = true;
            //cmBoja.SelectedItem = "crna";
            cmBoja.Text = "crna";
            t2.Stop();

            t2 = new DispatcherTimer();
            t2.Tick += t_Tick3;
            t2.Interval = new TimeSpan(0, 0, 0, 1, 0);
            t2.Start();
        }

        void t_Tick3(object sender, EventArgs e)    //zatvaranje comboboxa
        {
            cmBoja.IsDropDownOpen = false;
            cmBoja.Text = "crna";
            t2.Stop();

            t2 = new DispatcherTimer();
            t2.Tick += t_Tick4;
            t2.Interval = new TimeSpan(0, 0, 0, 0, 300);
            t2.Start();
        }

        public int j = 0;
        void t_Tick4(object sender, EventArgs e)    //za unos opisa
        {
            txtOpis.Text = listaOpis[j];
            j++;
            if (j == listaOpis.Count())
            {
                //Sacuvaj.Background = Brushes.Silver;
                t2.Stop();

                reset();
            }
        }

        public void reset()
        {
            i = 0;
            j = 0;
            txtOznaka.Text = "";
            cmBoja.Text = "";
            txtOpis.Text = "";
            //Sacuvaj.Background = Brushes.LightGray;
            t2 = new DispatcherTimer();
            t2.Tick += t_Tick1;
            t2.Interval = new TimeSpan(0, 0, 0, 0, 300);
            t2.Start();
        }

    }
}
