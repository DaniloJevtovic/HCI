using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Projekat.Etiketa
{
    [Serializable]
    public class EtiketaA: INotifyPropertyChanged
    {
        private string _oznaka;
        private string _boja;
        private string _opis;
        
        public EtiketaA() 
        {
 
        }

        public string Oznaka 
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public string Boja 
        {
            get
            {
                return _boja;
            }

            set
            {
                if (value != _boja)
                {
                    _boja = value;
                    OnPropertyChanged("Boja");
                }
            }  
        }

        public string Opis
        {
            get
            {
                return _opis;
            }

            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
