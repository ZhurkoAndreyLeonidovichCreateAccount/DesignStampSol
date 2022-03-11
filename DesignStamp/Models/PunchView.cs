using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class PunchView
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
        [Display(Name = "Кол-во пуансонов")]
        public int AmountPunch { get; set; }


    }
}
