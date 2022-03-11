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
    public class TopPlatesService
    {
        private readonly DataManager _dataManager;
        public TopPlatesService(DataManager dataManager)
        {
            _dataManager = dataManager;

        }

        public void SaveTopPlateCalcToDb(TopPlate stamp, string StampName)
        {
            stamp.StampName = StampName;
            stamp.Name = StampName + "-06";
            _dataManager.TopPlates.SaveTopPlate(stamp);
        }

        public TopPlateView GetTopPlateViewByStampName(string stampName)
        {
            var column = _dataManager.Stamps.GetStampByName(stampName, true).column;
            var topPlate = _dataManager.TopPlates.GetTopPlateByStampName(stampName);
            TopPlateView topPlateView = new TopPlateView();
            topPlateView.Name = topPlate.Name;
            topPlateView.TotalLength = topPlate.TotalLength;
            topPlateView.TotalWidth = topPlate.TotalWidth;
            topPlateView.СastLength = topPlate.СastLength;
            topPlateView.СastWidth = topPlate.СastWidth;
            topPlateView.СastHeight = topPlate.СastHeight;
            topPlateView.SfelfWidth = topPlate.SfelfWidth;
            topPlateView.SfelfHeight = topPlate.SfelfHeight;
            topPlateView.Hieght = topPlate.Hieght;
            topPlateView.StampName = topPlate.StampName;
            topPlateView.Weight = WeightCalculation.GetTopPlateWeight(topPlate, column.Diametr);
            return topPlateView;
        }
    }
}
