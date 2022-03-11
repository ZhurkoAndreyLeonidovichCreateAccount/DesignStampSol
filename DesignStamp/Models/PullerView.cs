using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class PullerView
    {
        [Display(Name = "№ съемника")]
        public string Name { get; set; }
        [Display(Name = "Длина (мм)")]
        public int Length { get; set; }
        [Display(Name = "Ширина (мм)")]
        public int Width { get; set; }
        [Display(Name = "Высота (мм)")]
        public double Hieght { get; set; }
        [Display(Name = "Масса(мм)")]
        public double Weight { get; set; }
        public string StampName { get; set; }
    }
}
