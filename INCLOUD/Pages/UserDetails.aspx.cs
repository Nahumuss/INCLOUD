using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INCLOUD.Pages
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else if (Request.Form["submit"] != null)
            {
                MyADOHelper.Update(Session["email"].ToString(), "username", Request.Form["username"]);
                MyADOHelper.Update(Session["email"].ToString(), "firstname", Request.Form["finame"]);
                MyADOHelper.Update(Session["email"].ToString(), "lastname", Request.Form["laname"]);
                MyADOHelper.Update(Session["email"].ToString(), "password", Request.Form["passmake"]);
                MyADOHelper.Update(Session["email"].ToString(), "bdate", Request.Form["bdate"]);
                MyADOHelper.Update(Session["email"].ToString(), "country", Request.Form["country"]);
            }
            else
            {
                Session["username"] = MyADOHelper.Select(Session["email"].ToString(), "username");
                Session["finame"] = MyADOHelper.Select(Session["email"].ToString(), "firstname");
                Session["laname"] = MyADOHelper.Select(Session["email"].ToString(), "lastname");
                Session["password"] = MyADOHelper.Select(Session["email"].ToString(), "password");
                Session[MyADOHelper.Select(Session["email"].ToString(), "gender").ToString()] = "checked";
                Session["country"] = MyADOHelper.Select(Session["email"].ToString(), "country");
                string bdate = MyADOHelper.Select(Session["email"].ToString(), "bdate").ToString();
                bdate = bdate.Remove(bdate.LastIndexOf('/') + 5);
                string newstr = "";
                string[] arr = new string[3];
                arr = bdate.Split('/');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Length < 2)
                    {
                        string num = arr[i];
                        arr[i] = "0" + num;
                    }
                }
                newstr += arr[2] + '-';
                newstr += arr[1] + '-';
                newstr += arr[0];
                Session["bdate"] = newstr;
            }
        }
    }
}