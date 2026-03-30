using System;

namespace exam.Models
{
    public class Car
    {
        public int Id_car { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime Release_Year { get; set; }
        public string Gos_number { get; set; }
        public int Id_Client { get; set; }
    }
}
