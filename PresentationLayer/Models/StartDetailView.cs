using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
   public class StartDetailView
    {
        //    [Display(Name = "Имя детали"), RegularExpression(@"\d*-\d*", ErrorMessage = "Некорректное имя")]
        //    [Required(ErrorMessage = "Не указано имя детали")]
        public string Name { get; set; }

        //[Display(Name = "Длина (мм)"), Range(100, 500, ErrorMessage = "Недопустимая длинна")]
        //[Required(ErrorMessage = "Не указана длина")]
        public int Length { get; set; }

        //[Display(Name = "Щирина (мм)"), Range(100, 500, ErrorMessage = "Недопустимая ширина")]
        //[Required(ErrorMessage = "Не указана ширина")]
        public int Width { get; set; }

        //[Display(Name = "Толщина (мм)"), Range(1, 10, ErrorMessage = "Недопустимая толщина")]
        //[Required(ErrorMessage = "Не указана толщина")]
        public int Thickness { get; set; }

        public List<DifferHole> differHoles { get; set; }

        //[Required]
        //[Display(Name = "Напряжение при срезе (Мпа)")]
        public int ShearingStress { get; set; }
        //public int TearResistance { get; set; }
        //[Display(Name = "Количество различных диаметров отверстий")]
        public int AmountDiametrHoles { get; set; }

        //[Display(Name = "Имя штампа"), RegularExpression(@"\d{4}-\d*", ErrorMessage = "Некорректное имя штампа")]
        //[Required(ErrorMessage = "Не указано имя штампа")]
        public string StampName { get; set; }
    }
}
