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

using Projekat.Help;
using Projekat.Tip;
using System.Data;
using System.Collections;

namespace Projekat.Vrsta
{
    public partial class NovaVrsta1 : Window
    {
        private ViewModel vm;

        DataGrid dg;

        public class ViewModel
        {
            public VrstaA Vrsta { get; set; }
        }

        public NovaVrsta1(DataGrid dg)  //konstruktor kada dodajes iz pregleda kako bi osvjezio pregled
        {
            InitializeComponent();

            this.dg = dg;

            vm = new ViewModel();
            vm.Vrsta = new VrstaA();
            this.DataContext = vm;

            Datum.DisplayDateStart = DateTime.Today;
        }

        public NovaVrsta1()
        {
            InitializeComponent();

            this.dg = new DataGrid();
            
            vm = new ViewModel();
            vm.Vrsta = new VrstaA();
            this.DataContext = vm;
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (txtOznaka.Text != "" && txtIme.Text != "" && txtOpis.Text != "" && _tipTxt.Text != "" &&
                _etiketaTxt.Text != "" && txtStUgr.Text != null && Ikonica.Source != null && turStat.Text != null)
            {
                double n;
                if (double.TryParse(godPrihod.Text, out n)) //NAPISI NESTO BOLJE!!!
                {
                    SerijalizacijaVrste.deserijalizacijaVrste();
                    Podaci.getInstance().Vrste.Add(vm.Vrsta);
                    SerijalizacijaVrste.serijalizacijaVrste();
                    this.dg.ItemsSource = Podaci.getInstance().Vrste;
                    this.Close();
                }
                else
                    MessageBox.Show("Godisnji prihod mora biti broj!!!");
            }
            else
                MessageBox.Show("Niste popunili sva polja!!!");
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
                vm.Vrsta.Ikonica = fileDialog.FileName;
            }
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            var s = new Pomoc();
            if (s.ShowDialog().Equals(true)) { }
            //s.Show();
        }

        private void OdaberTipa_Click(object sender, RoutedEventArgs e)
        {
            var s = new OdabirTipa();
            if (s.ShowDialog().Equals(true)) { }
            if(s.result != "")  //u slucaju da se ponovo klikne na biranje tipa pa se ne odabere nista da ne bi ponistio predhodno obrisano
                _tipTxt.Text = s.result;
        }

        private void OdabirEtikete_Click(object sender, RoutedEventArgs e)
        {
            var s = new OdabirEtikete();
            if (s.ShowDialog().Equals(true)) { }
            if (s.result != "")  //u slucaju da se ponovo klikne na biranje etikete pa se ne odabere nista da ne bi ponistio predhodno obrisano
                _etiketaTxt.Text = s.result;
        }
    }
}
