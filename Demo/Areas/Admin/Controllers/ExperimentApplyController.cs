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

namespace Demo.Areas.Admin.Controllers
{
    public class ExperimentApplyController : Controller
    {
        private NCCUEntities db = new NCCUEntities();
        private ExperimentApplyServices services = new ExperimentApplyServices();

        // GET: Admin/ExperimentApply
        public ActionResult Index()
        {
            return View(services.GetIndex());
        }

        // GET: Admin/ExperimentApply/Create
        public ActionResult Create()
        {
            return View(services.GetCreate());
        }

        // GET: Admin/ExperimentApply/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ExperimentApplyRUDViewModel model = services.GetEdit(id.Value);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // GET: Admin/ExperimentApply/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ExperimentApplyRUDViewModel model = services.GetDetails(id.Value);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // GET: Admin/ExperimentApply/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ExperimentApplyRUDViewModel model = services.GetDelete(id.Value);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: Admin/ExperimentApply/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExperimentApplyAddViewModel experiment_Apply)
        {
            if (services.Create(experiment_Apply))
            {
                return RedirectToAction("Index");
            }

            return View(experiment_Apply);
        }

        

        // POST: Admin/ExperimentApply/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExperimentApplyRUDViewModel viewModel)
        {
            if (services.Edit(viewModel))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
            
        }

        // POST: Admin/ExperimentApply/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (services.Delete(id))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                services.Dispose(disposing);
            }
            base.Dispose(disposing);
        }
    }
}
