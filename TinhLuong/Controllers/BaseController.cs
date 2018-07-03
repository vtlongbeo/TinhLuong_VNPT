using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TinhLuong.Models;

namespace TinhLuong.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sess = Session[SessionCommon.Username];

            //var sess2 = Session[LoginSession.USER_SESSION];
            if (sess == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { Controller = "Login", action = "Index" }));
                Session.Abandon();
                filterContext.HttpContext.Response.Redirect("/dang-nhap");
            }
            else if (sess != null)
            {
                //var getMTT = new LoginBLL().GetOneAdmin_User(sess.ToString());
                //if (getMTT.Status == false && sessGroupID.ToString() != CommonConst.ADMIN_GROUP)
                //{
                //    Session.Abandon();
                //    filterContext.Result = new RedirectToRouteResult(new
                //    RouteValueDictionary(new { Controller = "Login", action = "Index", Area = "Admin" }));
                //    filterContext.HttpContext.Response.Redirect("/dang-nhap-quan-tri");
                //}
            }
            base.OnActionExecuting(filterContext);
        }

        public void setAlert(string mssg, string type)
        {
            TempData["AlertMessage"] = mssg;
            switch (type)
            {
                case "success":
                    {
                        TempData["AlertType"] = "alert-success";
                        break;
                    }
                case "warning":
                    {
                        TempData["AlertType"] = "alert-warning";
                        break;
                    }
                case "error":
                    {
                        TempData["AlertType"] = "alert-error";
                        break;
                    }
                case "info":
                    {
                        TempData["AlertType"] = "alert-info";
                        break;
                    }
                case "dark":
                    {
                        TempData["AlertType"] = "alert-dark";
                        break;
                    }
            }

        }
        protected void setAlertTime(string mssg, string type)
        {
            TempData["AlertMessageTime"] = mssg;
            switch (type)
            {
                case "success":
                    {
                        TempData["AlertTypeTime"] = "alert-success";
                        break;
                    }
                case "warning":
                    {
                        TempData["AlertTypeTime"] = "alert-warning";
                        break;
                    }
                case "error":
                    {
                        TempData["AlertTypeTime"] = "alert-error";
                        break;
                    }
                case "info":
                    {
                        TempData["AlertTypeTime"] = "alert-info";
                        break;
                    }
                case "dark":
                    {
                        TempData["AlertTypeTime"] = "alert-dark";
                        break;
                    }
            }
        }
    }
}