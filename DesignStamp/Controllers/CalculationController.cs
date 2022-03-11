using BuissnesLayer;
using DataLayer.Entities;
using DesignStamp.CalculationData;
using DesignStamp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Controllers
{
    [Authorize]
    public class CalculationController : Controller
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;
        public CalculationController(DataManager dataManager)
        {

            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(_datamanager);
        }

        public IActionResult Index(int flag)
        {
            var presses = _datamanager.Presses.GetAllPress();
            Press press = new Press();
            press.Id = 0;
            press.Name = "Выберите пресс";
            presses[0] = press;
            ViewData["Lst"] = new SelectList(presses, "Id", "Name");

            if (flag == 1)
            {
                var detailView = JsonConvert.DeserializeObject<StartDetailView>(HttpContext.Session.GetString("detail"));
                return View(detailView);
            }


            else
                return View();

        }

        public IActionResult DifferHoles(StartDetailView detailView, int flag)
        {
            //if(_datamanager.DetailsView.GetDetailByName(detailView.Name)!=null)
            //    return RedirectToAction(nameof(ChooseColumn));
            if(flag==0)
            HttpContext.Session.SetString("detail", JsonConvert.SerializeObject(detailView));
            else
            {
               detailView = JsonConvert.DeserializeObject<StartDetailView>(HttpContext.Session.GetString("detail"));
            }
               
            if (detailView.AmountDiametrHoles == 0)
                return RedirectToAction(nameof(AllDataView));

            ViewData["Amount"] = detailView.AmountDiametrHoles;
            if(flag==1)
            {
                return View(detailView.DifferHoles);
            }
            return View();
        }


        public IActionResult AllDataView(List<DifferHole> holeData)
        {

            var detailView = JsonConvert.DeserializeObject<StartDetailView>(HttpContext.Session.GetString("detail"));
            detailView.DifferHoles = holeData;
           
            HttpContext.Session.SetString("detail", JsonConvert.SerializeObject(detailView));




            return View(detailView);
        }


        public IActionResult StartCalculation()
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ///получение и сохранение детали
            var detail = JsonConvert.DeserializeObject<StartDetailView>(HttpContext.Session.GetString("detail"));
            _servicesmanager.Details.SaveDetailStartViewToDb(detail);

            //////////////////////////////////////////////////////////////////////////////////////////////////
            ///Расчитать все усилия
            var forсe = AllCalculation.СalculationForses(detail);

            /////////////////////////////////////////////////////////////////////////////////////////////////
            ///Расчет матрицы
            var matrix = AllCalculation.СalculationMatrix(forсe, detail);

            /////////////////////////////////////////////////////////////////////////////////////////////////
            ///Расчет державки
            var holder = AllCalculation.СalculationHolder(matrix);
            /////////////////////////////////////////////////////////////////////////////////////////////////////
   
            ///Расчет пуансон-матрицы          
            var punchMatrix = AllCalculation.СalculationPunchMatrix(forсe, detail);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            
            ///Расчет нижней плиты
            ColumnCaclulation column = new ColumnCaclulation();
            var bottomPlate = AllCalculation.СalculationBottomPlate(holder, column);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            ///Расчет верхней плиты           
            var topPlate = AllCalculation.СalculationTopPlate(bottomPlate,detail.ClosedHeight, matrix.Hieght, punchMatrix.Hieght, holder);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            ///Рачет пружины
            var springs = _datamanager.Springs.GetAllSpring();
            var spring = AllCalculation.СalculationSpring(springs, forсe, detail);
            ////////////////////////////////////////////////////////////////////////////
            ///Расчет съемника           
            var puller = AllCalculation.СalculationPuller(spring, detail, punchMatrix);

            //////////////////////////////////////////////////////////////////////////
            ///Расчет Втулки
            var bushings = _datamanager.Bushings.GetAllBushing();
            var bushing = AllCalculation.СalculationBushing(bushings, column.Diametr, topPlate.Hieght);

            //////////////////////////////////////////////////////////////////////////////
            ///Расчет колонки
            var columns = _datamanager.Columns.GetAllColumn();
            var columnDb = AllCalculation.СalculationColumn(columns, column, bottomPlate.Hieght, topPlate.Hieght,detail.Thickness);

            /////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Расчет кожуха
            var press = _datamanager.Presses.GetPressById(detail.IdPress);
            var covers = _datamanager.Covers.GetAllCover();
            var cover = AllCalculation.СalculationCover(covers,columnDb.Height, columnDb.HeightDepth, bottomPlate, topPlate, press.PressRamStroke, detail.ClosedHeight);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            List<Punch> punches = new List<Punch>();
            List<EnlargedPunch> EnlargtdPunches = new List<EnlargedPunch>();
            if (detail.DifferHoles != null)
            {
                ///Расчет пуансонов
                var punchesList = _datamanager.Punches.GetAllPunch();
                punches = AllCalculation.СalculationPunch(punchesList, matrix.Hieght, detail.DifferHoles);
                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///Расчет увеличенных пуансонов
                var EnlargedPunchesList = _datamanager.EnlargedPunches.GetAllEnlargedPunch();
                EnlargtdPunches = AllCalculation.СalculationEnlargedPunch(EnlargedPunchesList, matrix.Hieght, detail.DifferHoles);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Сохранение штампа
            _servicesmanager.Stamps.SaveStampCalcToDb(detail.StampName, detail.ClosedHeight, detail.Name,  spring, bushing, columnDb, punches, EnlargtdPunches, cover, detail.IdPress);
            _servicesmanager.AllForces.SaveForсeDataToDb(forсe, detail.StampName);
            _servicesmanager.Matrices.SaveMatrixCalcToDb(matrix, detail.StampName);
            _servicesmanager.Holders.SaveHolderCalcToDb(holder, detail.StampName);
            _servicesmanager.BottomPlates.SaveBottomPlateCalcToDb(bottomPlate, detail.StampName);
            _servicesmanager.TopPlates.SaveTopPlateCalcToDb(topPlate, detail.StampName);
            _servicesmanager.PunchMatrices.SavePunchMatrixCalcToDb(punchMatrix, detail.StampName);
            _servicesmanager.Pullers.SavePullerCalcToDb(puller, detail.StampName);
            

            return View(detail);

        }

    }
}
