﻿using System;
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
    public class ItemCalActController : Controller
    {
        private NCCUEntities db = new NCCUEntities();
        // GET: Admin/ItemAcc
        public ActionResult Index()
        {
            var item = db.Item_CalAct.Include(i => i.DeviceInfo)
                .GroupBy(x => new { x.datetime, x.devicesId })
                .AsEnumerable()
                .Select(p => new ItemCalActViewModel
                {
                    Key = p.Key.ToString(),
                    Attributes = returnAttrVal(p.First().attr),
                    Items = p
                });

            return View(item.ToList());
        }

        private string returnAttrVal(string attr)
        {
            if (attr.Contains("receive"))
                return "撥入";
            else if (attr.Contains("call"))
                return "撥出";

            return "";
        }
    }

}
