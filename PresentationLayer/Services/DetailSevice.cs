using BuissnesLayer;
using DataLayer.Entities;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
    public class DetailSevice
    {
        private DataManager _dataManager;
        private DifferHoleService _differHoleService;


        public DetailSevice(DataManager dataManager)
        {
            _dataManager = dataManager;
            _differHoleService = new DifferHoleService(dataManager);
        }

        public void SaveDetailStartViewToDb(StartDetailView startDetail, List<DifferHole> differHoles = null)
        {
            Detail detail = new Detail();
            detail.Name = startDetail.Name;
            detail.Length = startDetail.Length;
            detail.Width = startDetail.Width;
            detail.Thickness = startDetail.Thickness;
            detail.ShearingStress = startDetail.ShearingStress;

            detail.AmountDiametrHoles = startDetail.AmountDiametrHoles;

            //if (differHoles != null)
            //    detail.differHoles = _differHoleService.ListDifferHoleViewtoDB(differHoles);


            _dataManager.Details.SaveDetail(detail);
        }

        public StartDetailView GetDetailStartViewFromDb(Detail detail, string Name = null)
        {
            //_dataManager.Details.GetDetailByName(detail)
            StartDetailView detailView = new StartDetailView
            {
                Name = detail.Name,
                Length = detail.Length,
                Width = detail.Width,
                Thickness = detail.Thickness,
                ShearingStress = detail.ShearingStress,
                differHoles = detail.differHoles

            };
            if (Name != null)
            { detailView.StampName = Name; }
            return detailView;
        }
    }
}

        
