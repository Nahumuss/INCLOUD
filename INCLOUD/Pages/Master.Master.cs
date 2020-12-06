using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INCLOUD.Pages
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["signout"] != null)
            {
                Session.Abandon();
                Response.Redirect("HomePage.aspx");
            }
            if (Request.Form["starrate"] != null)
            {
                Application["stars"] = (int)Application["stars"] + int.Parse(Request.Form["star"]);
                Application["starsCount"] = (int)Application["starsCount"] + 1;
                Application[Session["email"].ToString()] = true;
            }
        }
    }
}