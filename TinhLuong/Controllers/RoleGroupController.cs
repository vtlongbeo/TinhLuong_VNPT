using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;

namespace TinhLuong.Controllers
{
    public class RoleGroupController : BaseController
    {
        SaveLog sv = new SaveLog();
        // GET: RoleGroup
        PhanQuyenBLL bll = new PhanQuyenBLL();
        [CheckCredential(RoleID = "VIEWS_GROUP_ROLES")]
        public ActionResult Index()
        {
        //    sv.save(Session[SessionCommon.Username].ToString(), "He thong->Phan quyen");
            var rs =bll.getAll_DM_Group();
            return View(rs);
        }

        /// <summary>
        /// Thêm Role
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        [CheckCredential(RoleID = "ASSIGN_ROLE")]
        public ActionResult AddRole(string GroupID)
        {
            //sv.save(Session[SessionCommon.Username].ToString(), "He thong->Phan quyen->Add role->GroupID-" + GroupID);
            Session.Add("GroupID_Role", GroupID);
            ViewBag.GroupName = bll.getName_Group(GroupID);
            ViewBag.RoleGroupID= bll.GetAll_Group_Right_GroupID(GroupID);
            var rs = bll.getAll_DM_Rights();
            return View(rs);
        }

        /// <summary>
        /// Thay đổi trạng thái quyền
        /// </summary>
        /// <param name="RightID"></param>
        /// <returns></returns>
        [CheckCredential(RoleID = "ASSIGN_ROLE")]
        public JsonResult changeSttRole(string RightID)
        {
            sv.save(Session[SessionCommon.Username].ToString(), "He thong->Phan quyen->Cap quyen->Changstt->RightID-" + RightID +"-GroupRole-"+ Session["GroupID_Role"].ToString());
            var rs = bll.Update_Group_Right(RightID, Session["GroupID_Role"].ToString());
            return Json(new
            {
                status = rs
            });
        }


        [CheckCredential(RoleID = "VIEWS_GROUP_ROLES")]
        public ActionResult AddNewGroup()
        {
           // sv.save(Session[SessionCommon.Username].ToString(), "He thong->Phan quyen->Add new group");
            return View();
        }


        [CheckCredential(RoleID = "VIEWS_GROUP_ROLES")]
        [HttpPost]
        public ActionResult AddNewGroup(string GroupName)
        {
            var rs = bll.Insert_DM_Group(GroupName);
            if (rs > 0)
            {
                sv.save(Session[SessionCommon.Username].ToString(), "He thong->Phan quyen->Add new group->Success->Groupname-"+GroupName);
                setAlert("Thêm mới thành công", "success");
            }
            else
            {
                sv.save(Session[SessionCommon.Username].ToString(), "He thong->Phan quyen->Add new group->Fail->Groupname-" + GroupName);
                setAlert("Xảy ra lỗi thực thi", "error");
            }
            return Redirect("/role-group");
        }


        [CheckCredential(RoleID = "VIEWS_GROUP_ROLES")]
        public ActionResult DeleteGroup(string GroupID)
        {
            var rs = bll.Delete_DM_Group(GroupID);
            if (rs > 0)
            {
                sv.save(Session[SessionCommon.Username].ToString(), "He thong->Phan quyen->Delete group->Success->GroupID-" + GroupID);
                setAlert("Xóa thành công", "success");
            }
            else if (rs == 0)
            {
                sv.save(Session[SessionCommon.Username].ToString(), "He thong->Phan quyen->Delete group->Fail->GroupID-" + GroupID);
                setAlert("Xảy ra lỗi thực thi", "error");
            }
            else
            {
                sv.save(Session[SessionCommon.Username].ToString(), "He thong->Phan quyen->Delete group->Fail Dependecies Data->GroupID-" + GroupID);
                setAlert("Không thể xóa bản ghi này do ràng buộc dữ liệu", "error");
            }
            return Redirect("/role-group");
        }
    }
}