using BuissnesLayer;
using DataLayer.Entities;
using DesignStamp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignStamp.Services
{
    public class DetailSevice
    {
        private readonly DataManager _dataManager;
        


        public DetailSevice(DataManager dataManager)
        {
            _dataManager = dataManager;
            
        }

        public void SaveDetailStartViewToDb(StartDetailView startDetail, List<DifferHole> differHoles = null)
        {
            Detail detail = new Detail();
            detail.Name = startDetail.Name;
            detail.Length = startDetail.Length;
            detail.Width = startDetail.Width;
            detail.Thickness = startDetail.Thickness;
            detail.ShearingStress = startDetail.ShearingStress;
            detail.differHoles = startDetail.DifferHoles;
            detail.AmountDiametrHoles = startDetail.AmountDiametrHoles;

            //if (DifferHoles != null)
            //    detail.DifferHoles = _differHoleService.ListDifferHoleViewtoDB(DifferHoles);


            _dataManager.Details.SaveDetail(detail);
        }

        public StartDetailView GetDetailStartViewFromDb(Detail detail, string Name = null)
        {
            //_dataManager.DetailsView.GetDetailByName(detail)
            StartDetailView detailView = new StartDetailView
            {
                Name = detail.Name,
                Length = detail.Length,
                Width = detail.Width,
                Thickness = detail.Thickness,
                ShearingStress = detail.ShearingStress,
                DifferHoles = detail.differHoles

            };
            if (Name != null)
            { detailView.StampName = Name; }
            return detailView;
        }
    }
}

        
