//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.IO;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Web.Security;
//using System.Drawing.Imaging;

//namespace DreamMall
//{
//    public class GlobalFunc
//    {
//        public static void CheckPicture(HttpPostedFileBase pic)
//        {
//            if (pic != null)
//            {
//                if (pic.ContentLength > 300000)
//                {
//                    throw new PictureSizeException(pic.FileName);
//                }
//                var supportedTypes = new[] { "jpg", "jpeg", "png", "gif" };

//                string fileExt = System.IO.Path.GetExtension(pic.FileName).Substring(1);

//                if (!supportedTypes.Contains(fileExt.ToLower()))
//                {
//                    throw new PictureFormatException(pic.FileName);
//                }
//            }
//        }
//        public static void CheckPicture(HttpPostedFileBase pic, int size)
//        {
//            if (pic != null)
//            {
//                if (pic.ContentLength > size)
//                {
//                    throw new PictureSizeException(pic.FileName);
//                }
//                var supportedTypes = new[] { "jpg", "jpeg", "png", "gif" };

//                string fileExt = System.IO.Path.GetExtension(pic.FileName).Substring(1);

//                if (!supportedTypes.Contains(fileExt.ToLower()))
//                {
//                    throw new PictureFormatException(pic.FileName);
//                }
//            }
//        }

//        public static void uploadImg(HttpPostedFileBase imageControl, string TableName, Guid Guid, string fileName)//upload img and no web , app
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/";
//            if (imageControl != null && imageControl.ContentLength > 0)
//            {
//                if (!Directory.Exists(HttpContext.Current.Server.MapPath(dir)))
//                {
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir));
//                }
//                //save picture
//                var webpath = Path.Combine(HttpContext.Current.Server.MapPath(dir), fileName + Path.GetExtension(imageControl.FileName));
//                imageControl.SaveAs(webpath);
//            }
//        }
//        public static void uploadImg(HttpPostedFileBase imageControl, string TableName, Guid Guid, string fileName, double scaleFactor)//upload img and have scaleimg
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/";

//            if (imageControl != null && imageControl.ContentLength > 0)
//            {
//                if (!Directory.Exists(HttpContext.Current.Server.MapPath(dir)))
//                {
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir));
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir + GlobalData.WebDir));
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir + GlobalData.AppDir));
//                }
//                var webpath = Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.WebDir, fileName + Path.GetExtension(imageControl.FileName));
//                imageControl.SaveAs(webpath);
//                var apppath = Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.AppDir, fileName + Path.GetExtension(imageControl.FileName));
//                Resize(webpath, apppath, scaleFactor);//resize
//            }
//        }
//        public static void uploadImg(HttpPostedFileBase imageControl, string TableName, Guid Guid, string fileName, int AppImageWidth, int AppImageHeight)//upload img and app img have static width , height
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/";

//            if (imageControl != null && imageControl.ContentLength > 0)
//            {
//                if (!Directory.Exists(HttpContext.Current.Server.MapPath(dir)))
//                {
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir));
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir + GlobalData.WebDir));
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir + GlobalData.AppDir));
//                }
//                var webpath = Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.WebDir, fileName + Path.GetExtension(imageControl.FileName));
//                imageControl.SaveAs(webpath);
//                ResizeApp(webpath, Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.AppDir, fileName + Path.GetExtension(imageControl.FileName)), AppImageWidth, AppImageHeight);
//            }
//        }
//        public static void uploadThumb(HttpPostedFileBase imageControl, string TableName, Guid Guid, string fileName, double scaleFactor)
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/";

//            if (imageControl != null && imageControl.ContentLength > 0)
//            {
//                if (!Directory.Exists(HttpContext.Current.Server.MapPath(dir)))
//                {
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir));
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir + GlobalData.WebDir));
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir + GlobalData.AppDir));
//                }
//                var webpath = Path.Combine(HttpContext.Current.Server.MapPath(dir), fileName + Path.GetExtension(imageControl.FileName));
//                imageControl.SaveAs(webpath);
//                var apppath = Path.Combine(HttpContext.Current.Server.MapPath(dir), "thumb" + Path.GetExtension(imageControl.FileName));
//                Resize(webpath, apppath, scaleFactor);//resize
//            }
//        }

