using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace INCLOUD
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["numberOfUsers"] = 0;
            Application["numberOfOnlineUsers"] = 0;
            Application["stars"] = 0;
            Application["starsCount"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Session["fails"] = 0;
            Application["numberOfUsers"] = (int)Application["numberOfUsers"] + 1;
            Application["numberOfOnlineUsers"] = (int)Application["numberOfOnlineUsers"] + 1;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["numberOfOnlineUsers"] = (int)Application["numberOfOnlineUsers"] - 1;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}