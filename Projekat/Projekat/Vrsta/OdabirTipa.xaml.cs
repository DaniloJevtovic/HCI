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
using System.Data;

using Projekat.Tip;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace Projekat.Vrsta
{
    public partial class OdabirTipa : Window
    {
        private string file = "tipovi.xml";
        public string result="";

        public OdabirTipa()
        {
            InitializeComponent();

            DataSet dataSet = new DataSet();

            dataSet.ReadXml(file);
            DataView dataView = new DataView(dataSet.Tables[0]);
            TipoviTabelaOdb.ItemsSource = dataView;
          
            //TipoviTabelaOdb.ItemsSource = Podaci.getInstance().Tipovi;
        }

        private void Odaberi_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)TipoviTabelaOdb.SelectedItem;
            result = (drv["Oznaka"]).ToString();    //odabir tipa po oznaci, moze i po imenu
            //MessageBox.Show(result, "Odabrano");
            this.Close();          
        }
    }
}
