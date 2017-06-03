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

using Projekat.Vrsta;
using Projekat.Help;


namespace Projekat.Tip
{
    public partial class PregledTipova : Window
    {
        public PregledTipova()
        {
            InitializeComponent();
            TipoviTabela.ItemsSource = Podaci.getInstance().Tipovi;
        }

        //pretraga po oznaci
        private void txtOznaka_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(TipoviTabela.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    TipP tip = o as TipP;
                    return (tip.Oznaka.ToUpper().StartsWith(filter.ToUpper()));
                };
            }
        }

        //pretraga po imenu
        private void txtIme_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(TipoviTabela.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    TipP tip = o as TipP;
                    return (tip.Ime.ToUpper().StartsWith(filter.ToUpper()));
                };
            }
        }

        #region Click

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var s = new NoviTip1(TipoviTabela);
            if (s.ShowDialog().Equals(true)) { }
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            if (TipoviTabela.SelectedItem != null)
            {
                TipP tip = (TipP)TipoviTabela.SelectedItem;
                int ind = TipoviTabela.SelectedIndex;

                var s = new IzmjenaTipa(tip, ind);
                if (s.ShowDialog().Equals(true)) { }
                TipoviTabela.Items.Refresh();

                SerijalizacijaTipa.deserijalizacijaTipa();
                TipoviTabela.ItemsSource = Podaci.getInstance().Tipovi;
            }

            else
            {
                MessageBox.Show("Niste selektovali tip");
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            foreach (TipP tip in Podaci.getInstance().Tipovi.ToList())
            {
                if (tip.Equals(TipoviTabela.SelectedItem))
                {

                    foreach (VrstaA vrsta in Podaci.getInstance().Vrste)
                    {
                        if (tip.Oznaka == vrsta.Tip)
                        {
                            MessageBox.Show("Nije moguće obrisati tip jer je povezan sa vrstom");
                            break;
                        }

                        else
                        {
                            MessageBoxResult msg = MessageBox.Show("Da li ste sigurni da želite da obrišete selektovani tip?", "Potvrda brisanja tipa", MessageBoxButton.YesNo);

                            if (msg == MessageBoxResult.Yes)
                            {
                                Podaci.getInstance().Tipovi.Remove(tip);
                                SerijalizacijaTipa.serijalizacijaTipa();
                                TipoviTabela.Items.Refresh();
                            }

                            break;
                        }
                    }


                }
            }
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            var s = new PomocTip("C:/Users/Lemur/GIT/HCI/Projekat/Projekat/Help/pregledTipova.htm");
            if (s.ShowDialog().Equals(true)) { }
        }

        #endregion Click

        private void txtOznaka_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtIme.IsFocused.Equals(true))
                txtOznaka.Text = "";
        }

        private void txtIme_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtOznaka.IsFocused.Equals(true))
                txtIme.Text = "";
        }
    }
}
