using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using studio_sat.Util;
using studio_sat.Models;
using Newtonsoft.Json;

namespace studio_sat.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        [Route("Home/Index")]
        public IActionResult IndexOne()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var data = DataController.Instance.LVMasterList;
            return View(data);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
