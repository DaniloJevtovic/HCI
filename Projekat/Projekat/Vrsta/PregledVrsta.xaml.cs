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

namespace Projekat.Vrsta
{
    /// <summary>
    /// Interaction logic for PregledVrsta.xaml
    /// </summary>
    public partial class PregledVrsta : Window, INotifyPropertyChanged
    {
        private ICollectionView _dataGridCollection;
        private string _filterString;

        public PregledVrsta()
        {
            InitializeComponent();
            DataGridCollection = CollectionViewSource.GetDefaultView(TestData);
            DataGridCollection.Filter = new Predicate<object>(Filter);
        }

        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set
            {
                _dataGridCollection = value;
                NotifyPropertyChanged("DataGridCollection");
            }
        }

        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                NotifyPropertyChanged("FilterString");
                FilterCollection();
            }
        }

        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }

        public bool Filter(object obj)
        {
            var data = obj as Vrsta;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return data.Oznaka.Contains(_filterString) || data.Boja.Contains(_filterString);
                }
                return true;
            }
            return false;
        }

        public IEnumerable<Vrsta> TestData
        {
            get
            {
                yield return new Vrsta { Oznaka = "1", Ime="da", Boja = "crvena", Opis = "dasddasdalsdkjalskdjalskda", StatusUgr="ugrozena", Tip="sda", OpasnaZaLjude="da", NaIUCNListi="ne", ZiviUNas="da", TuristickiStatus="izolovana", GodPrihod="242", DatumOtrkivanja="2.3.1940"};
                yield return new Vrsta { Oznaka = "2", Ime = "dabc", Boja = "plava", Opis = "dasddasdalsdkjalskdjalskda", StatusUgr = "ugrozena", Tip = "sdhfga", OpasnaZaLjude = "ne", NaIUCNListi = "ne", ZiviUNas = "da", TuristickiStatus = "habituirana", GodPrihod = "242", DatumOtrkivanja = "12.3.1460" };
                yield return new Vrsta { Oznaka = "3", Ime = "daff", Boja = "zelena", Opis = "dasddasdalsdkjalskdjalskda", StatusUgr = "ugrozena", Tip = "shnva", OpasnaZaLjude = "ne", NaIUCNListi = "da", ZiviUNas = "ne", TuristickiStatus = "izolovana", GodPrihod = "22", DatumOtrkivanja = "2.5.2005" };
                yield return new Vrsta { Oznaka = "4", Ime = "dafds", Boja = "zuta", Opis = "dasddasdalsdkjalskdjalskda", StatusUgr = "ugrozena", Tip = "reta", OpasnaZaLjude = "da", NaIUCNListi = "ne", ZiviUNas = "da", TuristickiStatus = "habituirana", GodPrihod = "1242", DatumOtrkivanja = "9.3.1960" };
                yield return new Vrsta { Oznaka = "5", Ime = "dagds", Boja = "ljubicasta", Opis = "dasddasdalsdkjalskdjalskda", StatusUgr = "ugrozena", Tip = "sbca", OpasnaZaLjude = "da", NaIUCNListi = "ne", ZiviUNas = "da", TuristickiStatus = "djelimicno habituirana", GodPrihod = "23432", DatumOtrkivanja = "2.3.1980" };
                yield return new Vrsta { Oznaka = "6", Ime = "dafda", Boja = "crna", Opis = "dasddasdalsdkjalskdjalskda", StatusUgr = "ugrozena", Tip = "snvba", OpasnaZaLjude = "ne", NaIUCNListi = "da", ZiviUNas = "ne", TuristickiStatus = "izolovana", GodPrihod = "2432", DatumOtrkivanja = "12.10.1960" };
                yield return new Vrsta { Oznaka = "7", Ime = "dabc", Boja = "smedja", Opis = "dasddasdalsdkjalskdjalskda", StatusUgr = "ugrozena", Tip = "sda", OpasnaZaLjude = "da", NaIUCNListi = "ne", ZiviUNas = "ne", TuristickiStatus = "habituirana", GodPrihod = "41242", DatumOtrkivanja = "3.1.1930" };
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #region Click

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var s = new NovaVrsta1();
            s.Show();
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion Click
    }
}
