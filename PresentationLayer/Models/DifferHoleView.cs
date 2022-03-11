using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class DifferHoleView
    {
        [Display(Name = "№")]
        public int Id { get; set; }
        [Display(Name = "Количество отверстий")]
        public int AmountHole { get; set; }
        [Display(Name = "Диаметр (мм)")]
        public int Diametr { get; set; }
    }
}
