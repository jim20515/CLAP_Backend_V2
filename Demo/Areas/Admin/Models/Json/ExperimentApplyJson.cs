using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo.Areas.Admin.Models.Json
{
    public class ExperimentApplyJson
    {
        public class ExperimentItemJson
        {
            public JArray _items { get; set; }
        }

        public class UpdatePolicyJson
        {
            public JArray _policies { get; set; }
        }
    }
}