using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2.Models
{
    public class DzialLogistyki
    {

        public Dostawa Dostawa { get; set; }
        public Magazyn Magazyn { get; set; }

        public void WyslijDoKlienta(Zgloszenie zgloszenie)
        {
            Console.WriteLine($"Sending order ID {zgloszenie.ID} to the customer...");
            Console.WriteLine($"Order ID {zgloszenie.ID} sent to the customer.");
        }
    }
}
