using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;
using TinhLuongINFO;
namespace TinhLuong.Controllers
{
    public class ChamCongController : BaseController
    {
        // GET: ChamCong
        SaveLog sv = new SaveLog();
        string nhansuid = "1";
        int thang = 1;
        int nam = 2018;

        [CheckCredential(RoleID = "CHAM_CONG_DONVI")]
        public ActionResult Index()
        {
            if (Session[SessionCommon.DonViID].ToString() == "VTT")
                drpDonViCha();
            else
                drpDonViCha(Session[SessionCommon.DonViID].ToString());
            drpNam();
            drpThang();

            return View();
        }


        [CheckCredential(RoleID = "CHAM_CONG_DONVI")]
        public ActionResult IndexDetail(int thang, int nam, string DonViID)
        {
            //sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Bang luong don vi->thang-" + thang + "-nam" + nam); 

            drpNam(nam.ToString());
            drpThang(thang.ToString());
            if (Session[SessionCommon.DonViID].ToString() != "VTT")
            {
                drpDonViCha(Session[SessionCommon.DonViID].ToString());
                var chamcong = new ChamCongBLL().GetChamCongDonVi(thang.ToString(), nam.ToString(), Session[SessionCommon.DonViID].ToString(), "", Session[SessionCommon.Username].ToString());
                return View(chamcong);
            }
            else
            {
                drpDonViCha(DonViID.Replace("_", "-"));
                var chamcong = new ChamCongBLL().GetChamCongDonVi(thang.ToString(), nam.ToString(), DonViID.Replace("_", "-"), "", Session[SessionCommon.Username].ToString());
                return View(chamcong);
            }

        }


        [CheckCredential(RoleID = "CHAM_CONG_DONVI")]
        public ActionResult ChiTietChamCong(string NhanSuID, int Thang, int Nam)
        {
            nhansuid = NhanSuID;
            thang = Thang;
            nam = Nam;
            // sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Bang luong don vi->Detail->NhanSuID-" + NhanSuID + "-thang-" + Thang + "-nam-" + Nam);
            //var ChamCong = new ChamCongBLL().GetChamCongDonViByNhanSu(NhanSuID, Thang.ToString(), Nam.ToString(), 0);
            var ChamCong = new ChamCongBLL().GetInfoByNhanSuID(NhanSuID, Thang, Nam);
            LoadLoaiNgayChamCong("");
            return View(ChamCong);
        }


        [CheckCredential(RoleID = "CHAM_CONG_DONVI")]
        public ActionResult ChiTietTrucDem(string NhanSuID, int Thang, int Nam)
        {
            nhansuid = NhanSuID;
            thang = Thang;
            nam = Nam;
            // sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Bang luong don vi->Detail->NhanSuID-" + NhanSuID + "-thang-" + Thang + "-nam-" + Nam);
            //var ChamCong = new ChamCongBLL().GetChamCongDonViByNhanSu(NhanSuID, Thang.ToString(), Nam.ToString(), 0);
            var ChamCong = new ChamCongBLL().GetInfoByNhanSuID(NhanSuID, Thang, Nam);
            LoadLoaiNgayChamCong("");
            return View(ChamCong);
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
                Value = (DateTime.Now.Year + 2).ToString()
            });

