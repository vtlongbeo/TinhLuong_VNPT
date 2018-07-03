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
    public class ChotSoController : Controller
    {
        SaveLog sv = new SaveLog();
        // GET: ChotSo
        [CheckCredential(RoleID = "CHOT_SO")]
        public ActionResult Index()
        {
            //sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat Luong->Chot So lieu");
            drpThang();
            drpNam();
            LoadDonVi();
            ViewBag.DmBangLuong = "--Chọn loại lương";
            return View();
        }



        [CheckCredential(RoleID = "CHOT_SO")]
        public ActionResult IndexDetail(int Thang, int Nam, string DonViID, string BangLuong)
        {
           // sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat Luong->Chot So lieu->Detail-Thang-"+Thang+"-nam-"+Nam+"-donviid-"+DonViID+"-bangluong-"+BangLuong);
            var donvi_af = DonViID.Replace("_", "-");
            if (BangLuong == "NULL")
            {
                var dm = new ChotSoBLL().GetByBangChot(decimal.Parse(Session["ChotSoThang"].ToString()), decimal.Parse(Session["ChotSoNam"].ToString()), Session["ChotSoDonVi"].ToString());
                var rs = new ChotSoBLL().GetListChotso(Thang, Nam, donvi_af);
                drpThang(Thang.ToString());
                drpNam(Nam.ToString());
                LoadDonVi(DonViID.ToString());
                //ViewBag.DmBangLuong = new SelectList(listItems,"Value", "Text",null);
                LoadDMChotSo("NULL");
                return View(rs);
            }
            else
            {
                var rs = new ChotSoBLL().GetListChotso_BangID(Thang, Nam, donvi_af,BangLuong);
                drpThang(Thang.ToString());
                drpNam(Nam.ToString());
                LoadDonVi(DonViID.ToString());
                LoadDMChotSo(BangLuong.ToString());
                return View(rs);
            }
           
        }

        /// <summary>
        /// thay đổi trạng thái mở/khóa sổ
        /// </summary>
        /// <param name="thang"></param>
        /// <param name="nam"></param>
        /// <param name="bangid"></param>
        /// <param name="donviid"></param>
        /// <param name="trinhtrang"></param>
        /// <returns></returns>
        public JsonResult changeStatus(int thang,int nam, string bangid, string donviid, int trinhtrang)
        {
            if (trinhtrang == 1) trinhtrang = 0;
            else trinhtrang = 1;
            sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat Luong->Chot So lieu->ChangeStt-Thang-" + thang + "-nam-" + nam + "-donviid-" + donviid + "-bangluong-" + bangid+"-TinhTrangSauCapnhat-"+trinhtrang);
            var rs = new ChotSoBLL().CapnhatBangChotSo(nam, thang, bangid, donviid, trinhtrang, Session[SessionCommon.Username].ToString());
            return Json(new
            {
                status = rs
            });
        }

        public JsonResult changeStatusBtnAll(int thang, int nam, string bangid, string donviid, int trinhtrang)
        {
            donviid = donviid.Replace("_", "-");
            sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat Luong->Chot So lieu->ChangeStt-Thang-" + thang + "-nam-" + nam + "-donviid-" + donviid + "-bangluong-" + bangid + "-TinhTrangSauCapnhat-" + trinhtrang);
            var rs = new ChotSoBLL().CapnhatBangChotSo(nam, thang, bangid, donviid, trinhtrang, Session[SessionCommon.Username].ToString());
            return Json(new
            {
                status = rs
            });
        }

        /// <summary>
        /// load combobox
        /// </summary>
        /// <param name="selected"></param>
        public void LoadDonVi(string selected=null)
        {
            var dv = new ChotSoBLL().Select_ByDonViCha(Session[SessionCommon.DonViID].ToString());
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

        public void LoadDMChotSo(string selected=null)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            var dm = new ChotSoBLL().GetByBangChot(decimal.Parse(Session["ChotSoThang"].ToString()), decimal.Parse(Session["ChotSoNam"].ToString()), Session["ChotSoDonVi"].ToString());
            listItems.Add(new SelectListItem
            {
                Text = "--Chọn loại lương--",
                Value = "NULL"
            });
            foreach (var item in dm)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.BangID,
                    Value = item.BangID
                });
            }

            ViewBag.DmBangLuong = new SelectList(listItems, "Value", "Text", selected);
        }

        public JsonResult loadDMChoSo(int Thang, int nam, string DonViID)
        {
            Session.Add("ChotSoNam", nam);
            Session.Add("ChotSoThang", Thang);
            Session.Add("ChotSoDonVi", DonViID.Replace("_","-"));
            var dm = new ChotSoBLL().GetByBangChot(Thang, nam, DonViID.Replace("_", "-"));
            return Json(new SelectList(dm, "BangID", "BangID"));
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
    }
}