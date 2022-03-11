using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
   public class EnlargedPunch
    {
        public int Id { get; set; }
        [Display(Name = "№ пуансона")]
        public string Name { get; set; }
        [Display(Name = "Мин диаметр (мм)")]
        public int DiametrHoleFirst { get; set; }
        [Display(Name = "Макс диаметр (мм)")]
        public int DiametrHoleLast { get; set; }
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

    }
}
