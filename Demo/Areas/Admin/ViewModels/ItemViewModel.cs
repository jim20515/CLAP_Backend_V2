using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Areas.Admin.Models;

namespace Demo.Areas.Admin.ViewModels
{
    public class ItemViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Acc> Items { get; set; }
    }

    public class ItemAccViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Acc> Items { get; set; }
    }

    public class ItemAppViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_App> Items { get; set; }
    }

    public class ItemBrowserViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Browser> Items { get; set; }
    }

    public class ItemBluetoothViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Bluetooth> Items { get; set; }
    }

    public class ItemCalActViewModel
    {
        public string Key { get; set; }
        public string Attributes { get; set; }
        public IEnumerable<Item_CalAct> Items { get; set; }
    }

    public class ItemCallViewModel
    {
        public string Key { get; set; }
        public string Attributes { get; set; }
        public IEnumerable<Item_Call> Items { get; set; }
    }

    public class ItemExtmediaViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Extmedia> Items { get; set; }
    }

    public class ItemGpsViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Gps> Items { get; set; }
    }

    public class ItemGsmViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Gsm> Items { get; set; }
    }

    public class ItemLiViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Li> Items { get; set; }
    }

    public class ItemLocaleViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Locale> Items { get; set; }
    }

    public class ItemMagnViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Magn> Items { get; set; }
    }

    public class ItemOriViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Ori> Items { get; set; }
    }

    public class ItemPhotoViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Photo> Items { get; set; }
    }

    public class ItemPkgViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Pkg> Items { get; set; }
    }

    public class ItemPowViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Pow> Items { get; set; }
    }

    public class ItemPresViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Pres> Items { get; set; }
    }

    public class ItemPxViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Px> Items { get; set; }
    }

    public class ItemRingerViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Ringer> Items { get; set; }
    }

    public class ItemScreenViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Screen> Items { get; set; }
    }

    public class ItemSmsViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Sms> Items { get; set; }
    }

    public class ItemTempViewModel
    {
        public string Key { get; set; }
        public IEnumerable<Item_Temp> Items { get; set; }
    }

    public class ItemTrafficViewModel
    {
        public string Key { get; set; }
        public string Attributes { get; set; }
        public IEnumerable<Item_Traffic> Items { get; set; }
    }

    public class ItemWifiViewModel
    {
        public string Key { get; set; }
        public string Attributes { get; set; }
        public IEnumerable<Item_Wifi> Items { get; set; }
    }
}