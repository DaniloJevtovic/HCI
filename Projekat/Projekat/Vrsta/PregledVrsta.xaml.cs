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
using System.ComponentModel;
using System.Data;

namespace Projekat.Vrsta
{
    public partial class PregledVrsta : Window
    {
        //private string file = "vrste.xml";

        public PregledVrsta()
        {
            InitializeComponent();
            VrsteTabela.ItemsSource = Podaci.getInstance().Vrste;
        }

        #region Click

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var s = new NovaVrsta1(VrsteTabela);
            if (s.ShowDialog().Equals(true)) { }
            //s.Show();
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            if (VrsteTabela.SelectedItem != null)
            {
                VrstaA vrsta = (VrstaA)VrsteTabela.SelectedItem;
                int ind = VrsteTabela.SelectedIndex;

                var s = new IzmjenaVrste(vrsta, ind);
                if (s.ShowDialog().Equals(true)) { }
                VrsteTabela.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Niste selektovali vrstu");
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            foreach (VrstaA tip in Podaci.getInstance().Vrste.ToList())
            {
                if (tip.Equals(VrsteTabela.SelectedItem))
                {
                    MessageBoxResult msg = MessageBox.Show("Da li ste sigurni da želite da obrišete selektovanu vrstu?", "Potvrda brisanja tipa", MessageBoxButton.YesNo);

                    if (msg == MessageBoxResult.Yes)
                    {
                        Podaci.getInstance().Vrste.Remove(tip);
                        SerijalizacijaVrste.serijalizacijaVrste();
                        VrsteTabela.Items.Refresh();
                    }
                }
            }
        }

        #endregion Click
    }
}
