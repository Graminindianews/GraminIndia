using GraminIndia.Areas.Admin.Model;
using GraminIndia.Areas.Admin.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraminIndia.Areas.Admin.Controllers
{
    public class AddNewsController : Controller
    {
        public ActionResult AddNews()
        {
            if (Session["AdminLoginId"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("~/AdminLogin.aspx");
            }
        }
        [HttpPost]
        public JsonResult SaveNews(News news)
        {
            try
            {
                HttpFileCollectionBase files = Request.Files;
                news.ImageUrlA = "";
                news.ImageUrlB = "";
                news.ImageUrlC = "";
                if (Request.Files.Count > 0)
                {
                    if (Request.Files.Count == 1)
                    {
                        news.ImageUrlA = Uploadfile(files[0]);
                    }
                    if (Request.Files.Count == 2)
                    {
                        news.ImageUrlA = Uploadfile(files[0]);
                        news.ImageUrlB = Uploadfile(files[1]);
                    }
                    if (Request.Files.Count == 3)
                    {
                        news.ImageUrlA = Uploadfile(files[0]);
                        news.ImageUrlB = Uploadfile(files[1]);
                        news.ImageUrlC = Uploadfile(files[2]);
                    }
                }
                using (var repo = new NewsRepository())
                {
                    var data = repo.InsertNews(news);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public string Uploadfile(HttpPostedFileBase file)
        {
            string fname = "";
            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
            {
                string[] testfiles = file.FileName.Split(new char[] { '\\' });
                fname = testfiles[testfiles.Length - 1];
            }
            else
            {
                fname = file.FileName;
            }
            //fname = string.Format("{0:ddMMyyyyhhmmss}", DateTime.Now) + "_news" + Path.GetExtension(file.FileName);
            fname = string.Format("{0:ddMMyyyyhhmmss}", DateTime.Now) + Path.GetExtension(file.FileName);
            var filepath = Path.Combine(Server.MapPath("~/Upload/UploadNews/"), fname);
            fname = "~/Upload/UploadNews/" + fname;
            file.SaveAs(filepath);
            return fname;
        }

        [HttpGet]
        public JsonResult GetNews()
        {
            try
            {
                using (var repo = new NewsRepository())
                {
                    var data = repo.GetNewsList();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpPost]
        public JsonResult ViewNews(int id)
        {
            try
            {
                //byte[] cover = GetImageFromDataBase(id);
                using (var repo = new NewsRepository())
                {
                    var data = repo.ViewNewsDetails(id);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}