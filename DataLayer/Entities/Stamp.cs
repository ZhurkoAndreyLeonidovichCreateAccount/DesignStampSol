using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
      public class Stamp
      {
        [Key]
        [Display(Name = "№ штампа")]
        public string Name { get; set; }
        [Display(Name = "закрытая высота")]
        public int ClosedHeight { get; set; }
      


        public List<PunchesID> PunchesId { get; set; }
        public List<EnlargedPunchesID> EnlargedPunchesId { get; set; }



        // Навигационные свойства

        public Detail detail { get; set; }
        [Display(Name = "№ детали")]
        public string detailName { get; set; }

        public Bushing bushing { get; set; }
        public int BushingId { get; set; }

        public Column column { get; set; }
        public int ColumnId { get; set; }

        public Spring spring { get; set; }
        public int SpringId { get; set; }

        public Cover cover { get; set; }
        public int CoverId { get; set; }

        public Press press { get; set; }
        public int PressId { get; set; }

    }
}
