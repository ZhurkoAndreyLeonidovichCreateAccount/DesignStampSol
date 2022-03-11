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
    public class CoverService
    {
        private readonly DataManager _dataManager;
        public CoverService(DataManager dataManager)
        {
            _dataManager = dataManager;

        }

        public CoverView GetCoverView(Cover cover)
        {

            CoverView coverView = new CoverView();
            coverView.Id = cover.Id;
            coverView.Name = cover.Name;
            coverView.Diametr = cover.Diametr;
            coverView.TotalHeight = cover.TotalHeight;
            coverView.PressHeight = cover.PressHeight;
            coverView.AmountCover = BasicConstant.AmountColumnAndBushing;


            return coverView;
        }

        public CoverView GetCoverViewById(int id)
        {

            var cover = _dataManager.Covers.GetCoverById(id);
            CoverView coverView = new CoverView();
            coverView.Id = cover.Id;
            coverView.Name = cover.Name;
            coverView.Diametr = cover.Diametr;
            coverView.TotalHeight = cover.TotalHeight;
            coverView.PressHeight = cover.PressHeight;
            coverView.AmountCover = BasicConstant.AmountColumnAndBushing;

            return coverView;
        }


    }
}
