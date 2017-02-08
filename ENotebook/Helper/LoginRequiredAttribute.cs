using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENotebook.Helper
{
    public class LoginRequiredAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["UserId"] == null)
            {
                if (
                    HttpContext.Current.Request.Cookies["EMail"] != null
                    &&
                    HttpContext.Current.Request.Cookies["Password"] != null
                    )
                {
                    string userId = HttpContext.Current.Request.Cookies["EMail"].Value;
                    string password = HttpContext.Current.Request.Cookies["Password"].Value;
                    LoginHelper helper = new LoginHelper();
                    bool loginSuccessed = helper.LoginUser(userId, password, "on", HttpContext.Current);
                    if (!loginSuccessed)
                    {
                        filterContext.Result = new RedirectResult("~/Login", true);
                    }

                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Login", true);
                }
            }
        }
    }
}