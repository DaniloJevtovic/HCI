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
using System.Collections.ObjectModel;
using System.Data;
using System.IO;


namespace Projekat.Etiketa
{
    public partial class PregledEtiketa : Window
    {
        public PregledEtiketa()
        {
            InitializeComponent();
            EtiketeTable.ItemsSource = Podaci.getInstance().Etikete;
        }

        //filtriranje po oznaci
        private void txtOznaka_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(EtiketeTable.ItemsSource);
            
            if (filter == "")
                cv.Filter = null;
            
            else
            {
                cv.Filter = o =>
                {
                    EtiketaA et = o as EtiketaA;
                    return (et.Oznaka.ToUpper().StartsWith(filter.ToUpper()));
                };
            }
        }

        //filtriranje po Boji
        private void txtBoja_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(EtiketeTable.ItemsSource);
            
            if (filter == "")
                cv.Filter = null;
            
            else
            {
                cv.Filter = o =>
                {
                    EtiketaA et = o as EtiketaA;
                    return (et.Boja.ToUpper().StartsWith(filter.ToUpper()));
                };
            }
        }

        #region Click

        private void btnDodaj_Click(object sender, RoutedEventArgs e)   //konstruktor iz pregleda
        {
            var s = new NovaEtiketa1(EtiketeTable);
            if (s.ShowDialog().Equals(true)) { }
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            if (EtiketeTable.SelectedItem != null)
            {
                EtiketaA et = (EtiketaA)EtiketeTable.SelectedItem;
                int ind = EtiketeTable.SelectedIndex;

                var s = new IzmjenaEtikete(et, ind);
                if (s.ShowDialog().Equals(true)) { }
                EtiketeTable.Items.Refresh();

                SerijalizacijaEtikete.deserijalizacijaEtikete();
                EtiketeTable.ItemsSource = Podaci.getInstance().Etikete;
            }

            else
            {
                MessageBox.Show("Niste selektovali etiketu");
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            foreach(EtiketaA et in Podaci.getInstance().Etikete.ToList())
            {
                if (et.Equals(EtiketeTable.SelectedItem))
                {
                    MessageBoxResult msg = MessageBox.Show("Da li ste sigurni da želite da obrišete selektovanu etiketu?", "Potvrda brisanja etikete", MessageBoxButton.YesNo);

                    if (msg == MessageBoxResult.Yes)
                    {
                        Podaci.getInstance().Etikete.Remove(et);
                        SerijalizacijaEtikete.serijalizacijaEtikete();
                        EtiketeTable.Items.Refresh();   //napokon!
                    }
                }
            }
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            var s = new PomocEtiketa("C:/Users/Lemur/GIT/HCI/Projekat/Projekat/Help/pregledEtiketa.htm");
            if (s.ShowDialog().Equals(true)) { }
        }
        #endregion Click



        private void txtOznaka_LostFocus(object sender, RoutedEventArgs e)
        {
            //txtOznaka.Text = "";    //kad izgubi fokus brise se tekst
        }

        private void txtBoja_LostFocus(object sender, RoutedEventArgs e)
        {
            //txtBoja.Text = "";      //kad izbrise fokus brise tekst
        }
 
    }

}

