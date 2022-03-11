using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
   public class Bushing
   {
        public int Id { get; set; }
        [Display(Name = "№ втулки")]
        public string Name { get; set; }
        [Display(Name = "Диаметр внедрения (мм)")]
        public int PressedDiametr { get; set; }
        [Display(Name = "Диаметр фланца  (мм)")]
        public int FlangeDiametr { get; set; }
        [Display(Name = "Диаметр колонки  (мм)")]
        public int ColumnDiametr { get; set; }
        [Display(Name = "Высота  (мм)")]
        public int TotalHeight { get; set; }
        [Display(Name = "Высота внедрения (мм)")]
        public int DepthHeight { get; set; }

    }
}
