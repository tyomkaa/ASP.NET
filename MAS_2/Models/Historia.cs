using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2.Models
{
    [Serializable]
    public class Historia
    {
        private Klient klient;
        private Zgloszenie zgloszenie;
        private DateTime dataStart { get; set; }
        private DateTime dataEnd { get; set; }
        private static List<Historia> historiaList = new List<Historia>();

        public Historia(Klient klient, Zgloszenie zgloszenie, DateTime dataStart, DateTime dataEnd)
        {
            this.klient = klient;
            this.zgloszenie = zgloszenie;
            this.dataStart = dataStart;
            this.dataEnd = dataEnd;
        }

        public static void AddToHistoria(Historia historia)
        {
            historiaList.Add(historia);
        }

        public static void ShowOrderHistory(List<Klient> klienci)
        {
            Console.WriteLine("\nShowing order history for a client");
            Console.Write("Enter the client's ID: ");
            int clientId = int.Parse(Console.ReadLine());

            Klient klient = klienci.FirstOrDefault(k => k.ID == clientId);
            if (klient == null)
            {
                Console.WriteLine($"Client with ID {clientId} not found.");
                return;
            }

            List<Historia> clientHistory = Historia.historiaList.Where(h => h.klient.ID == klient.ID).ToList();
            if (clientHistory.Count == 0)
            {
                Console.WriteLine($"Client {klient.Imie} has no order history.");
                return;
            }

            Console.WriteLine($"Order history for client {klient.Imie}:");
            foreach (Historia historia in clientHistory)
            {
                Console.WriteLine($"- Order ID: {historia.zgloszenie.ID}, Description: {historia.zgloszenie.MateracLateksowy.Rodzaj}, Start date: {historia.dataStart:d}, End date: {historia.dataEnd:d}");
            }
        }


    }

}
