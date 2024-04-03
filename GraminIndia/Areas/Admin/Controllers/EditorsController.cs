using GraminIndia.Areas.Admin.Model;
using GraminIndia.Areas.Admin.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Helper;

namespace GraminIndia.Areas.Admin.Controllers
{
    public class EditorsController : Controller
    {
        public ActionResult UserRegistration()
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
        [HttpGet]
        public JsonResult GetEditors()
        {
            try
            {
                using (var repo = new EditorsRepository())
                {
                    var data = repo.GetNavigationList();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpPost]
        public JsonResult CreateRegistration(Editors editor)
        {
            try
            {
                using (var repo = new EditorsRepository())
                {
                    editor.Password = Stringcl.Encrypt(editor.Password);
                    var data = repo.SaveRegistration(editor);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpGet]
        public JsonResult EditUserRegistration(int id)
        {
            try
            {
                using (var repo = new EditorsRepository())
                {
                    var data = repo.EditEditorRegistration(id);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpPost]
        public JsonResult UpdateEditorRegistration(Editors obj)
        {
            string fname = "";
            try
            {
                HttpFileCollectionBase files = Request.Files;
                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        fname = string.Format("{0 : ddMMyyyyhhmmss}", DateTime.Now) + "_editers" + Path.GetExtension(file.FileName);
                        var filepath = Path.Combine(Server.MapPath("~/Upload/Editors/"), fname);
                        fname = "~/Upload/Editors/" + fname;
                        file.SaveAs(filepath);
                        obj.UserProfilePicture = fname;
                    }
                }
                else
                {
                    obj.UserProfilePicture = "";
                }
                using (var repo = new EditorsRepository())
                {
                    var data = repo.UpdateUsers(obj);
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