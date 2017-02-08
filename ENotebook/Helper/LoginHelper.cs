using Bussiness;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENotebook.Helper
{
    public class LoginHelper
    {
       internal bool LoginUser(string eMail,string password, string rememberMe, HttpContext httpContext)
        {
            User u = new UserBLL().Login(eMail,password);
            if (u!=null)
            {
                httpContext.Session["UserId"] = u.ID;
                httpContext.Session["FullName"] = string.Format("{0} {1}", u.FirstName, u.LastName);
                if (!string.IsNullOrEmpty(rememberMe) && rememberMe == "on")
                {
                    httpContext.Response.Cookies["EMail"].Value = eMail;
                    httpContext.Response.Cookies["EMail"].Expires = DateTime.Now.AddYears(1);
                        
                    httpContext.Response.Cookies["Password"].Value = password;
                    httpContext.Response.Cookies["Password"].Expires = DateTime.Now.AddYears(1);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}