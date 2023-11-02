using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2.Models
{
    public class Dostawa
    {
        public string AdresKlienta { get; set; }
        public DateTime DataPrzyjazdu { get; set; }
        public Transport Transport { get; set; }
        public DzialLogistyki DzialLogistyki { get; set; }

        public Dostawa(string adresKlienta, DateTime dataPrzyjazdu, Transport transport, DzialLogistyki dzialLogistyki)
        {
            AdresKlienta = adresKlienta;
            DataPrzyjazdu = dataPrzyjazdu;
            Transport = transport;
            DzialLogistyki = dzialLogistyki;
        }
    }
}
