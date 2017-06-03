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
    public partial class PomocVrsta : Window
    {
        public PomocVrsta()
        {
            InitializeComponent();
        }

        public PomocVrsta(String adresa)
        {
            InitializeComponent();
            webEtiketa.Navigate(adresa);
        }
    }
}
