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

namespace Projekat.Etiketa
{
    /// <summary>
    /// Interaction logic for NovaEtiketa1.xaml
    /// </summary>
    public partial class NovaEtiketa1 : Window
    {
        public NovaEtiketa1()
        {
            InitializeComponent();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
