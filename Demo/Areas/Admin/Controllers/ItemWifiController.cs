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
    public class ItemWifiController : Controller
    {
        private NCCUEntities db = new NCCUEntities();
        // GET: Admin/ItemAcc
        public ActionResult Index()
        {
            var item = db.Item_Wifi.Include(i => i.DeviceInfo)
                .GroupBy(x => new { x.datetime, x.devicesId })
                .AsEnumerable()
                .Select(p => new ItemWifiViewModel
                {
                    Key = p.Key.ToString(),
                    Attributes = returnAttrVal(p.First().attr),
                    Items = p
                });

            return View(item.ToList());
        }

        private string returnAttrVal(string attr)
        {
            if ("ssid".Equals(attr))
                return "SSID";
            else if ("rssi".Equals(attr))
                return "RSSI";

            return "";
        }
    }

}
