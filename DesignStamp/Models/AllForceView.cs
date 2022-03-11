using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class AllForceView
    {

        public int Id { get; set; }

        [Display(Name = "Общее усилие (Кн)")]
        public double Ptotal { get; set; }
        [Display(Name = "Усилие вырубки (Кн)")]
        public double Pfelling { get; set; }
        [Display(Name = "Усилие пробивки (Кн)")]
        public double Ppunching { get; set; }
        [Display(Name = "Усилие снятия (Кн)")]
        public double Qremoval { get; set; }
        [Display(Name = "Усилие пресса (Кн)")]
        public double Ppress { get; set; }
        [Display(Name = "Имя штампа")]
        public string StampName{ get; set; }

    }
}
