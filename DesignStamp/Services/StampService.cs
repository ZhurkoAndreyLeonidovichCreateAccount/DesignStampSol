using BuissnesLayer;
using DataLayer.Entities;
using DesignStamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Services
{
    public class StampService
    {
        private readonly DataManager _dataManager;
        private readonly AllForceService _allForceService;
        private readonly MatrixService _servicesMatrix;
        private readonly PunchMatrixService _servicesPunchMatrix;
        private readonly HolderService _servicesHolder;
        private readonly PullerService _servicesPuller;
        private readonly BottomPlatesService _bottomPlatesService;
        private readonly TopPlatesService _topPlatesService;
        private readonly ColumnService _columnService;
        private readonly BushingService _bushingService;
        private readonly PressService _pressService;


       private readonly SpringService _springService;
        private readonly CoverService _coverService;
        private readonly PunchService _punchService;
        private readonly EnlargedPunchService _enlargedPunchService;





        public StampService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesMatrix = new MatrixService(_dataManager);
            _servicesPunchMatrix = new PunchMatrixService(_dataManager);
            _servicesHolder = new HolderService(_dataManager);
            _servicesPuller = new PullerService(_dataManager);
            _bottomPlatesService = new BottomPlatesService(_dataManager);
            _topPlatesService = new TopPlatesService(_dataManager);
            _columnService = new ColumnService(_dataManager);
            _bushingService = new BushingService(_dataManager);
            _springService = new SpringService(_dataManager);
            _coverService = new CoverService(_dataManager);
            _punchService = new PunchService(_dataManager);
            _enlargedPunchService = new EnlargedPunchService(_dataManager);
            _allForceService = new AllForceService(_dataManager);
            _pressService = new PressService(_dataManager);
        }

     

        public void SaveStampCalcToDb(string stampName, int ClosedHight, string detailName, Spring spring, Bushing bushing, Column column, List<Punch> punches, List<EnlargedPunch> enlargtdPunches,Cover cover,int pressId)
        {
            Stamp stamp = new Stamp();
            stamp.Name = stampName;
            stamp.ClosedHeight = ClosedHight;
            stamp.detailName = detailName;
            stamp.SpringId = spring.Id;
            stamp.BushingId = bushing.Id;
            stamp.ColumnId = column.Id;
            stamp.CoverId = cover.Id;
            stamp.PressId = pressId;
            List<PunchesID> punchesID = new List<PunchesID>(); ;
            List<EnlargedPunchesID> enlargedPunchesID = new List<EnlargedPunchesID>();
            if (punches.Count!=0&&punches[0]!=null)
            {

                foreach (var item in punches)
                {
                    punchesID.Add(new PunchesID { PunchID = item.Id, StampName = stampName });
                }

            }

            if (enlargtdPunches.Count!=0&&enlargtdPunches[0]!=null)
            {
                foreach (var item in enlargtdPunches)
                {
                    enlargedPunchesID.Add(new EnlargedPunchesID { EnlargedPunchID = item.Id, StampName = stampName });
                }

            }

            if (punchesID != null)
                stamp.PunchesId = punchesID;

            if (enlargedPunchesID != null)
                stamp.EnlargedPunchesId = enlargedPunchesID;

            _dataManager.Stamps.SaveStamp(stamp);


        }

      

        public StampView GetViewStampByName(string stampName)
        {
            var stamp = _dataManager.Stamps.GetStampByName(stampName, true);
            StampView stampView = new StampView();
            stampView.Name = stamp.Name;
            stampView.NameDetail = stamp.detailName;
            stampView.ClosedHeight = stamp.ClosedHeight;
            stampView.AllForce = _allForceService.GetAllForceViewByStampName(stamp.Name);
            stampView.Matrix = _servicesMatrix.GetMatrixViewByStampName(stampName);
            stampView.PunchMatrix=_servicesPunchMatrix.GetPunchMatrixViewByStampName(stampName);
            stampView.Holder=_servicesHolder.GetHolderViewByStampName(stampName);
            stampView.Puller = _servicesPuller.GetPullerViewByStampName(stampName);
            stampView.BottomPlate=_bottomPlatesService.GetBottomPlateViewByStampName(stampName);
            stampView.TopPlate = _topPlatesService.GetTopPlateViewByStampName(stampName);
            stampView.Column = _columnService.GetColumnViewById(stamp.ColumnId);
            stampView.Cover = _coverService.GetCoverView(stamp.cover);
            stampView.Bushing = _bushingService.GetBushingViewById(stamp.BushingId);
            stampView.Spring = _springService.GetSpringViewById(stamp.SpringId, stampView.AllForce.Qremoval);
            stampView.Weight = stampView.Matrix.Weight + stampView.PunchMatrix.Weight + stampView.Holder.Weight + stampView.Puller.Weight + stampView.BottomPlate.Weight + stampView.TopPlate.Weight + stampView.Column.Weight + stampView.Bushing.Weight;
            if (stamp.PunchesId.Count != 0) 
            stampView.Punches = _punchService.GetPunchesViewById(stamp.PunchesId, stamp.detail.differHoles);
            if (stamp.EnlargedPunchesId.Count != 0)
                stampView.EnlargedPunches = _enlargedPunchService.GetEnlargedPunchesViewById(stamp.EnlargedPunchesId, stamp.detail.differHoles);
            stampView.Press = _pressService.GetPressViewById(stamp.PressId, stampName);
            return stampView;
        }

        public void SaveStampColumnToDb(int id, int oldId)
        {
            var stamp = _dataManager.Stamps.GetStampByColumnId(oldId);
            stamp.ColumnId = id;
            _dataManager.Stamps.SaveStamp(stamp);
        }

        public void SaveStampBushingToDb(int id, int oldId)
        {
            var stamp = _dataManager.Stamps.GetStampByBushingId(oldId);
            stamp.BushingId = id;
            _dataManager.Stamps.SaveStamp(stamp);
        }

        public void SaveStampCoverToDb(int id, int oldId)
        {
            var stamp = _dataManager.Stamps.GetStampByCoverId(oldId);
            stamp.CoverId = id;
            _dataManager.Stamps.SaveStamp(stamp);
        }

        public void SaveStampSpringToDb(int id, int oldId)
        {
            var stamp=_dataManager.Stamps.GetStampBySpringId(oldId);
            stamp.SpringId = id;
            _dataManager.Stamps.SaveStamp(stamp);
        }

        public void SaveStampPunchToDb(int id, int oldId)
        {
            var punch = _dataManager.PunchesID.GetPunchIDById(oldId);
            punch.PunchID = id;
            _dataManager.PunchesID.SavePunchesID(punch);

        }

        public void SaveStampEnlargedPunchToDb(int id, int oldId)
        {
            var enlargedPunch = _dataManager.EnlargedPunchesID.GetEnlargedPunchIDById(oldId);
            enlargedPunch.EnlargedPunchID = id;
            _dataManager.EnlargedPunchesID.SaveEnlargedPunchesID(enlargedPunch);

        }

        public void SaveStampPressToDb(int id, int oldId)
        {
            var stamp = _dataManager.Stamps.GetStampByPressId(oldId);
            stamp.PressId = id;
            _dataManager.Stamps.SaveStamp(stamp);
        }

    }
}
