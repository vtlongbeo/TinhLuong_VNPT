using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinhLuong.Models;
using TinhLuongBLL;
using System.Data.OleDb;

namespace TinhLuong.Controllers
{
    public class ImportExcelController : BaseController
    {
        /// <summary>
        /// import file lương tạm ứng kỳ 1
        /// </summary>
        /// <returns></returns>
        /// 
        SaveLog sv = new SaveLog();
        [CheckCredential(RoleID = "IMPORT_EXCELPTTB_KDTM")]
        public ActionResult Index()
        {
          //  sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Cac Khoan thu Nhap Ky 1");
            return View();
        }


        /// <summary>
        /// View data befor import
        /// </summary>
        /// <returns></returns>
        [CheckCredential(RoleID = "IMPORT_EXCELPTTB_KDTM")]
        public ActionResult Success()
        {
            try
            {
                DataTable dt = (DataTable)Session["dtImport"];
                if (dt.Rows.Count > 0 || dt!=null)
                {
                    string cl1 = dt.Rows[0]["NhanSuID"].ToString();
                    string cl11 = dt.Rows[0]["TT_THEMGIO"].ToString();
                    string cl2 = dt.Rows[0]["CHENUOC"].ToString();
                    string cl3 = dt.Rows[0]["ANCA"].ToString();
                    string cl4 = dt.Rows[0]["LUONGKY1"].ToString();
                    string cl5 = dt.Rows[0]["THUNHAP1"].ToString();
                    string cl6 = dt.Rows[0]["CTP_KHOANTH"].ToString();
                    string cl7 = dt.Rows[0]["CTP_KHAC"].ToString();
                    string cl8 = dt.Rows[0]["BOIDUONGK3"].ToString();
                    string cl9 = dt.Rows[0]["Nam"].ToString();
                    string cl10 = dt.Rows[0]["Thang"].ToString();
                    return View(dt);
                }
                else if (dt.Rows.Count == 0 || dt == null)
                {
                    setAlert("Cấu trúc tệp không chính xác hoặc không có dữ liệu để import", "error");
                    return Redirect("/import-ky-1");
                }
                else
                {
                    setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                    return Redirect("/import-ky-1");
                }

            }
            catch
            {
                setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                return Redirect("/import-ky-1");
            }

        }

        /// <summary>
        /// import data to db
        /// </summary>
        /// <returns></returns>
        [CheckCredential(RoleID = "IMPORT_EXCELPTTB_KDTM")]
        public ActionResult ImportDB()
        {
            DataTable dt = (DataTable)Session["dtImport"];
            string rows = "";
            int dem = 0;

            if (dt.Rows.Count > 0)
            {
                if (new ImportExcelBLL().GetChotSo(int.Parse(dt.Rows[0]["Thang"].ToString()), int.Parse(dt.Rows[0]["Nam"].ToString()), Session[SessionCommon.DonViID].ToString(), "BangLuong") == false)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Cac khoan thu nhap ky 1->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Do thang luong da chot");
                    setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            int thunhap1 = !string.IsNullOrWhiteSpace(dt.Rows[i]["THUNHAP1"].ToString()) ? int.Parse(dt.Rows[i]["THUNHAP1"].ToString()) : 0;
                            int luongky1 = !string.IsNullOrWhiteSpace(dt.Rows[i]["LUONGKY1"].ToString()) ? int.Parse(dt.Rows[i]["LUONGKY1"].ToString()) : 0;
                            int anca = !string.IsNullOrWhiteSpace(dt.Rows[i]["ANCA"].ToString()) ? int.Parse(dt.Rows[i]["ANCA"].ToString()) : 0;
                            int themgio = !string.IsNullOrWhiteSpace(dt.Rows[i]["TT_THEMGIO"].ToString()) ? int.Parse(dt.Rows[i]["TT_THEMGIO"].ToString()) : 0;
                            int chenuoc = !string.IsNullOrWhiteSpace(dt.Rows[i]["CHENUOC"].ToString()) ? int.Parse(dt.Rows[i]["CHENUOC"].ToString()) : 0;
                            int khoanth = !string.IsNullOrWhiteSpace(dt.Rows[i]["CTP_KHOANTH"].ToString()) ? int.Parse(dt.Rows[i]["CTP_KHOANTH"].ToString()) : 0;
                            int ctp_khac = !string.IsNullOrWhiteSpace(dt.Rows[i]["CTP_KHAC"].ToString()) ? int.Parse(dt.Rows[i]["CTP_KHAC"].ToString()) : 0;
                            int boiduongk3 = !string.IsNullOrWhiteSpace(dt.Rows[i]["BOIDUONGK3"].ToString()) ? int.Parse(dt.Rows[i]["BOIDUONGK3"].ToString()) : 0;
                            var rs = new ImportExcelBLL().CapNhatBangLuongKy1_Import(int.Parse(dt.Rows[i]["Nam"].ToString()), int.Parse(dt.Rows[i]["Thang"].ToString()), dt.Rows[i]["NhanSuID"].ToString(), Session[SessionCommon.DonViID].ToString(), anca,
                            khoanth, themgio, chenuoc, ctp_khac, boiduongk3, thunhap1, luongky1, Session[SessionCommon.Username].ToString());
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
                    }
                    if (dem == dt.Rows.Count)
                    {
                        Session.Remove("dtImport");
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Cac khoan thu nhap ky 1->Import Thanh Cong");
                        setAlert("Import dữ liệu thành công", "success");
                        return Redirect("/update-khoan-thanh-toan/thang-" + dt.Rows[0][1].ToString() + "-nam-" + dt.Rows[0][0].ToString());
                    }
                    else if (0 < dem && dem < dt.Rows.Count)
                    {
                        string msg1 = " Dòng " + rows.ToString() + " import không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng!";
                        setAlertTime(msg1, "error");
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Cac khoan thu nhap ky 1->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Dong import k thanh cong-" + rows);

                        return Redirect("/import-ky-1/doc-file");
                    }
                    else
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Cac khoan thu nhap ky 1->Import khong Thanh Cong");
                        setAlert("Import dữ liệu không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng", "error");
                    }

                }
            }
            else
            {
                setAlert("Không có dữ liệu để import!", "error");
            }
            return Redirect("/import-ky-1");
        }

        /// <summary>
        /// read file import to get data
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImportexcelToDb(HttpPostedFileBase file)
        {

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
                        //connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path1 + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
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
                    return Redirect("/import-ky-1/doc-file");
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
            return Redirect("/import-ky-1");

        }
    }
}