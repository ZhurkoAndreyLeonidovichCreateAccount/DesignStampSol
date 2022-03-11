using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class HolderView
    {
        [Display(Name = "№ державки")]
        public string Name { get; set; }
        [Display(Name = "Длина (мм)")]
        public double Length { get; set; }
        [Display(Name = "Ширина(мм)")]
        public double Width { get; set; }
        [Display(Name = "Высота (мм)")]
        public double TotalHieght { get; set; }
        [Display(Name = "Толщина верха (мм)")]
        public double BodyHieght { get; set; }
        [Display(Name = "Масса (кг)")]
        public double Weight { get; set; }
        public string StampName { get; set; }


    }
}
