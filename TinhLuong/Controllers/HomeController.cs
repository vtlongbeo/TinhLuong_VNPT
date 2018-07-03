using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;

namespace TinhLuong.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult MenuTop()
        {
            var rs = new HomeBLL().GetOne_DM_Users(Session[SessionCommon.Username].ToString());
            return PartialView(rs);
        }

        public ActionResult ChangePassword()
        {
            return PartialView();
        }
        public JsonResult ChangePasswordAction(string NewPassword, string OldPassword)
        {
            var rs = new HomeBLL().ChangePassword(Session[SessionCommon.Username].ToString(), EnDeCryptMD5.Encrypt(OldPassword, "salary", true), EnDeCryptMD5.Encrypt(NewPassword, "salary", true));
            if (rs == 1) Session.Abandon();
            return Json(new
            {
                status = rs
            });
        }
        public ActionResult RoleLimit()
        {
            return View();
        }



    }
}