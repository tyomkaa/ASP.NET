using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2.Models
{
    [Serializable]
    public class Ksiegowosc
    {
        public bool CzyIstniejePlatnosc { get; set; }

        public Magazyn Magazyn { get; set; }
        public DzialSprzedazy DzialSprzedazy { get; set; }

        public void WyslijFakture()
        {
            Console.WriteLine("Sending an invoice");
            Console.Write("Does the payment exist? (yes/no): ");
            string paymentExist = Console.ReadLine().ToLower();

            if (paymentExist == "yes")
            {
                CzyIstniejePlatnosc = true;
                Console.WriteLine("Invoice sent successfully");
            }
            else if (paymentExist == "no")
            {
                CzyIstniejePlatnosc = false;
                Console.WriteLine("Invoice sent with a reminder to make the payment");
            }
            else
            {
                Console.WriteLine("Invalid input. Invoice not sent.");
            }
        }
    }
}
