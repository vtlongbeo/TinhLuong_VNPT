using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;
using TinhLuongINFO;

namespace TinhLuong.Controllers
{
    public class PhanQuyenController : BaseController
    {
        SaveLog sv = new SaveLog();
        // GET: PhanQuyen
        PhanQuyenBLL bll = new PhanQuyenBLL();
        [CheckCredential(RoleID = "VIEWS_DS_ROLES")]
        public ActionResult Index()
        {
          //  sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan");
            var rs = bll.GetAll_DM_User();
            return View(rs);
        }


        [CheckCredential(RoleID = "VIEWS_DS_ROLES")]
        public JsonResult Change_IsActive(string UserName)
        {
            if (Session[SessionCommon.Username].ToString().ToLower() != UserName.ToLower())
            {
                var rs = bll.Change_IsActive(UserName);
                if (rs == 1)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->Active User thanh cong- user-" + UserName);
                    setAlert("Active User thành công!", "success");
                }
                else if (rs == 0)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->Lock User thanh cong- user-" + UserName);
                    setAlert("Lock User thành công!", "success");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->Xảy ra lỗi k câp nhat- user-" + UserName);

                    setAlert("Xảy ra lỗi trong quá trình thực thi", "error");
                }
                return Json(new
                {
                    status = rs
                });
            }
            else setAlert("Không thể tự thao tác với tài khoản của chính bạn?", "error");
            return Json(new
            {
                status = -11
            });
        }

        public ActionResult GetAllRole_User(string UserName)
        {
            ViewBag.UserName = UserName;
            var groupid = bll.GetGroup_UserName(UserName);
            LoadGroup(groupid.ToString());
            return View();
        }

        ///load nhóm quyền
        ///
        public void loadDrpDonVi(string selected = null)
        {
            var rs = bll.GetAll_DM_DonVi();
            ViewBag.DonViID = new SelectList(rs, "DonViID", "TenDonVi", selected);
        }
        public void LoadGroup(string selected = null)
        {
            var bs = bll.getAll_DM_Group();
            ViewBag.GroupID = new SelectList(bs, "GroupID", "GroupName", selected);
        }


        [CheckCredential(RoleID = "UPDATE_ROLE")]
        public ActionResult Update_Group_User(string UserName, string GroupID)
        {
            if (Session[SessionCommon.Username].ToString().ToLower() != UserName.ToLower())
            {
                var rs = bll.Update_User_Group(UserName, GroupID);
                if (rs > 0)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->Cap quyen- user-" + UserName + "-group-" + GroupID + "-Success");
                    setAlert("Cập nhật quyền hệ thống thành công", "success");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->Cap quyen- user-" + UserName + "-group-" + GroupID + "-Fail");
                    setAlert("Xảy ra lỗi trong quá trình thực thi!", "error");
                }
            }
            else setAlert("Không thể tự thao tác với tài khoản của chính bạn?", "error");
            return Redirect("/phanquyen");
        }


        //thêm mới user
        [CheckCredential(RoleID = "ADD_USER")]
        public ActionResult AddNewAcc()
        {
           // sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->AddNewAcc");
            loadDrpDonVi();
            LoadGroup();
            return View();
        }


        //thêm mới user
        [CheckCredential(RoleID = "VIEWS_DS_ROLES")]
        [HttpPost]
        public ActionResult AddNewAcc(DM_Users user)
        {
            var passD = bll.GetPassDefault();
            user.PassWord = EnDeCryptMD5.Encrypt(passD, "salary", true);
            if (bll.CheckUser(user.UserName) == "NOT_EXISTS")
            {
                var rs = bll.Insert_User(user);
                if (rs > 0)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->AddNewAcc-Them thanh cong user-" + user.UserName);
                    setAlert("Thêm tài khoản thành công", "success");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->AddNewAcc-Them that bai user-" + user.UserName);
                    setAlert("Xảy ra lỗi trong quá trình thực thi", "error");
                }
            }
            else
            {
                sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->AddNewAcc-Them that bai user-" + user.UserName + "-do trung tai khoan");
                setAlert("Tài khoản đã tồn tại trong hệ thống. Vui lòng chọn tài khoản khác!", "error");
            }
            return Redirect("/phanquyen");
        }

        /// <summary>
        /// Xóa user
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        [CheckCredential(RoleID = "VIEWS_DS_ROLES")]
        public JsonResult DeleteUser(string UserName)
        {
            if (Session[SessionCommon.Username].ToString().ToLower() != UserName.ToLower())
            {
                var rs = bll.Delete_User(UserName);
                if (rs > 0)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->DeleteAcc-Xóa thanh cong user-" + UserName);
                    setAlert("Xóa tài khoản thành công", "success");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->Delete-Xoa khong thanh cong user-" + UserName);
                    setAlert("Xảy ra lỗi thực thi!", "error");
                }
            }
            else setAlert("Không thể tự thao tác với tài khoản của chính bạn?", "error");
            return Json(new
            {
                status = 10
            });
        }

        /// <summary>
        /// Reset mật khẩu
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public JsonResult ResetPass(string UserName)
        {
            if (Session[SessionCommon.Username].ToString().ToLower() != UserName.ToLower())
            {
                var passD = bll.GetPassDefault();
                var passEnC = EnDeCryptMD5.Encrypt(passD, "salary", true);
                var rs = bll.ResetPass(UserName, passEnC);
                if (rs > 0)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->ResetPass-thanh cong user-" + UserName + "-pass-" + passD);
                    setAlert("Cập nhật mật khẩu thành công. Mật khẩu mặc định là " + passD, "success");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Tai khoan->ResetPass-khong thanh cong user-" + UserName + "-pass-" + passD);
                    setAlert("Xảy ra lỗi thực thi!", "error");
                }
            }
            else setAlert("Không thể tự thao tác với tài khoản của chính bạn?", "error");
            return Json(new
            {
                status = 10
            });
        }
    }
}