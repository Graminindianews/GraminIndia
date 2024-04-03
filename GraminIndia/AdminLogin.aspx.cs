using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.Helper;
using Website.Models;
using Website.Repository;

namespace GraminIndia
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
		protected void btnLogin_Click(object sender, EventArgs e)
		{
			LoginModel model = new LoginModel();
			LoginRepository repo = new LoginRepository();
			try
			{
				string UserName = txtUserName.Text.ToString();
				string Password = txtPassword.Text.ToString();

				if (!String.IsNullOrEmpty(UserName) || !String.IsNullOrEmpty(UserName))
				{
					string ePaasword = Stringcl.Encrypt(Password);
					model = repo.GetLoginDetail(UserName, ePaasword);
					if (model.UserId > 0)
					{
						Session["AdminLoginId"] = model.UserId;
						Session["UserName"] = model.LoginName;
						Response.Redirect("Admin/Dashboad/Dashboard", false);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}