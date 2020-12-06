using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INCLOUD.Pages
{
    public partial class ChangePass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
            if (Request.Form["submit"] != null)
            {
                if (MyADOHelper.IsRightAnswer(Session["changePassEmail"].ToString(), Request.Form["secureVeri"]))
                {
                    ClientScript.RegisterStartupScript(GetType(), "Security Error Message", "securityQuestVeri(true);", true);
                    MyADOHelper.Update(Session["changePassEmail"].ToString(), "password", Request.Form["passmake"]);
                    Session["fails"] = 0;
                    Response.Redirect("SignIn.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Security Error Message", "securityQuestVeri(false);", true);
                }
            }
            if (Request.QueryString["v"] != null && Request.QueryString["m"] != null && Session["v"] != null && Session["changePassEmail"] != null)
            {
                if (Session["changePassEmail"].ToString() == Request.QueryString["m"] && (int)Session["v"] == int.Parse(Request.QueryString["v"]))
                {
                    char securityQuestion = char.Parse((MyADOHelper.Select(Session["changePassEmail"].ToString(), "securequest").ToString()).Replace(" ", String.Empty));
                    switch (securityQuestion)
                    {
                        case 'p':
                            Session["secQuest"] = "What's your pet name?";
                            break;
                        case 'f':
                            Session["secQuest"] = "What's your best friend name?";
                            break;
                        case 'l':
                            Session["secQuest"] = "Where do you live?";
                            break;
                        case 'm':
                            Session["secQuest"] = "What's your mother's last name before she merried?";
                            break;
                        case 's':
                            Session["secQuest"] = "What's the name of the first school you were in?";
                            break;
                        default:
                            Session["secQuest"] = "wtf";
                            break;
                    }
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
            else
            {
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}