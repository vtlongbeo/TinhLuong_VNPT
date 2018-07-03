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
    public class ImportTienLuongBSController : BaseController
    {

        // GET: ImportLuongUngCuu
        /// <summary>
        /// import file lương tạm ứng kỳ 1
        /// </summary>
        /// <returns></returns>
        /// 
        SaveLog sv = new SaveLog();
        [CheckCredential(RoleID = "IMPORT_LUONGKHAC")]
        public ActionResult Index()
        {
            //  sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Cac Khoan thu Nhap Ky 1");
            return View();
        }


        /// <summary>
        /// View data befor import
        /// </summary>
        /// <returns></returns>
        [CheckCredential(RoleID = "IMPORT_LUONGKHAC")]
        public ActionResult Success()
        {
            try
            {
                DataTable dt = (DataTable)Session["dtImport"];
                if (dt.Rows.Count > 0 || dt != null)
                {
                    string cl1 = dt.Rows[0]["NhanSuID"].ToString();
                    string cl2 = dt.Rows[0]["TongTien"].ToString();
                    string cl3 = dt.Rows[0]["donviid"].ToString();
                    string cl4 = dt.Rows[0]["donvichaID"].ToString();
                    string cl5 = dt.Rows[0]["thunop"].ToString();
                    string cl6 = dt.Rows[0]["ngayck"].ToString();
                    string cl7 = dt.Rows[0]["sotk"].ToString();
                    string cl8 = dt.Rows[0]["chuyenkhoan"].ToString();
                    return View(dt);
                }
                else if (dt.Rows.Count == 0 || dt == null)
                {
                    setAlert("Cấu trúc tệp không chính xác hoặc không có dữ liệu để import", "error");
                    return Redirect("/import-bs");
                }
                else
                {
                    setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                    return Redirect("/import-bs");
                }

            }
            catch
            {
                setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                return Redirect("/import-bs");
            }

        }

        /// <summary>
        /// import data to db
        /// </summary>
        /// <returns></returns>
        [CheckCredential(RoleID = "IMPORT_LUONGKHAC")]
        public ActionResult ImportDB()
        {
            DataTable dt = (DataTable)Session["dtImport"];
            string rows = "";
            int dem = 0;

            if (dt.Rows.Count > 0)
            {
                if (new ImportExcelBLL().Delete_BoSung_Temp()==false)
                {
                    setAlert("Không thể import dữ liệu. Vui lòng thử lại!", "error");
                }
                else
                {
                     for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            string nhansuid = dt.Rows[i]["nhansuid"].ToString();
                            int tongtien = !string.IsNullOrWhiteSpace(dt.Rows[i]["TongTien"].ToString()) ? int.Parse(dt.Rows[i]["TongTien"].ToString()) : 0;
                            string donviid = dt.Rows[i]["donviid"].ToString();
                            string donvichaID = dt.Rows[i]["donvichaID"].ToString();
                            int chuyenkhoan = !string.IsNullOrWhiteSpace(dt.Rows[i]["chuyenkhoan"].ToString()) ? int.Parse(dt.Rows[i]["chuyenkhoan"].ToString()) : 0;
                            string ngayck = dt.Rows[i]["ngayck"].ToString();
                            string sotk = dt.Rows[i]["sotk"].ToString();
                            int thunop = !string.IsNullOrWhiteSpace(dt.Rows[i]["thunop"].ToString()) ? int.Parse(dt.Rows[i]["thunop"].ToString()) : 0;
                            var rs = new ImportExcelBLL().UpdateBoSung(nhansuid, tongtien, donviid, donvichaID, chuyenkhoan, ngayck, thunop, Session[SessionCommon.Username].ToString(), sotk);
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
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Import lương bổ sung->Import Thanh Cong");
                        setAlert("Import dữ liệu thành công", "success");
                        return Redirect("/import-bs");
                    }
                    else if (0 < dem && dem < dt.Rows.Count)
                    {
                        string msg1 = " Dòng " + rows.ToString() + " import không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng!";
                        setAlertTime(msg1, "error");
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Ứng cứu, trực đêm->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Dong import k thanh cong-" + rows);

                        return Redirect("/import-bs/doc-file");
                    }
                    else
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Ứng cứu, trực đêm ->Import khong Thanh Cong");
                        setAlert("Import dữ liệu không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng", "error");
                    }

                }
            }
            else
            {
                setAlert("Không có dữ liệu để import!", "error");
            }
            return Redirect("/import-bs");
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
                    //if (dt1.Rows.Count > 0)
                    //{
                    //    var nhansu = new ImportExcelBLL().GetBangLuongDonVi(Session[SessionCommon.DonViID].ToString(), decimal.Parse(dt1.Rows[0]["Thang"].ToString()), decimal.Parse(dt1.Rows[0]["Nam"].ToString()));
                    //    for (int i = 0; i < dt1.Rows.Count; i++)
                    //    {
                    //        string ma = dt1.Rows[i]["NhanSuID"].ToString();
                    //        if (!(nhansu.Contains(dt1.Rows[i]["NhanSuID"].ToString())) && !string.IsNullOrWhiteSpace(dt1.Rows[i]["NhanSuID"].ToString()))
                    //        {
                    //            rows = rows == "" ? rows + " " + dt1.Rows[i]["NhanSuID"].ToString() : rows + ", " + dt1.Rows[i]["NhanSuID"].ToString();
                    //        }
                    //    }
                    //    if (rows != "") setAlertTime("Nhân viên có mã " + rows + " không có trong bảng lương đề nghị xem lại trước khi import dữ liệu", "error");
                    //}
                    System.IO.File.Delete(path1);
                    return Redirect("/import-bs/doc-file");
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
            return Redirect("/import-bs");

        }

    }
}