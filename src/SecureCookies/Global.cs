using System;
using System.Web;

namespace SecureCookies
{
    public class Global : Umbraco.Web.UmbracoApplication
    {
      public void Init(HttpApplication application)
      {
          application.EndRequest += (new EventHandler(this.Application_EndRequest));
      }
    
      private void Application_EndRequest(object sender, EventArgs e)
      {
          if (Response.Cookies.Count > 0)
            {
                foreach (string s in Response.Cookies.AllKeys)
                {
                         Response.Cookies[s].Secure = true;
                         Response.Cookies[s].HttpOnly = true;
                }
            }
      }

    }
}

