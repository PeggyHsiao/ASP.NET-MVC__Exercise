using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace projFileUpload.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Create()
        {
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase[] photos)
        {
            //string FileName = "";

            //if (photo != null)
            //{
            //    if (photo.ContentLength > 0)
            //    {
            //        FileName = Path.GetFileName(photo.FileName);
            //        var path = Path.Combine(Server.MapPath("~/Photos"), FileName);

            //        photo.SaveAs(path);
            //    }
            //}

            string fname = "";

            for (int i = 0; i < photos.Length; i++)
            {
                HttpPostedFileBase f = (HttpPostedFileBase)photos[i];

                if (f != null)
                {
                    fname = f.FileName.Substring(f.FileName.LastIndexOf("\\") + 1);
                    f.SaveAs(Server.MapPath("~/Photos") + "\\" + fname);
                }
            }
            return RedirectToAction("ShowPhotos");
        }

        public string ShowPhotos()
        {
            string show = "";
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Photos"));

            FileInfo[] fInfo = dir.GetFiles();

            int n = 0;

            foreach (FileInfo result in fInfo)
            {
                n++;

                show += "<a href='../Photos/" + result.Name + "' target='_blank'><img src='../Photos/" + result.Name + "' width='90' height='60' border='0'></a> ";

                if (n % 4 == 0)
                {
                    show += "<p>";
                }
            }
            show += "<p><a href='Create'>BACK</a></p>";

            return show;
        }
    }
}