//        public static void uploadImgBrandActivity(HttpPostedFileBase imageControl, string TableName, Guid Guid)
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/";

//            if (imageControl != null && imageControl.ContentLength > 0)
//            {
//                if (!Directory.Exists(HttpContext.Current.Server.MapPath(dir)))
//                {
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir));
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir + GlobalData.WebDir));
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir + GlobalData.AppDir));
//                }
//                // web/result no change size
//                var webresultpath = Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.WebDir, GlobalData.Result_pic + Path.GetExtension(imageControl.FileName));
//                imageControl.SaveAs(webresultpath);
//                // web/list
//                Resize(webresultpath, Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.WebDir, GlobalData.List_pic + Path.GetExtension(imageControl.FileName)), 0.555555556);
//                // app/result 
//                Resize(webresultpath, Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.AppDir, GlobalData.Result_pic + Path.GetExtension(imageControl.FileName)), 0.555555556);
//                // app/list
//                Resize(webresultpath, Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.AppDir, GlobalData.List_pic + Path.GetExtension(imageControl.FileName)), 0.333333333);
//            }
//        }
//        public static void uploadCardActivity(HttpPostedFileBase imageControl, string TableName, Guid Guid)
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/";

//            if (imageControl != null && imageControl.ContentLength > 0)
//            {
//                if (!Directory.Exists(HttpContext.Current.Server.MapPath(dir)))
//                {
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir));
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir + GlobalData.WebDir));
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir + GlobalData.AppDir));
//                }
//                // web/result no change size
//                var webresultpath = Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.WebDir, GlobalData.Result_pic + Path.GetExtension(imageControl.FileName));
//                imageControl.SaveAs(webresultpath);
//                // web/list
//                Resize(webresultpath, Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.WebDir, GlobalData.List_pic + Path.GetExtension(imageControl.FileName)), 0.5);
//                // app/list
//                Resize(webresultpath, Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.AppDir, GlobalData.List_pic + Path.GetExtension(imageControl.FileName)), 0.5);
//            }
//        }

//        private static ImageCodecInfo GetEncoder(ImageFormat format)
//        {

//            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

//            foreach (ImageCodecInfo codec in codecs)
//            {
//                if (codec.FormatID == format.Guid)
//                {
//                    return codec;
//                }
//            }
//            return null;
//        }

//        public static void Resize(string imageFile, string outputFile, double scaleFactor)
//        {
//            using (var srcImage = Image.FromFile(imageFile))
//            {
//                var newWidth = (int)(srcImage.Width * scaleFactor);
//                var newHeight = (int)(srcImage.Height * scaleFactor);
//                using (var newImage = new Bitmap(newWidth, newHeight))
//                using (var graphics = Graphics.FromImage(newImage))
//                {
//                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
//                    graphics.InterpolationMode = InterpolationMode.Bicubic;
//                    graphics.PixelOffsetMode = PixelOffsetMode.Half;
//                    graphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
//                    newImage.Save(outputFile, srcImage.RawFormat);
//                }
//            }
//        }
//        public static void ResizeApp(string imageFile, string outputFile, int Width, int Height)
//        {
//            using (var srcImage = Image.FromFile(imageFile))
//            {
//                var newWidth = Width;
//                var newHeight = Height;
//                using (var newImage = new Bitmap(newWidth, newHeight))
//                using (var graphics = Graphics.FromImage(newImage))
//                {

//                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
//                    graphics.InterpolationMode = InterpolationMode.Bicubic;
//                    graphics.PixelOffsetMode = PixelOffsetMode.Half;
//                    graphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
//                    graphics.Dispose();
//                    newImage.Save(outputFile, srcImage.RawFormat);
//                }
//            }
//        }

