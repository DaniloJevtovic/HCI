using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml.Serialization;

namespace Projekat.Vrsta
{
    public class SerijalizacijaVrste
    {
        private static string file = "vrste.xml";

        public SerijalizacijaVrste() { }

        public static void serijalizacijaVrste()
        {
            var serializer = new XmlSerializer(typeof(List<VrstaA>));
            using (var stream = File.Open(file, FileMode.Create))
            {
                serializer.Serialize(stream, Podaci.getInstance().Vrste);
            }

        }

        public static void deserijalizacijaVrste()
        {
            if (File.Exists(file) == false) //ako ne postoji fajl 
                serijalizacijaVrste();

            var serializer = new XmlSerializer(typeof(List<VrstaA>));
            using (var stream = File.OpenRead(file))
            {
                var vrste = (List<VrstaA>)(serializer.Deserialize(stream));
                Podaci.getInstance().Vrste = vrste;
            }
        }
    }
}
