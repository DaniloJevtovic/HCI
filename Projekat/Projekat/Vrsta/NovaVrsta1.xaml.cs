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
using Projekat.Etiketa;
using System.Data;
using System.Collections;
using System.Collections.ObjectModel;

namespace Projekat.Vrsta
{
    public partial class NovaVrsta1 : Window
    {
        private ViewModel vm;
        DataGrid dg;
        public int etBr = 0;

        ObservableCollection<VrstaA> vrste;

        public class ViewModel
        {
            public VrstaA Vrsta { get; set; }   //nova vrsta koju cu da ubacujem u podatke

            public List<EtiketaA> sveEtikete { get; set; }      //sve etikete koje sam sacuvao/ ucitavam ih iz podataka
            public List<TipP> sviTipovi { get; set; }           //svi tagovi koje sam sacuvao/ ucitavam ih iz podataka

            public List<CheckBox> prikEtikete { get; set; }      //cekboxovi
            public List<EtiketaA> selektovane { get; set; }     //etikete koje su selektovane
        }

        public NovaVrsta1(DataGrid dg, ObservableCollection<VrstaA> vr)  //konstruktor za datagrid kako bi osvjezio pregled kad dodam novu vrstu
        {
            InitializeComponent();

            this.dg = dg;

            vrste = new ObservableCollection<VrstaA>();
            vrste = vr;

            vm = new ViewModel();
            vm.Vrsta = new VrstaA();

            vm.selektovane = new List<EtiketaA>();  //pravim novu listu u koju cu da dodajm samo one etikete koje su selektovane

            vm.prikEtikete = new List<CheckBox>();
            vm.Vrsta.Etikete = new List<EtiketaA>();

            vm.sveEtikete = Podaci.getInstance().Etikete;
            vm.sviTipovi = Podaci.getInstance().Tipovi;
            
            //this.DataContext = vm;

            ucitavanjeTipova();
            ucitavanjeEtiketa();

            this.DataContext = vm;
        }

        public NovaVrsta1(ObservableCollection<VrstaA> vr)
        {
            InitializeComponent();

            this.dg = new DataGrid();

            vrste = new ObservableCollection<VrstaA>();
            vrste = vr;
            
            vm = new ViewModel();
            vm.Vrsta = new VrstaA();    //nova vrsta koju cu da dodajem
            
            
            vm.selektovane = new List<EtiketaA>();          //pravim novu listu u koju cu da dodajm samo one etikete koje su selektovane
            
            vm.prikEtikete = new List<CheckBox>();          //pravim novu listu cekboxova koje cu da dadajem 
            vm.Vrsta.Etikete = new List<EtiketaA>();        //nova lista vrsta za novu vrstu koju cu da ubacujem
            
            vm.sveEtikete = Podaci.getInstance().Etikete;   //ucitavama sve etikete iz podataka
            vm.sviTipovi = Podaci.getInstance().Tipovi;     //ucitavam sve tipove iz podataka

            //this.DataContext = vm;

            ucitavanjeTipova();
            ucitavanjeEtiketa();
            
            this.DataContext = vm;
        }

        private void ucitavanjeTipova()
        {
            foreach (TipP tip in vm.sviTipovi)  //combobox popunjavam svim tipovima
            {
                cmbTip.Items.Add(tip.Oznaka);
                cmbTip.ToolTip = tip.Ime;
            }
        }

