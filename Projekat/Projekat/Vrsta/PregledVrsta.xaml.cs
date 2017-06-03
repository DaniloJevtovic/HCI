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
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace Projekat.Vrsta
{
    public partial class PregledVrsta : Window
    {
        //private string file = "vrste.xml";

        private ViewModel vm;
        ObservableCollection<VrstaA> vrste;
        ObservableCollection<VrstaA> vrsteNaCanvasu;

        Canvas can;

        public class ViewModel
        {
            public List<VrstaA> Vrste { get; set; }
        }

        public PregledVrsta(ObservableCollection<VrstaA> vr, ObservableCollection<VrstaA> vrCanvas, Canvas canvas)
        {
            InitializeComponent();

            vrste = new ObservableCollection<VrstaA>();
            vrsteNaCanvasu = new ObservableCollection<VrstaA>();
            can = new Canvas();

            vrste = vr;
            vrsteNaCanvasu = vrCanvas;
            can = canvas;


            vm = new ViewModel();
            vm.Vrste = Podaci.getInstance().Vrste;
            
            VrsteTabela.ItemsSource = Podaci.getInstance().Vrste;
            
            //this.DataContext = vm;
            //VrsteTabela.ItemsSource = vm.vrste;
        }

        //pretraga po oznaci
        private void txtOznaka_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(VrsteTabela.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    VrstaA vrsta = o as VrstaA;
                    return (vrsta.Oznaka.ToUpper().StartsWith(filter.ToUpper()));
                };
            }
        }

        //pretraga po imenu
        private void txtIme_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(VrsteTabela.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    VrstaA vrsta = o as VrstaA;
                    return (vrsta.Ime.ToUpper().StartsWith(filter.ToUpper()));
                };
            }
        }

        #region Click

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            //int poc = Podaci.getInstance().Vrste.Count;

            var s = new NovaVrsta1(VrsteTabela, vrste);
            if (s.ShowDialog().Equals(true)) { }

            int kraj = Podaci.getInstance().Vrste.Count;

            //if (poc != kraj)
            //{
                //vrste.Add(Podaci.getInstance().Vrste.Last());   //na listu vrsta koje nisu na kanvasu dodajem poslednju dodatu vrstu
            //}
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            if (VrsteTabela.SelectedItem != null)
            {
                VrstaA vrsta = (VrstaA)VrsteTabela.SelectedItem;
                int ind = VrsteTabela.SelectedIndex;

                var s = new IzmjenaVrste1(vrsta , ind);
                if (s.ShowDialog().Equals(true)) { }


            
                VrsteTabela.Items.Refresh();

                SerijalizacijaVrste.deserijalizacijaVrste();
                VrsteTabela.ItemsSource = Podaci.getInstance().Vrste;
            } 
            else
            {
                MessageBox.Show("Niste selektovali vrstu");
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            foreach (VrstaA vrsta in Podaci.getInstance().Vrste.ToList())
            {
                if (vrsta.Equals(VrsteTabela.SelectedItem))
                {
                    MessageBoxResult msg = MessageBox.Show("Da li ste sigurni da želite da obrišete selektovanu vrstu?", "Potvrda brisanja tipa", MessageBoxButton.YesNo);

                    if (msg == MessageBoxResult.Yes)
                    {
                        Podaci.getInstance().Vrste.Remove(vrsta);
                        SerijalizacijaVrste.serijalizacijaVrste();
                        VrsteTabela.Items.Refresh();

                        vrste.Remove(vrsta);
                        vrsteNaCanvasu.Remove(vrsta);

                        //brise ikonicu sa kanvasa!!!!!!!!!!! proslijedio si mu u konstruktoru pregledavrste kanvas
                        UIElement remove = null;
                        foreach (UIElement elem in can.Children)
                        {
                            if (elem.Uid == vrsta.Oznaka)
                            {
                                remove = elem;
                                break;
                            }
                        }
                        can.Children.Remove(remove);
                    }
                }
            }
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            var s = new PomocVrsta("C:/Users/Lemur/GIT/HCI/Projekat/Projekat/Help/pregledVrsta.htm");
            if (s.ShowDialog().Equals(true)) { }
        }
        #endregion Click
        
        private void txtOznaka_LostFocus(object sender, RoutedEventArgs e)
        {
            //txtOznaka.Text = null;
        }

        private void txtIme_LostFocus(object sender, RoutedEventArgs e)
        {
            //txtIme.Text = null;
        }
    }
}
