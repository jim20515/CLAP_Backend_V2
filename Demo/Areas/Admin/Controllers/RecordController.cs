using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Demo.Areas.Admin.Models.Json;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Areas.Admin.Models;
using System.Data.SqlClient;

namespace Demo.Areas.Admin.Controllers
{
    public class RecordController : ApiController
    {
        private NCCUEntities db = new NCCUEntities();

        // POST: api/Record
        public void Post([FromBody]string value)
        {
            ExperimentRecordJson record = JsonConvert.DeserializeObject<ExperimentRecordJson>(value);

            if (record == null)
                return;

            foreach (var item in record.Items)
            {
                var ItemTable = db.vwExperimentItem.Where(x => x.AttrName.Equals(item.Attr));
                if (ItemTable == null || ItemTable.Count() != 0)
                    continue;

                string sql = "INSERT INTO " + ItemTable.First().Name+ "(DeviceId,Attr,AttrVal,DateTime) VALUES(@DeviceId,@Attr,@AttrVal,@DateTime)";

                List<SqlParameter> parameterList = new List<SqlParameter>();
                parameterList.Add(new SqlParameter("@DeviceId", record.DeviceId));
                parameterList.Add(new SqlParameter("@Attr", item.Attr));
                parameterList.Add(new SqlParameter("@AttrVal", item.AttrVal));
                parameterList.Add(new SqlParameter("@DateTime", item.DateTime));
                SqlParameter[] parameters = parameterList.ToArray();
                int result = db.Database.ExecuteSqlCommand(sql, parameters);
            }

        }

    }
}
