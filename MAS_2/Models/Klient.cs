using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2.Models
{
    [Serializable]
    public class Klient : DaneOsobowe
    {
        private List<Historia> historiaList;

        private List<Zgloszenie> zgloszenia = new List<Zgloszenie>(); //Zwykła
        private static List<Klient> extent = new List<Klient>();
        
        public string Email { get; set; }
        [Column("NumerTelefonu")]
        public string? NumerTelefonu { get; set; }

        public Klient() : base(0, "", "")
        {
        }


        public Klient(int iD, string imie, string nazwisko, string email, string numerTelefonu = "") : base(iD, imie, nazwisko)
        {
            Email = email;
            NumerTelefonu = string.IsNullOrEmpty(numerTelefonu) ? null : numerTelefonu;
            extent.Add(this);
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Imie}, Surname: {Nazwisko} Email: {Email}, Phone Number: {NumerTelefonu ?? "N/A"}";
        }

        public static void ShowKlienci(List<Klient> extent)
        {
            Console.WriteLine("\nShowing all clients");

            foreach (var item in extent)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void CreateNewClient(List<Klient> klienci)
        {
            Console.WriteLine("\nCreating a new client");
            Console.Write("Enter the client's ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter the client's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter the client's last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter the client's email address: ");
            string email = Console.ReadLine();
            Console.Write("Enter the client's phone number (optional): ");
            string phoneNumber = Console.ReadLine();

            Klient klient = string.IsNullOrEmpty(phoneNumber)
                ? new Klient(id, firstName, lastName, email)
                : new Klient(id, firstName, lastName, email, phoneNumber);

            klienci.Add(klient);

            Console.WriteLine("Client created successfully");
        }

        public static void DeleteClient(List<Klient> klienci, List<Zgloszenie> zgloszenia, int clientId)
        {
            Klient klient = klienci.FirstOrDefault(k => k.ID == clientId);
            if (klient == null)
            {
                Console.WriteLine($"Client with ID {clientId} not found.");
                return;
            }

            Console.Write($"Are you sure you want to delete client {klient.Imie}? This will also delete all their orders (y/n): ");
            string answer = Console.ReadLine().ToLower();
            if (answer != "y")
            {
                Console.WriteLine("Deletion canceled.");
                return;
            }

            List<Zgloszenie> klientZgloszenia = zgloszenia.Where(z => z.Klient.ID == klient.ID).ToList();
            if (klientZgloszenia.Count > 0)
            {
                Console.WriteLine($"Client {klient.Imie} has the following active orders:");
                foreach (Zgloszenie zgloszenie in klientZgloszenia)
                {
                    Console.WriteLine($"- Order ID: {zgloszenie.ID}, Description: {zgloszenie.MateracLateksowy.Rodzaj}");
                }
                Console.Write("Are you sure you want to delete client and their orders (y/n): ");
                answer = Console.ReadLine().ToLower();
                if (answer != "y")
                {
                    Console.WriteLine("Deletion canceled.");
                    return;
                }
                zgloszenia.RemoveAll(z => z.Klient.ID == klient.ID);
            }

            klienci.Remove(klient);
            Console.WriteLine($"Client {klient.Imie} deleted.");
        }

    }
}
