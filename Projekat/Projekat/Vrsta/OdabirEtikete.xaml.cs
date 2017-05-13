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

namespace Projekat.Vrsta
{
    public partial class OdabirEtikete : Window
    {
        private string file = "etikete.xml";
        public string result = "";

        public OdabirEtikete()
        {
            InitializeComponent();

            DataSet dataSet = new DataSet();

            dataSet.ReadXml(file);
            try //ukoliko nema etiketa
            {
                DataView dataView = new DataView(dataSet.Tables[0]);
                EtiketeTabelaOdb.ItemsSource = dataView;
            }
            catch { }
        }

        private void Odaberi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView drv = (DataRowView)EtiketeTabelaOdb.SelectedItem;
                result = (drv["Oznaka"]).ToString();    //odabir etikete po oznaci, moze i po boji
                //MessageBox.Show(result, "Odabrano");
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }
    }
}
