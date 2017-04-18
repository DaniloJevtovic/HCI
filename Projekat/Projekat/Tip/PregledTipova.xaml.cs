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

namespace Projekat.Tip
{
    public partial class PregledTipova : Window
    {
        private string file = "tipovi.xml";

        public PregledTipova()
        {
            InitializeComponent();

            DataSet dataSet = new DataSet();

            dataSet.ReadXml(file);
            DataView dataView = new DataView(dataSet.Tables[0]);
            TipoviTabela.ItemsSource = dataView;
            TipoviTabela.UpdateLayout();

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
