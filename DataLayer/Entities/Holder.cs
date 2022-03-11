using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
   public class Holder
    {
       [Key]
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


        // Навигационные свойства
        public Stamp stamp { get; set; }
        public string StampName { get; set; }
    }
}
