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

namespace Projekat.Vrsta
{
    public partial class IzmjenaVrste : Window
    {
        VrstaA vr;
        int ind;

        public IzmjenaVrste(VrstaA vrsta, int index)
        {
            InitializeComponent();

            vr = vrsta;
            ind = index;

            this.txtOznaka.Text = vrsta.Oznaka;
            this.txtIme.Text = vrsta.Ime;
            this.txtOpis.Text = vrsta.Opis;
            this._tipTxt.Text = vrsta.Tip;
            this._etiketaTxt.Text = vrsta.Etiketa;
            this.txtStUgr.Text = vrsta.StUgr;
            this.opZaLjude.IsChecked = vrsta.OpZaLjude;
            this.naIucn.IsChecked = vrsta.NaIucn;
            this.uNas.IsChecked = vrsta.ZiviUNasMjes;
            this.turStat.Text = vrsta.TurStatus;
            this.godPrihod.Text = vrsta.GodPrihod.ToString();
            this.Datum.Text = vrsta.DatOtkr.ToString();

        }

        public IzmjenaVrste()
        {
            InitializeComponent();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            Podaci.getInstance().Vrste.RemoveAt(ind);
            SerijalizacijaVrste.serijalizacijaVrste();

            vr.Oznaka = txtOznaka.Text;
            vr.Ime = txtIme.Text;
            vr.Opis = txtOpis.Text;
            vr.Tip = _tipTxt.Text;
            vr.Etiketa = _etiketaTxt.Text;
            vr.StUgr = txtStUgr.Text;

            vr.OpZaLjude = (bool)opZaLjude.IsChecked;
            vr.NaIucn = (bool)naIucn.IsChecked;
            vr.ZiviUNasMjes = (bool)uNas.IsChecked;

            vr.TurStatus = turStat.Text;

            vr.GodPrihod = (float)Convert.ToDouble(godPrihod.Text);
            //vr.GodPrihod = float.Parse(godPrihod.Text);
            vr.DatOtkr = (DateTime)Convert.ToDateTime(Datum.Text);

            Podaci.getInstance().Vrste.Insert(ind, vr);
            SerijalizacijaVrste.serijalizacijaVrste();

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
                vr.Ikonica = fileDialog.FileName;
            }
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OdaberTipa_Click(object sender, RoutedEventArgs e)
        {
            var s = new OdabirTipa();
            if (s.ShowDialog().Equals(true)) { }
            if (s.result != "")  //u slucaju da se ponovo klikne na biranje tipa pa se ne odabere nista da ne bi ponistio predhodno obrisano
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
