using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class StampView
    {
        [Display(Name = "№ штампа")]
        public string Name { get; set; }
        [Display(Name = "№ детали")]
        public string NameDetail { get; set; }
        [Display(Name = "Закрытая высота")]
        public int ClosedHeight { get; set; }
        [Display(Name = "Масса")]
        public double Weight { get; set; }
        public AllForceView AllForce { get; set; }
        public HolderView Holder { get; set; }
        public MatrixView Matrix { get; set; }
        public PullerView Puller { get; set; }
        public PunchMatrixView PunchMatrix { get; set; }
        public SpringView Spring { get; set; }
        public BottomPlateView BottomPlate { get; set; }
        public TopPlateView TopPlate { get; set; }
        public BushingView Bushing { get; set; }
        public ColumnView Column { get; set; }
        public CoverView Cover { get; set; }
        public List<PunchView> Punches { get; set; }
        public List<EnlargedPunchView> EnlargedPunches { get; set; }
        public PressView Press { get; set; }
        


    }
}
