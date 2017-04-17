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
using System.IO;
using System.Xml.Serialization;

using Projekat.Help;
using System.ComponentModel;



namespace Projekat.Etiketa
{
    /// <summary>
    /// Interaction logic for NovaEtiketa1.xaml
    /// </summary>
    public partial class NovaEtiketa1 : Window
    {
        private ViewModel vm;

        public class ViewModel
        {
            public EtiketaA Etiketa { get; set; }
        }

        public NovaEtiketa1()
        {
            InitializeComponent();
            vm = new ViewModel();
            vm.Etiketa = new EtiketaA();

            //vm.Etiketa.Oznaka = txtOpis.Text;
            //vm.Etiketa.Boja = cmBoja.Text;
            //vm.Etiketa.Opis = txtOpis.Text;
            this.DataContext = vm;
            
        }

        #region Click

        
        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            SerijalizacijaEtikete.deserijalizacijaEtikete();
            Podaci.getInstance().Etikete.Add(vm.Etiketa);   //u listu etiketa dodaje etiketu
            SerijalizacijaEtikete.serijalizacijaEtikete();
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            var s = new Pomoc();
            s.Show();
        }
        #endregion
    }
}
