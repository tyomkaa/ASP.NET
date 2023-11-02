using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2.Models
{
    [Serializable]
    public class DaneOsobowe
    {
        private static List<DaneOsobowe> extent = new List<DaneOsobowe>();

        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public DaneOsobowe(int iD, string imie, string nazwisko)
        {
            ID = iD;
            Imie = imie;
            Nazwisko = nazwisko;
            extent.Add(this);
        }
    }
}
