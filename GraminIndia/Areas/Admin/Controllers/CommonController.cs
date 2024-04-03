using GraminIndia.Areas.Admin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraminIndia.Areas.Admin.Controllers
{
    public class CommonController : Controller
    {
        public ActionResult Index()
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
        public JsonResult GetDesignation()
        {
            try
            {
                using (var repo = new CommonRepository())
                {
                    var data = repo.GetDesignationList();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpGet]
        public JsonResult GetCountry()
        {
            try
            {
                using (var repo = new CommonRepository())
                {
                    var data = repo.GetCountryList();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpGet]
        public JsonResult GetState()
        {
            try
            {
                using (var repo = new CommonRepository())
                {
                    var data = repo.GetStateList();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpGet]
        public JsonResult GetDistrict()
        {
            try
            {
                using (var repo = new CommonRepository())
                {
                    var data = repo.GetDistrictList();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpGet]
        public JsonResult GetSalutation()
        {
            try
            {
                using (var repo = new CommonRepository())
                {
                    var data = repo.GetSalutationList();
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