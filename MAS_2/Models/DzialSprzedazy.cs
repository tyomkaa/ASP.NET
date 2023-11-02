using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2.Models
{
    [Serializable]
    public class DzialSprzedazy
    {
        public string NazwaProduktu { get; set; }
        public int Ilosc { get; set; }
        public string Zleceniodawca { get; set; }
        public string Adres { get; set; }
        public string NumerTelefonu { get; set; }
        public decimal CenaSprzedazy { get; set; }

        public Zgloszenie Zgloszenie { get; set; }
        public Ksiegowosc Ksiegowosc { get; set; }

        public void FormujZgloszenie()
        {
            Console.WriteLine("Forming a new notification");
            Console.Write("Enter the product name: ");
            NazwaProduktu = Console.ReadLine();
            Console.Write("Enter the quantity: ");
            Ilosc = int.Parse(Console.ReadLine());
            Console.Write("Enter the customer's name: ");
            Zleceniodawca = Console.ReadLine();
            Console.Write("Enter the address: ");
            Adres = Console.ReadLine();
            Console.Write("Enter the phone number: ");
            NumerTelefonu = Console.ReadLine();
            Console.Write("Enter the selling price: ");
            CenaSprzedazy = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Notification formed successfully");
        }
    }
}
