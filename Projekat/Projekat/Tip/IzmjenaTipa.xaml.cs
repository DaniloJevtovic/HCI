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
using Microsoft.Win32;

namespace Projekat.Tip
{
    public partial class IzmjenaTipa : Window
    {
        //TipP ti;
        //int ind;

        private ViewModel vm;

        public class ViewModel
        {
            public TipP Tip { get; set; }
            public string stTip { get; set; }
        }

        public IzmjenaTipa(TipP tip, int index)
        {
            InitializeComponent();
            
            //ti = tip;
            //ind = index;

            vm = new ViewModel();
            vm.Tip = tip;   //preuzimam proslijedjeni tip tj selektovani

            vm.stTip = tip.Oznaka;

            this.DataContext = vm;

            /*
            
            this.txtOznaka.Text = tip.Oznaka;
            this.txtIme.Text = tip.Ime;
            this.Ikonica.Source = new BitmapImage(new Uri(tip.Ikonica.ToString()));
            this.txtOpis.Text = tip.Opis;
            **/
        }

        public IzmjenaTipa()
        {
            InitializeComponent();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            List<TipP> tipovi = new List<TipP>();

            foreach (TipP tip in Podaci.getInstance().Tipovi)
            {
                if (tip.Oznaka == vm.stTip)
                {
                    tipovi.Add(vm.Tip);
                }
                else
                {
                    tipovi.Add(tip);
                }
            }

            Podaci.getInstance().Tipovi = tipovi;
            SerijalizacijaTipa.serijalizacijaTipa();
            this.Close();

            /*
            if (txtOznaka.Text != "" && txtIme.Text != "" && txtOpis.Text != "")  //Ikonica.Source != null
            {
                Podaci.getInstance().Tipovi.RemoveAt(ind);
                SerijalizacijaTipa.serijalizacijaTipa();

                ti.Oznaka = txtOznaka.Text;
                ti.Ime = txtIme.Text;
                ti.Opis = txtOpis.Text;

                Podaci.getInstance().Tipovi.Insert(ind, ti);
                SerijalizacijaTipa.serijalizacijaTipa();
                this.Close();
            }

            else
                MessageBox.Show("Niste popunili sva polja!!!");
             * */
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIkonica_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Title = "Izaberite ikonicu";
            fileDialog.Filter = "Images|*.jpg;*.jpeg;*.png|" +
                                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                "Portable Network Graphic (*.png)|*.png";
            if (fileDialog.ShowDialog() == true)
            {
                Ikonica.Source = new BitmapImage(new Uri(fileDialog.FileName));
                vm.Tip.Ikonica = fileDialog.FileName;
                //ti.Ikonica = fileDialog.FileName;
            }
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
