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

namespace Projekat.Vrsta
{
    /// <summary>
    /// Interaction logic for PregledVrsta.xaml
    /// </summary>
    public partial class PregledVrsta : Window
    {
        private string file = "vrste.xml";

        public PregledVrsta()
        {
            InitializeComponent();

            DataSet dataSet = new DataSet();

            dataSet.ReadXml(file);
            DataView dataView = new DataView(dataSet.Tables[0]);
            VrsteTabela.ItemsSource = dataView;
            VrsteTabela.UpdateLayout();
        }

        #region Click

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var s = new NovaVrsta1();
            if (s.ShowDialog().Equals(true)) { }
            //s.Show();
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            var s = new IzmjenaVrste();
            if (s.ShowDialog().Equals(true)) { }
            //s.Show();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion Click
    }
}
