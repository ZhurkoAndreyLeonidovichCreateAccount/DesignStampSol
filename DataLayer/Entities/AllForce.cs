using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
   public class AllForce
    {
        public int Id { get; set; }

        public double Pfelling { get; set; }

        public double Ppunching { get; set; }

        // Навигационные свойства
        public Stamp stamp { get; set; }
        public string StampName { get; set; }
    }
}

   
