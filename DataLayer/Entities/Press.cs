using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
   public class Press
    {
        public int Id { get; set; }
        [Display(Name = "№ пресса")]
        public string Name { get; set; }
        [Display(Name = "Усилие (Кн)")]
        public int Ppress { get; set; }
        [Display(Name = "Ход (мм)")]
        public int PressRamStroke { get; set; }
        [Display(Name = "Длина адаптера (мм)")]
        public int LengthAdapt { get; set; }
        [Display(Name = "Ширина адаптера (мм)")]
        public int WidthAdapt { get; set; }
    }
}
