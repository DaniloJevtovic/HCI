using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Projekat.Etiketa;
using System.ComponentModel;

namespace Projekat
{
    public class Podaci: INotifyPropertyChanged
    {
        private static Podaci instance = null;
        
        private List<EtiketaA> etikete;
        

        private Podaci()
        {
            this.etikete = new List<EtiketaA>();
        }

        public static Podaci getInstance()
        {
            if (instance == null)
                instance = new Podaci();
            return instance;
        }

        public List<EtiketaA> Etikete
        {
            get
            {
                return etikete;
            }

            set
            {
                if (value != etikete)
                {
                    etikete = value;
                    OnPropertyChanged("Etikete");
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
