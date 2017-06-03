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

using Projekat.Etiketa;
using Projekat.Tip;
using Projekat.Help;



namespace Projekat.Vrsta
{
    public partial class IzmjenaVrste1 : Window
    {
        //VrstaA vr;  //nova vrsta tj vrsta koja ce biti izmjenjena
        //int ind;

        private ViewModel vm;

        public int etBr = 0;

        public class ViewModel
        {
            public VrstaA Vrsta { get; set; }
            public string stVrsta { get; set; }

            public List<EtiketaA> sveEtikete { get; set; }      //sve etikete koje sam sacuvao
            public List<TipP> sviTipovi { get; set; }    //svi tagovi koje sam sacuvao


            public List<EtiketaA> selEtikete { get; set; }     //selektovane etikete  
            public List<CheckBox> prikEtikete { get; set; }
            public List<EtiketaA> selektovane { get; set; }
        }

        public IzmjenaVrste1(VrstaA vrsta, int index)
        {
            InitializeComponent();
            vm = new ViewModel();

            vm.Vrsta = new VrstaA();
            vm.Vrsta = vrsta;   //dodjeljujem prosljedjenu vrstu

            vm.stVrsta = vrsta.Oznaka;

            vm.sviTipovi = new List<TipP>();
            vm.sviTipovi = Podaci.getInstance().Tipovi;

            vm.sveEtikete = new List<EtiketaA>();
            vm.sveEtikete = Podaci.getInstance().Etikete;

            vm.prikEtikete = new List<CheckBox>();
            vm.selektovane = new List<EtiketaA>();

            ucitavanjeTipova();
            ucitavanjeEtiketa();

            vm.Vrsta.Etikete = vm.selektovane;
            vm.Vrsta.Ikonica = vrsta.Ikonica;

            this.DataContext = vm;

        }

        private void ucitavanjeTipova()
        {
            //foreach (TipP tip in Podaci.getInstance().Tipovi)   //combobox popunjavam svim tipovima
            foreach (TipP tip in vm.sviTipovi)
            {
                cmbTip.Items.Add(tip.Oznaka);
                cmbTip.ToolTip = tip.Ime;
            }
        }

        private void ucitavanjeEtiketa()
        {
            //int etBr = 0;
            //foreach (EtiketaA et in Podaci.getInstance().Etikete)
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
                
                foreach (EtiketaA oznacenaEti in vm.Vrsta.Etikete)
                {
                    if (oznacenaEti.Oznaka == et.Oznaka)
                    {
                        cb.IsChecked = true;
                        break;
                    }
                }

                vm.prikEtikete.Add(cb);

                sp.Children.Add(cb);    //u stek panel ubacujem cb
                Grid.SetColumn(sp, etBr % 4);   //6
                Grid.SetRow(sp, etBr / 4);  //6
                listEti.Children.Add(sp);
                ++etBr;
            }
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            var s = new Pomoc();
            if (s.ShowDialog().Equals(true)) { }
        }

        private void noviTip_Click(object sender, RoutedEventArgs e)
        {
            int poc = Podaci.getInstance().Tipovi.Count;    //na pocetku provjerim duzinu liste

            var s = new NoviTip1();
            if (s.ShowDialog().Equals(true)) { }

            int kraj = Podaci.getInstance().Tipovi.Count;   //kad se zatvori dijalog provjerim duzinu listu

            if (poc != kraj)     //ukoliko se kraj i pocetak razlikuju znaci da je nesto dodato, te dodajem posljednji kako ne bi pravio duplikate tipova
                cmbTip.Items.Add(Podaci.getInstance().Tipovi.Last().Oznaka);   //na postojecu listu tipova dodaje zadnje dodatai tip tj novi tip
        }

        private void novaEtiketa_Click(object sender, RoutedEventArgs e)
        {
            int poc = Podaci.getInstance().Etikete.Count;    //na pocetku provjerim duzinu liste

            var s = new NovaEtiketa1();
            if (s.ShowDialog().Equals(true)) { }

            int kraj = Podaci.getInstance().Etikete.Count;

            if (poc != kraj)
            {
                EtiketaA et = Podaci.getInstance().Etikete.Last();

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

                //vm.selEtikete = Podaci.getInstance().Etikete;   //PAZZI ovo dodajem zato sto mjenjam listu etiketa
                vm.sveEtikete = Podaci.getInstance().Etikete;
            }

            //SerijalizacijaEtikete.deserijalizacijaEtikete();    ///PAZZZII

            //listEti.ItemsSource = Podaci.getInstance().Etikete;
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
                //vr.Ikonica = fileDialog.FileName;
                vm.Vrsta.Ikonica = fileDialog.FileName;
            }
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            vm.Vrsta.Etikete.Clear();

            for (int i = 0; i < vm.sveEtikete.Count(); i++)
            {
                if (vm.prikEtikete[i].IsChecked == true)
                {
                    vm.Vrsta.Etikete.Add(vm.sveEtikete[i]);
                }
            }

            List<VrstaA> vrste = new List<VrstaA>();

            foreach (VrstaA vrsta in Podaci.getInstance().Vrste)
            {
                if (vrsta.Oznaka == vm.stVrsta)
                {
                    vrste.Add(vm.Vrsta);
                }
                else
                {
                    vrste.Add(vrsta);
                }
            }

            Podaci.getInstance().Vrste = vrste;
            SerijalizacijaVrste.serijalizacijaVrste();
            this.Close();

            /*
            if (txtOznaka.Text != "" && txtIme.Text != "" && txtOpis.Text != "" && cmbTip.Text != "" &&
                txtStUgr.Text != null && turStat.Text != null) //Ikonica.Source != null
            {
                double n;
                if (double.TryParse(godPrihod.Text, out n))
                {
                    Podaci.getInstance().Vrste.RemoveAt(ind);       //brisem vrstu na tom indeksu
                    SerijalizacijaVrste.serijalizacijaVrste();      //cuvam bez te vrste
                    
                    for (int i = 0; i < vm.prikEtikete.Count; i++)
                    {
                        if (vm.prikEtikete[i].IsChecked == true)
                        {
                            vm.selektovane.Add(vm.selEtikete[i]);
                        }
                    }
                    vm.Vrsta.Etikete = vm.selektovane;

                    vr.Etikete = vm.Vrsta.Etikete;  //!!!!!!!!

                    vr.Oznaka = txtOznaka.Text;
                    vr.Ime = txtIme.Text;
                    vr.Opis = txtOpis.Text;

                    vr.Tip = cmbTip.Text;

                    vr.StUgr = txtStUgr.Text;

                    vr.OpZaLjude = (bool)opZaLjude.IsChecked;
                    vr.NaIucn = (bool)naIucn.IsChecked;
                    vr.ZiviUNasMjes = (bool)uNas.IsChecked;

                    vr.TurStatus = turStat.Text;

                    vr.GodPrihod = (float)Convert.ToDouble(godPrihod.Text);
                    //vr.GodPrihod = float.Parse(godPrihod.Text);
                    vr.DatOtkr = (DateTime)Convert.ToDateTime(Datum.Text);

                    Podaci.getInstance().Vrste.Insert(ind, vr); //na mjestu gdje sam obrisao ubacujem novu vrsu
                    SerijalizacijaVrste.serijalizacijaVrste();  //vrsim serijalizaciju

                    this.Close();
                }
                else
                    MessageBox.Show("Godisnji prihod mora biti broj!");
            }
            else
                MessageBox.Show("Niste popunili sva polja!");
             * */
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
