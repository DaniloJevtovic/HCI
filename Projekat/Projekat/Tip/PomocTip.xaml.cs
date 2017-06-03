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
    public partial class PomocTip : Window
    {
        public PomocTip()
        {
            InitializeComponent();
        }

        public PomocTip(String adresa)
        {
            InitializeComponent();
            webTip.Navigate(adresa);
        }
    }
}
