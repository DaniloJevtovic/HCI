using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml.Serialization;

namespace Projekat.Etiketa
{
    public class SerijalizacijaEtikete
    {
        private static string file = "etikete.xml";

        public SerijalizacijaEtikete() { }

        public static void serijalizacijaEtikete()
        {
            var serializer = new XmlSerializer(typeof(List<EtiketaA>));
            using (var stream = File.Open(file, FileMode.Create))
            {
                serializer.Serialize(stream, Podaci.getInstance().Etikete);
            }

        }

        public static void deserijalizacijaEtikete()
        {
            if (File.Exists(file) == false) //ako ne postoji fajl 
                serijalizacijaEtikete();

            var serializer = new XmlSerializer(typeof(List<EtiketaA>));
            using (var stream = File.OpenRead(file))
            {
                var etikete = (List<EtiketaA>)(serializer.Deserialize(stream));
                Podaci.getInstance().Etikete = etikete;
            }
        }
    }
}
