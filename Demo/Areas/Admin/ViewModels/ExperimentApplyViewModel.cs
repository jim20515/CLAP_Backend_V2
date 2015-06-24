using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Demo.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo.Areas.Admin.ViewModels
{
    public class ExperimentItem
    {
        public string Text { get; set; }
        public int ItemId { get; set; }
        public bool Checked { get; set; }
    }

    public class UpdatePolicy : GlobalData.UpdatePolicy
    {
        public bool Checked { get; set; }
    }

    public class ExperimentApplyViewModel
    {
        [DisplayName("描述")]
        [StringLength(500, ErrorMessage = "字數不能超過500")]
        public string Description { get; set; }

        [Required]
        [DisplayName("實驗名稱")]
        [StringLength(100, ErrorMessage = "字數不能超過100")]
        public string Title { get; set; }

        [Required]
        [DisplayName("上傳原則")]
        public List<ExperimentItem> ExperItemList { get; set; }

        [Required]
        [DisplayName("實驗項目")]
        public List<UpdatePolicy> UpdatePolicyList { get; set; }
    }

    public class ExperimentApplyEditViewModel : ExperimentApplyViewModel
    {
        public int id { get; set; }
    }

    public class ExperimentApplyAddViewModel : ExperimentApplyViewModel
    {
        [DisplayName("創建時間")]
        public DateTime CreateTime { get; set; }

        [DisplayName("修改時間")]
        public DateTime ModifyTime { get; set; }
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