using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
  public  class EnlargedPunchesID
    {
        public int ID { get; set; }

        // Навигационные свойства
        public Stamp stamp { get; set; }
        public string StampName { get; set; }

        public EnlargedPunch enlargedPunch { get; set; }
        public int EnlargedPunchID { get; set; }
    }
}
