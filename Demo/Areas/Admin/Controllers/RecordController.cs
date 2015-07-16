using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Areas.Admin.Models;
using Demo.Areas.Admin.ViewModels;
using Demo.Utils;
using Demo.Areas.Admin.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Demo.Areas.Admin.Models.Json;
using System.Data.SqlClient;
using Demo.Utils;

namespace Demo.Areas.Admin.Controllers
{
    public class RecordController : Controller
    {
        private NCCUEntities db = new NCCUEntities();

        // POST: api/Record
        public bool Post(string value)
        {
            try
            {
                ExperimentRecordJson record = JsonConvert.DeserializeObject<ExperimentRecordJson>(value);

                if (record == null)
                    return false;   

                foreach (var item in record.Items)
                {
                    var ItemTable = db.vwExperimentItem.Where(x => x.AttrName.Equals(item.Attr));
                    if (ItemTable == null || ItemTable.Count() == 0)
                        continue;

                    string sql = "INSERT INTO [Item." + ItemTable.First().Name + "] (DevicesId,Attr,AttrVal,DateTime) VALUES(@DevicesId,@Attr,@AttrVal,@DateTime)";

                    List<SqlParameter> parameterList = new List<SqlParameter>();
                    parameterList.Add(new SqlParameter("@DevicesId", record.DeviceId));
                    parameterList.Add(new SqlParameter("@Attr", item.Attr));
                    parameterList.Add(new SqlParameter("@AttrVal", item.AttrVal));
                    parameterList.Add(new SqlParameter("@DateTime", item.DateTime));
                    SqlParameter[] parameters = parameterList.ToArray();

                    int result = db.Database.ExecuteSqlCommand(sql, parameters);
                }

                return true;
            }
            catch (Exception e)
            {
                LogFile.SaveTxtFile(e);
                LogFile.SaveTxtFile("Record", value);

                return false;
            }
            
        }

    }
}
