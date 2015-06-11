using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Example.Models
{
    // T-SQL Scripts
    //CREATE TABLE [dbo].[Employees] (
    //    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    //    [Name]       NVARCHAR (50)  NULL,
    //    [Introduce]  NVARCHAR (MAX) NULL,
    //    [Age]        INT     NULL,
    //    [LogoPath]   NVARCHAR (50)  NULL,
    //    [StartDate]  DATETIME       NULL,
    //    [EndDate]    DATETIME       NULL,
    //    [EnrollDate] DATETIME       NULL,
    //    [Status]     BIT            NULL,
    //    PRIMARY KEY CLUSTERED ([Id] ASC)
    //);
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }

        [AllowHtml]
        [UIHint("Editor")]
        [Display(Name = "介紹")]
        public string Introduce { get; set; }

        [Display(Name = "年齡")]
        [Required]
        public Nullable<int> Age { get; set; }

        [UIHint("FileInput")]
        [Display(Name = "大頭照")]
        public string LogoPath { get; set; }

        [Display(Name = "開始時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> StartDate { get; set; }

        [Display(Name = "結束時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> EndDate { get; set; }

        [Required]
        [Display(Name = "註冊時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> EnrollDate { get; set; }

        [UIHint("BooleanButtonLabel")]
        [Display(Name = "狀態")]
        public bool Status { get; set; }
    }

    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}