using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Projekat.Etiketa;

namespace Projekat.Vrsta
{
    [Serializable]
    public class VrstaA : INotifyPropertyChanged
    {
        private string _oznaka;
        private string _ime;
        private string _opis;
        private string _tip;
        private List<EtiketaA> _etikete;
        private string _stUgr;
        private string _ikonica;
        private bool _opZaLjude;
        private bool _naIucn;
        private bool _ziviUNasMjes;
        private string _turStatus;
        private float _godPrihod;
        private DateTime _datOtkr;

        //x i y koordinate vrste
        private int x;
        private int y;

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

        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
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

        public string Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                if (value != _tip)
                {
                    _tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        public List<EtiketaA> Etikete
        {
            get
            {
                return _etikete;
            }
            set
            {
                if (value != _etikete)
                {
                    _etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }

        public string StUgr
        {
            get
            {
                return _stUgr;
            }
            set
            {
                if (value != _stUgr)
                {
                    _stUgr = value;
                    OnPropertyChanged("Status ugrozenosti");
                }
            }
        }

        public string Ikonica
        {
            get
            {
                return _ikonica;
            }
            set
            {
                if (value != _ikonica)
                {
                    _ikonica = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        public bool OpZaLjude
        {
            get
            {
                return _opZaLjude;
            }
            set
            {
                if (value != _opZaLjude)
                {
                    _opZaLjude = value;
                    OnPropertyChanged("Opasna za ljude");
                }
            }
        }

        public bool NaIucn
        {
            get
            {
                return _naIucn;
            }
            set
            {
                if (value != _naIucn)
                {
                    _naIucn = value;
                    OnPropertyChanged("Na IUCN listi");
                }
            }
        }

        public bool ZiviUNasMjes
        {
            get
            {
                return _ziviUNasMjes;
            }
            set
            {
                if (value != _ziviUNasMjes)
                {
                    _ziviUNasMjes = value;
                    OnPropertyChanged("Zivi u naseljenom mjestu");
                }
            }
        }

        public string TurStatus
        {
            get
            {
                return _turStatus;
            }
            set
            {
                if (value != _turStatus)
                {
                    _turStatus = value;
                    OnPropertyChanged("Turisticki status");
                }
            }
        }

        public float GodPrihod
        {
            get
            {
                return _godPrihod;
            }
            set
            {
                if (value != _godPrihod)
                {
                    _godPrihod = value;
                    OnPropertyChanged("Godisnji prihod od turizma");
                }
            }
        }

        public DateTime DatOtkr
        {
            get
            {
                return _datOtkr;
            }
            set
            {
                if (value != _datOtkr)
                {
                    _datOtkr = value;
                    OnPropertyChanged("Datum otkrivanja");
                }
            }
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                if (value != x)
                {
                    x = value;
                    OnPropertyChanged("X");
                }
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                if (value != y)
                {
                    y = value;
                    OnPropertyChanged("Y");
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
