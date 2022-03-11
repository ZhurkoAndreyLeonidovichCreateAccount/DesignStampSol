using BuissnesLayer;
using DataLayer.Entities;
using DesignStamp.CalculationData;
using DesignStamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Services
{
    public class MatrixService
    {

        readonly private DataManager _dataManager;
        readonly private AllForceService _allForceService;


        public MatrixService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _allForceService = new AllForceService(_dataManager);

        }

        public void SaveMatrixCalcToDb (Matrix matrix, string StampName)
        {
            matrix.StampName = StampName;
            matrix.Name = StampName + "-01";
            _dataManager.Matrices.SaveMatrix(matrix);
        }

        public MatrixView GetMatrixViewByStampName(string stampName)
        {
          
            var matrix = _dataManager.Matrices.GetMatrixByStampName(stampName);
            var force= _allForceService.GetAllForceViewByStampName(stampName);
            var detail = _dataManager.Stamps.GetStampByName(stampName, true).detail;
            MatrixView matrixView = new MatrixView();
            matrixView.Name = matrix.Name;
            matrixView.Length = matrix.Length;
            matrixView.Width = matrix.Width;
            matrixView.Hieght = matrix.Hieght;
            matrixView.StampName = matrix.StampName;
            if (force.Pfelling > BasicConstant.BoundaryScrewValuePower)
                matrixView.MinimAmountScrew = Math.Round(force.Qremoval / BasicConstant.PscrewM16, MidpointRounding.AwayFromZero) + " M16";
            else
                matrixView.MinimAmountScrew = Math.Round(force.Qremoval / BasicConstant.PscrewM12, MidpointRounding.AwayFromZero) + " M12";

            matrixView.Weight = WeightCalculation.GetMatrixWeight(matrix, detail);

            return matrixView;
        }


        public MatrixView GetMatrixViewByName(string name)
        {

            var matrix = _dataManager.Matrices.GetMatrixByName(name);
           var force= _allForceService.GetAllForceViewByStampName(matrix.StampName);
            var detail = _dataManager.Stamps.GetStampByName(matrix.StampName, true).detail;
            MatrixView matrixView = new MatrixView();
            matrixView.Name = matrix.Name;
            matrixView.Length = matrix.Length;
            matrixView.Width = matrix.Width;
            matrixView.Hieght = matrix.Hieght;
            matrixView.StampName=matrix.StampName;
            if (force.Pfelling > BasicConstant.BoundaryScrewValuePower)
                matrixView.MinimAmountScrew = Math.Round(force.Qremoval / BasicConstant.PscrewM16, MidpointRounding.AwayFromZero) + " M16";
            else
                matrixView.MinimAmountScrew = Math.Round(force.Qremoval / BasicConstant.PscrewM12, MidpointRounding.AwayFromZero) + " M12";

            matrixView.Weight = WeightCalculation.GetMatrixWeight(matrix, detail);

            return matrixView;
        }
    }
}
