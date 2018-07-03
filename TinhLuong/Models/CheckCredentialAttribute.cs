using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace TinhLuong.Models
{
    public class CheckCredentialAttribute : AuthorizeAttribute
    {
        public string RoleID { set; get; }
        public static string sess = null;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var session = HttpContext.Current.Session[SessionCommon.Username];

            var groupid = HttpContext.Current.Session[SessionCommon.GroupID];
            if (session == null)
            {
                sess = null;
                return false;
            }
            else
            {
                sess = session.ToString();
            }

            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.ToString()); // Call another method to get rights of the user from DB

            if (privilegeLevels.Contains(this.RoleID)|| session.ToString()=="admin")
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Home/RoleLimit");
                return false;
            }

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (sess == null)
            {
                filterContext.HttpContext.Response.Redirect("/dang-nhap");
                //filterContext.RouteData.Values["area"] = "Admin";
                //filterContext.RouteData.Values["controller"] = "Login";
                //filterContext.RouteData.Values["action"] = "Index";
                //    filterContext.Result = new ViewResult
                //    {
                //        //ViewName = "~/Areas/Admin/Views/Login/Index.cshtml";
                //        vi
                //};
            }
            else
            {

                filterContext.Result = new ViewResult
                {

                    ViewName = "~/Views/Home/RoleLimit.cshtml"
                };
            }

        }
        private List<string> GetCredentialByLoggedInUser(string userName)
        {
            var credentials = (List<string>)HttpContext.Current.Session[SessionCommon.SESSION_CREDENTIALS];
            return credentials;
        }
    }
}