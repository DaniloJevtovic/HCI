using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Projekat.Tip
{
    public class SerijalizacijaTipa
    {
        private static string file = "tipovi.xml";

        public SerijalizacijaTipa() { }

        public static void serijalizacijaTipa()
        {
            var serializer = new XmlSerializer(typeof(List<TipP>));
            using (var stream = File.Open(file, FileMode.Create))
            {
                serializer.Serialize(stream, Podaci.getInstance().Tipovi);
            }

        }

        public static void deserijalizacijaTipa()
        {
            if (File.Exists(file) == false) //ako ne postoji fajl 
                serijalizacijaTipa();

            var serializer = new XmlSerializer(typeof(List<TipP>));
            using (var stream = File.OpenRead(file))
            {
                var tipovi = (List<TipP>)(serializer.Deserialize(stream));
                Podaci.getInstance().Tipovi = tipovi;
            }
        }
    }
}
