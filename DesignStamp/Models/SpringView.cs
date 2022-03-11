using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class SpringView
    {
        public int Id { get; set; }
        [Display(Name = "№ пружины")]
        public string Name { get; set; }
        [Display(Name = "Усилие (Кн)")]
        public double Pspring { get; set; }
        [Display(Name = "Диаметр (мм)")]
        public int Diametr { get; set; }
        [Display(Name = "Мин толщина (мм)")]
        public int Tmin { get; set; }
        [Display(Name = "Макс толщина (мм)")]
        public int Tmax { get; set; }
        [Display(Name = "Ход (мм)")]
        public int Stroke { get; set; }
        [Display(Name = "Длина винта (мм)")]
        public int LengthScrew { get; set; }
        [Display(Name = "Мин кол-во пружин")]
        public double MinAmountSpring { get; set; }


    }
}
