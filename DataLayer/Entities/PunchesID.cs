using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
  public  class PunchesID
    {
        public int ID { get; set; }
        //public int AmountPunch { get; set; }

        public Stamp stamp { get; set; }
        public string StampName { get; set; }
        public Punch punch { get; set; }
        public int PunchID { get; set; }
    }
}
