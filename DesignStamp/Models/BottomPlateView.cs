using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class BottomPlateView
    {
        [Display(Name = "№ плиты")]
        public string Name { get; set; }
        [Display(Name = "Длина (мм)")]
        public double TotalLength { get; set; }
        [Display(Name = "Длина отлива (мм)")]
        public double СastLength { get; set; }
        [Display(Name = "Ширина отлива (мм)")]
        public double СastWidth { get; set; }
        [Display(Name = "Высота отлива (мм)")]
        public double СastHeight { get; set; }
        [Display(Name = "Ширина (мм)")]
        public double TotalWidth { get; set; }
        [Display(Name = "Ширина полки (мм)")]
        public double SfelfWidth { get; set; }
        [Display(Name = "Высота полки (мм)")]
        public double SfelfHeight { get; set; }
        [Display(Name = "Высота (мм)")]
        public double Hieght { get; set; }
        [Display(Name = "Масса (кг)")]
        public double Weight { get; set; }

        public string StampName { get; set; }
    }
}
