using System;
using System.Collections.Generic;
using System.Linq;
using studio_sat.Util;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace studio_sat.Controllers
{
    public class LaunchVehicle
    {
        public LaunchVehicle()
        {
            LVName = "";
            LaunchButtonEnabled = true;
            LVOrbitRadius = 0;
            LVImagePath = "";
            LVDeployPayloadEnabled = false;
            LVOrbitStatus = OrbitStatus.UNKNOWN;
            PayLoad = new Payload();
            PayloadName = "";
            LVStatusMessage = "READY TO LAUNCH";
            LVTMStartStatus = TelemetryStatus.UNKNOWN;
            LVTMStopStatus = TelemetryStatus.UNKNOWN;
        }

        [JsonProperty("name")]
        public string LVName
        {
            get; set;
        }

        [JsonProperty("orbitRadius")]
        public int LVOrbitRadius
        {
            get; set;
        }

        public string LVStatusMessage
        {
            get; set;
        }

        [JsonProperty("image")]
        public string LVImagePath
        {
            get; set;
        }

        public bool LVDeployPayloadEnabled
        {
            get; set;
        }
        public bool LaunchButtonEnabled
        {
            get; set;
        }
        public TelemetryStatus LVTMStartStatus
        {
            get; set;
        }
        public TelemetryStatus LVTMStopStatus
        {
            get; set;
        }
        public OrbitStatus LVOrbitStatus
        {
            get; set;
        }

        [JsonProperty("payload")]
        public string PayloadName
        {
            get; set;
        }

        public Payload PayLoad
        {
            get; set;
        }

    }
}
