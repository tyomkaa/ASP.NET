using System;
using System.Collections.Generic;

namespace MAS_2.Models
{
    public enum MateracType
    {
        Memory,
        Siedmiostrefowy,
        Jednostrefowy
    }

    [Serializable]
    public class MateracLateksowy
    {
        public static List<MateracLateksowy> extent = new List<MateracLateksowy>();
        public static float VAT = 0.23f;

        public int ID { get; set; }
        public string Rodzaj { get; set; }
        public string Cecha { get; set; }
        public float Wysokosc { get; set; }
        public string Sztywnosc { get; set; }
        public string Przeznaczenie { get; set; }
        public float Cena { get; set; }
        public float Brutto { get { return Cena * (1 + VAT); } }
        public MateracType Type { get; set; }

        public MateracLateksowy()
        {
        }

        private MateracLateksowy(int iD, string rodzaj, string cecha, float wysokosc, string sztywnosc, string przeznaczenie, float cena, MateracType type)
        {
            ID = iD;
            Rodzaj = rodzaj;
            Cecha = cecha;
            Wysokosc = wysokosc;
            Sztywnosc = sztywnosc;
            Przeznaczenie = przeznaczenie;
            Cena = cena;
            Type = type;

            extent.Add(this);
        }

        public override string ToString()
        {
            return $"ID: {ID}, Type: {Rodzaj}, Feature: {Cecha}, Height: {Wysokosc} cm, Firmness: {Sztywnosc}, Purpose: {Przeznaczenie}, Price (net): {Cena} PLN, Price (gross): {Brutto} PLN";
        }

        public static void ShowMaterace(List<MateracLateksowy> extent)
        {
            Console.WriteLine("\nShowing all mattresses");

            foreach (var item in extent)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static MateracLateksowy CreateNewMattress(List<MateracLateksowy> materace)
        {
            Console.WriteLine("Creating a new mattress");
            Console.Write("Enter the mattress ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter the mattress type (Memory/Siedmiostrefowy/Jednostrefowy): ");
            string typeInput = Console.ReadLine();
            if (!Enum.TryParse(typeInput, true, out MateracType type))
            {
                throw new Exception("Invalid mattress type.");
            }

            Console.Write("Enter the mattress feature: ");
            string cecha = Console.ReadLine();
            Console.Write("Enter the mattress height (in cm): ");
            float wysokosc = float.Parse(Console.ReadLine());
            Console.Write("Enter the mattress firmness: ");
            string sztywnosc = Console.ReadLine();
            Console.Write("Enter the mattress purpose: ");
            string przeznaczenie = Console.ReadLine();
            Console.Write("Enter the mattress price: ");
            float cena = float.Parse(Console.ReadLine());

            Console.WriteLine("Mattress created");

            MateracLateksowy newMattress = new MateracLateksowy(id, "latex", cecha, wysokosc, sztywnosc, przeznaczenie, cena, type);
            materace.Add(newMattress);

            ShowMaterace(materace);

            return newMattress;
        }

        public static MateracLateksowy CreateNewMattress(List<MateracLateksowy> materace, float cena)
        {
            int id = extent.Count > 0 ? extent.Max(x => x.ID) + 1 : 1;
            string cecha = "standard";
            float wysokosc = 20;
            string sztywnosc = "medium";
            string przeznaczenie = "bed";

            MateracLateksowy newMattress = new MateracLateksowy(id, "latex", cecha, wysokosc, sztywnosc, przeznaczenie, cena, MateracType.Memory);
            materace.Add(newMattress);

            ShowMaterace(materace);

            return newMattress;
        }
    }
}
