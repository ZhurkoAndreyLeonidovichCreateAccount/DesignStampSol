using BuissnesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
   public class AllForceService
    {
        private DataManager _dataManager;
        


        public AllForceService(DataManager dataManager)
        {
            _dataManager = dataManager;
            
        }

        public void SaveForсeDataToDb(ForсeData startDetail)
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
    }
}
