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
    public class BaoCaoChungController : BaseController
    {
        SaveLog sv = new SaveLog();
        // GET: BaoCaoChung
        [CheckCredential(RoleID = "VIEW_EXCEL_DS")]
        public ActionResult Index()
        {
            //sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi");
            Session["NamBS"] = null;
            List<NhanVien> listItems = new List<NhanVien>();
            listItems.Add(new NhanVien
            {
                Hoten = "--Chọn nhân viên--",
                NhansuID = 0,
            });
            List<DM_DonVi> listItems1 = new List<DM_DonVi>();
            listItems1.Add(new DM_DonVi
            {
                TenDonVi = "--Chọn tất cả--",
                DonViID = "All",
            });
            drpThang();
            drpNam();
            drpNamBS();
            drpDonViCha();
            loadLoaiBS();
            ViewBag.Tram = new SelectList(listItems1, "DonViID", "TenDonVi", null);
            ViewBag.NhanVien = new SelectList(listItems, "NhanSuID", "HoTen", null);
            return View();
        }



        [CheckCredential(RoleID = "VIEW_EXCEL_DS")]
        public ActionResult getData(int thang, int nam, string DonViCha, string ToTram, int NhanVien)
        {
            //sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi->Thang-" + thang + "-nam-" + nam + "-DVCha-" + DonViCha + "-Totram-" + ToTram + "-NhanSuID-" + NhanVien);
            Session["NamBS"] = null;
            drpThang(thang.ToString());
            drpNam(nam.ToString());
            drpNamBS();
            loadLoaiBS();
            drpDonViCha(DonViCha.ToString());
            drpDonViTram(ToTram.ToString());
            drpNhanVien(NhanVien.ToString());
            DonViCha = DonViCha.Replace("_", "-");
            ToTram = ToTram.Replace("_", "-");
            if (DonViCha == "All")
            {
                var rs = new BaoCaoChungBLL().RequestTableNhanVien(nam, thang, Session[SessionCommon.DonViID].ToString(), Session[SessionCommon.DonViID].ToString(), "dv");
                return View(rs);
            }
            else
            {
                if (ToTram == "All")
                {
                    var rs = new BaoCaoChungBLL().RequestTableNhanVien(nam, thang, DonViCha, Session[SessionCommon.DonViID].ToString(), "dv");
                    return View(rs);
                }
                else
                {
                    if (NhanVien == 0)
                    {
                        var rs = new BaoCaoChungBLL().RequestTableNhanVien(nam, thang, ToTram, Session[SessionCommon.DonViID].ToString(), "dv");
                        return View(rs);
                    }
                    else
                    {
                        var rs = new BaoCaoChungBLL().RequestTableNhanVien(nam, thang, NhanVien.ToString(), Session[SessionCommon.DonViID].ToString(), "nv");
                        return View(rs);
                    }
                }
            }
        }


        /// <summary>
        /// get table bangluong idNhansu
        /// </summary>
        /// 
        [CheckCredential(RoleID = "VIEW_EXCEL_DS")]
        [HttpGet]
        public ActionResult Details(string NhanSuID, int Thang, int Nam)
        {
           // sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi->Detail-NhanSuID-" + NhanSuID + "-Thang-" + Thang + "-nam-" + Nam);
            var bangluong = new BangLuongDonViBLL().GetBangLuongDonViByNhanSu(NhanSuID, Thang, Nam);
            loadDrpDonVi(bangluong.Rows[0]["DonViID"].ToString());
            return View(bangluong);
        }

        /// <summary>
        /// Xuất file báo cáo
        /// </summary>
        /// <param name="thang"></param>
        /// <param name="nam"></param>
        /// <param name="dv"></param>
        /// <param name="tram"></param>
        /// <param name="type"></param>
        /// <param name="luong"></param>
        /// <returns></returns>
        [CheckCredential(RoleID = "VIEW_EXCEL_DS")]
        public ActionResult TongHopReport(int thang, int nam, string dv, string tram, string type, string luong)
        {
            Session.Add(SessionCommon.Thang, thang);
            Session.Add(SessionCommon.nam, nam);
            Session.Add("LoaiLuong", luong);
            string content = "";
            if (dv == "All")
                Session.Add("DonVi_BaoCao", Session[SessionCommon.DonViID].ToString());
            else if (tram == "All")
                Session.Add("DonVi_BaoCao", dv.Replace("_", "-"));
            else
                Session.Add("DonVi_BaoCao", tram.Replace("_", "-"));
            if (type == "BangLuong")
            {
                //sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi->ViewReport->In Quyet Toan-thang-" + thang + "-nam-" + nam + "-DVID-" + dv + "-tram-" + tram);
                content = "~/Reports/BaoCaoChung/TongHopLuong.aspx";
            }

            else if (type == "Ky1")
            {
               // sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi->ViewReport->In Ky 1-thang-" + thang + "-nam-" + nam + "-DVID-" + dv + "-tram-" + tram);
                content = "~/Reports/BaoCaoChung/BangKeChiTietCacKhoan.aspx";
            }

            else if (type == "PTTB")
            {
                //sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi->ViewReport->In PTTB-thang-" + thang + "-nam-" + nam + "-DVID-" + dv + "-tram-" + tram);
                content = "~/Reports/BaoCaoChung/PhatTrienThueBao.aspx";
            }
            else if (type == "KKLD")
            {
                //sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi->ViewReport->In KKLD-thang-" + thang + "-nam-" + nam + "-DVID-" + dv + "-tram-" + tram);
                content = "~/Reports/BaoCaoChung/KKLaoDong.aspx";
            }

            return Redirect(content);
        }


        [CheckCredential(RoleID = "VIEW_EXCEL_DS")]
        public ActionResult TongHopReport_ChuyenKhoanKy1(int thang, int nam, string dv, string tram, string type, string luong)
        {
            Session.Add(SessionCommon.Thang, thang);
            Session.Add(SessionCommon.nam, nam);
            Session.Add("LoaiLuong", luong);
            string content = "";
           // sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi->ViewReport->Chuyen Khoan Ky 1-thang-" + thang + "-nam-" + nam + "-DVID-" + dv + "-tram-" + tram);
            if (type == "Agri")
                content = "~/Reports/BaoCaoChung/Frm_Bank.aspx";
            else if (type == "VC")
                content = "~/Reports/BaoCaoChung/FrmVietComBank.aspx";
            else if (type == "Viettin")
                content = "~/Reports/BaoCaoChung/FrmViettinBank.aspx";
            return Redirect(content);
        }



        [CheckCredential(RoleID = "VIEW_EXCEL_DS")]
        public ActionResult TongHopReport_ChuyenQT(int thang, int nam, string dv, string tram, string type, string luong)
        {
            Session.Add(SessionCommon.Thang, thang);
            Session.Add(SessionCommon.nam, nam);
            Session.Add("LoaiLuong", luong);
           // sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi->ViewReport->Chuyen Khoan Quyet Toan-thang-" + thang + "-nam-" + nam + "-DVID-" + dv + "-tram-" + tram);

            string content = "";
            if (type == "Agri")
                content = "~/Reports/BaoCaoChung/Frm_Bank.aspx";
            else if (type == "VC")
                content = "~/Reports/BaoCaoChung/FrmVietComBank.aspx";
            else if (type == "Viettin")
                content = "~/Reports/BaoCaoChung/FrmViettinBank.aspx";
            return Redirect(content);
        }

        public void loadDrpDonVi(string selected = null)
        {
            var rs = new BangLuongDonViBLL().SelectByDonVi(Session[SessionCommon.DonViID].ToString());
            ViewBag.DonViID = new SelectList(rs, "DonViID", "TenDonVi", selected);
        }
        public void loadLoaiBS(string selected = null)
        {
            if (Session["NamBS"] == null)
            {
                List<DM_LoaiBoSung> listItems = new List<DM_LoaiBoSung>();
                listItems.Add(new DM_LoaiBoSung
                {
                    DienGiai = "--Chọn tất cả--",
                    Loai = 0,
                });
                ViewBag.LoaiBS = new SelectList(listItems, "Loai", "DienGiai", selected);
            }
            else
            {
                var rs = new BaoCaoChungBLL().GetLoaiBoSung(int.Parse(Session["NamBS"].ToString()));
                ViewBag.LoaiBS = new SelectList(rs, "Loai", "DienGiai", selected);
            }

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
        public void drpNamBS(string selected = null)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "2016",
                Value = "2016"
            });
            listItems.Add(new SelectListItem
            {
                Text = "2017",
                Value = "2017",
            });
            listItems.Add(new SelectListItem
            {
                Text = "2018",
                Value = "2018"
            });
            listItems.Add(new SelectListItem
            {
                Text = "2019",
                Value = "2019"
            });
            listItems.Add(new SelectListItem
            {
                Text = "2020",
                Value = "2020"
            });


            ViewBag.drpNamBS = new SelectList(listItems, "Value", "Text", selected);
        }
        public void LoadDonVi(string selected = null)
        {
            var dv = new BaoCaoChungBLL().Get_ListTenDonVi(Session[SessionCommon.DonViID].ToString());
            List<DM_DonVi> listItems = new List<DM_DonVi>();

            foreach (var item in dv)
            {
                listItems.Add(new DM_DonVi
                {
                    TenDonVi = item.TenDonVi,
                    DonViID = item.DonViID.Replace("-", "_"),
                });
            }
            ViewBag.DonViID = new SelectList(listItems, "DonViID", "TenDonVi", selected);
        }
        public void drpDonViCha(string selected = null)
        {
            var dmtram = new BaoCaoChungBLL().Get_ListTenDonVi(Session[SessionCommon.DonViID].ToString());
            List<DM_DonVi> listItems = new List<DM_DonVi>();
            listItems.Add(new DM_DonVi
            {
                TenDonVi = "--Chọn tất cả--",
                DonViID = "All",
            });
            foreach (var item in dmtram)
            {
                listItems.Add(new DM_DonVi
                {
                    TenDonVi = item.TenDonVi,
                    DonViID = item.DonViID.Replace("-", "_"),
                });
            }
            ViewBag.DonViID = new SelectList(listItems, "DonViID", "TenDonVi", selected);
        }
        public void drpNhanVien(string selected = null)
        {
            if (Session["DonViTram"] == null)
            {
                List<NhanVien> listItems = new List<NhanVien>();
                listItems.Add(new NhanVien
                {
                    Hoten = "--Chọn tất cả--",
                    NhansuID = 0,
                });
                ViewBag.Nhanvien = new SelectList(listItems, "NhanSuID", "HoTen", selected);
            }
            else
            {
                var dmtram = new BaoCaoChungBLL().Get_ListTenNhanVien(Session["DonViTram"].ToString());
                List<NhanVien> listItems = new List<NhanVien>();
                listItems.Add(new NhanVien
                {
                    Hoten = "--Chọn tất cả--",
                    NhansuID = 0,
                });
                foreach (var item in dmtram)
                {
                    listItems.Add(new TinhLuongINFO.NhanVien
                    {
                        Hoten = item.Hoten,
                        NhansuID = item.NhansuID,
                    });
                }
                ViewBag.Nhanvien = new SelectList(listItems, "NhanSuID", "HoTen", selected);
            }
        }
        public void drpDonViTram(string selected = null)
        {
            List<DM_DonVi> listItems = new List<DM_DonVi>();
            listItems.Add(new DM_DonVi
            {
                TenDonVi = "--Chọn tất cả--",
                DonViID = "All",
            });
            if (Session["DonViCha"] != null)
            {
                var dmtram = new BaoCaoChungBLL().Get_ListTenTram(Session["DonViCha"].ToString());
                foreach (var item in dmtram)
                {
                    listItems.Add(new DM_DonVi
                    {
                        TenDonVi = item.TenDonVi,
                        DonViID = item.DonViID.Replace("-", "_"),
                    });
                }
            }

            ViewBag.Tram = new SelectList(listItems, "DonViID", "TenDonVi", selected);
        }
        public JsonResult LoadDonViTram(string donviID)
        {
            Session.Add("DonViCha", donviID.Replace("_", "-"));
            var tram = new BaoCaoChungBLL().Get_ListTenTram(donviID.Replace("_", "-"));
            List<DM_DonVi> listItems = new List<DM_DonVi>();

            foreach (var item in tram)
            {
                listItems.Add(new DM_DonVi
                {
                    TenDonVi = item.TenDonVi,
                    DonViID = item.DonViID.Replace("-", "_"),
                });
            }
            return Json(new SelectList(listItems, "DonViID", "TenDonVi"));
        }
        public JsonResult LoadBS(int Nam)
        {
            Session.Add("NamBS", Nam);
            var bs = new BaoCaoChungBLL().GetLoaiBoSung(Nam);
            return Json(new SelectList(bs, "Loai", "DienGiai"));
        }
        public JsonResult LoadNhanVien(string donviID)
        {
            Session.Add("DonViTram", donviID.Replace("_", "-"));
            var tram = new BaoCaoChungBLL().Get_ListTenNhanVien(donviID.Replace("_", "-"));
            return Json(new SelectList(tram, "NhanSuID", "HoTen"));
        }
        /// gửi tin nhắn kỳ 1
        /// 

        [CheckCredential(RoleID = "NHANTIN")]
        public ActionResult SendSMSKy1(int thang, int nam)
        {
            int loai = 1;
            SMS.SMSSoapClient ws = new SMS.SMSSoapClient("SMSSoap12");
            var rs = ws.SendAlertSalaryExt(nam, thang, 1, "", Session[SessionCommon.Username].ToString());
            if (rs > 0)
            {
                sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi->SMS->SMS Ky 1-thang-" + thang + "-nam-" + nam + "->Success");
                setAlert("Đã gửi tin nhắn tới toàn thể CBNV VTT", "success");
                var result = new BaoCaoChungBLL().ActiveLuong(nam, thang, loai);
            }
            else
            {
                sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi->SMS->SMS Ky 1-thang-" + thang + "-nam-" + nam + "->Fail");
                setAlert("Lỗi trong quá trình gửi yêu cầu tới máy chủ. Vui lòng thử lại!", "error");
            }
            return Redirect("/BaoCaoChung");
        }
        [CheckCredential(RoleID = "NHANTIN")]
        public ActionResult SendSMSQuyetToan(int thang, int nam)
        {
            int loai = 2;
            SMS.SMSSoapClient ws = new SMS.SMSSoapClient("SMSSoap12");
            var rs = ws.SendAlertSalaryExt(nam, thang, loai, "", Session[SessionCommon.Username].ToString());
            if (rs > 0)
            {
                sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi->SMS->SMS Quyet Toan-thang-" + thang + "-nam-" + nam + "->Success");
                setAlert("Đã gửi tin nhắn tới toàn thể CBNV VTT", "success");
                var result = new BaoCaoChungBLL().ActiveLuong(nam, thang, loai);
            }
            else
            {
                sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Bang luong don vi->SMS->SMS Quyet Toan-thang-" + thang + "-nam-" + nam + "->Fail");
                setAlert("Lỗi trong quá trình gửi yêu cầu tới máy chủ. Vui lòng thử lại!", "error");
            }
            return Redirect("/BaoCaoChung");
        }

    }
}