        private void ucitavanjeEtiketa()
        {
            //int etBr = 0;
            foreach (EtiketaA et in vm.sveEtikete)
            {
                //if (etBr % 4 == 0)
                listEti.RowDefinitions.Add(new RowDefinition());

                // definisem male stek panele koje cu da dodajem |* |
                StackPanel sp = new StackPanel();
                sp.Background = Brushes.Silver;
                sp.MinHeight = 21;
                sp.MaxHeight = 21;
                sp.Margin = new System.Windows.Thickness(2, 2, 2, 2);
                sp.ToolTip = et.Boja;

                //definisem cekboxove
                CheckBox cb = new CheckBox();
                cb.Margin = new System.Windows.Thickness(2, 2, 2, 2);
                cb.Content = et.Oznaka;
                cb.Foreground = Brushes.Black;
                vm.prikEtikete.Add(cb);

                sp.Children.Add(cb);    //u stek panel ubacujem cb
                Grid.SetColumn(sp, etBr % 4);   //6
                Grid.SetRow(sp, etBr / 4);  //6
                listEti.Children.Add(sp);
                ++etBr;
            }
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (txtOznaka.Text != "" && txtIme.Text != "" && txtOpis.Text != "" && cmbTip.Text != null 
                 && txtStUgr.Text != null && turStat.Text != null) 
            {
                double n;
                if (double.TryParse(godPrihod.Text, out n)) //NAPISI NESTO BOLJE!!!
                {
                    for (int i = 0; i < vm.prikEtikete.Count; i++)  //prolazim kroz cekboxove
                    {
                        if (vm.prikEtikete[i].IsChecked == true)    //provjeravam koje su etikete selektovane
                        {
                            vm.selektovane.Add(vm.sveEtikete[i]);   //ako je etiketa seletovana dodajem je u listu selektovanih etiketa
                        }
                    }
                    vm.Vrsta.Etikete = vm.selektovane;  //selektovane etikete pridruzujem novoj vrsti
                     
   
                    SerijalizacijaTipa.deserijalizacijaTipa();
                    if (Ikonica.Source == null) //za preuzimanje ikonice od tipa ukoliko se ne doda
                    {
                        SerijalizacijaTipa.deserijalizacijaTipa();
                        foreach (TipP tip in Podaci.getInstance().Tipovi)
                        {
                            if (tip.Oznaka.Equals(vm.Vrsta.Tip))
                            {
                                vm.Vrsta.Ikonica = tip.Ikonica;
                            }
                        }
                    }
                    vrste.Add(vm.Vrsta);
                    Podaci.getInstance().Vrste.Add(vm.Vrsta);
                    SerijalizacijaVrste.serijalizacijaVrste();
                    

                    MessageBox.Show("Podaci uspješno sačuvani.");
                    //vrste.Add(vm.Vrsta);

                    //SerijalizacijaVrste.deserijalizacijaVrste();
                    this.dg.ItemsSource = vrste;

                    this.Close();
                }
                else
                    MessageBox.Show("Godisnji prihod mora biti broj!");
            }
            else
                MessageBox.Show("Niste popunili sva obavezna* polja!");
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
            var s = new PomocVrsta("C:/Users/Lemur/GIT/HCI/Projekat/Projekat/Help/vrsta.htm");
            if (s.ShowDialog().Equals(true)) { }
        }

        private void noviTip_Click(object sender, RoutedEventArgs e)
        {
            int poc = Podaci.getInstance().Tipovi.Count;    //na pocetku provjerim duzinu liste

            var s = new NoviTip1();
            if (s.ShowDialog().Equals(true)) { }
            

            int kraj = Podaci.getInstance().Tipovi.Count;   //kad se zatvori dijalog provjerim duzinu listu

            if (poc != kraj)     //ukoliko se kraj i pocetak razlikuju znaci da je nesto dodato, te dodajem posljednji kako ne bi pravio duplikate tipova
            {
                cmbTip.Items.Add(Podaci.getInstance().Tipovi.Last().Oznaka);   //na postojecu listu tipova dodaje zadnje dodatai tip tj novi tip
            }
            
            //vm.sviTipovi = Podaci.getInstance().Tipovi;   //moze i ovako
            //ucitavanjeTipova();
        }

        private void novaEtiketa_Click(object sender, RoutedEventArgs e)
        {
            int poc = Podaci.getInstance().Etikete.Count;   //na pocetku isto kao i za tip provjeravam duzinu liste

            var s = new NovaEtiketa1();
            if (s.ShowDialog().Equals(true)) { }

            int kraj = Podaci.getInstance().Etikete.Count;   //kad se zatvori dijalog provjerim duzinu listu

            if (poc != kraj)
            {
                EtiketaA et = Podaci.getInstance().Etikete.Last();      //uzimam zadnju etiketu 

                listEti.RowDefinitions.Add(new RowDefinition());

                // definisem stek panele koje cu da dodajem |* |
                StackPanel sp = new StackPanel();
                sp.Background = Brushes.Silver;
                sp.MinHeight = 21;
                sp.MaxHeight = 21;
                sp.Margin = new System.Windows.Thickness(2, 2, 2, 2);
                sp.ToolTip = et.Boja;

                CheckBox cb = new CheckBox();
                cb.Margin = new System.Windows.Thickness(2, 2, 2, 2);
                cb.Content = et.Oznaka;
                cb.Foreground = Brushes.Black;
                vm.prikEtikete.Add(cb);

                sp.Children.Add(cb);    //u stek panel ubacujem cb
                Grid.SetColumn(sp, etBr % 4);   //6
                Grid.SetRow(sp, etBr / 4);  //6
                listEti.Children.Add(sp);

                ++etBr;

                vm.sveEtikete = Podaci.getInstance().Etikete;   //PAZZI ovo dodajem zato sto mjenjam listu etiketa
            }
        }
    }
}
