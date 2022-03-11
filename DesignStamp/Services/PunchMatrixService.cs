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
    public class PunchMatrixService
    {

        private DataManager _dataManager;



        public PunchMatrixService(DataManager dataManager)
        {
            _dataManager = dataManager;

        }

        public void SavePunchMatrixCalcToDb(PunchMatrix punchMatrix, string StampName)
        {
            punchMatrix.StampName = StampName;
            punchMatrix.Name = StampName + "-03";
            _dataManager.PunchMatrices.SavePunchMatrix(punchMatrix);
        }

        public PunchMatrixView GetPunchMatrixViewByStampName(string stampName)
        {
            var punchMatrix = _dataManager.PunchMatrices.GetPunchMatrixByStampName(stampName);
            var detail = _dataManager.Stamps.GetStampByName(stampName, true).detail;
            PunchMatrixView punchMatrixView = new PunchMatrixView();
            punchMatrixView.Name = punchMatrix.Name;
            punchMatrixView.Length = punchMatrix.Length;
            punchMatrixView.Width = punchMatrix.Width;
            punchMatrixView.Hieght = punchMatrix.Hieght;
            punchMatrixView.FlangeHieght = punchMatrix.FlangeHieght;
            punchMatrixView.FlangeWidth = punchMatrix.FlangeWidth;
            punchMatrixView.StampName = punchMatrix.StampName;
            punchMatrixView.Weight = WeightCalculation.GetPunchMatrixWeight(punchMatrix,detail);
            return punchMatrixView;
        }
    }
}
