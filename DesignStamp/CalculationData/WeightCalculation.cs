using DataLayer.Entities;
using DesignStamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.CalculationData
{
    public static class WeightCalculation
    {
        public static double GetMatrixWeight(Matrix matrix,Detail detail)
        {
           
            double TotalValume = matrix.Length * matrix.Width * matrix.Hieght;
            double EmptyValume = detail.Length * detail.Width * matrix.Hieght;
            double RealVolume = TotalValume - EmptyValume;
            return  Math.Round(RealVolume * BasicConstant.MetalDensity / 1000000000, MidpointRounding.AwayFromZero);
        }

        public static double GetPunchMatrixWeight(PunchMatrix punchMatrix, Detail detail)
        {
            double ValumeWithoutFlange = detail.Length * detail.Width * (punchMatrix.Hieght - punchMatrix.FlangeHieght);
            double ValumeFlange = punchMatrix.Length * punchMatrix.Hieght * punchMatrix.FlangeHieght;
            double TotalValume = ValumeWithoutFlange + ValumeFlange;
            return Math.Round(TotalValume * BasicConstant.MetalDensity / 1000000000, MidpointRounding.AwayFromZero);
        }

        public static double GetBushingWeight(Bushing bushing)
        {
            double volumePress = Math.PI * bushing.PressedDiametr * bushing.PressedDiametr / 4 * bushing.DepthHeight;
            double volumeFlange = Math.PI * bushing.FlangeDiametr * bushing.FlangeDiametr / 4 * (bushing.TotalHeight - bushing.DepthHeight);
            double emptyVolume = Math.PI * bushing.ColumnDiametr * bushing.ColumnDiametr / 4 * bushing.TotalHeight;
            double totalVolume = volumePress + volumeFlange - emptyVolume;
            return Math.Round(totalVolume * BasicConstant.MetalDensity / 1000000000, MidpointRounding.AwayFromZero);
        }

        public static double GetColumnWeight(Column column)
        {
            var volume =Math.PI* column.Diametr* column.Diametr / 4 * column.Height;
            return Math.Round(volume * BasicConstant.MetalDensity / 1000000000, MidpointRounding.AwayFromZero);
        }

        public static double GetBottomPlateWeight(BottomPlate bottomPlate,int columnDepth,int diametr)
        {
            double volumeTotal = (bottomPlate.TotalLength -bottomPlate.СastWidth*2) * (bottomPlate.TotalWidth-2*bottomPlate.SfelfWidth) * bottomPlate.Hieght;
            double volumeColumn = Math.PI * diametr * diametr / 4 * columnDepth * BasicConstant.AmountColumnAndBushing;
            double volumeCast = bottomPlate.СastLength * bottomPlate.СastWidth * bottomPlate.СastHeight;
            double volume = volumeTotal+ volumeCast - volumeColumn;
            return Math.Round(volume * BasicConstant.MetalDensity / 1000000000, MidpointRounding.AwayFromZero);
        }

        public static double GetTopPlateWeight(TopPlate topPlate, int diametr)
        {
            double volumeTotal = (topPlate.TotalLength-topPlate.СastWidth*2) * (topPlate.TotalWidth-2*topPlate.SfelfWidth) * topPlate.Hieght;
            double volumeColumn = Math.PI * diametr * diametr / 4 * topPlate.Hieght * BasicConstant.AmountColumnAndBushing;
            double volumeCast = topPlate.СastLength * topPlate.СastWidth * topPlate.СastHeight;
            double volume = volumeTotal+volumeCast - volumeColumn;
            return Math.Round(volume * BasicConstant.MetalDensity / 1000000000, MidpointRounding.AwayFromZero);
        }


        public static double GetPullerWeight(Puller puller, Detail detail)
        {
            double TotalVolume = puller.Length * puller.Width * puller.Hieght;
            double EmptyVolume = detail.Length * detail.Width * puller.Hieght;
            double RealVolume = TotalVolume - EmptyVolume;
            return Math.Round(RealVolume * BasicConstant.MetalDensity / 1000000000, MidpointRounding.AwayFromZero);
        }

        public static double GetHolderWeight(Holder holder, Matrix matrix)
        {
            double TotalVolume = holder.Length * holder.Width * holder.TotalHieght;
            double EmptyVolume = matrix.Length * matrix.Width * (holder.TotalHieght - holder.BodyHieght);
            double RealVolume = TotalVolume - EmptyVolume;
            return Math.Round(RealVolume * BasicConstant.MetalDensity / 1000000000, MidpointRounding.AwayFromZero);
        }


    }
}
