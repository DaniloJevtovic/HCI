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
        //private string file = "tipovi.xml";

        public PregledTipova()
        {
            InitializeComponent();

            TipoviTabela.ItemsSource = Podaci.getInstance().Tipovi;
            /*
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(file);
            DataView dataView = new DataView(dataSet.Tables[0]);
            TipoviTabela.ItemsSource = dataView;
            TipoviTabela.UpdateLayout();
             * */
        }

        #region Click

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var s = new NoviTip1(TipoviTabela);
            //var s = new NoviTip1();
            if(s.ShowDialog().Equals(true)){}   //modalni dijalog ;)
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            var s = new IzmjenaTipa();
            if (s.ShowDialog().Equals(true)) { }
            //s.Show();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion Click
    }
}
