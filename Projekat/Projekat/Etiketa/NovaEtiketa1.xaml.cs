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
    public partial class NovaEtiketa1 : Window
    {
        private ViewModel vm;
        DataGrid dg;

        public class ViewModel
        {
            public EtiketaA Etiketa { get; set; }
        }

        public NovaEtiketa1(DataGrid d)     //konstruktor za dodavanje nove etikete iz tabele, kako bi osvjezio prikaz
        {
            InitializeComponent();

            this.dg = d;
            vm = new ViewModel();
            vm.Etiketa = new EtiketaA();
            this.DataContext = vm;
        }

        public NovaEtiketa1()
        {
            InitializeComponent();

            this.dg = new DataGrid();
            vm = new ViewModel();
            vm.Etiketa = new EtiketaA();
            this.DataContext = vm;
        }

        #region Click

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (txtOznaka.Text != "" && txtOpis.Text != "")
            {
                if (cmBoja.Text != null)
                {
                    SerijalizacijaEtikete.deserijalizacijaEtikete();
                    Podaci.getInstance().Etikete.Add(vm.Etiketa);   //u listu etiketa dodaje etiketu
                    SerijalizacijaEtikete.serijalizacijaEtikete();
                    this.dg.ItemsSource = Podaci.getInstance().Etikete;  //!pazi
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Niste odabrali boju!");
                }
            }

            else
                MessageBox.Show("Niste popunili sva polja!");   
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            var s = new PomocEtiketa("C:/Users/Lemur/GIT/HCI/Projekat/Projekat/Help/etiketa.htm");
            if (s.ShowDialog().Equals(true)) { }
        }
        
        #endregion
    }
}
