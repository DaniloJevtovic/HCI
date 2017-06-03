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
    public partial class IzmjenaEtikete : Window
    {
        //EtiketaA et;
        //int ind;

        private ViewModel vm;

        public class ViewModel
        {
            public EtiketaA Etiketa { get; set; }
            public string stEtiketa { get; set; }
        }

        public IzmjenaEtikete(EtiketaA etiketa, int index)
        {
            InitializeComponent();

            //et = new EtiketaA();
            //et = etiketa;

            vm = new ViewModel();
            vm.Etiketa = etiketa;   //preuzimam selektovanu etiketu

            vm.stEtiketa = etiketa.Oznaka;

            this.DataContext = vm;

            /*
            et = etiketa;
            ind = index;
            txtOznaka.Text = vm.Etiketa.Oznaka;
            this.txtOznaka.Text = etiketa.Oznaka;
            this.txtBoja.Text = etiketa.Boja;
            this.txtOpis.Text = etiketa.Opis;
             * */
        }

        public IzmjenaEtikete()
        {
            InitializeComponent();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            List<EtiketaA> etikete = new List<EtiketaA>();

            foreach (EtiketaA etiketa in Podaci.getInstance().Etikete)
            {
                if (etiketa.Oznaka == vm.stEtiketa)
                {
                    etikete.Add(vm.Etiketa);
                }
                else
                {
                    etikete.Add(etiketa);
                }
            }

            Podaci.getInstance().Etikete = etikete;
            SerijalizacijaEtikete.serijalizacijaEtikete();
            this.Close();

            /*
            if (txtOznaka.Text != "" && txtOpis.Text != "" && txtBoja.Text != null)
            {
                Podaci.getInstance().Etikete.RemoveAt(ind);
                SerijalizacijaEtikete.serijalizacijaEtikete();

                et.Oznaka = txtOznaka.Text;
                et.Opis = txtOpis.Text;
                et.Boja = txtBoja.Text;

                Podaci.getInstance().Etikete.Insert(ind, et);
                SerijalizacijaEtikete.serijalizacijaEtikete();
                this.Close();
            }
            else
                MessageBox.Show("Niste popunili sva polja!");
             * 
             * */
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
    }
}
