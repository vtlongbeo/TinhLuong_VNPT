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
    public class TinhLuongBS_Ver1Controller : BaseController
    {
        // GET: TinhLuongBS_Ver1
        [CheckCredential(RoleID = "TINH_LUONGBOSUNG")]
        public ActionResult Index()
        {
            drpNam(DateTime.Now.Year.ToString());
            drpThang(DateTime.Now.Month.ToString());
            drpNam1(DateTime.Now.Year.ToString());
            return View();
        }

        public void drpThang(string selected = null)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "1",
                Value = "1"
            });
            listItems.Add(new SelectListItem
            {
                Text = "2",
                Value = "2",
            });
            listItems.Add(new SelectListItem
            {
                Text = "3",
                Value = "3"
            });
            listItems.Add(new SelectListItem
            {
                Text = "4",
                Value = "4"
            });
            listItems.Add(new SelectListItem
            {
                Text = "5",
                Value = "5"
            });
            listItems.Add(new SelectListItem
            {
                Text = "6",
                Value = "6"
            });
            listItems.Add(new SelectListItem
            {
                Text = "7",
                Value = "7"
            });
            listItems.Add(new SelectListItem
            {
                Text = "8",
                Value = "8"
            });
            listItems.Add(new SelectListItem
            {
                Text = "9",
                Value = "9"
            });
            listItems.Add(new SelectListItem
            {
                Text = "10",
                Value = "10"
            });
            listItems.Add(new SelectListItem
            {
                Text = "11",
                Value = "11"
            });
            listItems.Add(new SelectListItem
            {
                Text = "12",
                Value = "12"
            });
            ViewBag.drpThang = new SelectList(listItems, "Value", "Text", selected);
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

        public void drpNam1(string selected = null)
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
            ViewBag.drpNam1 = new SelectList(listItems, "Value", "Text", selected);
        }

        [CheckCredential(RoleID = "TINH_LUONGBOSUNG")]
        public ActionResult TinhLuong(decimal drpThang, decimal drpNam, string DienGiai, decimal drpNam1, DateTime NgayCK)
        {
            //Session.Add(SessionCommon.Thang, quy);
            //Session.Add(SessionCommon.nam, nam);
            string ngayck = NgayCK.Day+"/"+NgayCK.Month +"/" + NgayCK.Year;
            var rs = new TinhLuongBoSungQuyBLL().TinhLuongBoSung(drpNam,DienGiai,ngayck,drpThang,drpNam1,Session[SessionCommon.Username].ToString());
            if (rs)
            {
                setAlert("Tính toán dữ liệu thành công!", "success");
                return Redirect("/TinhLuongBS_Ver1");
            }
            else
            {
                setAlert("Cập nhật thất bại", "error");
                return Redirect("/TinhLuongBS_Ver1");
            }

        }
    }
}