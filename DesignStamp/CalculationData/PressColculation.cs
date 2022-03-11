using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.CalculationData
{
    public static class PressColculation
    {
        public static bool ComparisonForce(double Pcalc, double Ppress)
        {
            if (Ppress > Pcalc)
                return true;
            else
                return false;

        }

        public static bool ComparisonPerimatr(int lengthAdapt, int widthAdapt, double totalLength, double totalWidth)
        {
            if ((lengthAdapt + widthAdapt) > totalLength + totalWidth)
                return true;
            else
                return false;
        }
    }
}
