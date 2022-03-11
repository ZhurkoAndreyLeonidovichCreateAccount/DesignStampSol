using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.CalculationData
{
    public class ColumnCaclulation
    {
        public int Diametr { get; set; }
        public int Height { get; set; }
        //глубина вхождения в плиту
        public int Depth { get; set; }




        public int GetColumnDepth(double width)
        {
            if (width >= 800)
            {
                Diametr = 71;
                Depth = 110;
            }
                
            else 
            {
                Diametr = 63;
                Depth = 90;
            }
            return Depth;
        }
    }

   

}

