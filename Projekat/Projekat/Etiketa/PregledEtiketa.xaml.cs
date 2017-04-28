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
        //private string file = "etikete.xml";
        //public string result = "";
        private string filterString;

        public PregledEtiketa()
        {
            InitializeComponent();

            EtiketeTable.ItemsSource = Podaci.getInstance().Etikete;
            
            /*
            DataSet dataSet = new DataSet();
            if (File.Exists(file) == false)
                SerijalizacijaEtikete.serijalizacijaEtikete();
            
            dataSet.ReadXml(file);
            DataView dataView = new DataView(dataSet.Tables[0]);
            EtiketeTable.ItemsSource = dataView;
            EtiketeTable.UpdateLayout();

            //this.DataContext = this;
            */
        }

        #region Click

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var s = new NovaEtiketa1(EtiketeTable);
            if (s.ShowDialog().Equals(true)) { }
            //s.Show();
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            if (EtiketeTable.SelectedItem != null)
            {
                EtiketaA et = (EtiketaA)EtiketeTable.SelectedItem;
                int ind = EtiketeTable.SelectedIndex;

                var s = new IzmjenaEtikete(et, ind);
                if (s.ShowDialog().Equals(true)) { }
                //s.Show();
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

        #endregion Click

        #region Search

        public string FilterString
        {
            get { return filterString; }
            set
            {
                filterString = value;
                NotifyPropertyChanged("FilterString");
            }
        }

        private void FilterCollection()
        {
            if (EtiketeTable != null)
            {
                EtiketeTable.Items.Refresh();
            }
        }

        public bool Filter(object obj)
        {
            var data = obj as EtiketaA;
            if (data != null)
            {
                if(!string.IsNullOrEmpty(filterString))
                {
                    return data.Oznaka.Contains(filterString) || data.Boja.Contains(filterString);  //po oznaci i boji
                }
            }

            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion Search
    }

}

