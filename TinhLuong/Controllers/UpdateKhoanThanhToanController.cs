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
    public class UpdateKhoanThanhToanController : BaseController
    {
        SaveLog sv = new SaveLog();
        // GET: UpdateKhoanThanhToan
        [CheckCredential(RoleID = "NHAP_LUONGKY1")]
        public ActionResult Index()
        {
            //sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Cac khoan thanh toan");
            drpThang();
            drpNam();
            return View();
        }
        [CheckCredential(RoleID = "NHAP_LUONGKY1")]
        public ActionResult IndexDetail(int Thang, int Nam)
        {
            //sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Cac khoan thanh toan-thang-" + Thang + "-nam-" + Nam);
            drpNam(Nam.ToString());
            drpThang(Thang.ToString());
            var bangluongk1 = new UpdateKhoanThanhToanBLL().GetBangLuongKyIDonVi(Session[SessionCommon.DonViID].ToString(), Thang, Nam);
            return View(bangluongk1);
        }


        [CheckCredential(RoleID = "NHAP_LUONGKY1")]
        [HttpGet]
        public ActionResult Details(string NhanSuID, int Thang, int Nam)
        {
            DataTable dt = new DataTable();
            //sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Cac khoan thanh toan-> Detail-thang-" + Thang + "-nam-" + Nam + "-NhanSuID-+" + NhanSuID);
            //var bangluongk1_nhanvien = new UpdateKhoanThanhToanBLL().GetBangLuongKy1_ByNhanVien(NhanSuID, Thang, Nam);
            var bangluongk1_nhanvien = new UpdateKhoanThanhToanBLL().GetBangLuongKyIDonVi(Session[SessionCommon.DonViID].ToString(), Thang, Nam);
            var ok = bangluongk1_nhanvien.Select("NhanSuID='" + NhanSuID+"'").CopyToDataTable();
            loadDrpDonVi(ok.Rows[0]["DonViID"].ToString());
            return View(ok);
        }


        [CheckCredential(RoleID = "NHAP_LUONGKY1")]
        public ActionResult UpdateKhoanThanhToan(decimal Thang, decimal Nam, string NhanSuID, string SOTK, decimal ANCA, decimal CTP_KHOANTH, decimal TT_THEMGIO, decimal CHENUOC,
          decimal CTP_KHAC, decimal BOIDUONGK3, decimal THUNHAP1, decimal LUONGKY1, decimal THUNHAP12)
        {
            if (new ImportExcelBLL().GetChotSo(Thang, Nam, Session[SessionCommon.DonViID].ToString(), "BangLuongKy1") == false)
            {
                setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
            }
            else
            {
                var rs = new UpdateKhoanThanhToanBLL().BangLuongKy1_Update(Thang, Nam, NhanSuID, SOTK, ANCA, CTP_KHOANTH, TT_THEMGIO, CHENUOC,
          CTP_KHAC, BOIDUONGK3, THUNHAP1, LUONGKY1, THUNHAP12);
                if (rs > 0)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Cac khoan thanh toan->UpdateKhoanThanhtoan-thang-" + Thang + "-nam-" + Nam + "-NhanSuID-" + NhanSuID + "->Success");
                    setAlert("Cập nhật thành công", "success");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Cac khoan thanh toan->UpdateKhoanThanhtoan-thang-" + Thang + "-nam-" + Nam + "-NhanSuID-" + NhanSuID + "->Fail");
                    setAlert("Cập nhật không thành công", "error");
                }
            }

            return Redirect("/update-khoan-thanh-toan/thang-" + Thang + "-nam-" + Nam);

        }


        public void loadDrpDonVi(string selected = null)
        {
            var rs = new BangLuongDonViBLL().SelectByDonVi(Session[SessionCommon.DonViID].ToString());
            ViewBag.DonViID = new SelectList(rs, "DonViID", "TenDonVi", selected);
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
                Text =(DateTime.Now.Year-2).ToString(),
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
                Value = (DateTime.Now.Year ).ToString()
            });
            listItems.Add(new SelectListItem
            {
                Text = (DateTime.Now.Year +1).ToString(),
                Value = (DateTime.Now.Year +1).ToString()
            });
            listItems.Add(new SelectListItem
            {
                Text = (DateTime.Now.Year +2).ToString(),
                Value = (DateTime.Now.Year +2).ToString()
            });
            ViewBag.drpNam = new SelectList(listItems, "Value", "Text", selected);
        }
    }
}