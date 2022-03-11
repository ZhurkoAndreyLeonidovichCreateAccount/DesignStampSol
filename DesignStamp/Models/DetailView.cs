using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Models
{
    public class DetailView
    {

        [Display(Name = "№ детали")]
        public string Name { get; set; }
        [Display(Name = "№ штампа")]
        public string StampName { get; set; }

    }
}
