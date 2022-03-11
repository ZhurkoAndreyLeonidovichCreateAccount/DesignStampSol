using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
   public class Matrix
    {

        [Key]
        [Display(Name = "№ матрицы")]
        public string Name { get; set; }
        [Display(Name = "Длина (мм)")]
        public double Length { get; set; }
        [Display(Name = "Ширина (мм)")]
        public double Width { get; set; }
        [Display(Name = "Высота(мм)")]
        public double Hieght { get; set; }
        [Display(Name = "Масса (кг)")]

        // Навигационные свойства

        public Stamp stamp { get; set; }
        public string StampName  { get; set; }
    }
}
