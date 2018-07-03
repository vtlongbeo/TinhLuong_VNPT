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
    public class BangLuongDonViController : BaseController
    {
        SaveLog sv = new SaveLog();
        // GET: Cập nhật bảng lương đơn vị
        [CheckCredential(RoleID = "TINH_LUONG")]
        public ActionResult Index()
        {
           // sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Bang luong don vi");
            drpThang();
            drpNam();
            return View();
        }



        [CheckCredential(RoleID = "TINH_LUONG")]
        public ActionResult IndexDetail(int thang, int nam)
        {
            //sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Bang luong don vi->thang-" + thang + "-nam" + nam);
            drpNam(nam.ToString());
            drpThang(thang.ToString());
            var bangluong = new BangLuongDonViBLL().GetBangLuongDonVi(Session[SessionCommon.DonViID].ToString(), thang, nam);
            return View(bangluong);
        }

        /// <summary>
        /// Xem chi tiet bang luong
        /// </summary>
        /// <param name="NhanSuID"></param>
        /// <param name="Thang"></param>
        /// <param name="Nam"></param>
        /// <returns></returns>
        [CheckCredential(RoleID = "TINH_LUONG")]
        [HttpGet]
        public ActionResult Details(string NhanSuID, int Thang, int Nam)
        {
           // sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Bang luong don vi->Detail->NhanSuID-" + NhanSuID + "-thang-" + Thang + "-nam-" + Nam);
            var bangluong = new BangLuongDonViBLL().GetBangLuongDonViByNhanSu(NhanSuID, Thang, Nam);
            loadDrpDonVi(bangluong.Rows[0]["DonViID"].ToString());
            return View(bangluong);
        }


        /// <summary>
        /// cập nhật bảng lương
        /// </summary>
        /// <param name="businessObject"></param>
        /// <returns></returns>
        /// 
        [CheckCredential(RoleID = "TINH_LUONG")]
        [HttpPost]
        public ActionResult UpdateLuongDonVi(BangLuong businessObject)
        {
            businessObject.UserName = Session[SessionCommon.Username].ToString();
            businessObject.NgayUp = DateTime.Now;
            if (new ImportExcelBLL().GetChotSo(businessObject.Thang, businessObject.Nam, Session[SessionCommon.DonViID].ToString(), "BangLuong") == false)
            {
                setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
            }
            else
            {
                var rs = new BangLuongDonViBLL().Update_BangLuongDonVi(businessObject);
                if (rs > 0)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Bang luong don vi->Update->NhanSuId-" + businessObject.NhanSuID + "-nam-" + businessObject.Nam + "-than-g" + businessObject.Thang + "->Success");
                    setAlert("Cập nhật thành công", "success");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Bang luong don vi->Update->NhanSuId-" + businessObject.NhanSuID + "-nam-" + businessObject.Nam + "-thang-" + businessObject.Thang + "->Fail");
                    setAlert("Cập nhật không thành công", "error");
                }
            }
            return Redirect("/bang-luong-don-vi/thang-" + businessObject.Thang + "-nam-" + businessObject.Nam);
        }


        /// <summary>
        /// add new Nhan vien
        /// </summary>
        /// <param name="selected"></param>
        /// 
        public ActionResult AddNewEmp()
        {
            if (Session[SessionCommon.Username].ToString().ToLower() == "admin")
            {
                loadDrpDonVi();
                AdddrpNam(DateTime.Now.Year.ToString());
                AdddrpThang(DateTime.Now.Month.ToString());
                return View();
            }
            else
            {
                setAlert("Bạn không có quyền thêm mới", "error");
                return Redirect("/bang-luong-don-vi");
            }
        }


        [HttpPost]
        public ActionResult AddNewEmp(BangLuong businessObject)
        {
            if (Session[SessionCommon.Username].ToString().ToLower() == "admin")
            {
                businessObject.UserName = Session[SessionCommon.Username].ToString();
                var rs = new BangLuongDonViBLL().Insert_BangLuongDonVi(businessObject);
                if (rs > 0)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Bang luong don vi->Addnew->NhanSuId-" + businessObject.NhanSuID + "-nam-" + businessObject.Nam + "-thang-" + businessObject.Thang + "->Success");
                    setAlert("Thêm mới thành công", "success");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap nhat luong->Bang luong don vi->Addnew->NhanSuId-" + businessObject.NhanSuID + "-nam-" + businessObject.Nam + "-thang-" + businessObject.Thang + "->Fail");
                    setAlert("Thêm mới không thành công", "error");
                }
            }
            return Redirect("/bang-luong-don-vi/thang-" + businessObject.Thang + "-nam-" + businessObject.Nam);

        }

        /// <summary>
        /// Load combobox
        /// </summary>
        /// <param name="selected"></param>
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
                Value = (DateTime.Now.Year - +2).ToString()
            });


            ViewBag.drpNam = new SelectList(listItems, "Value", "Text", selected);
        }
        public void AdddrpThang(string selected = null)
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
        public void AdddrpNam(string selected = null)
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
            ViewBag.Nam = new SelectList(listItems, "Value", "Text", selected);
        }
    }
}