//        public static void deleteImage(string TableName, Guid Guid)
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/";

//            if (Directory.Exists(HttpContext.Current.Server.MapPath(dir)))//資料夾存在 
//            {
//                //delete
//                try
//                {
//                    Directory.Delete(HttpContext.Current.Server.MapPath(dir), true);
//                }
//                catch (Exception e)
//                {
//                    EventLog.Write(e.Message);
//                }
//            }

//        }
//        public static void deleteImage(string TableName, Guid Guid, string FileName)
//        {
//            string dir = HttpContext.Current.Server.MapPath("~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/");
//            string appDir = HttpContext.Current.Server.MapPath("~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/App/");
//            string webDir = HttpContext.Current.Server.MapPath("~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/Web/");
//            if (Directory.Exists(dir))
//            {
//                deleteFileByFileName(dir, FileName);
//                //
//                if (Directory.Exists(appDir))//檢查Guid/App資料夾
//                {
//                    deleteFileByFileName(appDir, FileName);
//                }
//                if (Directory.Exists(webDir))//檢查Guid/Web資料夾
//                {
//                    deleteFileByFileName(webDir, FileName);
//                }
//            }
//        }
//        public static void deleteFileByFileName(string FilePath, string FileName)
//        {
//            foreach (string fname in System.IO.Directory.GetFiles(FilePath))//檢查Guid資料夾
//            {
//                if (Path.GetFileNameWithoutExtension(fname) == FileName)
//                {
//                    try
//                    {
//                        System.IO.File.Delete(fname);
//                    }
//                    catch (Exception e)
//                    {
//                        EventLog.Write(e.Message);
//                    }
//                }
//            }
//        }

//        public static string CheckFile(HttpPostedFileBase file)
//        {
//            if (file != null)
//            {
//                //if (file.ContentLength > 204800)
//                //{
//                //    return "檔案大小過大  請勿大於200kb ";
//                //}
//                var supportedTypes = new[] { "jpg", "jpeg", "pdf", "doc", "docx", "xls", "xlsx", "txt", "mov", "mp4", "ogg" };

//                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);

//                if (!supportedTypes.Contains(fileExt))
//                {
//                    return "檔案格式錯誤  請上傳jpg,jpeg,pdf,doc,docx,xls,xlsx,txt,mov,mp4,ogg格式";
//                }
//            }
//            return null;
//        }
//        public static string CheckFile(HttpPostedFileBase file, string[] filetype)
//        {
//            if (file != null)
//            {
//                //if (file.ContentLength > 204800)
//                //{
//                //    return "檔案大小過大  請勿大於200kb ";
//                //}
//                //var supportedTypes = new[] { "jpg", "jpeg", "pdf", "doc", "docx", "xls", "xlsx", "txt", "mov", "mp4", "ogg" };
//                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);

//                if (!filetype.Contains(fileExt))
//                {
//                    return "檔案格式錯誤  請上傳" + String.Concat(filetype) + "格式";
//                }
//            }
//            return null;
//        }

//        public static void uploadFile(HttpPostedFileBase File, string TableName, Guid Guid)
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/";

//            if (File != null && File.ContentLength > 0)
//            {
//                if (!Directory.Exists(HttpContext.Current.Server.MapPath(dir)))
//                {
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir));
//                }
//                var webpath = Path.Combine(HttpContext.Current.Server.MapPath(dir), File.FileName);
//                File.SaveAs(webpath);

//            }
//        }
//        public static void uploadFile(HttpPostedFileBase File, string TableName, Guid Guid, string FileName)
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/";

//            if (File != null && File.ContentLength > 0)
//            {
//                if (!Directory.Exists(HttpContext.Current.Server.MapPath(dir)))
//                {
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir));
//                }
//                var webpath = Path.Combine(HttpContext.Current.Server.MapPath(dir), FileName + Path.GetExtension(File.FileName));
//                File.SaveAs(webpath);

