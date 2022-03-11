using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Detail
    {
       [Key]
        [Display(Name = "№ детали")]
        public string Name { get; set; }
        [Display(Name = "Длина (мм)")]
        public int Length { get; set; }
        [Display(Name = "Ширина (мм)")]
        public int Width { get; set; }
        [Display(Name = "Толщина (мм)")]
        public int Thickness { get; set; }
        public List<DifferHole> differHoles { get; set; }
        [Display(Name = "Напряжение среза (МПа)")]
        public int ShearingStress { get; set; }
        //public int TearResistance { get; set; }
        public int AmountDiametrHoles { get; set; }


        
    }
}

