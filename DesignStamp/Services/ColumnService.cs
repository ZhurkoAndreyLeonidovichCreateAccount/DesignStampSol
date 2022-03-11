using BuissnesLayer;
using DesignStamp.CalculationData;
using DesignStamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Services
{
    public class ColumnService
    {
        private readonly DataManager _dataManager;
        public ColumnService(DataManager dataManager)
        {
            _dataManager = dataManager;

        }

        public ColumnView GetColumnViewById(int id)
        {
            var column = _dataManager.Columns.GetColumnById(id);
            ColumnView columnView = new ColumnView();
            columnView.Id = column.Id;
            columnView.Name = column.Name;
            columnView.Diametr = column.Diametr;
            columnView.HeightDepth = column.HeightDepth;
            columnView.Height = column.Height;
            columnView.Weight= WeightCalculation.GetColumnWeight(column);
            columnView.AmountColumn = BasicConstant.AmountColumnAndBushing;

           
            return columnView;
        }

        //public ColumnView GetAllColumnsView()
        //{
        //    var columns = _dataManager.Columns.GetAllColumn();
        //    ColumnView columnView = new ColumnView();
        //    columnView.Name = column.Name;
        //    columnView.Diametr = column.Diametr;
        //    columnView.HeightDepth = column.HeightDepth;
        //    columnView.Height = column.Height;
        //    columnView.Weight = WeightCalculation.GetColumnWeight(column);
        //    columnView.AmountColumn = BasicConstant.AmountColumnAndBushing;


        //    return columnView;
        //}
    }
}
