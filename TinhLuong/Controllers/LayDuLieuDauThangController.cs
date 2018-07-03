using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;

namespace TinhLuong.Controllers
{
    public class LayDuLieuDauThangController : BaseController
    {
        SaveLog sv = new SaveLog();
        // GET: TinhLuong3Ps
        [CheckCredential(RoleID = "CHOT_SO")]
        public ActionResult Index()
        {
            

            // sv.save(Session[SessionCommon.Username].ToString(), "Tinh Luong->Tinh Luong 3Ps");
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

        [HttpPost]
        public JsonResult GetNgayCong(int thang, int nam)
        {
            var rs = new ImportExcelBLL().Get_SoNgayCong(thang, nam);
            return Json(new
            {
                status = rs
            });
        }



        [CheckCredential(RoleID = "CHOT_SO")]
        public ActionResult TinhLuong(int drpThang, int drpNam, int NC)
        {
            Session.Add(SessionCommon.Thang, drpThang);
            Session.Add(SessionCommon.nam, drpNam);
            try
            {
                var check = new ImportExcelBLL().GetChotSo(drpThang, drpNam, Session[SessionCommon.DonViID].ToString(), "BangLuong");
                if (check)
                {
                    var outPut = new TinhLuong3PsBLL().CopyBangLuongThang( drpThang, drpNam,NC);
                    if (outPut==1)
                    {
                        
                            sv.save(Session[SessionCommon.Username].ToString(), "Tinh Luong->CopyBangLuongThang->CopyBangLuongThang thanh cong-thang-" + drpThang + "-nam-" + drpNam);
                            setAlert("Lấy thông số lương thành công", "success");
                        return Redirect("/bang-luong-don-vi/thang-"+ drpThang + "-nam-"+drpNam);
                    }
                    else if (outPut == -1)
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Tinh Luong->CopyBangLuongThang->CopyBangLuongThang that bai-thang-" + drpThang + "-nam-" + drpNam);
                        setAlert("Cập nhật thất bại do tháng lương đã tồn tại", "error");
                    }
                    else
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Tinh Luong->CopyBangLuongThang->CopyBangLuongThang that bai-thang-" + drpThang + "-nam-" + drpNam);
                        setAlert("Lỗi thực thi, Cập nhật thất bại", "error");
                    }
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Tinh Luong->CopyBangLuongThang->CopyBangLuongThang that bai do thang luong da chot-thang-" + drpThang + "-nam-" + drpNam);
                    setAlert("Tháng lương đã chốt, không cập nhật lại được!", "error");
                }
            }
            catch
            {
                setAlert("Cập nhật thất bại", "error");
            }
            return Redirect("/lay-du-lieu-thang");
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
    }
}