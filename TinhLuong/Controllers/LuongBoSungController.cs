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
    public class LuongBoSungController : BaseController
    {
        // GET: LuongBoSung[
        SaveLog sv = new SaveLog();
        [CheckCredential(RoleID = "VIEW_EXCEL_DS")]
        public ActionResult Index()
        {
          //  sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Luong Bo Sung");
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
        public ActionResult ReportBS(int nam, int LoaiBS, string dv, string tram, string type)
        {
            string content = "";
            Session.Add("LoaiBS", LoaiBS);
            Session.Add("NamBS", nam);
            if (dv == "All")
                Session.Add("DonVi_BaoCao_BS", Session[SessionCommon.DonViID].ToString());
            else if (tram == "All")
                Session.Add("DonVi_BaoCao_BS", dv.Replace("_", "-"));
            else
                Session.Add("DonVi_BaoCao_BS", tram.Replace("_", "-"));
            if (type == "BS")
                content = "~/Reports/BaoCaoChung/Frm_BangLuongBoSung.aspx";
           // sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Luong Bo Sung->ViewReport-nam-"+nam+"-loaibs-"+LoaiBS+"-dv-"+dv+"-tram-"+tram);
            return Redirect(content);
        }

        [CheckCredential(RoleID = "VIEW_EXCEL_DS")]
        public ActionResult Report_ChuyenKhoanBS(int nam, int LoaiBS, string dv, string tram, string type)
        {
            string content = "";
            Session.Add("LoaiBS", LoaiBS);
            Session.Add("NamBS", nam);
            if (dv == "All")
                Session.Add("DonVi_BaoCao_BS", Session[SessionCommon.DonViID].ToString());
            else if (tram == "All")
                Session.Add("DonVi_BaoCao_BS", dv.Replace("_", "-"));
            else 
                Session.Add("DonVi_BaoCao_BS", tram.Replace("_", "-"));
            if (type == "Agri")
                content = "~/Reports/BaoCaoChung/FrmBoSung_Agri.aspx";
            else if (type == "VC")
                content = "~/Reports/BaoCaoChung/FrmBoSung_VietCom.aspx";
            else if (type == "Viettin")
                content = "~/Reports/BaoCaoChung/FrmBoSung_Viettin.aspx";
            else if (type == "TienMat")
                content = "~/Reports/BaoCaoChung/NhanTienMatBS.aspx";
           // sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Luong Bo Sung->ViewReport Chuyen khoan-nam-" + nam + "-loaibs-" + LoaiBS + "-dv-" + dv + "-tram-" + tram);

            return Redirect(content);
        }


        [CheckCredential(RoleID = "NHANTIN")]
        public ActionResult SendSMSBoSung(int thang, int nam, int LoaiBS, string DienGiai)
        {
            SMS.SMSSoapClient ws = new SMS.SMSSoapClient("SMSSoap12");
           var rs = ws.SendAlertSalaryExt(nam, thang, LoaiBS, DienGiai, Session[SessionCommon.Username].ToString());
            //var rs = ws.SendPortalOTPSMS(927, "tuyennv.tnn");
            if (rs > 0)
            {
               sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Luong Bo Sung->SMS-thang-"+thang+"-nam-" + nam + "-loaibs-" + LoaiBS+"->Success");
                setAlert("Đã gửi tin nhắn tới toàn thể CBNV VTT", "success");
                var result = new BaoCaoChungBLL().ActiveLuong(nam, thang, LoaiBS);
            }
            else
            {
               sv.save(Session[SessionCommon.Username].ToString(), "Bao Cao->Luong Bo Sung->SMS-thang-" + thang + "-nam-" + nam + "-loaibs-" + LoaiBS + "->Fail");
                setAlert("Không gửi được tin nhắn. Vui lòng thử lại!", "error");
            }
            return Redirect("/luong-bo-sung");
        }

        //Load combobox
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
                Value = (DateTime.Now.Year + 2).ToString()
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
    }
}