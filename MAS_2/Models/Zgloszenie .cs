using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MAS_2.Models
{
    [Serializable]
    public class Zgloszenie
    {
        private List<Historia> historiaList;
        private Klient klient;
        private static List<Zgloszenie> extent = new List<Zgloszenie>();

        public int ID { get; set; }
        public Klient Klient { get; set; }
        public MateracLateksowy MateracLateksowy { get; set; }
        public DateTime DataZainicjalizowania { get; set; }
        public DateTime DataZrealizowania { get; set; }
        public string Status { get; set; } 

        public static Dictionary<MateracLateksowy, Zgloszenie> mapaMateracy = new Dictionary<MateracLateksowy, Zgloszenie>();

        public Zgloszenie()
        {
            
        }

        public Zgloszenie(int id, Klient klient, MateracLateksowy materac, DateTime dataZainicjalizowania, DateTime dataZrealizowania)
        {
            ID = id;
            Klient = klient;
            MateracLateksowy = materac;
            DataZainicjalizowania = dataZainicjalizowania;
            DataZrealizowania = dataZrealizowania;
            Status = "w trakcie przetwarzania"; 
            extent.Add(this);
            if (!mapaMateracy.ContainsKey(materac))
            {
                mapaMateracy.Add(materac, this);
            }
        }

       
        public void ChangeStatus(string newStatus)
        {
            Status = newStatus;
        }

        
        public string GetStatus()
        {
            return Status;
        }

        

        public override string ToString()
        {
            return $"ID: {ID}, Client: {Klient.Imie}, Mattress: {MateracLateksowy.Rodzaj}, Order Date: {DataZainicjalizowania.ToShortDateString()}, Delivery Date: {DataZrealizowania.ToShortDateString()}, Status: {Status}";
        }

        public static void ShowOrders(List<Zgloszenie> extent)
        {
            Console.WriteLine("\nShowing all orders");

            foreach (var item in extent)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
