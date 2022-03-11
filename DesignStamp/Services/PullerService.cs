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
    public class PullerService
    {
        private DataManager _dataManager;

        public PullerService(DataManager dataManager)
        {
            _dataManager = dataManager;

        }

        public void SavePullerCalcToDb(Puller puller, string StampName)
        {
            puller.StampName = StampName;
            puller.Name = StampName + "-04";
            _dataManager.Pullers.SavePuller(puller);
        }

        public PullerView GetPullerViewByStampName(string stampName)
        {
            var puller = _dataManager.Pullers.GetPullerByStampName(stampName);
            var detail = _dataManager.Stamps.GetStampByName(stampName, true).detail;
            PullerView pullerView = new PullerView();
            pullerView.Name = puller.Name;
            pullerView.Length = puller.Length;
            pullerView.Width = puller.Width;
            pullerView.Hieght = puller.Hieght;
            pullerView.StampName = puller.StampName;
            pullerView.Weight= WeightCalculation.GetPullerWeight(puller, detail);
            return pullerView;
        }
    }
}
