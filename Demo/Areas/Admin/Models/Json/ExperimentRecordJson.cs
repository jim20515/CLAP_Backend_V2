using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo.Areas.Admin.Models.Json
{
    public class ExperimentRecordJson
    {
        public int ExperimentId { get; set; }
        public int DeviceId { get; set; }
        public List<ExperimentItemJson> Items { get; set; }
    }

    public class ExperimentItemJson
    {
        public string Attr { get; set; }
        public string AttrVal { get; set; }
        public DateTime DateTime { get; set; }
    }
}