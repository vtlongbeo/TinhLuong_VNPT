using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;

namespace TinhLuong.Controllers
{
    public class ImportCSHT_PTTBController : BaseController
    {
        SaveLog sv = new SaveLog();
        // GET: Nhập lương Tìm kiếm, LĐ thuê bao từ CSHT
        [CheckCredential(RoleID = "IMPORT_CSHTPTTB_KDTM")]
        public ActionResult Index()
        {
           // sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat Luong->Luong tim kiem ,LD tu CSHT");
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
        /// Cập nhật lương từ CSHT_PTTB
        /// </summary>
        /// <param name="thang"></param>
        /// <param name="nam"></param>
        /// <returns></returns>
        [CheckCredential(RoleID = "IMPORT_CSHTPTTB_KDTM")]
        public ActionResult LuongReport(int thang, int nam)
        {
            Session.Add(SessionCommon.Thang, thang);
            Session.Add(SessionCommon.nam, nam);
            if (new ImportExcelBLL().GetChotSo(thang, nam, Session[SessionCommon.DonViID].ToString(), "BangLuong"))
                {
                    bool outPut = new ImportExcelBLL().Update_SQLPTTB(nam,thang, Session[SessionCommon.DonViID].ToString(), Session[SessionCommon.Username].ToString());
                if (outPut)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat Luong->Luong tim kiem ,LD tu CSHT->Import Thanh Cong- Thang-" + thang + "-nam-" + nam);
                    setAlert("Cập nhật thành công", "success");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat Luong->Luong tim kiem ,LD tu CSHT->Import That bai- Thang-" + thang + "-nam-" + nam);
                    setAlert("Cập nhật thất bại", "error");
                }
                }
                else
                {
                sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat Luong->Luong tim kiem ,LD tu CSHT->Import Khong Thanh Cong- Thang-" + thang + "-nam-" + nam+ "-Do thang luong da chot");
                setAlert("Tháng đã chốt lương, không thể thao tác!", "error");
                }
            return Redirect("/importcsht_pttb");
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