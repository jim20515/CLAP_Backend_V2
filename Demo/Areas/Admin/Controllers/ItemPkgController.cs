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
    public class ItemPkgController : Controller
    {
        private NCCUEntities db = new NCCUEntities();
        // GET: Admin/ItemAcc
        public ActionResult Index()
        {
            var item = db.Item_Pkg.Include(i => i.DeviceInfo)
                .GroupBy(x => new { x.datetime, x.devicesId })
                .AsEnumerable()
                .Select(p => new ItemPkgViewModel
                {
                    Key = p.Key.ToString(),
                    Items = p
                });

            return View(item.ToList());
        }

    }

}