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
    public partial class PregledVrsta : Window
    {
        public PregledVrsta()
        {
            InitializeComponent();
        }

        #region Click

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var s = new NovaVrsta1();
            s.Show();
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            var s = new IzmjenaVrste();
            s.Show();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion Click
    }
}
