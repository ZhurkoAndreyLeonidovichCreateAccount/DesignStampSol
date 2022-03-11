using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class CoverView
    {
        public int Id { get; set; }
        [Display(Name = "№ кожуха")]
        public string Name { get; set; }
        [Display(Name = "Высота (мм)")]
        public int TotalHeight { get; set; }
        [Display(Name = "Высота сложенная (мм)")]
        public int PressHeight { get; set; }
        [Display(Name = "Диаметр (мм)")]
        public int Diametr { get; set; }
        [Display(Name = "кол-во кожухов")]
        public int AmountCover { get; set; }

    }
}
