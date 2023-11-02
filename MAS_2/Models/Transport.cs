using System;
using System.Collections.Generic;

namespace MAS_2.Models
{
    public class Transport
    {
        private HashSet<Samochod> obslugiwaneSamochody;
        public DateTime PlanowanaDataRozpoczecia { get; set; }
        public DateTime FaktycznaDataRozpoczecia { get; set; }
        public DateTime PlanowanaDataZakonczenia { get; set; }
        public DateTime FaktycznaDataZakonczenia { get; set; }
        public decimal WartoscTransportu
        {
            get
            {
                decimal sumaWartosci = 0;
                foreach (var samochod in obslugiwaneSamochody)
                {
                    sumaWartosci += samochod.Ladownosc;
                }
                return sumaWartosci;
            }
        }
        public static int LimitWartosci { get; set; }

        public Transport()
        {
            obslugiwaneSamochody = new HashSet<Samochod>();
        }

        public void DodajSamochod(Samochod samochod)
        {
            if (CzySpelniaWarunki(samochod))
            {
                obslugiwaneSamochody.Add(samochod);
            }
            else
            {
                throw new Exception("Samochod nie spelnia warunkow ograniczenia subset.");
            }
        }

        public void UsunSamochod(Samochod samochod)
        {
            obslugiwaneSamochody.Remove(samochod);
        }

        public bool CzySpelniaWarunki(Samochod samochod)
        {
            return samochod.Ladownosc <= samochod.MaksLadownosc;
        }

        public void WyswietlSamochody()
        {
            foreach (var samochod in obslugiwaneSamochody)
            {
                Console.WriteLine($"Samochod: Ladownosc={samochod.Ladownosc}, MaksLadownosc={samochod.MaksLadownosc}");
            }
        }
    }
}
