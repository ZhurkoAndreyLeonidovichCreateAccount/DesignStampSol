using BuissnesLayer;
using PresentationLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
   public class ServicesManager
    {
        DataManager _dataManager;
        private DetailSevice _detailService;
        private DifferHoleService _differHoleService;

        public ServicesManager(DataManager dataManager)          
        {
            _dataManager = dataManager;

            _detailService = new DetailSevice(_dataManager);
        }
        public DetailSevice Details { get { return _detailService; } }
        public DifferHoleService DifferHoles { get { return _differHoleService; } }

    }
}
