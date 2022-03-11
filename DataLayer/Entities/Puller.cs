using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
   public class Puller
    {

        [Key]
        [Display(Name = "№ съемника")]
        public string Name { get; set; }
        [Display(Name = "Длина (мм)")]
        public int Length { get; set; }
        [Display(Name = "Ширина (мм)")]
        public int Width { get; set; }
        [Display(Name = "Высота (мм)")]
        public double Hieght { get; set; }

        // Навигационные свойства

        public Stamp stamp { get; set; }
        public string StampName { get; set; }
    }
}
