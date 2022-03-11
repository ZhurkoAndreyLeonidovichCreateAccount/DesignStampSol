using BuissnesLayer;
using DesignStamp.CalculationData;
using DesignStamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Services
{
    public class PressService
    {
        private readonly DataManager _dataManager;
      
        private readonly AllForceService _allForceService;
       

       public PressService(DataManager dataManager)
        {
            _dataManager = dataManager;

            _allForceService = new AllForceService(dataManager);
          

        }

        public PressView GetPressViewById(int id, string stampName)
        {
            var press = _dataManager.Presses.GetPressById(id);
            var allForceView = _allForceService.GetAllForceViewByStampName(stampName);
            var topPlateView = _dataManager.TopPlates.GetTopPlateByStampName(stampName);
           
            PressView pressView = new PressView();
            pressView.Id = press.Id;
            pressView.Name = press.Name;
            pressView.Ppress = press.Ppress;
            pressView.PressRamStroke = press.PressRamStroke;
            pressView.LengthAdapt = press.LengthAdapt;
            pressView.WidthAdapt = press.WidthAdapt;
            pressView.Pflag = PressColculation.ComparisonForce(allForceView.Ppress, press.Ppress);
            pressView.PerimetrFlag = PressColculation.ComparisonPerimatr(press.LengthAdapt, press.WidthAdapt, topPlateView.TotalLength, topPlateView.TotalWidth);

            return pressView;
        }
    }
}
