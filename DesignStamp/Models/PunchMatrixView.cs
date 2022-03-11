using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class PunchMatrixView
    {
        [Display(Name = "№ пуансон-матрицы")]
        public string Name { get; set; }
        [Display(Name = "Длина (мм)")]
        public int Length { get; set; }
        [Display(Name = "Ширина (мм)")]
        public int Width { get; set; }
        [Display(Name = "Высота (мм)")]
        public int Hieght { get; set; }
        [Display(Name = "Высота фланца (мм)")]
        public int FlangeHieght { get; set; }
        [Display(Name = "Ширина фланца (мм)")]
        public int FlangeWidth { get; set; }
        [Display(Name = "Масса (кг)")]
        public double Weight { get; set; }
        public string StampName { get; set; }
    }
}
