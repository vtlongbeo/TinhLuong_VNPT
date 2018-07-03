using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;
using TinhLuongINFO;

namespace TinhLuong.Controllers
{
    public class TinhLuongKH_FiberController : BaseController
    {
        // GET: TinhLuongKH_Fiber
        public ActionResult Index()
        {
            DMLoaiLuong();
            DMdrpNam();
            DMdrpThang();
            DMLoaiDV();
            return View();
        }

        public ActionResult TinhLuong(int drpNam, int drpThang,string LoaiLuong, string LoaiDV)
        {
            int SoTien = 0;
            DMLoaiLuong(LoaiLuong);
            DMLoaiDV(LoaiDV);
            DMdrpNam(drpNam.ToString());
            DMdrpThang(drpThang.ToString());
            ViewBag.Type = LoaiLuong;
            ViewBag.SoTien = SoTien;
            DataTable rs= new DataTable();
            if (new ImportExcelBLL().GetChotSo(drpThang, drpNam, Session[SessionCommon.DonViID].ToString(), "BangLuong") == false)
            {
                setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
            }
            else
            {
                 rs = new TinhLuongBoSungQuyBLL().TinhLuongKH_Fiber(drpThang, drpNam, LoaiLuong, SoTien, LoaiDV);
                if (rs.Rows.Count > 0) setAlert("Tính toán thành công", "success");
                
            }
            return View(rs);


        }
        public void DMdrpThang(string selected = null)
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
        public void DMdrpNam(string selected = null)
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

        public void DMLoaiLuong(string selected = null)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "Lương fiber",
                Value = "FIBER"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Lương lưu lượng",
                Value = "LL"
            });
            //listItems.Add(new SelectListItem
            //{
            //    Text ="Lương kế hoạch",
            //    Value = "KH"
            //});
            ViewBag.LoaiLuong = new SelectList(listItems, "Value", "Text", selected);
        }

        public void DMLoaiDV(string selected = null)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "Khối quản lý ",
                Value = "KQL"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Trung tâm CNTT",
                Value = "THC"
            });
           
            ViewBag.LoaiDV = new SelectList(listItems, "Value", "Text", selected);
        }

    }
}