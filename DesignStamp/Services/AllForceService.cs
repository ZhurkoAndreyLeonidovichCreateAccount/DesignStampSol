using BuissnesLayer;
using DataLayer.Entities;
using DesignStamp.CalculationData;
using DesignStamp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignStamp.Services
{
   public class AllForceService
    {
        private DataManager _dataManager;
        


        public AllForceService(DataManager dataManager)
        {
            _dataManager = dataManager;
            
        }

        public void SaveForсeDataToDb(AllForce allForce, string stampName)
        {
           

            allForce.StampName = stampName;
           
            _dataManager.AllForces.SaveAllForce(allForce);
        }

        public AllForceView GetAllForceViewByStampName(string stampName)
        {
           var allForce = _dataManager.AllForces.GetAllForceByStampName(stampName);
            AllForceView allForceView = new AllForceView();
            allForceView.Pfelling = allForce.Pfelling;
            allForceView.Ppunching = allForce.Ppunching;
            allForceView.Ptotal = allForce.Ppunching + allForce.Pfelling;
            allForceView.Qremoval= allForce.Pfelling * 0.05;
            allForceView.Ppress = Math.Round(allForceView.Ptotal + allForceView.Ptotal * 0.25);
            allForceView.StampName = allForce.StampName;
            return allForceView;
        }
    }
}
