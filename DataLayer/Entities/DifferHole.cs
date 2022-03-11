using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class DifferHole
    {
        
        public int Id { get; set; }
        [Display(Name = "Количество отверстий"), Range(1, 50, ErrorMessage = "Недопустимое количество отверстий")]
        public int AmountHole { get; set; }
        [Display(Name = "Диаметр (мм)"), Range(5, 51, ErrorMessage = "Недопустимый диаметр")]
        public int Diametr { get; set; }

        // Навигационные свойства

        
        public Detail detail { get; set; }
        public string detailName { get; set; }
    }
}
