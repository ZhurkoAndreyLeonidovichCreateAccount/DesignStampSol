using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class PressView
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
        public bool Pflag { get; set; }
        public bool PerimetrFlag { get; set; }
    }
}
