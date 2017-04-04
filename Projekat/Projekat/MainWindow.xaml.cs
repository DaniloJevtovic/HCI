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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Projekat.Vrsta;
using Projekat.Tip;
using Projekat.Etiketa;
using Projekat.Help;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;  //glavni prozor se prikazuje u centru
        }


        #region Click

        private void NovaVrsta_Click(object sender, RoutedEventArgs e)
        {
            var s = new NovaVrsta1();
            s.Show();
        }

        private void NoviTip_Click(object sender, RoutedEventArgs e)
        {
            var s = new NoviTip1();
            s.Show();
        }

        private void NovaEtiketa_Click(object sender, RoutedEventArgs e)
        {
            var s = new NovaEtiketa1();
            s.Show();
        }

        private void PregledVrsta_Click(object sender, RoutedEventArgs e)
        {
            var s = new PregledVrsta();
            s.Show();
        }

        private void PregledTipova_Click(object sender, RoutedEventArgs e)
        {
            var s = new PregledTipova();
            s.Show();
        }

        private void PregledEtiketa_Click(object sender, RoutedEventArgs e)
        {
            var s = new PregledEtiketa();
            s.Show();
        }

   
        private void Tutorijal_Click(object sender, RoutedEventArgs e)
        {
            var s = new Tutorijal();
            s.Show();
        }

        private void Demo_Click(object sender, RoutedEventArgs e)
        {
            var s = new Demo();
            s.Show();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            var s = new About();
            s.Show();
        }
     
        #endregion Click

    }
}
