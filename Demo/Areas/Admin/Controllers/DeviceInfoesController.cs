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
    public class DeviceInfoesController : ApiController
    {
        private NCCUEntities db = new NCCUEntities();

        // GET: api/DeviceInfoes
        //public ActionResult GetDeviceInfo()
        //{
        //    return View(db.DeviceInfo.ToList());
        //}

        // POST: api/DeviceInfoes
        [ResponseType(typeof(DeviceInfo))]
        public IHttpActionResult PostDeviceInfo()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DeviceInfo deviceInfo = new DeviceInfo();

            db.DeviceInfo.Add(deviceInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi",
            new
            {
                id = deviceInfo.id,
                AuthCode = deviceInfo.AuthCode
            }, deviceInfo);
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