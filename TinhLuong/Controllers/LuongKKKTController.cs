using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;

namespace TinhLuong.Controllers
{
    public class LuongKKKTController : BaseController
    {
        SaveLog sv = new SaveLog();
        // GET: LuongKKKT
        [CheckCredential(RoleID = "TINH_LUONGKKKT")]
        public ActionResult Index()
        {
           // sv.save(Session[SessionCommon.Username].ToString(), "Tinh Luong->Tinh lương KKKT");
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


        [CheckCredential(RoleID = "TINH_LUONGKKKT")]
        public ActionResult LuongKKKTReport(int thang, int nam, string type)
        {
            Session.Add(SessionCommon.Thang, thang);
            Session.Add(SessionCommon.nam, nam);
            if (type == "print")
            {
                //sv.save(Session[SessionCommon.Username].ToString(), "Tinh Luong->Tinh lương KKKT->ViewReport-thang-" + thang + "-nam-" + nam);
                string content = "~/Reports/ReportsLuongKKKT/ReportKKTT.aspx";
                return Redirect(content);
            }
            else
            {
                if (new ImportExcelBLL().GetChotSo(thang, nam, Session[SessionCommon.DonViID].ToString(), "BangLuong"))
                {
                    bool outPut = new LuongKKKTBLL().UpdateLKK(thang, nam);
                    if (outPut)
                    {
                        bool outPut1 = new LuongKKKTBLL().ThemMoiTinhLuong_Log(thang, nam, Session[SessionCommon.Username].ToString(), DateTime.Now, "Tinh Luong KK Khen thưởng", "Bang Luong", "");
                        if (outPut1)
                        {
                            sv.save(Session[SessionCommon.Username].ToString(), "Tinh Luong->Tinh lương KKKT->Tinh Luong - thang-" + thang + "-nam-" + nam + "-Success");
                            setAlert("Đã tính lương khen thưởng thành công", "success");
                        }
                        else setAlert("Cập nhật Log thất bại!", "error");
                    }
                    else
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Tinh Luong->Tinh lương KKKT->Tinh Luong - thang-" + thang + "-nam-" + nam + "-Fail");
                        setAlert("Cập nhật lương khen thưởng thất bại", "error");
                    }
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Tinh Luong->Tinh lương KKKT->Tinh Luong - thang-" + thang + "-nam-" + nam + "-Fail do thang luong da chot");
                    setAlert("Tháng đã chốt lương, không tính lại được!", "error");
                }
            }
            return Redirect("/LuongKKKT");
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