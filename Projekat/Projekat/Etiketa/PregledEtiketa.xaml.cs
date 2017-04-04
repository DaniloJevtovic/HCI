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

namespace Projekat.Etiketa
{
    /// <summary>
    /// Interaction logic for PregledEtiketa.xaml
    /// </summary>
    public partial class PregledEtiketa : Window, INotifyPropertyChanged
    {
        private ICollectionView _dataGridCollection;
        private string _filterString;

        public PregledEtiketa()
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
            var data = obj as Etiketa;
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

        public IEnumerable<Etiketa> TestData
        {
            get
            {
                yield return new Etiketa { Oznaka = "913", Boja = "crna", Opis = "fsdfsd dfsdfs" };
                yield return new Etiketa { Oznaka = "224", Boja = "bjela", Opis = "fsdfsd" };
                yield return new Etiketa { Oznaka = "321", Boja = "plava", Opis = "dfsdfs dfs dfsfs" };
                yield return new Etiketa { Oznaka = "432", Boja = "crvena", Opis = "dfsdfs fdsdfsdfsdfsdffghf" };
                yield return new Etiketa { Oznaka = "521", Boja = "zuta", Opis = "hgfhfgh dfswer" };
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
            var s = new NovaEtiketa1();
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

