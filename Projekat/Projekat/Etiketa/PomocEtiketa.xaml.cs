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
    public partial class PomocEtiketa : Window
    {
        public PomocEtiketa()
        {
            InitializeComponent();
        }

        public PomocEtiketa(String adresa)
        {
            InitializeComponent();
            webEtiketa.Navigate(adresa);
        }
    }
}
