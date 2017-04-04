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

namespace Projekat.Tip
{
    /// <summary>
    /// Interaction logic for PregledTipova.xaml
    /// </summary>
    public partial class PregledTipova : Window, INotifyPropertyChanged
    {
        private ICollectionView _dataGridCollection;
        private string _filterString;

        public PregledTipova()
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
            var data = obj as Tip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return data.Oznaka.Contains(_filterString) || data.Ime.Contains(_filterString);
                }
                return true;
            }
            return false;
        }

        public IEnumerable<Tip> TestData
        {
            get
            {
                yield return new Tip { Oznaka = "132", Ime = "tigar", Ikonica = "/", Opis = "dasddas lskdjalskda" };
                yield return new Tip { Oznaka = "232", Ime = "africki slon", Ikonica = "/", Opis = "dasdd sdkjalskdjalskda" };
                yield return new Tip { Oznaka = "812", Ime = "divlji konj", Ikonica = "/", Opis = "dasds dalsd kjal skdjalskda" };
                yield return new Tip { Oznaka = "484", Ime = "lemur", Ikonica = "/", Opis = "dasdas das dgfg " };
                yield return new Tip { Oznaka = "315", Ime = "delfin", Ikonica = "/", Opis = "dasddasdalsdkjalskdjalskda" };
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
            var s = new NoviTip1();
            s.Show();
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            var s = new IzmjenaTipa();
            s.Show();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion Click
    }
}
