using DataLayer.Entities;
using DesignStamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.CalculationData
{
    public static class AllCalculation
    {
        public static AllForce СalculationForses(StartDetailView detail)
        {
            AllForce force = new AllForce();
            double Lfelling = (detail.Length + detail.Width) * 2;
            double Lpunching=0;
            foreach (var item in detail.DifferHoles)
            {
                var temp = Math.PI * item.Diametr * item.AmountHole;
                Lpunching += temp;
            }
            force.Ppunching = Math.Round(BasicConstant.Kcorrective * Lpunching * detail.Thickness * detail.ShearingStress / 1000/5)*5;
            force.Pfelling = Math.Round( BasicConstant.Kcorrective * Lfelling * detail.Thickness * detail.ShearingStress / 1000/5)*5;
            
            return force;

        }


        public static Matrix СalculationMatrix(AllForce force, StartDetailView detail)
        {
            Matrix matrix = new Matrix();
            var value = Math.Pow((100 * force.Pfelling), (double)1 / 3);
            //return Math.Round(x / m) * m;
            
            
                matrix.Hieght = Math.Round(value / 5) * 5;
                          

            if (force.Pfelling > BasicConstant.BoundaryScrewValuePower)
            {
                matrix.Length = Math.Round((detail.Length + BasicConstant.BodyBetweenDetailAndMatrixM16) / 5.0, MidpointRounding.AwayFromZero)*5;
                matrix.Width = Math.Round((detail.Width + BasicConstant.BodyBetweenDetailAndMatrixM16)/5.0, MidpointRounding.AwayFromZero)*5;
                
            }

            else
            {
                matrix.Length = Math.Round((detail.Length + BasicConstant.BodyBetweenDetailAndMatrixM12) / 5.0, MidpointRounding.AwayFromZero) * 5;
                matrix.Width = Math.Round((detail.Width + BasicConstant.BodyBetweenDetailAndMatrixM12) / 5.0, MidpointRounding.AwayFromZero) * 5;
            }

            return matrix;
        }


        public static Holder СalculationHolder(Matrix matrix)
        {
            Holder holder = new Holder();
            holder.Length = matrix.Length + BasicConstant.BodyBetweenMatrixAndHolder;
            holder.Width = matrix.Width + BasicConstant.BodyBetweenMatrixAndHolder;
            holder.TotalHieght = Math.Round((matrix.Hieght / 3 + BasicConstant.HeightBetweenMatrixAndPlate)/5)*5;
            return holder;

        }

        public static BottomPlate СalculationBottomPlate(Holder holder, ColumnCaclulation column)
        {
            BottomPlate StampPlate = new BottomPlate();
            StampPlate.TotalLength = holder.Length + BasicConstant.BodyBetweenHolderAndPlateLength;
            StampPlate.TotalWidth = holder.Width + BasicConstant.BodyBetweenHolderAndPlateWidth;
            StampPlate.Hieght = column.GetColumnDepth(StampPlate.TotalWidth) + BasicConstant.MinimumPlateBody;
            StampPlate.СastLength = StampPlate.TotalWidth - (StampPlate.SfelfWidth * 2) - 80;
            StampPlate.СastWidth = BasicConstant.CastWidth;
            StampPlate.СastHeight = StampPlate.Hieght - 60;
            StampPlate.SfelfWidth = BasicConstant.ShelfWidth;
            StampPlate.SfelfHeight = BasicConstant.ShelfHeight;
            return StampPlate;

        }

        public static TopPlate СalculationTopPlate(BottomPlate bottomPlate, int closedHeight, double matrixHeight, int punchMatrixHeight , Holder holder)
        {
            TopPlate topPlate = new TopPlate();
            topPlate.TotalLength = bottomPlate.TotalLength;
            topPlate.TotalWidth = bottomPlate.TotalWidth;
            topPlate.Hieght = closedHeight - (bottomPlate.Hieght + punchMatrixHeight + (matrixHeight - 2) + BasicConstant.HeightBetweenMatrixAndPlate);
            topPlate.СastWidth = bottomPlate.СastWidth;
            topPlate.СastLength = bottomPlate.СastLength;
            topPlate.СastHeight = topPlate.Hieght - 60;
            topPlate.SfelfWidth = bottomPlate.SfelfWidth;
            topPlate.SfelfHeight = bottomPlate.SfelfHeight;
            double hieght5 = Math.Round(topPlate.Hieght / 5) * 5;
            double diff = topPlate.Hieght - hieght5;
            holder.TotalHieght += diff;
            holder.BodyHieght += diff+BasicConstant.HeightBetweenMatrixAndPlate;
            topPlate.Hieght = hieght5;
            return topPlate;

        }

        public static PunchMatrix СalculationPunchMatrix(AllForce force, StartDetailView detail)
        {
            PunchMatrix punchMatrix = new PunchMatrix();
            if (force.Pfelling>=BasicConstant.BoundaryScrewValuePower)
            {
                punchMatrix.Length = detail.Length + BasicConstant.BodyBetweenFlangeAndPunchMatrixM16;
                punchMatrix.Width = detail.Width + BasicConstant.BodyBetweenFlangeAndPunchMatrixM16;
                punchMatrix.FlangeHieght = BasicConstant.BodyBetweenFlangeAndPunchMatrixM16;
                punchMatrix.FlangeWidth = BasicConstant.BodyBetweenFlangeAndPunchMatrixM16;
            }

            else
            {
                punchMatrix.Length = detail.Length + BasicConstant.BodyBetweenFlangeAndPunchMatrixM12;
                punchMatrix.Width = detail.Width + BasicConstant.BodyBetweenFlangeAndPunchMatrixM12;
                punchMatrix.FlangeHieght = BasicConstant.BodyBetweenFlangeAndPunchMatrixM12;
                punchMatrix.FlangeWidth = BasicConstant.BodyBetweenFlangeAndPunchMatrixM12;
            }
            punchMatrix.Hieght = punchMatrix.FlangeHieght + BasicConstant.DistanceFromFlangeToPuller + BasicConstant.HeightPuller + detail.Thickness+2;


            return punchMatrix;
        }

        public static Spring СalculationSpring(List<Spring> springs, AllForce allForce, StartDetailView detail)
        {
            
            int Diametr;
            int Stroke;
            double Qremoval = allForce.Pfelling * 0.05;
            if (Qremoval / BasicConstant.Pspring >= BasicConstant.BoundaryAmountSpring)
                Diametr = 55;
            else
                Diametr = 32;

            Stroke = 3 + detail.Thickness;

            var spring = springs.Where(d => d.Diametr == Diametr && d.Tmax > detail.Thickness && d.Stroke > Stroke).OrderBy(i => i.LengthScrew).First();

            return spring;

        }

        public static Puller СalculationPuller( Spring spring, StartDetailView detail, PunchMatrix punch)

        {
            Puller puller = new Puller();
            if (spring.Diametr == 55)
            {
                puller.Length = detail.Length + BasicConstant.BodyPullerD55+punch.FlangeWidth;
                puller.Width = detail.Width + BasicConstant.BodyPullerD55 + punch.FlangeWidth;
            }

            else
            {
                puller.Length = detail.Length + BasicConstant.BodyPullerD32 + punch.FlangeWidth;
                puller.Width = detail.Width + BasicConstant.BodyPullerD32 + punch.FlangeWidth;
            }

            puller.Hieght = BasicConstant.HeightPuller;
            return puller;
        }

        public static Cover СalculationCover(List<Cover> covers,int columnHeight, int columnHeightDepth, BottomPlate bottom, TopPlate top, int pressRamStroke, int closedHeight)
        {
            //double columnHightInTop = (columnHeight - columnHeightDepth) - (closedHeight- bottom.Hieght - top.Hieght);
            double columnHightWithoutDepth = columnHeight - columnHeightDepth;
            double plateHieght = closedHeight-(bottom.Hieght + top.Hieght) + pressRamStroke;
            var cover = covers.Where(d => d.TotalHeight+ columnHightWithoutDepth > plateHieght).OrderBy(d=>d.TotalHeight).FirstOrDefault();
            if (cover == null)
                cover = covers.OrderByDescending(d => d.TotalHeight).FirstOrDefault();

            if(cover.Diametr==140)
            {
                bottom.TotalLength -= BasicConstant.DifferBetweenCovers;
                
                top.TotalLength -= BasicConstant.DifferBetweenCovers;
               

            }
            return cover;
        }

        public static Bushing СalculationBushing(List<Bushing> bushings, int DiametrColumn, double PlateHeight)
        {
            var bushing = bushings.Where(d => d.DepthHeight + BasicConstant.MinimumPlateBody < PlateHeight && d.ColumnDiametr == DiametrColumn).OrderByDescending(i => i.DepthHeight).FirstOrDefault();
            if (bushing == null)
                bushing = bushings.Where(d => d.ColumnDiametr == DiametrColumn).OrderBy(d => d.DepthHeight).FirstOrDefault();

            return bushing;
        }

        public static Column СalculationColumn(List<Column> columns, ColumnCaclulation column, double bottomHeightPlate, double topHeightPlate, int thickness)
        {
            column.Height = (int)((BasicConstant.ClosedHeight - (bottomHeightPlate+ topHeightPlate)) + column.Depth+ thickness+3);
            var columBD = columns.Where(d => d.Diametr == column.Diametr && d.Height > column.Height).OrderBy(i => i.Height).FirstOrDefault();
            if (columBD == null)
                columBD= columns.Where(d => d.Diametr == column.Diametr ).OrderByDescending(i => i.Height).FirstOrDefault();
            return columBD;
        }

        public static List<Punch> СalculationPunch(List<Punch> punches, double hieght, List<DifferHole> differHoles)
        {
            List<Punch> punches1 = new List<Punch>();

            if (differHoles != null)
            {
                foreach (var item in differHoles)
                {
                    if (item.Diametr < 24)
                    {
                        punches1.Add(punches.Where(d => d.DiametrHole == item.Diametr && d.HeightTottal <= hieght + BasicConstant.HeightBetweenMatrixAndPlate).OrderByDescending(i => i.HeightTottal).FirstOrDefault());
                        
                    }

                }
            }
            return punches1;

        }

        public static List<EnlargedPunch> СalculationEnlargedPunch(List<EnlargedPunch> EnlargedPunches, double hieght, List<DifferHole> differHoles)
        {
            List<EnlargedPunch> EnlargedPunches1 = new List<EnlargedPunch>();

            if (differHoles != null)
            {
                foreach (var item in differHoles)
                {
                    if (item.Diametr + BasicConstant.PunchWearAllowance >= 24)
                    {
                        EnlargedPunches1?.Add(EnlargedPunches.Where(d => d.DiametrHoleFirst < item.Diametr + BasicConstant.PunchWearAllowance && d.DiametrHoleLast > item.Diametr + BasicConstant.PunchWearAllowance && d.HeightTottal <= hieght + BasicConstant.HeightBetweenMatrixAndPlate)
                        .OrderByDescending(d => d.HeightTottal).First());

                    }

                }
            }
            
            return EnlargedPunches1;

        }
    }
}

