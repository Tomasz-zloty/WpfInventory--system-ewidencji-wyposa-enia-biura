using System;

namespace WpfInventory
{
    public class Przedmiot
    {
      
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);
        public string Nazwa { get; set; }
        public string Kategoria { get; set; }
        public int Ilosc { get; set; }
        public string Status { get; set; }
    }
}