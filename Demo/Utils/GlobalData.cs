using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace Demo.Utils
{
    public class GlobalData
    {
        public class UpdatePolicy
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public UpdatePolicy() { }
            public UpdatePolicy(int id, string name)
            {
                this.Id = id;
                this.Name = name;
            }
        }

        public static List<UpdatePolicy> UpdatePolicyList = new List<UpdatePolicy>{
            new UpdatePolicy(1, "插上電源時"),
            new UpdatePolicy(2, "連上Wifi時")
        };
    }

    public static class EventLog
    {
        public static string FilePath { get; set; }

        public static void Write(string format, params object[] arg)
        {
            Write(string.Format(format, arg));
        }

        public static void Write(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);

            if (string.IsNullOrEmpty(FilePath))
            {
                //FilePath = Directory.GetCurrentDirectory();
                FilePath = HttpContext.Current.Server.MapPath("~/");
            }
            string filename = FilePath +
                string.Format("\\ErrorLog.txt");
            FileInfo finfo = new FileInfo(filename);
            if (finfo.Directory.Exists == false)
            {
                finfo.Directory.Create();
            }
            string writeString = string.Format("{0:yyyy/MM/dd HH:mm:ss} {1}",
                DateTime.Now, message) + Environment.NewLine;
            File.AppendAllText(filename, writeString, Encoding.Unicode);
        }
    }

}