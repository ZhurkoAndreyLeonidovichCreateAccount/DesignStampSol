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
    public class HolderService
    {
        private readonly DataManager _dataManager;
        private readonly MatrixService _matrixService;

        public HolderService(DataManager dataManager)
        {
            _dataManager = dataManager;

        }

        public void SaveHolderCalcToDb(Holder holder, string StampName)
        {
            holder.StampName = StampName;
            holder.Name = StampName + "-02";
            _dataManager.Holders.SaveHolder(holder);
        }

        public HolderView GetHolderViewByStampName(string stampName)
        {
            var holder = _dataManager.Holders.GetHolderByStampName(stampName);
            var matrix = _dataManager.Matrices.GetMatrixByStampName(stampName);
            HolderView holderView = new HolderView();
            holderView.Name = holder.Name;
            holderView.Length = holder.Length;
            holderView.Width = holder.Width;
            holderView.TotalHieght = holder.TotalHieght;
            holderView.BodyHieght = holder.BodyHieght;
            holderView.StampName = holder.StampName;
            holderView.Weight= WeightCalculation.GetHolderWeight(holder, matrix);
            return holderView;
        }


        //public HolderView GetHolderViewByName(string name)
        //{
        //    var holder = _dataManager.Holders.GetHolderByStampName(name);
        //    var matrix = _matrixService.GetMatrixViewByStampName(holder.StampName);
        //    HolderView holderView = new HolderView();
        //    holderView.Name = holder.Name;
        //    holderView.Length = holder.Length;
        //    holderView.Width = holder.Width;
        //    holderView.TotalHieght = holder.TotalHieght;
        //    holderView.BodyHieght = holder.BodyHieght;
        //    holderView.Weight = WeightCalculation.GetHolderWeight(holder, matrix);
        //    return holderView;

        //}
    }
}
