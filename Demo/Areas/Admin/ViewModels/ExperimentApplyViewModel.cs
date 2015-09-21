using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Demo.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Demo.Areas.Admin.Models;

namespace Demo.Areas.Admin.ViewModels
{
    public class DetailJson
    {
        public List<UpdatePolicy> Policy { get; set; }
        public List<ItemsJson> Items { get; set; }
    }

    public class ItemsJson
    {
        public int ItemId;
        public string ItemName;
        public int AttrId;
        public string AttrName;
        public double? Condition;
    }

    public class ExperimentItem
    {
        public string Text { get; set; }
        public int ItemId { get; set; }
        public bool HasRecordSecond { get; set; }
        public bool Checked { get; set; }
    }

    public class ItemInterval
    {
        public int ItemId { get; set; }
        public int Interval { get; set; }
    }

    public class UpdatePolicy : GlobalData.UpdatePolicy
    {
        public bool Checked { get; set; }
    }

    public class ExperimentApplyBaseViewModel
    {
        [DisplayName("描述")]
        [StringLength(500, ErrorMessage = "字數不能超過500")]
        public string Description { get; set; }

        [Required]
        [DisplayName("實驗名稱")]
        [StringLength(100, ErrorMessage = "字數不能超過100")]
        public string Title { get; set; }

        [Required]
        [DisplayName("實驗列表")]
        public List<ExperimentItem> ExperItemList { get; set; }

        [Required]
        [DisplayName("上傳原則")]
        public List<UpdatePolicy> UpdatePolicyList { get; set; }

        [DisplayName("紀錄間隔")]
        public List<ItemInterval> ItemIntervalList { get; set; }
    }

    public class ExperimentApplyRUDViewModel : ExperimentApplyBaseViewModel
    {
        [DisplayName("實驗流水號")]
        public int id { get; set; }

        [DisplayName("創建時間")]
        public string CreateTime { get; set; }

        [DisplayName("修改時間")]
        public string ModifyTime { get; set; }
    }

    public class ExperimentApplyAddViewModel : ExperimentApplyBaseViewModel
    {
        
    }

    public class ExperimentApplyIndexViewModel
    {
        [DisplayName("編號")]
        public int Id { get; set; }

        [DisplayName("實驗名稱")]
        public string Title { get; set; }

        [DisplayName("項目")]
        public string Items { get; set; }

        [DisplayName("修改日期")]
        public string ModifyTime { get; set; }
    }

}