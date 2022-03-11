using BuissnesLayer;
using DataLayer.Entities;
using DesignStamp.CalculationData;
using DesignStamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Controllers
{
    public class HomeController : Controller
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;
        public HomeController(DataManager dataManager)
        {

            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(_datamanager);
        }

        public IActionResult Index()
        {
            return View();
        }



    }
}
