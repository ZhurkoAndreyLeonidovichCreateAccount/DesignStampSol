using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesignStamp.Models
{
   public class StartDetailView
    {
        [Display(Name = "№ детали"), RegularExpression(@"\d*-\d*", ErrorMessage = "Некорректное имя")]
        [Required(ErrorMessage = "Не указано имя детали")]
        [Remote(action: "CheckDetail", controller: "Details", ErrorMessage = "№ детали уже используется")]
        public string Name { get; set; }

        [Display(Name = "Длина (мм)"), Range(150, 600, ErrorMessage = "Недопустимая длинна")]
        [Required(ErrorMessage = "Не указана длина")]
        public int Length { get; set; }

        [Display(Name = "Щирина (мм)"), Range(150, 600, ErrorMessage = "Недопустимая ширина")]
        [Required(ErrorMessage = "Не указана ширина")]
        public int Width { get; set; }

        [Display(Name = "Толщина (мм)"), Range(1, 10, ErrorMessage = "Недопустимая толщина")]
        [Required(ErrorMessage = "Не указана толщина")]
        public int Thickness { get; set; }

        public List<DifferHole> DifferHoles { get; set; }

        [Required(ErrorMessage = "Не указано сопративление при срезе")]
        [Display(Name = "Напряжение при срезе (Мпа)")]
        public int ShearingStress { get; set; }
        public int TearResistance { get; set; }

        [Required(ErrorMessage = "Не указано количество различных диаметров")]
        [Display(Name = "Количество различных диаметров (мм)"), Range(0, 50, ErrorMessage = "Недопустимое количество отверстий")] 
        public int AmountDiametrHoles { get; set; }

        [Display(Name = "№ штампа"), RegularExpression(@"\d{4}-\d*", ErrorMessage = "Некорректное имя штампа")]
        [Required(ErrorMessage = "Не указано имя штампа")]
        [Remote(action: "CheckStamp", controller: "Stamps", ErrorMessage = "№ штампа уже используется")]
        public string StampName { get; set; }

        [Display(Name = "Закрытая высота штампа"), Range(470, 520, ErrorMessage = "Недопустимая закрытая высота")]
        [Required(ErrorMessage = "Не указан № штампа")]
        public int ClosedHeight { get; set; }

        [Range(1, 100, ErrorMessage = "Выберите пресс")]
        public int IdPress  { get; set; }


    }
}
