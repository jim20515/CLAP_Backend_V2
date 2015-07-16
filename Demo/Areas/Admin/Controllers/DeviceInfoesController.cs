using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Demo.Areas.Admin.Models;
using System.Web;
using System.Web.Mvc;


namespace Demo.Areas.Admin.Controllers
{
    public class DeviceInfoesController : Controller
    {
        private NCCUEntities db = new NCCUEntities();

        // POST: api/DeviceInfoes
        [ResponseType(typeof(DeviceInfo))]
        public JsonResult PostDeviceInfo(string uuid)
        {
            DeviceInfo deviceInfo = new DeviceInfo();

            var q = from p in db.DeviceInfo
                    where uuid.Equals(p.UUID)
                    select p;

            if (q != null && q.Count() >= 1)
            {
                return Json(new
                {
                    DevicesID = q.First().id,
                    AuthCode = q.First().AuthCode
                }, JsonRequestBehavior.AllowGet);
            }

            deviceInfo.UUID = uuid;
            db.DeviceInfo.Add(deviceInfo);
            db.SaveChanges();

            return Json(new
            {
                DevicesID = deviceInfo.id,
                AuthCode = deviceInfo.AuthCode
            }, JsonRequestBehavior.AllowGet);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeviceInfoExists(int id)
        {
            return db.DeviceInfo.Count(e => e.id == id) > 0;
        }
    }
}