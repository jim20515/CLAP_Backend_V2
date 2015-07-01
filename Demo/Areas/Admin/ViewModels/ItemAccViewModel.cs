using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Areas.Admin.Models;

namespace Demo.Areas.Admin.ViewModels
{
    public class ItemAccViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Acc> ItemAcc { get; set; }
    }
}