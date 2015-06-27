using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Demo.Areas.Admin.Models;
using Demo.Areas.Admin.ViewModels;
using System.Runtime.Serialization;
using Demo.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo.Areas.Admin.Services
{
    public class ExperimentApplyServices
    {
        private NCCUEntities db = new NCCUEntities();

        public List<ExperimentApplyIndexViewModel> GetIndex()
        {
            var Items = db.Experiment_Item.ToList();

            var list = db.Experiment_Apply
                       .AsEnumerable()
                       .Select(p => new ExperimentApplyIndexViewModel
                       {
                           Id = p.id,
                           Items = TransferItems(p.TotalItem, Items),
                           ModifyTime = string.Format("{0:yyyy/MM/dd}", p.ModifyTime),
                           Title = p.Title
                       });

            return list.ToList();
        }

        public ExperimentApplyAddViewModel GetCreate()
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

            return model;
        }

        public ExperimentApplyRUDViewModel GetEdit(int id)
        {
            return GetRUDViewModel(id);
        }

        public ExperimentApplyRUDViewModel GetDetails(int id)
        {
            return GetRUDViewModel(id);
        }

        public ExperimentApplyRUDViewModel GetDelete(int id)
        {
            return GetRUDViewModel(id);
        }

        public ExperimentApplyRUDViewModel GetRUDViewModel(int id)
        {
            Experiment_Apply experiment_Apply = db.Experiment_Apply.Find(id);
            if (experiment_Apply == null)
            {
                return null;
            }

            JObject restoredItem = JsonConvert.DeserializeObject<JObject>(experiment_Apply.TotalItem);

            var items = from p in db.Experiment_Item.AsEnumerable()
                        select new ExperimentItem
                        {
                            ItemId = p.id,
                            Text = p.Name,
                            Checked = (bool)restoredItem[p.id.ToString()]
                        };

            JObject restoredPolicy = JsonConvert.DeserializeObject<JObject>(experiment_Apply.UpdatePolicy);

            var policies = from p in GlobalData.UpdatePolicyList.AsEnumerable()
                           select new UpdatePolicy
                           {
                               id = p.id,
                               Name = p.Name,
                               Checked = (bool)restoredPolicy[p.id.ToString()]
                           };

            ExperimentApplyRUDViewModel model = new ExperimentApplyRUDViewModel()
            {
                id = experiment_Apply.id,
                Title = experiment_Apply.Title,
                Description = experiment_Apply.Description,
                CreateTime = string.Format("{0:yyyy/MM/dd HH:mm:ss}", experiment_Apply.CreateTime),
                ModifyTime = string.Format("{0:yyyy/MM/dd HH:mm:ss}", experiment_Apply.ModifyTime),
                ExperItemList = items.ToList(),
                UpdatePolicyList = policies.ToList()
            };

            return model;
        }

        public bool Create(ExperimentApplyAddViewModel experiment_Apply)
        {
            try
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
                    UpdatePolicy = policiesJson.ToString(),
                    ModifyTime = System.DateTime.Now
                };

                db.Experiment_Apply.Add(exp);
                db.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }

        }

        public bool Edit(ExperimentApplyRUDViewModel viewModel)
        {
            try
            {
                Experiment_Apply experiment_Apply = db.Experiment_Apply.Find(viewModel.id);
                if (experiment_Apply == null)
                {
                    return false;
                }

                JObject itemsJson = new JObject();
                foreach (var list in viewModel.ExperItemList)
                {
                    itemsJson.Add(list.ItemId.ToString(), list.Checked);
                }

                JObject policiesJson = new JObject();
                foreach (var list in viewModel.UpdatePolicyList)
                {
                    policiesJson.Add(list.id.ToString(), list.Checked);
                }

                experiment_Apply.Title = viewModel.Title;
                experiment_Apply.Description = viewModel.Description;
                experiment_Apply.TotalItem = itemsJson.ToString();
                experiment_Apply.UpdatePolicy = policiesJson.ToString();
                experiment_Apply.ModifyTime = System.DateTime.Now;

                db.Entry(experiment_Apply).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                Experiment_Apply experiment_Apply = db.Experiment_Apply.Find(id);
                db.Experiment_Apply.Remove(experiment_Apply);
                db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }

        public string TransferItems(string totalItem, List<Experiment_Item> nameList)
        {
            string returnValue = "";
            JObject items = JsonConvert.DeserializeObject<JObject>(totalItem);

            foreach (var item in items)
            {
                int id = Convert.ToInt32(item.Key);
                string a = item.Value.ToString();
                bool value = item.Value.ToString().ToUpper().Equals("TRUE") ? true : false;
                if (value)
                    returnValue += nameList.Where(x => x.id == id).Select(x => x.Name).FirstOrDefault() + " ";
            }

            return returnValue;
        }
    }
}