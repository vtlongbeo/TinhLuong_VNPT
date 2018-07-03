using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;

namespace TinhLuong.Controllers
{
    public class ChuyenKhoanKy1Controller : BaseController
    {
        // GET: ChuyenKhoanKy1
        public ActionResult Index()
        {
            if (Session[SessionCommon.Thang] == null | Session[SessionCommon.nam] == null)
            {
                drpNam();
                drpThang();
            }
            else
            {
                drpNam(Session[SessionCommon.nam].ToString());
                drpThang(Session[SessionCommon.Thang].ToString());
            }
            return View();
        }

        /// <summary>
        /// gửi tin nhắn chuyển khoản kỳ 1
        /// </summary>
        /// <param name="thang"></param>
        /// <param name="nam"></param>
        /// <returns></returns>
        /// S
        /// 
        SaveLog sv = new SaveLog();
        public ActionResult SendSMS(int thang, int nam)
        {
            SMS.SMSSoapClient ws = new SMS.SMSSoapClient("SMSSoap12");
             var s= ws.SendAlertSalary(thang, 1, Session[SessionCommon.Username].ToString());
            sv.save(Session[SessionCommon.Username].ToString(), "SendSMS CHuyển khoản kỳ 1-thang-" + thang + "-nam-" + nam + "->Success");
            setAlert("Đã gữi tin nhắn tới toàn thể CBNV VTT", "success");
            return Redirect("/ChuyenKhoanKy1");
        }

        //load combobox
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
                Text = (DateTime.Now.Year - 2).ToString(),
                Value = (DateTime.Now.Year - 2).ToString()
            });
            listItems.Add(new SelectListItem
            {
                Text = (DateTime.Now.Year - 1).ToString(),
                Value = (DateTime.Now.Year - 1).ToString(),
            });
            listItems.Add(new SelectListItem
            {
                Text = (DateTime.Now.Year).ToString(),
                Value = (DateTime.Now.Year).ToString()
            });
            listItems.Add(new SelectListItem
            {
                Text = (DateTime.Now.Year + 1).ToString(),
                Value = (DateTime.Now.Year + 1).ToString()
            });
            listItems.Add(new SelectListItem
            {
                Text = (DateTime.Now.Year + 2).ToString(),
                Value = (DateTime.Now.Year +2).ToString()
            });
            ViewBag.drpNam = new SelectList(listItems, "Value", "Text", selected);
        }
    }
}