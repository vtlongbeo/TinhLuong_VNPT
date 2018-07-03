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
    public class TinhLuongBoSungQuyController : BaseController
    {
        // GET: TinhLuongBoSungQuy
        TinhLuongBoSungQuyBLL bll = new TinhLuongBoSungQuyBLL();
        [CheckCredential(RoleID = "CHOT_SO")]
        public ActionResult Index()
        {
            drpQuy();
            drpNam();
            return View();
        }
        public ActionResult Detail()
        {
            Session["NamBSCT"] = null;
            drpLoaiBS();
            drpQuy();
            drpNam();
            return View();
        }
        [CheckCredential(RoleID = "CHOT_SO")]
        public ActionResult LuongKHTamUng()
        {
            if (Session["NAM"] == null)
                drpNam();
            else drpNam(Session["NAM"].ToString());
            drpLanhDao();
            return View();
        }
        [CheckCredential(RoleID = "CHOT_SO")]
        [HttpPost]
        public ActionResult UpLuongBS(DateTime ngayck)
        {
            string ngayck_string = ngayck.Day + "/" + ngayck.Month + "/" + ngayck.Year;
            var rs = bll.UpLuongBS(ngayck_string, Session[SessionCommon.Username].ToString());
            if (rs > 0)
                setAlert("Đẩy lương thành công", "success");
            else if (rs == -1000)
                setAlert("Xảy ra lỗi, Vui lòng thử lại", "error");
            else
                setAlert("Cập nhật không thành công do đã tồn tại loại bổ sung", "error");
            return Redirect("/dulieu-bsq");
        }
        private static IQueryable<BSQ_LuongKHTamUng> luongtamung;
        [CheckCredential(RoleID = "CHOT_SO")]
        [HttpGet]
        public JsonResult LoadDataLuongKHTamUng(int Nam)
        {
            Session.Add("NAM", Nam);
            bool stt = false;

            try
            {
                luongtamung = bll.GetAll_BSQ_LuongKHTamUng(Nam).AsQueryable();
                stt = true;
            }
            catch
            {
                stt = false;
            }

            return Json(new
            {
                data = luongtamung,
                status = stt
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetLuongKHTamUng_ID(string ID)
        {
            string[] chuoi = new string[] { };
            chuoi = ID.Split('_');
            var model = luongtamung.Where(x => x.Nam == int.Parse(chuoi[0]) && x.NhanSuID == int.Parse(chuoi[1]));
            return Json(new
            {
                status = true,
                data = model,
            }, JsonRequestBehavior.AllowGet);
        }
        [CheckCredential(RoleID = "CHOT_SO")]
        [HttpPost]
        public JsonResult UpdateLuongKH(string ID, decimal LuongKHTamUng, bool IsActive)
        {
            string[] chuoi = new string[] { };
            chuoi = ID.Split('_');
            var rs = bll.Update_LuongKHTamUng(int.Parse(chuoi[0]), int.Parse(chuoi[1]), LuongKHTamUng, IsActive);
            return Json(new
            {
                status = rs
            });
        }
        [CheckCredential(RoleID = "CHOT_SO")]
        public ActionResult TinhLuong(int drpQuy, int drpNam, string DienGiai, decimal NguonBoSung)
        {
            //Session.Add(SessionCommon.Thang, quy);
            //Session.Add(SessionCommon.nam, nam);
            var rs = bll.GetData_TinhLuongBoSungQuy(drpQuy, drpNam, NguonBoSung, DienGiai);
            if (rs)
            {
                setAlert("Tính toán dữ liệu thành công!", "success");
                return Redirect("/TinhLuongBoSungQuy/Detail");
            }
            else
            {
                setAlert("Cập nhật thất bại", "error");
                return Redirect("/TinhLuongBoSungQuy");
            }
           
        }
        [HttpGet]
        public JsonResult LoadData_BangThongTin(string value, string type, int Nam, int LoaiBS, int page, int pageSize)
        {
            value = value.ToLower();
            IQueryable<BSQ_BangThongTin> Bangthongtin = bll.GetAll_BSQ_BangThongTin(Nam, LoaiBS, Session[SessionCommon.DonViID].ToString()).AsQueryable();
            var modelBangthongtin = Bangthongtin;
            //if (!String.IsNullOrWhiteSpace(value))
            //{
            //    switch (type)
            //    {
            //        case "DonVi":
            //            modelBangthongtin = Bangthongtin.Where(x => x.DonViChaID.ToLower().Contains(value));
            //            break;
            //        case "ToTram":
            //            modelBangthongtin = Bangthongtin.Where(x => x.DonViID.ToLower().Contains(value));
            //            break;
            //        case "NhanSuID":
            //            modelBangthongtin = Bangthongtin.Where(x => x.NhanSuID.ToString().Contains(value));
            //            break;
            //        case "HoTen":
            //            modelBangthongtin = Bangthongtin.Where(x => x.HoTen.ToLower().Contains(value));
            //            break;
            //    }
            //    int i = 1;
            //    foreach(var item in modelBangthongtin)
            //    {
            //        item.STT = i;
            //        i++;
            //    }
            //}
            var totalBangThongTin = modelBangthongtin.Count();
            //modelBangthongtin = modelBangthongtin.Skip((page - 1) * pageSize).Take(pageSize);
            return Json(new
            {
                totalBangThongTin = totalBangThongTin,
                dataBangThongTin = modelBangthongtin,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult LoadData_NguonBSDV(string search, int Nam, int LoaiBS, int page, int pageSize)
        {
            search = search.ToLower();
            IQueryable<BSQ_PhanNguonDV> NguonBSDonVi = bll.GetAll_BSQ_PhanNguonDV_BoSung(Nam, LoaiBS, Session[SessionCommon.DonViID].ToString()).AsQueryable();
            var modelNguonBSDonVi = NguonBSDonVi;
            //if (!string.IsNullOrWhiteSpace(search))
            //{
            //    modelNguonBSDonVi = NguonBSDonVi.Where(x => x.DonViID.ToLower().Contains(search));
            //    int i = 1;
            //    foreach (var item in modelNguonBSDonVi)
            //    {
            //        item.STT = i;
            //        i++;
            //    }

            //}
            //modelNguonBSDonVi = modelNguonBSDonVi.Skip((page - 1) * pageSize).Take(pageSize);
            var totalNguonBSDonVi = modelNguonBSDonVi.Count();
            return Json(new
            {
                totalNguonBSDonVi = totalNguonBSDonVi,
                dataNguonBSDonVi = modelNguonBSDonVi,

                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult LoadData_BSDV(string value, string type, int Nam, int LoaiBS, int page, int pageSize)
        {
            value = value.ToLower();
            IQueryable<BSQ_BoSungDonVi> BSDonVi = bll.GetAll_BSQ_BoSungDonVi(Nam, LoaiBS, Session[SessionCommon.DonViID].ToString()).AsQueryable();
            var modelBSDonVi = BSDonVi;
            //if (!String.IsNullOrWhiteSpace(value))
            //{
            //    switch (type)
            //    {
            //        case "DonVi":
            //            modelBSDonVi = BSDonVi.Where(x=>x.DonViChaID.ToLower().Contains(value));
            //            break;
            //        case "ToTram":
            //            modelBSDonVi = BSDonVi.Where(x => x.DonViID.ToLower().Contains(value));
            //            break;
            //        case "TenToTram":
            //            modelBSDonVi = BSDonVi.Where(x => x.TenDonVi.ToLower().Contains(value));
            //            break;
            //    }
            //    int i = 1;
            //    foreach (var item in modelBSDonVi)
            //    {
            //        item.STT = i;
            //        i++;
            //    }
            //}
            var totalBSDonVi = BSDonVi.Count();
            //modelBSDonVi = modelBSDonVi.Skip((page - 1) * pageSize).Take(pageSize);
            return Json(new
            {
                totalBSDonVi = totalBSDonVi,
                dataBSDonVi = modelBSDonVi,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadData_BSLanhDao(int Nam, int LoaiBS, int page, int pageSize)
        {

            var BSDonVi = bll.GetAll_BSQ_LanhDao(Nam, LoaiBS, Session[SessionCommon.DonViID].ToString());
            //var modelBSDonVi = BSDonVi.Skip((page - 1) * pageSize).Take(pageSize);
            var totalBSDonVi = BSDonVi.Count;
            var modelBSDonVi = BSDonVi;
            return Json(new
            {
                totalBSDonVi = totalBSDonVi,
                dataBSDonVi = modelBSDonVi,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult TinhLuongBoSung(int Nam, int LoaiBS)
        {
            var ou = new ChotSoBLL().Tuyen_Check_ChotSoBS(Nam, LoaiBS);
            var rs=false;
            if (ou.OutputCode == 0)
            {
                 rs = bll.TinhLuongBoSungQuy(Nam, LoaiBS);
                setAlert("Tính toán dữ liệu thành công", "success");
            }
            
            else setAlert(ou.OutputString, "error");
            return Json(new
            {
                status = rs
            });
        }
        [CheckCredential(RoleID = "CHOT_SO")]
        [HttpPost]
        public JsonResult DeleteLuongBoSung(int Nam, int LoaiBS)
        {
            var rs = bll.TinhLuong_DeleteBoSungQuy(Nam, LoaiBS);
            if (rs.OutputCode==1) setAlert(rs.OutputString, "success");
            else setAlert(rs.OutputString, "error");
            return Json(new
            {
                status = rs
            });
        }

        [CheckCredential(RoleID = "CHOT_SO")]
        [HttpPost]
        public JsonResult UpdateBSQuy(string ID, decimal Value, string Type)
        {
            string[] key = new string[] { };
            key = ID.Split('_');
            var ou = new Ouput();
            if (Type== "GIAMTRUQUYLUONG" || Type== "P3BSDV" || Type == "P3BoSungDonVi")
                 ou = new ChotSoBLL().Tuyen_Check_ChotSoBS(int.Parse(key[1]), int.Parse(key[3]));
            else
                 ou = new ChotSoBLL().Tuyen_Check_ChotSoBS(int.Parse(key[1]), int.Parse(key[4]));
            var rs = false;
            if (ou.OutputCode==0)
            {
                if (Type == "GIAMTRUQUYLUONG" || Type == "P3BSDV")
                    rs = bll.Update_BSQ_PhanNguonDV_BoSung(int.Parse(key[1]), int.Parse(key[3]), key[2], Type, Value);
                else if (Type == "P1" || Type == "P2" || Type == "P3")
                    rs = bll.Update_BSQ_BangThongTin(int.Parse(key[1]), int.Parse(key[3]), int.Parse(key[4]), key[2], Type, Value);
                else if (Type == "P3LanhDao" || Type == "P3LanhDaoGiamTru")
                {
                    rs = bll.Update_BSQ_LanhDao_BoSung(int.Parse(key[1]),int.Parse(key[4]),int.Parse(key[3]),Type,Value);
                }
                else if (Type == "P3BoSungDonVi")
                {
                    rs = bll.Update_BSQ_BoSungDonVi(int.Parse(key[1]), int.Parse(key[3]), key[2], Type, Value);
                }
            }
            return Json(new
            {
                status = rs
            });
        }

        [CheckCredential(RoleID = "CHOT_SO")]
        [HttpPost]
        public JsonResult UpdateSoTK(string ID, string Value)
        {
            string[] key = new string[] { };
            key = ID.Split('_');
            var ou = new ChotSoBLL().Tuyen_Check_ChotSoBS(int.Parse(key[1]), int.Parse(key[4]));
            var rs = false;
            if (ou.OutputCode > 0)
            {

                 rs = bll.Update_BSQ_sOtAIkHOAN(int.Parse(key[1]), int.Parse(key[3]), int.Parse(key[4]), Value);

            }
            return Json(new
            {
                status = rs
            });
        }

        public void drpLoaiBS(string selected = null)
        {
            if (Session["NamBSCT"] == null)
            {
                List<DM_LoaiBoSung> listItems = new List<DM_LoaiBoSung>();
                listItems.Add(new DM_LoaiBoSung
                {
                    DienGiai = "--Chọn--",
                    Loai = 0,
                });
                ViewBag.LoaiBS = new SelectList(listItems, "Loai", "DienGiai", selected);
            }
            else
            {
                var rs = bll.getLuongBS(int.Parse(Session["NamBSCT"].ToString()));
                ViewBag.LoaiBS = new SelectList(rs, "LoaiBS", "DienGiai", selected);
            }


        }
        public void drpLanhDao(string selected = null)
        {
            if (Session["NamBSCT"] == null)
            {
                List<BSQ_LanhDao> listItems = new List<BSQ_LanhDao>();
                listItems.Add(new BSQ_LanhDao
                {
                    HoTen = "--Chọn--",
                    NhanSuID = 0,
                });
                ViewBag.LanhDao = new SelectList(listItems, "NhanSuID", "HoTen", selected);
            }
            else
            {
                var rs = bll.GetAll_LanhDao(int.Parse(Session["NamBSCT"].ToString()));
                ViewBag.LanhDao = new SelectList(rs, "NhanSuID", "HoTen", selected);
            }


        }
        public void drpQuy(string selected = null)
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
            ViewBag.drpQuy = new SelectList(listItems, "Value", "Text", selected);
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
        public JsonResult LoadBS(int Nam)
        {
            Session.Add("NamBSCT", Nam);
            var bs = bll.getLuongBS(Nam);
            return Json(new SelectList(bs, "LoaiBS", "DienGiai"));
        }

        public JsonResult LoadLanhDao(int Nam)
        {
            Session.Add("NamBSCT", Nam);
            var bs = bll.GetAll_LanhDao(Nam);
            return Json(new SelectList(bs, "NhanSuID", "HoTen"));
        }
        [CheckCredential(RoleID = "CHOT_SO")]
        [HttpPost]
        public JsonResult AddNewLanhDao(int LanhDao, int Nam)
        {
            var rs = bll.Insert_LuongKH(Nam, LanhDao);
            return Json(new
            {
                status = rs
            });
        }

        [CheckCredential(RoleID = "CHOT_SO")]
        [HttpPost]
        public JsonResult DeleteLanhDao(string ID)
        {
            string[] chuoi = new string[] { };
            chuoi = ID.Split('_');
            var rs = bll.Delete_LuongKH(int.Parse(chuoi[0]), int.Parse(chuoi[1]));
            return Json(new
            {
                status = rs
            });
        }
    }
}