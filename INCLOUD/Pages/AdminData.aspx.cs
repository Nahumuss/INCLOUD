using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace INCLOUD.Pages
{
    public partial class AdminData : System.Web.UI.Page
    {
        //Connection String
        string gone = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Users.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null || !(bool)Session["isAdmin"])
                Response.Redirect("HomePage.aspx");
            if (Request.Form["update"] != null)
            {
                for (int i = 0; Request.Form["" + i] != null ; i++)
                {
                    if (Request.Form["" + i].ToString()[0] == '@')
                        MyADOHelper.Update(Request.Form["" + i].ToString().Remove(0, 1), "isAdmin", false);
                    else
                        MyADOHelper.Update(Request.Form["" + i].ToString().Remove(Request.Form["" + i].ToString().LastIndexOf(',')), "isAdmin", true);
                }
                for (int i = 0; Request.Form["o" + i] != null; i++)
                {
                    if (Request.Form["o" + i] != null)
                    {
                        //Remove user's files and then user's details
                        using (SqlConnection cn = new SqlConnection(gone))
                        {
                            SqlCommand cmd = new SqlCommand("removeUser", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = Request.Form["o" + i].ToString();
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }
                        MyADOHelper.Delete(Request.Form["o" + i].ToString());
                        if (Session["email"].ToString() == Request.Form["o" + i].ToString())
                            Session.Abandon();
                    }
                }
            }
            
        }
        //Gets table's info
        protected static string GetChart(string email)
        {
            return MyADOHelper.TableOfUsers(email);
        }
    }
}