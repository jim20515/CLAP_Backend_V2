//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item_Gsm
    {
        public int id { get; set; }
        public int devicesId { get; set; }
        public string attr { get; set; }
        public string attrval { get; set; }
        public System.DateTime datetime { get; set; }
    
        public virtual DeviceInfo DeviceInfo { get; set; }
    }
}
