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
    public partial class NovaEtiketa1 : Window, INotifyPropertyChanged
    {
        public Etiketa etiketa;
        [XmlArray("Etikete"), XmlArrayItem(typeof(Etiketa), ElementName = "Etiketaaa")]
        public List<Etiketa> etikete;
        
        public NovaEtiketa1()
        {
            InitializeComponent();
            etiketa = new Etiketa();
            etikete = new List<Etiketa>();

            //etikete = ucitajDatoteku("etikete");
 
        }

        public void sacuvajDatoteku(String fileName)
        {
            using(FileStream stream = new FileStream(fileName, FileMode.Append))
            {
                var serializer = new XmlSerializer(typeof(List<Etiketa>));
                serializer.Serialize(stream, etikete);
            }
        }

        public static List<Etiketa> ucitajDatoteku(String fileName)
        {
            using(var stream = new FileStream(fileName,FileMode.Open))
            {
                var deserializer = new XmlSerializer(typeof(List<Etiketa>));
                return (List<Etiketa>)deserializer.Deserialize(stream);
            }
        }

        public void dodajEtiketu()
        {
            etiketa.Oznaka = txtOznaka.Text;
            etiketa.Boja = cmBoja.Text;
            etiketa.Opis = txtOpis.Text;

            etikete.Add(etiketa);
            sacuvajDatoteku("etikete");
        }

        /*
        public void dodajEtiketu(Etiketa et)
        {
            etiketa.Oznaka = txtOznaka.Text;
            etiketa.Boja = cmBoja.Text;
            etiketa.Opis = txtOpis.Text;
  
            etikete.Add(et);

            sacuvajDatoteku(etikete);
        }

        public void sacuvajDatoteku(List<Etiketa> etiketee)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Etiketa>));
            using (TextWriter writer = new StreamWriter("etikete.xml"))
            {
                serializer.Serialize(writer, etiketee);
            }
        }

        public void ucitajDatoteku()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Etiketa>));
            TextReader reader = new StreamReader("etikete.xml");
            object obj = deserializer.Deserialize(reader);
            

        }
        */


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


        #region Click

        
        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            //dodajEtiketu(etiketa);
            dodajEtiketu();
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
