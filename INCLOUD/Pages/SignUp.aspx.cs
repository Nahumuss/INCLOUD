using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INCLOUD.Pages
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
            if (Request.Form["submit"] != null)
            {
                string email = Request.Form["email"];
                if (MyADOHelper.Exist(email))
                {
                    ClientScript.RegisterStartupScript(GetType(), "Verifyaspx", "aspxVerification(true);", true);
                }
                else
                {
                    MyADOHelper.Insert(email, Request.Form["reguser"], Request.Form["finame"], Request.Form["laname"], Request.Form["passmake"], int.Parse(Request.Form["gender"]), Request.Form["bdate"], Request.Form["country"], char.Parse(Request.Form["securequest"]), Request.Form["secureans"]);
                    if (MyADOHelper.errorMessage != null)
                    {
                        Response.Write(MyADOHelper.errorMessage);
                        MyADOHelper.errorMessage = null;
                    }
                    else
                    {
                        Response.Redirect("SignIn.aspx");
                    }
                }
            }
        }
    }
}