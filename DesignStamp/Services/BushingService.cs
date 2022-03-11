using BuissnesLayer;
using DesignStamp.CalculationData;
using DesignStamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Services
{
    public class BushingService
    {
        private readonly DataManager _dataManager;
        public BushingService(DataManager dataManager)
        {
            _dataManager = dataManager;

        }

        public BushingView GetBushingViewById(int id)
        {
            var bushing = _dataManager.Bushings.GetBushingById(id);
            BushingView bushingView = new BushingView();
            bushingView.Id = bushing.Id;
            bushingView.Name = bushing.Name;
            bushingView.PressedDiametr = bushing.PressedDiametr;
            bushingView.ColumnDiametr = bushing.ColumnDiametr;
            bushingView.TotalHeight = bushing.TotalHeight;
            bushingView.DepthHeight = bushing.DepthHeight;
            bushingView.ColumnDiametr = bushing.ColumnDiametr;
            bushingView.FlangeDiametr = bushing.FlangeDiametr;
            bushingView.AmountBushing = BasicConstant.AmountColumnAndBushing;
            bushingView.Weight= WeightCalculation.GetBushingWeight(bushing);

            return bushingView;
        }
    }
}
