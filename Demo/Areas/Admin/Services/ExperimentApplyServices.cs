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
                           ModifyTime = string.Format("{0:yyyy/MM/dd HH:mm:ss}", p.ModifyTime),
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
                            HasRecordSecond = p.HasRecordInterval,
                            Text = p.Description
                        };

            var policies = from p in GlobalData.UpdatePolicyList
                           select new UpdatePolicy
                           {
                               Id = p.Id,
                               Name = p.Name,
                               Checked = p.Id == 1
                           };

            //var applySecondList = from p in items
            //                      .AsEnumerable()
            //                      where p.HasRecordSecond == true
            //                      select new Experiment_ApplySecond 
            //                      {
            //                         ItemId = p.ItemId
            //                      };

            var intervalList = from p in items
                               .AsEnumerable()
                               where p.HasRecordSecond
                               select new ItemInterval
                               {
                                   ItemId = p.ItemId
                               };

            ExperimentApplyAddViewModel model = new ExperimentApplyAddViewModel()
            {
                ExperItemList = items.ToList(),
                UpdatePolicyList = policies.ToList(),
                ItemIntervalList = intervalList.ToList()
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
            //var allApplySecondList = db.Experiment_ApplySecond.Where(x => x.ApplyId == id).AsEnumerable();

            if (experiment_Apply == null)
            {
                return null;
            }

            var policies = from p in GlobalData.UpdatePolicyList
                           .AsEnumerable()
                           select new UpdatePolicy
                           {
                               Id = p.Id,
                               Name = p.Name,
                               Checked = restoredPolicy(experiment_Apply.UpdatePolicy, p.Id)
                           };

            JObject restoredItem = JsonConvert.DeserializeObject<JObject>(experiment_Apply.TotalItem);

            var items = from p in db.Experiment_Item
                        .AsEnumerable()
                        select new ExperimentItem
                        {
                            ItemId = p.id,
                            Text = p.Description,
                            HasRecordSecond = p.HasRecordInterval,
                            Checked = restoredItem[p.id.ToString()] != null ? (bool)restoredItem[p.id.ToString()] : false
                        };

            JObject restoredInterval;

            if (experiment_Apply.ItemInterval == null)
                restoredInterval = new JObject();
            else
                restoredInterval = JsonConvert.DeserializeObject<JObject>(experiment_Apply.ItemInterval);

            var intervalList = from p in items
                                .AsEnumerable()
                               where p.HasRecordSecond == true
                               select new ItemInterval
                               {
                                   ItemId = p.ItemId,
                                   Interval = restoredInterval[p.ItemId.ToString()] != null ? (int)restoredInterval[p.ItemId.ToString()] : 0
                               };

            //var applySecond = from p in db.Experiment_ApplySecond
            //                  .AsEnumerable()
            //                  where p.ApplyId == id
            //                  select p;

            ExperimentApplyRUDViewModel model = new ExperimentApplyRUDViewModel()
            {
                id = experiment_Apply.id,
                Title = experiment_Apply.Title,
                Description = experiment_Apply.Description,
                CreateTime = string.Format("{0:yyyy/MM/dd HH:mm:ss}", experiment_Apply.CreateTime),
                ModifyTime = string.Format("{0:yyyy/MM/dd HH:mm:ss}", experiment_Apply.ModifyTime),
                ExperItemList = items.ToList(),
                UpdatePolicyList = policies.ToList(),
                ItemIntervalList = intervalList.ToList()
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
                    policiesJson.Add(list.Id.ToString(), list.Checked);
                }

                JObject IntervalJson = new JObject();
                foreach (var list in experiment_Apply.ItemIntervalList)
                {
                    if(list.Interval > 0)
                        IntervalJson.Add(list.ItemId.ToString(), list.Interval);
                }

                Experiment_Apply exp = new Experiment_Apply()
                {
                    Title = experiment_Apply.Title,
                    Description = experiment_Apply.Description,
                    TotalItem = itemsJson.ToString(),
                    ItemInterval = IntervalJson.ToString(),
                    UpdatePolicy = policiesJson.ToString(),
                    ModifyTime = System.DateTime.Now
                };

                db.Experiment_Apply.Add(exp);
                db.SaveChanges();

                //var insertApplySecondList = from p in experiment_Apply.ApplySecondList
                //                            where p.Second > 0
                //                            select new Experiment_ApplySecond
                //                            {
                //                                ApplyId = exp.id,
                //                                ItemId = p.ItemId,
                //                                Second = p.Second
                //                            };

                //db.Experiment_ApplySecond.AddRange(insertApplySecondList);
                db.SaveChanges();

                return true;
            }
            catch (Exception e)
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
                    policiesJson.Add(list.Id.ToString(), list.Checked);
                }

                JObject intervalJson = new JObject();
                foreach (var list in viewModel.ItemIntervalList)
                {
                    if(list.Interval > 0)
                        intervalJson.Add(list.ItemId.ToString(), list.Interval);
                }

                experiment_Apply.Title = viewModel.Title;
                experiment_Apply.Description = viewModel.Description;
                experiment_Apply.TotalItem = itemsJson.ToString();
                experiment_Apply.UpdatePolicy = policiesJson.ToString();
                experiment_Apply.ItemInterval = intervalJson.ToString();
                experiment_Apply.ModifyTime = System.DateTime.Now;

                db.Entry(experiment_Apply).State = EntityState.Modified;

                //db.Entry(viewModel.ApplySecondList.Where(x => x.Second > 0)).State = EntityState.Modified;
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

        public bool restoredPolicy(string updatePolicy, int id)
        {
            if (id == 1)
                return true;

            JObject restoredPolicy = JsonConvert.DeserializeObject<JObject>(updatePolicy);

            return restoredPolicy[id.ToString()] != null ? (bool)restoredPolicy[id.ToString()] : false;
        }
    }
}