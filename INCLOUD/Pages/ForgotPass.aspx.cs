using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace INCLOUD.Pages
{
    public partial class ForgotPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
            Random rnd = new Random();
            if (Request.Form["submit"] != null)
            {
                if (MyADOHelper.Exist(Request.Form["email"]))
                {
                    ClientScript.RegisterStartupScript(GetType(), "Send Mail Message", "sendMailMessage(true);", true);
                    Session["v"] = rnd.Next(99999999);
                    Session["changePassEmail"] = Request.Form["email"];
                    MailMessage mail = new MailMessage();
                    mail.To.Add(Request.Form["email"]);
                    mail.From = new MailAddress("itaynahumcloud@gmail.com");
                    mail.Subject = "INCloud Password Change";
                    mail.Body = "Click this link to change your password: \n http://localhost:57646/Pages/ChangePass.aspx?v=" + (int)Session["v"] + "&m=" + Request.Form["email"];
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("itaynahumcloud@gmail.com", "itay2003");
                    smtp.Send(mail);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Send Mail Message", "sendMailMessage(false);", true);
                }
            }
        }
    }
}