            ViewBag.drpNam = new SelectList(listItems, "Value", "Text", selected);
        }

        public void drpDonViCha(string selected = null)
        {
            var dmtram = new BaoCaoChungBLL().Get_ListTenDonVi(Session[SessionCommon.DonViID].ToString());
            List<DM_DonVi> listItems = new List<DM_DonVi>();
            if (selected != null)
                selected = selected.Replace("-", "_");

            foreach (var item in dmtram)
            {
                if (item.DonViID != "TNN-NCM" && item.DonViID != "TNN-TKD")
                    listItems.Add(new DM_DonVi
                    {
                        TenDonVi = item.TenDonVi,
                        DonViID = item.DonViID.Replace("-", "_"),
                    });
            }
            ViewBag.DonViID = new SelectList(listItems, "DonViID", "TenDonVi", selected);
        }


        [CheckCredential(RoleID = "CHAM_CONG_DONVI")]
        public void LoadLoaiNgayChamCong(string selected = null)
        {
            var rs = new ChamCongBLL().SelectByMaChamCong("");
            ViewBag.MaChamCong = new SelectList(rs, "MaChamCong", "TenChamCong", selected);
        }


        [CheckCredential(RoleID = "CHAM_CONG_DONVI")]
        public bool UpdateChamCong(int NhanVienID, string NgayCong, string MaChamCong, string Note, int TrucDem, string thang)
        {
            int Thang, Nam, Ngay;
            Nam = int.Parse(NgayCong.Substring(0, 4));
            Thang = int.Parse(NgayCong.Substring(5, 2));
            Ngay = int.Parse(NgayCong.Substring(8, 2));
            if (int.Parse(thang) != Thang)
                return false;
            else
                return new ChamCongBLL().UpdateChamCongByNhanVien(NhanVienID, Nam, Thang, Ngay, MaChamCong, Note, TrucDem, Session[SessionCommon.Username].ToString());
        }


        [CheckCredential(RoleID = "CHAM_CONG_DONVI")]
        public void ChotChamCong(string thang, string nam)
        {
            string str = "";
            if (new ImportExcelBLL().GetChotSo(int.Parse(thang), int.Parse(nam), Session[SessionCommon.DonViID].ToString(), "BangLuong") == false)
            {

                setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
            }
            else
            {
                str = new ChamCongBLL().ChotChamCong(thang, nam);
                var CapNhatLuongTrucDem = new ChamCongBLL().UpdateLuongTrucDem(thang, nam, Session[SessionCommon.Username].ToString());
                setAlert(str, "success");
            }

            
        }




        public JsonResult GetEvents(string NhanVienID, int thang, int nam, int TrucDem)
        {
            string Thang = thang.ToString();
            if (Thang.Length < 2)
                Thang = "0" + Thang;
            List<Event> events = new List<Event>();
            DataTable dt = new ChamCongBLL().GetChamCongDonViByNhanSu(NhanVienID, Thang, nam.ToString(), TrucDem);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["MaChamCong"].ToString() != "")
                {
                    Event _Event = new Event();
                    if (dt.Rows[i]["MaChamCong"].ToString() == "1/2X")
                    {
                        _Event.color = "blue";
                    }
                    else if (dt.Rows[i]["MaChamCong"].ToString() == "H")
                    {
                        _Event.color = "green";
                    }
                    else if (dt.Rows[i]["MaChamCong"].ToString() == "BH")
                    {
                        _Event.color = "yellow";
                    }
                    else if (dt.Rows[i]["MaChamCong"].ToString() == "NL" || dt.Rows[i]["MaChamCong"].ToString() == "NB" || dt.Rows[i]["MaChamCong"].ToString() == "P")
                    {
                        _Event.color = "green";
                    }
                    else if (dt.Rows[i]["MaChamCong"].ToString() == "N")
                    {
                        _Event.color = "black";
                    }
                    else if (dt.Rows[i]["MaChamCong"].ToString() == "Ô")
                    {
                        _Event.color = "red";
                    }

                    string ngay = dt.Rows[i]["Ngay"].ToString();
                    if (ngay.Length < 2)
                        ngay = "0" + ngay;

                    _Event.id = i;
                    _Event.title = dt.Rows[i]["TenChamCong"].ToString();
                    _Event.someKey = i;
                    _Event.note = dt.Rows[i]["GhiChu"].ToString();
                    _Event.start = nam.ToString() + "-" + Thang + "-" + ngay + "T07:00:00";
                    _Event.end = nam.ToString() + "-" + Thang + "-" + ngay + "T17:00:00";
                    _Event.allDay = true;
                    _Event.MaChamCong = dt.Rows[i]["MaChamCong"].ToString();
                    events.Add(_Event);
                }

            }
            var rows = events.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
        public class Event
        {
            public int id;
            public string title;
            public int someKey;
            public string start;
            public string end;
            public string textColor;
            public string color;
            public string className;
            public bool allDay;
            public string note;
            public string MaChamCong;
        }


        [CheckCredential(RoleID = "CHAM_CONG_DONVI")]
        public ActionResult BaoCaoChamCong(string thang, string nam, int trucdem, string dv, string tram)
        {
            Session.Add(SessionCommon.Thang, thang);
            Session.Add(SessionCommon.nam, nam);
            Session.Add("TrucDem", trucdem);
            string content = "";
            if (dv == "")
                Session.Add("DonVi_BaoCao", Session[SessionCommon.DonViID].ToString());
            else
                Session.Add("DonVi_BaoCao", dv.Replace("_", "-"));

            content = "~/Reports/BaoCaoChung/ChamCongDonVi.aspx";

            return Redirect(content);
        }

    }
}