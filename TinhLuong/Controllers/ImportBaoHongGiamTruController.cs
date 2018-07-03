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
    public class ImportBaoHongGiamTruController : BaseController
    {
        // GET: ImportBaoHongGiamTru
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
                if (dt.Rows.Count > 0 || dt != null)
                {
                    string cl8 = dt.Rows[0]["PhieuBaoHongID"].ToString();
                    string cl9 = dt.Rows[0]["Nam"].ToString();
                    string cl10 = dt.Rows[0]["Thang"].ToString();
                    return View(dt);
                }
                else if (dt.Rows.Count == 0 || dt == null)
                {
                    setAlert("Cấu trúc tệp không chính xác hoặc không có dữ liệu để import", "error");
                    return Redirect("/import-baohong");
                }
                else
                {
                    setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                    return Redirect("/import-baohong");
                }

            }
            catch
            {
                setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                return Redirect("/import-baohong");
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
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Import phiếu báo hỏng giảm trừ->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Do thang luong da chot");
                    setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
                }
                else
                {
                    new ImportExcelBLL().Delete_BaoHongGiamTru(int.Parse(dt.Rows[0]["Nam"].ToString()), int.Parse(dt.Rows[0]["Thang"].ToString()));

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                       try
                        {
                             var rs = new ImportExcelBLL().Import_BaoHongGiamTru(int.Parse(dt.Rows[i]["Nam"].ToString()), int.Parse(dt.Rows[i]["Thang"].ToString()), int.Parse(dt.Rows[i]["PhieuBaoHongID"].ToString()));
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
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Import phiếu báo hỏng giảm trừ->Import Thanh Cong");
                        setAlert("Import dữ liệu thành công", "success");
                        return Redirect("/import-baohong");
                    }
                    else if (0 < dem && dem < dt.Rows.Count)
                    {
                        string msg1 = " Dòng " + rows.ToString() + " import không thành công. Vui lòng import lại";
                        setAlertTime(msg1, "error");
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Import phiếu báo hỏng giảm trừ->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Dong import k thanh cong-" + rows);

                        return Redirect("/import-baohong");
                    }
                    else
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Import phiếu báo hỏng giảm trừ->Import khong Thanh Cong");
                        setAlert("Import dữ liệu không thành công import không thành công. Vui lòng import lại", "error");
                    }

                }
            }
            else
            {
                setAlert("Không có dữ liệu để import!", "error");
            }
            return Redirect("/import-baohong");
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
                    System.IO.File.Delete(path1);
                    return Redirect("/import-baohong/doc-file");
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
            return Redirect("/import-baohong");

        }
    }
}