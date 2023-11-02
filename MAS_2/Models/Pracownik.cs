using System;
using System.Collections.Generic;

namespace MAS_2.Models
{
    [Flags]
    public enum PracownikType
    {
        None = 0,
        Kierowca = 1,
        Ochroniarz = 1,
        SalesManager = 2,
        Buchalter = 3,
        Magazynier = 4,
        Logistyk = 5,
    }

    [Serializable]
    public class Pracownik : DaneOsobowe, IOchroniarz
    {

        public DateTime DataZatrudnienia { get; set; }
        public string Adres { get; set; }
        public static decimal Stawka { get; set; }
        private int doswiadczenieZawodowe;

        public int DoswiadczenieZawodowe //ograniczenie atrybutu
        {
            get => doswiadczenieZawodowe;
            set
            {
                if (value >= 2)
                    doswiadczenieZawodowe = value;
                else
                    throw new ArgumentException("Work experience must be at least 2 years.");
            }
        }

        public PracownikType TypyPracownika { get; set; }
        public bool PrzepracowaneDopCzas { get; set; }
        public static List<Pracownik> extent = new List<Pracownik>();

        protected Pracownik(int iD, string imie, string nazwisko, DateTime dataZatrudnienia, string adres, int doswiadczenieZawodowe, PracownikType typyPracownika) : base(iD, imie, nazwisko)
        {
            DataZatrudnienia = dataZatrudnienia;
            Adres = adres;
            DoswiadczenieZawodowe = doswiadczenieZawodowe;
            TypyPracownika = typyPracownika;
            extent.Add(this);
        }

        public decimal ObliczWyplate()
        {
            decimal wyplata = Stawka * (DoswiadczenieZawodowe + 1);
            return wyplata;
        }

        public decimal ObliczWyplateZaDopCzas()
        {
            if (TypyPracownika.HasFlag(PracownikType.Ochroniarz) && PrzepracowaneDopCzas)
            {
                decimal wyplata = ObliczWyplate() + (Stawka * 1.5m); 
                return wyplata;
            }
            else
            {
                return ObliczWyplate();
            }
        }
    }
}