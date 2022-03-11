using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class ColumnView
    {
        public int Id { get; set; }
        [Display(Name = "№ втулки")]
        public string Name { get; set; }
        [Display(Name = "Диаметр (мм)")]
        public int Diametr { get; set; }
        [Display(Name = "Высота (мм)")]
        public int Height { get; set; }
        [Display(Name = "Глубина внедрения (мм)")]
        public int HeightDepth { get; set; }
        [Display(Name = "Масса (кн)")]
        public double Weight { get; set; }
        [Display(Name = "Кол-во колонок")]
        public int AmountColumn { get; set; }
    }
}