//            }
//        }
//        public static void deleteFile(string TableName, Guid Guid)
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/" + TableName + "/" + Guid.ToString() + "/";

//            if (Directory.Exists(HttpContext.Current.Server.MapPath(dir)))//資料夾存在 
//            {
//                //delete
//                try
//                {
//                    Directory.Delete(HttpContext.Current.Server.MapPath(dir), true);
//                }
//                catch (Exception e)
//                {
//                    EventLog.Write(e.Message);
//                }
//            }
//        }

//        public static void uploadPDF(HttpPostedFileBase File, Guid Guid)
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/EDM/" + Guid.ToString() + "/";

//            if (File != null && File.ContentLength > 0)
//            {
//                if (!Directory.Exists(HttpContext.Current.Server.MapPath(dir)))//Current = null?
//                {
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir));
//                }
//                var webpath = Path.Combine(HttpContext.Current.Server.MapPath(dir), "edm.pdf");
//                File.SaveAs(webpath);

//            }
//        }
//        public static void deleteEDM(Guid Guid)
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/EDM/" + Guid.ToString() + "/";

//            if (Directory.Exists(HttpContext.Current.Server.MapPath(dir)))//資料夾存在 
//            {
//                //delete
//                try
//                {
//                    Directory.Delete(HttpContext.Current.Server.MapPath(dir), true);
//                }
//                catch (Exception e)
//                {
//                    EventLog.Write(e.Message);
//                }
//            }
//        }

//        public static void uploadPDFImage(HttpPostedFileBase imageControl, int index)
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/EDM/" + "TEMP" + "/";

//            if (imageControl != null && imageControl.ContentLength > 0)
//            //上傳路徑記得改掉
//            {
//                if (!Directory.Exists(HttpContext.Current.Server.MapPath(dir)))
//                {
//                    //新增TEMP資料夾
//                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir));
//                }
//                //save picture
//                var webpath = Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.EDM_large + "_" + index + ".jpg");
//                imageControl.SaveAs(webpath);
//                //resize and save picture
//                Resize(webpath, Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.EDM_middle + "_" + index + ".jpg"), GlobalData.EDMMiddleScaleFactor);
//                Resize(webpath, Path.Combine(HttpContext.Current.Server.MapPath(dir), GlobalData.EDM_small + "_" + index + ".jpg"), GlobalData.EDMSmallScaleFactor);
//            }
//        }

//        public static bool ChangeFileName(Guid guid)
//        {
//            string dirTemp = "~/" + GlobalData.ImageDir + "/EDM/" + "TEMP" + "/";
//            string dirGuid = "~/" + GlobalData.ImageDir + "/EDM/" + guid.ToString() + "/";
//            if (!Directory.Exists(HttpContext.Current.Server.MapPath(dirTemp)))
//            {
//                //TEMP資料夾不存在
//                //Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dir));
//                return false;
//            }
//            else
//            {
//                Directory.Move(HttpContext.Current.Server.MapPath(dirTemp), HttpContext.Current.Server.MapPath(dirGuid));
//                return true;
//            }
//        }

//        public static void deleteTemp()
//        {
//            string dir = "~/" + GlobalData.ImageDir + "/EDM/" + "TEMP" + "/";

//            if (Directory.Exists(HttpContext.Current.Server.MapPath(dir)))//資料夾存在 
//            {
//                //delete
//                try
//                {
//                    Directory.Delete(HttpContext.Current.Server.MapPath(dir), true);
//                }
//                catch (Exception e)
//                {
//                    EventLog.Write(e.Message);
//                }
//            }
//        }

//        public static string CheckPDF(HttpPostedFileBase file)
//        {
//            if (file != null)
//            {
//                //if (file.ContentLength > 204800)
//                //{
//                //    return "檔案大小過大  請勿大於200kb ";
//                //}
//                var supportedTypes = new[] { "pdf" };

