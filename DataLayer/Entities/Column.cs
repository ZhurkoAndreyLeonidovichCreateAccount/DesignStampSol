using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
   public class Column
    {
        public int Id { get; set; }
            
        [Display(Name = "№ колонки")]
        public string Name { get; set; }
        [Display(Name = "Диаметр (мм)"), Range(25, 100, ErrorMessage = "Недопустимый диаметр")]
        public int Diametr { get; set; }
        [Display(Name = "Высота (мм)"), Range(120, 560, ErrorMessage = "Недопустимая высота")]
        public int Height { get; set; }
        [Display(Name = "Глубина внедрения (мм)"), Range(36, 160, ErrorMessage = "Недопустимая глубина")]
        public int HeightDepth { get; set; }
        



    }
}
