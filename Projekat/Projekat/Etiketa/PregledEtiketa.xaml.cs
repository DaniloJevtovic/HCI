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
    /// <summary>
    /// Interaction logic for PregledEtiketa.xaml
    /// </summary>
    public partial class PregledEtiketa : Window
    {
        private string file = "etikete.xml";

        public PregledEtiketa()
        {
            InitializeComponent();

            DataSet dataSet = new DataSet();
            if (File.Exists(file) == false)
                SerijalizacijaEtikete.serijalizacijaEtikete();
            
            dataSet.ReadXml(file);
            DataView dataView = new DataView(dataSet.Tables[0]);
            EtiketeTable.ItemsSource = dataView;
            EtiketeTable.UpdateLayout();

            //this.DataContext = this;
            
        }

      /*  
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }

        public bool Filter(object obj)
        {
            var data = obj as EtiketaA;
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
         */

        #region Click

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var s = new NovaEtiketa1();
            if (s.ShowDialog().Equals(true)) { }
            //s.Show();
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            var s = new IzmjenaEtikete();
            if (s.ShowDialog().Equals(true)) { }
            //s.Show();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion Click
    }

}

