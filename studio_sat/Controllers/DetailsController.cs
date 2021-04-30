using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using Microsoft.Extensions.Logging;
using studio_sat.Util;
using studio_sat.Models;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace studio_sat.Controllers
{
    public class DetailsController : Controller
    {
        private List<LaunchVehicle> list = DataController.Instance.LVMasterList;
        private LaunchVehicle lvobj;

        public LaunchVehicle FindLaunchVehicle(string flv)
        {
            return list.Find(x => x.LVName == flv);
        }

        // GET: /<controller>/
        public IActionResult Index(string lvname)
        {
            var lvobj = FindLaunchVehicle(lvname);
            return View(lvobj);
        }

        [Route("Details/IndexOne")]
        public IActionResult IndexOne(string name)
        {
            return RedirectToAction("Index", new { lvname = name });
        }

        [Route("Details/Launch")]
        public IActionResult Launch(string name)
        {
            //remove this code and modify the master list in data controller and just send the name to index method.
            lvobj = FindLaunchVehicle(name);
            lvobj.LaunchButtonEnabled = false;
            lvobj.LVDeployPayloadEnabled = true;
            lvobj.LVOrbitStatus = OrbitStatus.INORBIT;
            lvobj.LVTMStartStatus = TelemetryStatus.ENABLED;
            lvobj.LVTMStopStatus = TelemetryStatus.ENABLED;
            lvobj.PayLoad.PLDataStartStatus = DataStatus.DISABLED;
            lvobj.PayLoad.PLDataStopStatus = DataStatus.DISABLED;
            lvobj.PayLoad.PLCommissionedStatus = CommissionedStatus.UNKNOWN;
            lvobj.PayLoad.PLTMStartStatus = TelemetryStatus.DISABLED;
            lvobj.PayLoad.PLTMStopStatus = TelemetryStatus.DISABLED;
            lvobj.LVStatusMessage = "I AM IN ORBIT";
            //remove this code and modify the master list in data controller and just send the name to index method.
            return RedirectToAction("Index", new { lvname = name });
        }
        public IActionResult DeployPayload(string name)
        {
            lvobj = FindLaunchVehicle(name);
            lvobj.LaunchButtonEnabled = false;
            lvobj.LVDeployPayloadEnabled = false;
            lvobj.LVOrbitStatus = OrbitStatus.INORBIT;
            lvobj.LVTMStartStatus = TelemetryStatus.ENABLED;
            lvobj.LVTMStopStatus = TelemetryStatus.ENABLED;
            lvobj.PayLoad.PLDataStartStatus = DataStatus.ENABLED;
            lvobj.PayLoad.PLDataStopStatus = DataStatus.ENABLED;
            lvobj.PayLoad.PLCommissionedStatus = CommissionedStatus.COMMISSIONED;
            lvobj.PayLoad.PLTMStartStatus = TelemetryStatus.ENABLED;
            lvobj.PayLoad.PLTMStopStatus = TelemetryStatus.ENABLED;
            lvobj.LVStatusMessage = "I AM IN ORBIT";
            lvobj.PayLoad.PLStatusMessage = "DEPLOYED";
            return RedirectToAction("Index", new { lvname = name });
        }
        public IActionResult Deorbit(string name)
        {
            lvobj = FindLaunchVehicle(name);
            lvobj.LaunchButtonEnabled = false;
            lvobj.LVDeployPayloadEnabled = false;
            lvobj.LVOrbitStatus = OrbitStatus.DEORBITTED;
            lvobj.LVTMStartStatus = TelemetryStatus.DISABLED;
            lvobj.LVTMStopStatus = TelemetryStatus.DISABLED;
            //lvobj.PayLoad.PLDataStartStatus = DataStatus.ENABLED;
            //lvobj.PayLoad.PLDataStopStatus = DataStatus.DISABLED;
            //lvobj.PayLoad.PLCommissionedStatus = CommissionedStatus.COMMISSIONED;
            ////lvobj.PayLoad.PLTMStartStatus = TelemetryStatus.ENABLED;
            //lvobj.PayLoad.PLTMStopStatus = TelemetryStatus.DISABLED;
            lvobj.LVStatusMessage = "DEORBITTED";
            //lvobj.PayLoad.PLStatusMessage = "DEPLOYED";
            return RedirectToAction("Index", new { lvname = name });
        }
        public IActionResult LaunchVehicleStartTelemetry(string name)
        {
            lvobj = FindLaunchVehicle(name);
            lvobj.LVTMStartStatus = TelemetryStatus.ENABLED;
            lvobj.LVTMStopStatus = TelemetryStatus.ENABLED;
            return RedirectToAction("Index", new { lvname = name });
        }
        public IActionResult LaunchVehicleStopTemetry(string name)
        {
            lvobj = FindLaunchVehicle(name);
            lvobj.LVTMStartStatus = TelemetryStatus.ENABLED;
            lvobj.LVTMStopStatus = TelemetryStatus.ENABLED;
            return RedirectToAction("Index", new { lvname = name });
        }
        public IActionResult PayloadStartTelemetry(string name)
        {
            lvobj = FindLaunchVehicle(name);
            lvobj.PayLoad.PLTMStartStatus = TelemetryStatus.ENABLED;
            lvobj.PayLoad.PLTMStopStatus = TelemetryStatus.ENABLED;
            return RedirectToAction("Index", new { lvname = name });
        }

        [Route("Details/PayloadStopTelemetry")]
        public IActionResult PayloadStopTelemetry(string name)
        {
            lvobj = FindLaunchVehicle(name);
            lvobj.PayLoad.PLTMStartStatus = TelemetryStatus.ENABLED;
            lvobj.PayLoad.PLTMStopStatus = TelemetryStatus.ENABLED;
            return RedirectToAction("Index", new { lvname = name });
        }

        [Route("Details/StartData")]
        public IActionResult StartData(string name)
        {
            lvobj = FindLaunchVehicle(name);
            lvobj.PayLoad.PLDataStartStatus = DataStatus.ENABLED;
            lvobj.PayLoad.PLDataStopStatus = DataStatus.ENABLED;
            return RedirectToAction("Index", new { lvname = name });
        }

        [Route("Details/StopData")]
        public IActionResult StopData(string name)
        {
            lvobj = FindLaunchVehicle(name);
            lvobj.PayLoad.PLDataStartStatus = DataStatus.ENABLED;
            lvobj.PayLoad.PLDataStopStatus = DataStatus.ENABLED;
            return RedirectToAction("Index", new { lvname = name });
        }

        [Route("Details/Decommission")]
        public IActionResult Decommission(string name)
        {
            lvobj = FindLaunchVehicle(name);
            lvobj.PayLoad.PLCommissionedStatus = CommissionedStatus.DECOMMISSIONED;
            lvobj.PayLoad.PLDataStartStatus = DataStatus.DISABLED;
            lvobj.PayLoad.PLDataStopStatus = DataStatus.DISABLED;
            lvobj.PayLoad.PLTMStartStatus = TelemetryStatus.DISABLED;
            lvobj.PayLoad.PLTMStopStatus = TelemetryStatus.DISABLED;
            lvobj.PayLoad.PLStatusMessage = "DECOMMISSIONED";
            return RedirectToAction("Index", new { lvname = name });
        }
    }
}
