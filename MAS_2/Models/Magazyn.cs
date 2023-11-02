using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2.Models
{
    public class Magazyn
    {
        private List<Zgloszenie> zgloszenia;

        public Magazyn()
        {
            zgloszenia = new List<Zgloszenie>();
        }

        public void UtworzZamowienie(List<Zgloszenie> zgloszenia, List<Klient> klienci, List<MateracLateksowy> materace, Klient klient = null, MateracLateksowy materac = null)
        {
            Console.WriteLine("Create a new order:");
            Console.WriteLine("Enter the ID of the order:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose a client from the following list by entering their ID or create a new client by entering 'n':");
            Klient.ShowKlienci(klienci);
            string input = Console.ReadLine();

            if (input == "n")
            {
                Klient.CreateNewClient(klienci);
                klient = klienci[^1];
            }
            else
            {
                int clientId = int.Parse(input);
                klient = klienci.Find(k => k.ID == clientId);
            }

            Console.WriteLine("Choose a mattress from the following list by entering its ID:");
            MateracLateksowy.ShowMaterace(materace);
            int mattressId = int.Parse(Console.ReadLine());
            materac = materace.Find(m => m.ID == mattressId);

            Console.Write("Enter the date of initialization in the format (dd/mm/yyyy):");
            DateTime dataZainicjalizowania = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter the delivery date (dd/mm/yyyy): ");
            DateTime dataZrealizowania = DateTime.Parse(Console.ReadLine());

            Zgloszenie zgloszenie = new Zgloszenie(id, klient, materac, dataZainicjalizowania, dataZrealizowania);
            zgloszenia.Add(zgloszenie);
            Historia.AddToHistoria(new Historia(klient, zgloszenie, dataZainicjalizowania, dataZrealizowania));
            Console.WriteLine($"Order with ID {id} created for {klient.Imie}.");
        }

        public void PrzygotujDokumenty(Zgloszenie zgloszenie)
        {
            Console.WriteLine($"Preparing documents for order ID {zgloszenie.ID}...");
            // Логика подготовки документов
            Console.WriteLine("Documents prepared.");
        }

    }
}
