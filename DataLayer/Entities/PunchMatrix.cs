using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
   public class PunchMatrix
    {


        [Key]
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


        // Навигационные свойства

        public Stamp stamp { get; set; }
        public string StampName { get; set; }
    }
}
