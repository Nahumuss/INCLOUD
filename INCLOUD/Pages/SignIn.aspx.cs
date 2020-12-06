using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INCLOUD.Pages
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["fails"] >= 3)
            {
                Response.Redirect("ForgotPass.aspx");
            }
            else if (Session["email"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else if (Request.Form["submit"] != null)
            {
                if (MyADOHelper.Authentication(Request.Form["email"], Request.Form["password"]))
                {
                    ClientScript.RegisterStartupScript(GetType(), "Login Error", "loginVerification(true);", true);
                    Session["email"] = Request.Form["email"];
                    Session["isAdmin"] = MyADOHelper.ShowIsAdmin(Session["email"].ToString());
                    Session["username"] = MyADOHelper.Select(Session["email"].ToString(), "username");
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Session["fails"] = (int)Session["fails"] + 1;
                    ClientScript.RegisterStartupScript(GetType(), "Login Error", "loginVerification(false);", true);
                }
            }
        }
    }
}