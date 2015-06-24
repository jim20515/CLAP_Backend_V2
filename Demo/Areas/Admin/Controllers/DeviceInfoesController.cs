//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Description;
//using Demo.Areas.Admin.Models;

//namespace Demo.Areas.Admin.Controllers
//{
//    public class DeviceInfoesController : ApiController
//    {
//        private NCCUEntities db = new NCCUEntities();

//        // GET: api/DeviceInfoes
//        public IQueryable<DeviceInfo> GetDeviceInfo()
//        {
//            return db.DeviceInfo;
//        }

//        // GET: api/DeviceInfoes/5
//        [ResponseType(typeof(DeviceInfo))]
//        public IHttpActionResult GetDeviceInfo(int id)
//        {
//            DeviceInfo deviceInfo = db.DeviceInfo.Find(id);
//            if (deviceInfo == null)
//            {
//                return NotFound();
//            }

//            return Ok(deviceInfo);
//        }

//        // PUT: api/DeviceInfoes/5
//        [ResponseType(typeof(void))]
//        public IHttpActionResult PutDeviceInfo(int id, DeviceInfo deviceInfo)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != deviceInfo.id)
//            {
//                return BadRequest();
//            }

//            db.Entry(deviceInfo).State = EntityState.Modified;

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!DeviceInfoExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/DeviceInfoes
//        [ResponseType(typeof(DeviceInfo))]
//        public IHttpActionResult PostDeviceInfo()
//        {
//            //if (!ModelState.IsValid)
//            //{
//            //    return BadRequest(ModelState);
//            //}

//            DeviceInfo deviceInfo = new DeviceInfo();

//            db.DeviceInfo.Add(deviceInfo);
//            db.SaveChanges();

//            return CreatedAtRoute("DefaultApi", 
//                new { 
//                    id = deviceInfo.id,
//                    AuthCode = deviceInfo.AuthCode
//                }, deviceInfo);
//        }

//        // DELETE: api/DeviceInfoes/5
//        [ResponseType(typeof(DeviceInfo))]
//        public IHttpActionResult DeleteDeviceInfo(int id)
//        {
//            DeviceInfo deviceInfo = db.DeviceInfo.Find(id);
//            if (deviceInfo == null)
//            {
//                return NotFound();
//            }

//            db.DeviceInfo.Remove(deviceInfo);
//            db.SaveChanges();

//            return Ok(deviceInfo);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool DeviceInfoExists(int id)
//        {
//            return db.DeviceInfo.Count(e => e.id == id) > 0;
//        }
//    }
//}