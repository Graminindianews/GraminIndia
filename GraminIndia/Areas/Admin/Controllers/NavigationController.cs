using GraminIndia.Areas.Admin.Model;
using GraminIndia.Areas.Admin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraminIndia.Areas.Admin.Controllers
{
    public class NavigationController : Controller
    {
        public ActionResult SectionModule()
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
        public JsonResult GetNavigation()
        {
            try
            {
                using (var repo = new NavigationRepository())
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
        public JsonResult AddNavigation(Navigation Navi)
        {
            try
            {
                using (var repo = new NavigationRepository())
                {
                    var data = repo.AddNavigation(Navi);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpGet]
        public JsonResult EditNavigation(int id)
        {
            try
            {
                using (var repo = new NavigationRepository())
                {
                    var data = repo.EditNavi(id);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpPost]
        public JsonResult UpdateNavigation(Navigation Navi)
        {
            try
            {
                using (var repo = new NavigationRepository())
                {
                    var data = repo.UpdateNavigation(Navi);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpPost]
        public JsonResult DeleteNavigation(int id)
        {
            try
            {
                using (var repo = new NavigationRepository())
                {
                    var data = repo.DeleteNavigation(id);
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