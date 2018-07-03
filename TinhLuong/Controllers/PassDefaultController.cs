using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;

namespace TinhLuong.Controllers
{
    public class PassDefaultController : BaseController
    {
        // GET: PassDefault
        SaveLog sv = new SaveLog();
        [CheckCredential(RoleID = "PASS_DEFAULT")]
        public ActionResult Index()
        {
          //  sv.save(Session[SessionCommon.Username].ToString(), "He thong->Mat khau mac dinh");
            ViewBag.PassDefault = new PhanQuyenBLL().GetPassDefault();
            return View();
        }
        [HttpGet]
        public ActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePass(string NewPass)
        {
            if (!string.IsNullOrWhiteSpace(NewPass))
            {
                var rs = new PhanQuyenBLL().ChangePass_Default(NewPass);
                if (rs > 0)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Mat khau mac dinh->Thay doi mat khau thanh cong-pass-" + NewPass);
                    setAlert("Thay đổi mật khẩu mặc định thành công", "success");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Mat khau mac dinh->Thay doi mat khau that bai-pass-"+NewPass);
                    setAlert("Cập nhật thất bại", "error");
                }
            }
            else setAlert("Vui lòng không để trống trường!", "error");
           
            return Redirect("/passdefault");
        }
    }
}