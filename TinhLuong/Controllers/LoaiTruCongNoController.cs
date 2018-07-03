using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;

namespace TinhLuong.Controllers
{
    public class LoaiTruCongNoController : Controller
    {
        // GET: LoaiTruCongNo 
        SaveLog sv = new SaveLog();
        [CheckCredential(RoleID = "VIEW_LOAITRUCONGNO")]
        public ActionResult Index()
        {
           // sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Cong no");
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
        /// export to luong khuyến khích lắp đặt
        /// </summary>
        /// <param name="thang"></param>
        /// <param name="nam"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [CheckCredential(RoleID = "VIEW_LOAITRUCONGNO")]
        public ActionResult LuongKKKTReport(int thang, int nam, string type)
        {
            Session.Add(SessionCommon.Thang, thang);
            Session.Add(SessionCommon.nam, nam);
            if (type == "print")
            {
               // sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Cong no->ViewReport-Thang"+thang+"-nam-"+nam);
                string content = "~/Reports/LoaiTruCongNo/LoaiTruCongNo.aspx";
                return Redirect(content);
            }
            return Redirect("/LoaiTruCongNo");

        }

        /// <summary>
        /// load combobox
        /// </summary>
        /// <param name="selected"></param>
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