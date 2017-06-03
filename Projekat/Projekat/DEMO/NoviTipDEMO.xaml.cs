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
using System.Windows.Threading;
using Projekat.Tip;

namespace Projekat.DEMO
{
    public partial class NoviTipDEMO : Window
    {
        private ViewModel vm;
        DataGrid dg;

        public class ViewModel
        {
            public TipP Tip { get; set; }
        }

        DispatcherTimer t2;
        public List<String> listaOznaka = new List<string>{"o", "oz", "ozn", "ozna", "oznak", "oznaka", "oznak", "ozna", "ozn",
            "oz", "o", "" , "" , "T", "T1", "T", "", "T", "Ti", "Tip"};

        public List<String> listaIme = new List<string>{"i", "", "", "", "", "", "i", "im", "ime", "ime t", "ime ti", "ime tip", "ime tipa"};

        public List<String> listaOpis = new List<string>{ "o", "ov", "ovo", "ovo j", "ovo je", "ovo je n", "ovo je ne", "ovo je nek",
            "ovo je neki", "ovo je neki o", "ovo je neki op", "ovo je neki opi", "ovo je neki opis", "ovo je neki opis t",
            "ovo je neki opis ti", "ovo je neki opis tip", "ovo je neki opis tipa"};

        public NoviTipDEMO()
        {
            InitializeComponent();

            this.dg = new DataGrid();
            vm = new ViewModel();
            vm.Tip = new TipP();
            this.DataContext = vm;

            t2 = new DispatcherTimer();
            t2.Tick += t_Tick1;
            t2.Interval = new TimeSpan(0, 0, 0, 0, 500);
            t2.Start();
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIkonica_Click(object sender, RoutedEventArgs e)
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
                t2.Interval = new TimeSpan(0, 0, 0, 0, 300);
                t2.Start();
            }
        }

        public int j = 0;
        void t_Tick2(object sender, EventArgs e)    //za unos imena
        {
            txtIme.Text = listaIme[j];
            j++;
            if (j == listaIme.Count())
            {
                t2.Stop();

                t2 = new DispatcherTimer();
                t2.Tick += t_Tick3;
                t2.Interval = new TimeSpan(0, 0, 0, 0, 300);
                t2.Start();
            }

        }

        
        void t_Tick3(object sender, EventArgs e)    //za unos ikonice
        {
            Ikonica.Source = new BitmapImage(new Uri("C:/Users/Lemur/GIT/HCI/Projekat/Projekat/Images/tip.png"));
            t2.Stop();

            t2 = new DispatcherTimer();
            t2.Tick += t_Tick4;
            t2.Interval = new TimeSpan(0, 0, 0, 0, 300);
            t2.Start();
        }

        public int k = 0;
        void t_Tick4(object sender, EventArgs e)    //za unos opisa
        {
            txtOpis.Text = listaOpis[k];
            k++;
            if (k == listaOpis.Count())
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
            k = 0;
            txtOznaka.Text = "";
            txtIme.Text = "";
            Ikonica.Source = null;
            txtOpis.Text = "";
            //Sacuvaj.Background = Brushes.LightGray;
            t2 = new DispatcherTimer();
            t2.Tick += t_Tick1;
            t2.Interval = new TimeSpan(0, 0, 0, 0, 300);
            t2.Start();
        }

    }
}
