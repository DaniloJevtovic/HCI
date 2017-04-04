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

namespace Projekat.Vrsta
{
    /// <summary>
    /// Interaction logic for IzmjenaVrste.xaml
    /// </summary>
    public partial class IzmjenaVrste : Window
    {
        public IzmjenaVrste()
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
