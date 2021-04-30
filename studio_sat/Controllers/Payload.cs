using System;
using System.Collections.Generic;
using System.Linq;
using studio_sat.Util;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace studio_sat.Controllers
{
    public class Payload
    {
        public Payload()
        {
            PLName = "";
            PLImagepath = "";
            PLType = PayLoadType.UNKNOWN;
            PLCommissionedStatus = CommissionedStatus.UNKNOWN;
            PLStatusMessage = "NOT DEPLOYED";
            PLDataStartStatus = DataStatus.UNKNOWN;
            PLDataStopStatus = DataStatus.UNKNOWN;
            PLTMStartStatus = TelemetryStatus.UNKNOWN;
            PLTMStopStatus = TelemetryStatus.UNKNOWN;
        }
        [JsonProperty("name")]
        public string PLName
        {
            get; set;
        }

        [JsonProperty("image")]
        public string PLImagepath
        {
            get; set;
        }
        public string PLStatusMessage
        {
            get; set;
        }

        public TelemetryStatus PLTMStartStatus
        {
            get; set;
        }
        public TelemetryStatus PLTMStopStatus
        {
            get; set;
        }
        public DataStatus PLDataStartStatus
        {
            get; set;
        }
        public DataStatus PLDataStopStatus
        {
            get; set;
        }
        public CommissionedStatus PLCommissionedStatus
        {
            get; set;
        }

        [JsonProperty("type")]
        public PayLoadType PLType 
        {
            get; set;
        }
    }
}
