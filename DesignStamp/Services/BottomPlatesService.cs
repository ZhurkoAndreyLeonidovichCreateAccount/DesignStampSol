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
    public class BottomPlatesService
    {
        private readonly DataManager _dataManager;
        public BottomPlatesService(DataManager dataManager)
        {
            _dataManager = dataManager;

        }

        public void SaveBottomPlateCalcToDb(BottomPlate stamp, string StampName)
        {
            stamp.StampName = StampName;
            stamp.Name = StampName + "-05";
            
            _dataManager.BottomPlates.SaveBottomPlate(stamp);
        }

        public BottomPlateView GetBottomPlateViewByStampName(string stampName)
        {
            var stampPlate=_dataManager.BottomPlates.GetBottomPlateByStampName(stampName);
            var column = _dataManager.Stamps.GetStampByName(stampName,true).column;
     
            BottomPlateView bottomPlateView = new BottomPlateView();
            bottomPlateView.Name = stampPlate.Name;
            bottomPlateView.TotalLength = stampPlate.TotalLength;
            bottomPlateView.TotalWidth = stampPlate.TotalWidth;
            bottomPlateView.Hieght = stampPlate.Hieght;
            bottomPlateView.SfelfWidth = stampPlate.SfelfWidth;
            bottomPlateView.SfelfHeight = stampPlate.SfelfHeight;
            bottomPlateView.СastLength = stampPlate.СastLength;
            bottomPlateView.СastWidth = stampPlate.СastWidth;
            bottomPlateView.СastHeight = stampPlate.СastHeight;
            bottomPlateView.StampName = stampPlate.StampName;
            bottomPlateView.Weight= WeightCalculation.GetBottomPlateWeight(stampPlate, column.HeightDepth, column.Diametr);
            return bottomPlateView;
        }
    }
}
