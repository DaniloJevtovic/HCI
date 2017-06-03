using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Projekat.Etiketa;
using Projekat.Tip;
using Projekat.Vrsta;

using System.ComponentModel;

namespace Projekat
{
    public class Podaci: INotifyPropertyChanged
    {
        private static Podaci instance = null;
        
        private List<EtiketaA> etikete;
        private List<TipP> tipovi;
        private List<VrstaA> vrste;

        private Podaci()
        {
            this.etikete = new List<EtiketaA>();
            this.tipovi = new List<TipP>();
            this.vrste = new List<VrstaA>();
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

        public List<TipP> Tipovi
        {
            get
            {
                return tipovi;
            }

            set
            {
                if (value != tipovi)
                {
                    tipovi = value;
                    OnPropertyChanged("Tipovi");
                }
            }
        }

        public List<VrstaA> Vrste
        {
            get
            {
                return vrste;
            }

            set
            {
                if (value != vrste)
                {
                    vrste = value;
                    OnPropertyChanged("Vrste");
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

        public static void ChangeDroppedVrsta(VrstaA vrsta)
        {
            foreach (VrstaA v in instance.Vrste)
            {
                if (v.Oznaka == vrsta.Oznaka)
                {
                    v.X = vrsta.X;
                    v.Y = vrsta.Y;
                    break;
                }
            }
            SerijalizacijaVrste.serijalizacijaVrste();
        }   //cuvanje novih kordinata vrste pri pomjeranju ikonice na kanvasu
    }
}