//                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);

//                if (!supportedTypes.Contains(fileExt))
//                {
//                    return "檔案格式錯誤  請上傳pdf格式";
//                }
//            }
//            return null;
//        }

//        public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
//        {
//            using (MemoryStream ms = new MemoryStream())
//            {
//                // Convert Image to byte[]
//                image.Save(ms, format);
//                byte[] imageBytes = ms.ToArray();

//                // Convert byte[] to Base64 String
//                string base64String = Convert.ToBase64String(imageBytes);
//                return base64String;
//            }
//        }

//        public static string GetYoutubeMoveCode(string url)
//        {
//            //分割string字串
//            //https://www.youtube.com/watch?v=X5MiQ6WF1Hs&list=RDX5MiQ6WF1Hs
//            //
//            string[] split = { "?", "&", "=" };//使用=來分割字串
//            string[] result = url.Split(split, StringSplitOptions.RemoveEmptyEntries);

//            int index = 0;
//            foreach (string s in result)
//            {
//                index++;
//                if (s == "v")
//                {
//                    break;
//                }
//            }

//            return result[index];
//        }

//        public static string[] GetMarqueeInfo(string hyperlink)
//        {

//            return null;
//        }

//        public static List<string> GetFullPathFilesInFloder(string folderPath, string specialFileName, string[] extensions)
//        {
//            var p = HttpContext.Current.Server.MapPath(folderPath);
//            if (System.IO.Directory.Exists(p))//如果有資料夾
//            {
//                var files = System.IO.Directory.GetFiles(p);
//                List<string> fileList = new List<string>();

//                foreach (string fname in files)
//                {
//                    var path = fname.Replace("C:", "").Replace("\\", "/");

//                    if (extensions != null)
//                    {
//                        foreach (string ext in extensions)
//                        {
//                            if (Path.GetExtension(fname).Equals(ext))
//                            {
//                                if (specialFileName != null)
//                                {
//                                    if (Path.GetFileNameWithoutExtension(fname).Contains(specialFileName))
//                                        fileList.Add(path);

//                                    continue;
//                                }

//                                fileList.Add(path);
//                            }

//                        }

//                    }
//                    else
//                    {
//                        fileList.Add(path);
//                    }

//                }
//                if (fileList.Count() == 0)
//                    throw new FileNotExistException(p);

//                return fileList;
//            }

//            throw new FileNotExistException(p);
//        }

//        public static List<string> GetFullPathFilesInFloder(string folderPath, string specialFileName, string extension)
//        {
//            return GetFullPathFilesInFloder(folderPath, specialFileName, new string[] { extension });
//        }

//        public static List<string> GetFullPathFilesInFloder(string folderPath, string[] extensions)
//        {
//            return GetFullPathFilesInFloder(folderPath, null, extensions);
//        }

//        public static List<string> GetFullPathFilesInFloder(string folderPath, string extension)
//        {
//            return GetFullPathFilesInFloder(folderPath, null, new string[] { extension });
//        }

//        //Get all files is insecure, because there are perhaps some hided filein the folder
//        //20141002 By Jim
//        //public static List<string> GetFilesInFloder(string folderPath)
//        //{
//        //    return GetFullPathFilesInFloder(folderPath, null);
//        //}

//        public static string CryptographyPassword(string password, string salt)
//        {
//            string cryptographyPassword =
//                FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, "sha1");
//            return cryptographyPassword;
//        }

//        public static string ToCsv(IEnumerable<string> source)
//        {
//            if (source == null) throw new ArgumentNullException("source");
//            return string.Join("\r\n", source.Select(s => s.ToString()).ToArray());
//        }

//        public static bool IsValid(string emailaddress)
//        {
//            try
//            {
//                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(emailaddress);

//                return true;
//            }
//            catch (FormatException)
//            {
//                return false;
//            }
//        }

//    }

//}