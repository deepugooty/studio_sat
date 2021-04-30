using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace studio_sat.Controllers
{
    public class DataController : Controller
    {
        private static readonly object _locker = new object();

        private static DataController instance;
        public static DataController Instance
        {
            get
            {
                lock (_locker)
                {
                    if (instance == null)
                    {
                        instance = new DataController();
                    }
                }
                return instance;
            }
        }

        private List<LaunchVehicle> lvmasterList = new List<LaunchVehicle>();
        public List<LaunchVehicle> LVMasterList
        {
            get { return lvmasterList; }
            set
            {
                lvmasterList = value;
            }
        }

        public DataController()
        {
            
        }
        
        public void LoadData()
        {
            var webClient = new WebClient();
            var LVjson = webClient.DownloadString(@"Util\LaunchVehicleConfig.json");
            var PLjson = webClient.DownloadString(@"Util\PayLoadConfig.json");
            var LVarray = JsonConvert.DeserializeObject<List<LaunchVehicle>>(LVjson);
            var PLarray = JsonConvert.DeserializeObject<List<Payload>>(PLjson);

            foreach (var a in LVarray)
            {
                var payLoadName = a.PayloadName;
                var PL = PLarray.Find(x => x.PLName == payLoadName);
                a.PayLoad = PL;
            }

            LVMasterList = LVarray;
        }       
    }
}
