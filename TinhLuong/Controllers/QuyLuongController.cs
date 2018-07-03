using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;

namespace TinhLuong.Controllers
{
    public class QuyLuongController : BaseController
    {
        // GET: QuyLuong
        SaveLog sv = new SaveLog();
        [CheckCredential(RoleID = "QUY_LUONG")]
        public ActionResult Index()
        {
           // sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat->Quy Luong Don vi");
            drpNam();
            drpThang();
            return View();
        }
        [CheckCredential(RoleID = "QUY_LUONG")]
        public ActionResult IndexDetail(int Thang, int Nam)
        {
            //sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat->Quy Luong Don vi-thang-" + Thang + "-nam-" + Nam);
            drpNam(Nam.ToString());
            drpThang(Thang.ToString());
            var data = new QuyLuongBLL().GetListQuyLuong(Thang, Nam, Session[SessionCommon.DonViID].ToString());
            return View(data);
        }

        /// <summary>
        /// Cập nhật quỹ lương
        /// </summary>
        /// <param name="Thang"></param>
        /// <param name="Nam"></param>
        /// <param name="DonViID"></param>
        /// <param name="QuyGT"></param>
        /// <param name="QuyTT"></param>
        /// <param name="QuyThe"></param>
        /// <param name="ChatLuongThang"></param>
        /// <param name="TyLe_HTKH"></param>
        /// <param name="TyLe_HTCNTT"></param>
        /// <param name="TyLe_The"></param>
        /// <param name="TyLe_Cuoc"></param>
        /// <param name="CSTL_LDDB"></param>
        /// <param name="STT"></param>
        /// <param name="QuyGT_KH"></param>
        /// <param name="QuyThe_KH"></param>
        /// <returns></returns>
        [CheckCredential(RoleID = "UPDATE_QUYLUONG")]
        public ActionResult UpdateQuyLuong(decimal Thang, decimal Nam, string DonViID, decimal QuyGT, decimal QuyTT, decimal QuyThe, decimal ChatLuongThang,
          decimal TyLe_HTKH, decimal TyLe_HTCNTT, decimal TyLe_The, decimal TyLe_Cuoc, decimal CSTL_LDDB, decimal STT, decimal QuyGT_KH, decimal QuyThe_KH)
        {
            if (new ImportExcelBLL().GetChotSo(Thang, Nam, Session[SessionCommon.DonViID].ToString(), "QuyLuongDV") == false)
                setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
            else
            {
                var rs = new QuyLuongBLL().CapnhatQuyLuong(Thang, Nam, DonViID, QuyGT, QuyTT, QuyThe, ChatLuongThang,
          TyLe_HTKH, TyLe_HTCNTT, TyLe_The, TyLe_Cuoc, CSTL_LDDB, STT, QuyGT_KH, QuyThe_KH);
                if (rs)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat->Quy Luong Don vi->Cap Nhat quy luong-thang-" + Thang + "-nam-" + Nam + "-dv-" + DonViID + "->Succsess");
                    setAlert("Cập nhật quỹ lương thành công!", "success");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat->Quy Luong Don vi->Cap Nhat quy luong-thang-" + Thang + "-nam-" + Nam + "-dv-" + DonViID + "->Fail");
                    setAlert("Cập nhật thất bại!", "error");
                }
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        //Thêm mới quỹ lương
        [CheckCredential(RoleID = "INSERT_QUYLUONG")]
        public ActionResult AddQuyLuong()
        {
            sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat->Quy Luong Don vi->Insert Quy Luong");
            drpNam();
            drpThang();
            return View();
        }
        [CheckCredential(RoleID = "INSERT_QUYLUONG")]
        [HttpPost]
        public ActionResult AddQuyLuong(decimal Thang, decimal Nam, string DonViID, decimal QuyGT, decimal QuyTT, decimal QuyThe, decimal ChatLuongThang,
          decimal TyLe_HTKH, decimal TyLe_HTCNTT, decimal TyLe_The, decimal TyLe_Cuoc, decimal CSTL_LDDB, decimal STT, decimal QuyGT_KH, decimal QuyThe_KH)
        {
            var rs = new QuyLuongBLL().ThemMoiQuyLuong(Thang, Nam, DonViID, QuyGT, QuyTT, QuyThe, ChatLuongThang,
           TyLe_HTKH, TyLe_HTCNTT, TyLe_The, TyLe_Cuoc, CSTL_LDDB, STT, QuyGT_KH, QuyThe_KH);
            if (rs)
            {
                sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat->Quy Luong Don vi->Insert quy luong-thang-" + Thang + "-nam-" + Nam + "-dv-" + DonViID + "->Succsess");
                setAlert("Thêm mới quỹ lương thành công!", "success");
            }
            else
            {
                sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat->Quy Luong Don vi->Insert quy luong-thang-" + Thang + "-nam-" + Nam + "-dv-" + DonViID + "->Fail");
                setAlert("Thêm mới thất bại!", "error");
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        /// <summary>
        /// Xem chi tiết từng quỹ lương
        /// </summary>
        /// <param name="DonViID"></param>
        /// <param name="Thang"></param>
        /// <param name="Nam"></param>
        /// <returns></returns>
        [CheckCredential(RoleID = "QUY_LUONG")]
        [HttpGet]
        public ActionResult Details(string DonViID, int Thang, int Nam)
        {
            var bangluong = new QuyLuongBLL().GetListQuyLuongByDonVi(Thang, Nam, DonViID);
            return View(bangluong);
        }

        /// <summary>
        /// Xóa quỹ lương
        /// </summary>
        /// <param name="DonViID"></param>
        /// <param name="Thang"></param>
        /// <param name="Nam"></param>
        /// <returns></returns>
        [CheckCredential(RoleID = "DELETE_QUYLUONG")]
        public ActionResult DeleteQuyLuong(string DonViID, decimal Thang, decimal Nam)
        {
            if (new ImportExcelBLL().GetChotSo(Thang, Nam, Session[SessionCommon.DonViID].ToString(), "QuyLuongDV") == false)
                setAlert("Dữ liệu đã chốt, không thể thao tác!", "error");
            else
            {
                var rs = new QuyLuongBLL().XoaQuyLuong(Thang, Nam, DonViID);
                if (rs)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat->Quy Luong Don vi->Xoa quy luong-thang-" + Thang + "-nam-" + Nam + "-dv-" + DonViID + "->Succsess");
                    setAlert("Xóa quỹ lương thành công!", "success");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat->Quy Luong Don vi->Xoa quy luong-thang-" + Thang + "-nam-" + Nam + "-dv-" + DonViID + "->Fail");
                    setAlert("Xóa thất bại!", "error");
                }
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        //Load combobox tháng năm
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
            ViewBag.Thang = new SelectList(listItems, "Value", "Text", selected);
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
            ViewBag.Nam = new SelectList(listItems, "Value", "Text", selected);
        }
    }
}