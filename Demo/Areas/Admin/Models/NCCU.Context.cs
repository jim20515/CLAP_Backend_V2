﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NCCUEntities : DbContext
    {
        public NCCUEntities()
            : base("name=NCCUEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DeviceInfo> DeviceInfo { get; set; }
        public virtual DbSet<Experiment_Apply> Experiment_Apply { get; set; }
        public virtual DbSet<Experiment_Item> Experiment_Item { get; set; }
        public virtual DbSet<Item_Acc> Item_Acc { get; set; }
        public virtual DbSet<Item_CalAct> Item_CalAct { get; set; }
        public virtual DbSet<Item_Browser> Item_Browser { get; set; }
        public virtual DbSet<Item_Call> Item_Call { get; set; }
        public virtual DbSet<Item_Extmedia> Item_Extmedia { get; set; }
        public virtual DbSet<Item_Gps> Item_Gps { get; set; }
        public virtual DbSet<Item_Gsm> Item_Gsm { get; set; }
        public virtual DbSet<Item_Li> Item_Li { get; set; }
        public virtual DbSet<Item_Locale> Item_Locale { get; set; }
        public virtual DbSet<Item_Magn> Item_Magn { get; set; }
        public virtual DbSet<Item_Ori> Item_Ori { get; set; }
        public virtual DbSet<Item_Pkg> Item_Pkg { get; set; }
        public virtual DbSet<Item_Pow> Item_Pow { get; set; }
        public virtual DbSet<Item_Pres> Item_Pres { get; set; }
        public virtual DbSet<Item_Px> Item_Px { get; set; }
        public virtual DbSet<Item_Screen> Item_Screen { get; set; }
        public virtual DbSet<Item_Sms> Item_Sms { get; set; }
        public virtual DbSet<Item_Temp> Item_Temp { get; set; }
        public virtual DbSet<Item_Wifi> Item_Wifi { get; set; }
        public virtual DbSet<Item_Ringer> Item_Ringer { get; set; }
        public virtual DbSet<Item_App> Item_App { get; set; }
        public virtual DbSet<Item_Bluetooth> Item_Bluetooth { get; set; }
        public virtual DbSet<Item_Traffic> Item_Traffic { get; set; }
        public virtual DbSet<Item_Photo> Item_Photo { get; set; }
        public virtual DbSet<Experiment_Attribute> Experiment_Attribute { get; set; }
        public virtual DbSet<vwExperimentItem> vwExperimentItem { get; set; }
    }
}
