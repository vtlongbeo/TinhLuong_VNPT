using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;
namespace TinhLuong.Controllers
{
    public class ChotSoBSController : BaseController
    {
        ChotSoBLL bll = new ChotSoBLL();
        // GET: ChotSoBS
        [CheckCredential(RoleID = "CHOT_SO")]
        public ActionResult Index()
        {
            drpNam();
            return View();
        }
        [CheckCredential(RoleID = "CHOT_SO")]
        public JsonResult GetListChotSo(int Nam)
        {
            var rs = bll.GetList_ChotSoBS(Nam);
            return Json(new
            {
                data = rs
            }, JsonRequestBehavior.AllowGet);
        }
        [CheckCredential(RoleID = "CHOT_SO")]
        [HttpPost]
        public JsonResult UpdateChotSo(int Nam,int LoaiBS)
        {
            var rs = bll.Tuyen_Update_ChotSoBS(Nam,LoaiBS,Session[SessionCommon.Username].ToString());
            return Json(new
            {
                data = rs
            });
        }
        public void drpNam(string selected = null)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = (DateTime.Now.Year).ToString(),
                Value = (DateTime.Now.Year).ToString()
            });
            listItems.Add(new SelectListItem
            {
                Text = (DateTime.Now.Year - 1).ToString(),
                Value = (DateTime.Now.Year - 1).ToString()
            });
            ViewBag.drpNam = new SelectList(listItems, "Value", "Text", selected);
        }
    }
}