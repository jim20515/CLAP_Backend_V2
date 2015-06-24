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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo.Areas.Admin.Controllers
{
    public class ExperimentApplyController : Controller
    {
        private NCCUEntities db = new NCCUEntities();

        // GET: Admin/ExperimentApply
        public ActionResult Index()
        {
            var Items = db.Experiment_Item.ToList();

            var list = from p in db.Experiment_Apply
                       select new ExperimentApplyIndexViewModel
                       {
                           Id = p.id,
                           Items = TransferItems(p.TotalItem, Items),
                           ModifyTime = string.Format("{0:yyyy/MM/dd}", p.ModifyTime),
                           Title = p.Title
                       };

            return View(list.ToList());
        }

        public string TransferItems(string totalItem, IEnumerable<Experiment_Item> nameList)
        {
            string returnValue = "";
            JObject items = JsonConvert.DeserializeObject<JObject>(totalItem);

            foreach (var item in items)
            {
                int id = Convert.ToInt32(item.Key);
                string a = item.Value.ToString();
                bool value = item.Value.ToString().ToUpper().Equals("TRUE") ? true : false;
                if (value)
                    returnValue += nameList.Where(x => x.id == id).Select(x => x.Name).FirstOrDefault() + "/r/n";
            }

            return returnValue;
        }

        // GET: Admin/ExperimentApply/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiment_Apply experiment_Apply = db.Experiment_Apply.Find(id);
            if (experiment_Apply == null)
            {
                return HttpNotFound();
            }
            return View(experiment_Apply);
        }

        // GET: Admin/ExperimentApply/Create
        public ActionResult Create()
        {
            var items = from p in db.Experiment_Item
                        select new ExperimentItem
                        {
                            ItemId = p.id,
                            Text = p.Name
                        };

            var policies = from p in GlobalData.UpdatePolicyList
                           select new UpdatePolicy
                           {
                               id = p.id,
                               Name = p.Name
                           };

            ExperimentApplyAddViewModel model = new ExperimentApplyAddViewModel()
            {
                ExperItemList = items.ToList(),
                UpdatePolicyList = policies.ToList()
            };
            return View(model);
        }

        // POST: Admin/ExperimentApply/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExperimentApplyAddViewModel experiment_Apply)
        {
            if (ModelState.IsValid)
            {
                JObject itemsJson = new JObject();
                foreach (var list in experiment_Apply.ExperItemList)
                {
                    itemsJson.Add(list.ItemId.ToString(), list.Checked);
                }

                JObject policiesJson = new JObject();
                foreach (var list in experiment_Apply.UpdatePolicyList)
                {
                    policiesJson.Add(list.id.ToString(), list.Checked);
                }

                Experiment_Apply exp = new Experiment_Apply()
                {
                    Title = experiment_Apply.Title,
                    Description = experiment_Apply.Description,
                    TotalItem = itemsJson.ToString(),
                    UpdatePolicy = policiesJson.ToString()
                };

                db.Experiment_Apply.Add(exp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(experiment_Apply);
        }

        // GET: Admin/ExperimentApply/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiment_Apply experiment_Apply = db.Experiment_Apply.Find(id);
            if (experiment_Apply == null)
            {
                return HttpNotFound();
            }
            return View(experiment_Apply);
        }

        // POST: Admin/ExperimentApply/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TotalItem,Description,UpdatePolicy,IsUpdate,CreateTime")] Experiment_Apply experiment_Apply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experiment_Apply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(experiment_Apply);
        }

        // GET: Admin/ExperimentApply/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiment_Apply experiment_Apply = db.Experiment_Apply.Find(id);
            if (experiment_Apply == null)
            {
                return HttpNotFound();
            }
            return View(experiment_Apply);
        }

        // POST: Admin/ExperimentApply/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Experiment_Apply experiment_Apply = db.Experiment_Apply.Find(id);
            db.Experiment_Apply.Remove(experiment_Apply);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
