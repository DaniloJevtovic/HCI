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
        TipP ti;
        int ind;

        public IzmjenaTipa(TipP tip, int index)
        {
            InitializeComponent();
            
            ti = tip;
            ind = index;

            this.txtOznaka.Text = tip.Oznaka;
            this.txtIme.Text = tip.Ime;
            //
            this.txtOpis.Text = tip.Opis;

        }

        public IzmjenaTipa()
        {
            InitializeComponent();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
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
                //vm.Tip.Ikonica = fileDialog.FileName;
                ti.Ikonica = fileDialog.FileName;
            }
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
