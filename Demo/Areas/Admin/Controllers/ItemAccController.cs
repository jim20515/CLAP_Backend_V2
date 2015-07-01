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
    public class ItemAccController : Controller
    {
        private NCCUEntities db = new NCCUEntities();
        // GET: Admin/ItemAcc
        public ActionResult Index()
        {
            var item_Acc = db.Item_Acc.Include(i => i.DeviceInfo)
                .GroupBy(x => x.datetime)
                .AsEnumerable()
                .Select(p => new ItemAccViewModel
                {
                    Key = string.Format("{0:yyyy/MM/dd}", p.Key),
                    ItemAcc = p
                });

            return View(item_Acc.ToList());
        }

    }

}
