using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
   public class Punch
    {
        public int Id { get; set; }
        [Display(Name = "№ пуансона")]
        public string Name { get; set; }
        [Display(Name = "Диаметр отвер (мм)")]
        public int DiametrHole { get; set; }
        [Display(Name = "Диаметр пос-ный (мм)")]
        public int DiametrSeat { get; set; }
        [Display(Name = "Диаметр фланца (мм)")]
        public int DiametrFlange { get; set; }
        [Display(Name = "Высота (мм)")]
        public int HeightTottal { get; set; }
        [Display(Name = "Высота пос-ная (мм)")]
        public int HeighSeat { get; set; }
        [Display(Name = "Высота фланца (мм)")]
        public int HeighFlange { get; set; }
        [Display(Name = "Высота пробивная (мм)")]
        public int HeightHole { get; set; }


    }
}
