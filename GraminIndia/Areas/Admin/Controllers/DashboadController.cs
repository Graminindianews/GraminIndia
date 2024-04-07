using GraminIndia.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraminIndia.Areas.Admin.Controllers
{
    public class DashboadController : Controller
    {
        public ActionResult Dashboard()
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
    }
}