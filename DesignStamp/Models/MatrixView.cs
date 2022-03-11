using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class MatrixView
    {
        [Display(Name = "№ матрицы")]
        public string Name { get; set; }
        [Display(Name = "Длина (мм)")]
        public double Length { get; set; }
        [Display(Name = "Ширина (мм)")]
        public double Width { get; set; }
        [Display(Name = "Высота(мм)")]
        public double Hieght { get; set; }
        [Display(Name = "Масса (кг)")]
        public double Weight { get; set; }
        [Display(Name = "Мин кол-во винтов")]
        public string MinimAmountScrew { get; set; }
        public string StampName { get; set; }
       

    }
}
