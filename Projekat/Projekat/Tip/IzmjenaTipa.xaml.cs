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
using Microsoft.Win32;

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
            OpenFileDialog fileDialog = new OpenFileDialog();


            fileDialog.Title = "Izaberite ikonicu";
            fileDialog.Filter = "Images|*.jpg;*.jpeg;*.png|" +
                                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                "Portable Network Graphic (*.png)|*.png";
            if (fileDialog.ShowDialog() == true)
            {
                Ikonica.Source = new BitmapImage(new Uri(fileDialog.FileName));
                //vm.Tip.Ikonica = fileDialog.FileName;
            }
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
