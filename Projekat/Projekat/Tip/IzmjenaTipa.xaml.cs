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

namespace Projekat.Tip
{
    /// <summary>
    /// Interaction logic for IzmjenaTipa.xaml
    /// </summary>
    public partial class IzmjenaTipa : Window
    {
        public IzmjenaTipa()
        {
            InitializeComponent();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIkonica_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
