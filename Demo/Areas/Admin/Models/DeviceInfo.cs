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
    
    public partial class DeviceInfo
    {
        public DeviceInfo()
        {
            this.Item_Acc = new HashSet<Item_Acc>();
            this.Item_CalAct = new HashSet<Item_CalAct>();
            this.Item_Browser = new HashSet<Item_Browser>();
            this.Item_Call = new HashSet<Item_Call>();
            this.Item_Extmedia = new HashSet<Item_Extmedia>();
            this.Item_Gps = new HashSet<Item_Gps>();
            this.Item_Gsm = new HashSet<Item_Gsm>();
            this.Item_Li = new HashSet<Item_Li>();
            this.Item_Locale = new HashSet<Item_Locale>();
            this.Item_Magn = new HashSet<Item_Magn>();
            this.Item_Ori = new HashSet<Item_Ori>();
            this.Item_Pkg = new HashSet<Item_Pkg>();
            this.Item_Pow = new HashSet<Item_Pow>();
            this.Item_Pres = new HashSet<Item_Pres>();
            this.Item_Px = new HashSet<Item_Px>();
            this.Item_Screen = new HashSet<Item_Screen>();
            this.Item_Sms = new HashSet<Item_Sms>();
            this.Item_Temp = new HashSet<Item_Temp>();
            this.Item_Wifi = new HashSet<Item_Wifi>();
        }
    
        public int id { get; set; }
        public System.Guid AuthCode { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        public virtual ICollection<Item_Acc> Item_Acc { get; set; }
        public virtual ICollection<Item_CalAct> Item_CalAct { get; set; }
        public virtual ICollection<Item_Browser> Item_Browser { get; set; }
        public virtual ICollection<Item_Call> Item_Call { get; set; }
        public virtual ICollection<Item_Extmedia> Item_Extmedia { get; set; }
        public virtual ICollection<Item_Gps> Item_Gps { get; set; }
        public virtual ICollection<Item_Gsm> Item_Gsm { get; set; }
        public virtual ICollection<Item_Li> Item_Li { get; set; }
        public virtual ICollection<Item_Locale> Item_Locale { get; set; }
        public virtual ICollection<Item_Magn> Item_Magn { get; set; }
        public virtual ICollection<Item_Ori> Item_Ori { get; set; }
        public virtual ICollection<Item_Pkg> Item_Pkg { get; set; }
        public virtual ICollection<Item_Pow> Item_Pow { get; set; }
        public virtual ICollection<Item_Pres> Item_Pres { get; set; }
        public virtual ICollection<Item_Px> Item_Px { get; set; }
        public virtual ICollection<Item_Screen> Item_Screen { get; set; }
        public virtual ICollection<Item_Sms> Item_Sms { get; set; }
        public virtual ICollection<Item_Temp> Item_Temp { get; set; }
        public virtual ICollection<Item_Wifi> Item_Wifi { get; set; }
    }
}
