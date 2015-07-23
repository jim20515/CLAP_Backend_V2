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

namespace Demo.Areas.Admin.Controllers
{
    public class ItemCallController : Controller
    {
        private NCCUEntities db = new NCCUEntities();
        // GET: Admin/ItemAcc
        public ActionResult Index()
        {
            var item = db.Item_Call.Include(i => i.DeviceInfo)
                .GroupBy(x => new { x.datetime, x.devicesId })
                .AsEnumerable()
                .Select(p => new ItemCallViewModel
                {
                    Key = p.Key.ToString(),
                    Attributes = returnAttrVal(p.First().attr),
                    Items = p
                });

            return View(item.ToList());
        }

        private string returnAttrVal(string attr)
        {
            if (attr.Contains("out"))
                return "撥出";
            else if (attr.Contains("in"))
                return "撥入";

            return "";
        }
    }

}
