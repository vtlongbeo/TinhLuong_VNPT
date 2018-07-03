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
    public class ImportLuongSuaChuaController : BaseController
    {
        // GET: ImportLuongSuaChua
        SaveLog sv = new SaveLog();
        public ActionResult Index()
        {
            DMLoaiLuong();
            return View();
        }


        [CheckCredential(RoleID = "IMPORT_SUACHUA")]
        public ActionResult Success()
        {
            DMLoaiLuong(Session["LoaiLuong"].ToString());
            try
            {
                DataTable dt = (DataTable)Session["dtImport"];
                if (dt.Rows.Count > 0)
                {
                    string cl1 = dt.Rows[0]["NhanSuID"].ToString();
                    string cl11 = dt.Rows[0]["LUONGKHAC"].ToString();
                    string cl9 = dt.Rows[0]["Nam"].ToString();
                    string cl10 = dt.Rows[0]["Thang"].ToString();
                    return View(dt);
                }
                else if (dt.Rows.Count == 0 || dt == null)
                {
                    setAlert("Cấu trúc tệp không chính xác hoặc không có dữ liệu để import", "error");
                    return Redirect("/import-luong-suachua");
                }
                else
                {
                    setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                    return Redirect("/import-luong-suachua");
                }
            }
            catch
            {
                setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp", "error");
                return Redirect("/import-luong-suachua");
            }

        }

        [CheckCredential(RoleID = "IMPORT_SUACHUA")]
        public ActionResult ImportDB()
        {
            string loailuong = Session["LoaiLuong"].ToString();
            DataTable dt = (DataTable)Session["dtImport"];
            string rows = "";
            int dem = 0;

            if (dt.Rows.Count > 0)
            {
                if (new ImportExcelBLL().GetChotSo(int.Parse(dt.Rows[0]["Thang"].ToString()), int.Parse(dt.Rows[0]["Nam"].ToString()), Session[SessionCommon.DonViID].ToString(), "BangLuong") == false)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Luong sua chua->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Do thang luong da chot");
                    setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
                }
                else
                {
                    //var delete = new ImportExcelBLL().Delete_LuongKhac(int.Parse(dt.Rows[0]["Nam"].ToString()), int.Parse(dt.Rows[0]["Thang"].ToString()), Session[SessionCommon.Username].ToString());
                    //if (delete)
                    //{
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                decimal LUONGKHAC = !string.IsNullOrWhiteSpace(dt.Rows[i]["LUONGKHAC"].ToString()) ? decimal.Parse(dt.Rows[i]["LUONGKHAC"].ToString()) : 0;
                                string NhanSuID = dt.Rows[i]["NhanSuID"].ToString();
                                decimal Thang = decimal.Parse(dt.Rows[i]["Thang"].ToString());
                                decimal Nam = decimal.Parse(dt.Rows[i]["Nam"].ToString());
                                string UserName = Session[SessionCommon.Username].ToString();
                                var rs = new ImportExcelBLL().Update_LUONGKHAC(Nam, Thang, UserName, LUONGKHAC, NhanSuID,loailuong);
                                if (rs) dem++;
                                else
                                {
                                    rows = rows == "" ? rows + "" + ((i + 1).ToString()) : rows + ", " + ((i + 1).ToString());
                                }
                            }
                            catch
                            {
                                rows = rows == "" ? rows + "" + ((i + 1).ToString()) : rows + ", " + ((i + 1).ToString());
                                continue;
                            }
                        //}
                    }
                    if (dem == dt.Rows.Count)
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Luong sua chua->Import Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString());
                        setAlert("Import dữ liệu thành công", "success");
                        return Redirect("/import-luong-suachua");
                    }
                    else if (0 < dem && dem < dt.Rows.Count)
                    {
                        string msg1 = " Dòng " + rows.ToString() + " import không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng!";
                        setAlertTime(msg1, "error");
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Luong sua chua->Import  khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Dong khong import-" + rows);
                        return Redirect("/import-luong-suachua/doc-file");
                    }
                    else
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Luong sua chua->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString());
                        setAlert("Import dữ liệu không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng", "error");
                    }

                }
            }
            else
            {
                setAlert("Không có dữ liệu để import!", "error");
            }
            return Redirect("/import-luong-suachua");
        }
        [HttpPost]
        public ActionResult ImportexcelToDb(HttpPostedFileBase file, string LoaiLuong)
        {
            Session.Add("LoaiLuong", LoaiLuong);
            if (file != null && file.ContentLength > 0)
            {
                string fileName = "fileUpload_" + Session[SessionCommon.Username].ToString() + "_" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "_" + file.FileName;
                string path1 = Path.Combine(Server.MapPath("~/Assets/Uploads/Import/"), RemoveUnicode.ConvertToUnsign2(fileName));
                string extension = Path.GetExtension(file.FileName);
                string connString = "";
                file.SaveAs(path1 + "" + extension);
                path1 = path1 + "" + extension;
                string[] validFileTypes = { ".xls", ".xlsx", ".csv" };
                DataTable dt;
                if (validFileTypes.Contains(extension))
                {

                    if (extension == ".csv")
                    {
                        dt = Utility.ConvertCSVtoDataTable(path1);
                        Session["dtImport"] = dt;
                    }
                    //Connection String to Excel Workbook  
                    else if (extension == ".xls")
                    {
                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 8.0;";
                       // connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path1 + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        try
                        {

                            dt = Utility.ConvertXSLXtoDataTable(path1, connString);
                            Session["dtImport"] = dt;
                        }
                        catch (Exception ex)
                        {
                            setAlert(ex.ToString(), "success");
                        }

                    }
                    else if (extension == ".xlsx")
                    {
                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        dt = Utility.ConvertXSLXtoDataTable(path1, connString);
                        Session["dtImport"] = dt;
                    }
                    DataTable dt1 = (DataTable)Session["dtImport"];
                    string rows = "";
                    if (dt1.Rows.Count > 0)
                    {
                        var nhansu = new ImportExcelBLL().GetBangLuongDonVi(Session[SessionCommon.DonViID].ToString(), decimal.Parse(dt1.Rows[0]["Thang"].ToString()), decimal.Parse(dt1.Rows[0]["Nam"].ToString()));
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            string ma = dt1.Rows[i]["NhanSuID"].ToString();
                            if (!(nhansu.Contains(dt1.Rows[i]["NhanSuID"].ToString())) && !string.IsNullOrWhiteSpace(dt1.Rows[i]["NhanSuID"].ToString()))
                            {
                                rows = rows == "" ? rows + " " + dt1.Rows[i]["NhanSuID"].ToString() : rows + ", " + dt1.Rows[i]["NhanSuID"].ToString();
                            }
                        }
                        if (rows != "") setAlertTime("Nhân viên có mã " + rows + " không có trong bảng lương đề nghị xem lại trước khi import dữ liệu", "error");
                    }
                    System.IO.File.Delete(path1);
                    return Redirect("/import-luong-suachua/doc-file");
                }
                else
                {
                    setAlert("Vui lòng chỉ Upload tệp có định dạng .xls, .xlsx hoặc .csv", "error");

                }

            }
            else
            {
                setAlert("Vui lòng chọn file", "error");
            }
            return Redirect("/import-luong-suachua");

        }
        public void DMLoaiLuong(string selected = null)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "Lương sửa chữa mạng lưới",
                Value = "SCML"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Lương sửa chữa thiết bị",
                Value = "SCTB"
            });
            ViewBag.LoaiLuong = new SelectList(listItems, "Value", "Text", selected);
        }
    }
}