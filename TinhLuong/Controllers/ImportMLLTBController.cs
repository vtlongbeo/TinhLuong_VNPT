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
    public class ImportMLLTBController : BaseController
    {
        // GET: ImportMLLTB
        SaveLog sv = new SaveLog();
        [CheckCredential(RoleID = "IMPORT_EXCELPTTB_KDTM")]
        public ActionResult Index()
        {
            DMLoaiTB();
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
            DMLoaiTB(Session["LoaiTB"].ToString());
            try
            {
                DataTable dt = (DataTable)Session["dtImport"];
                if (dt.Rows.Count > 0 || dt != null)
                {
                    string cl8 = dt.Rows[0]["DonViID"].ToString();
                    string cl9 = dt.Rows[0]["Nam"].ToString();
                    string cl10 = dt.Rows[0]["Thang"].ToString();
                    string cl11 = dt.Rows[0]["SLTB"].ToString();
                    string cl12 = dt.Rows[0]["TGMLL"].ToString();
                    return View(dt);
                }
                else if (dt.Rows.Count == 0 || dt == null)
                {
                    setAlert("Cấu trúc tệp không chính xác hoặc không có dữ liệu để import", "error");
                    return Redirect("/import-mlltb");
                }
                else
                {
                    setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                    return Redirect("/import-mlltb");
                }

            }
            catch
            {
                setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                return Redirect("/import-mlltb");
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
                try
                {
                    if (new ImportExcelBLL().GetChotSo(int.Parse(dt.Rows[0]["Thang"].ToString()), int.Parse(dt.Rows[0]["Nam"].ToString()), Session[SessionCommon.DonViID].ToString(), "BangLuong") == false)
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Import phiếu báo mll thiết bị->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Do thang luong da chot");
                        setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
                    }
                    else
                    {
                        bool delete = new ImportExcelBLL().Delete_MLLTB(int.Parse(dt.Rows[0]["Nam"].ToString()), int.Parse(dt.Rows[0]["Thang"].ToString()), Session["LoaiTB"].ToString());
                        if (delete)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                try
                                {
                                    var rs = new ImportExcelBLL().Insert_MLLTB(int.Parse(dt.Rows[i]["Nam"].ToString()), int.Parse(dt.Rows[i]["Thang"].ToString()), dt.Rows[i]["DonViID"].ToString(), Session["LoaiTB"].ToString(), int.Parse(dt.Rows[i]["TGMLL"].ToString()), int.Parse(dt.Rows[i]["SLTB"].ToString()));
                                    if (rs) dem++;
                                    else
                                    {
                                        rows = rows == "" ? rows + "" + ((i + 1).ToString()) : rows + ", " + ((i + 1).ToString());
                                    }
                                }
                                catch(Exception ex)
                                {
                                    rows = rows == "" ? rows + "" + ((i + 1).ToString()) : rows + ", " + ((i + 1).ToString());
                                    continue;
                                }
                            }
                            if (dem == dt.Rows.Count)
                            {
                                Session.Remove("dtImport");
                                sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Import Thiết bị MLL->Import Thanh Cong");
                                setAlert("Import dữ liệu thành công", "success");
                                return Redirect("/import-mlltb");
                            }
                            else if (0 < dem && dem < dt.Rows.Count)
                            {
                                string msg1 = " Dòng " + rows.ToString() + " import không thành công. Vui lòng import lại";
                                setAlertTime(msg1, "error");
                                sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Import Thiết bị MLL->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Dong import k thanh cong-" + rows);

                                return Redirect("/import-mlltb");
                            }
                            else
                            {
                                sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Import Thiết bị MLL->Import khong Thanh Cong");
                                setAlert("Import dữ liệu không thành công import không thành công. Vui lòng import lại", "error");
                            }
                        }
                        else
                            setAlert("Import dữ liệu không thành công import không thành công. Vui lòng import lại", "error");
                    }
                }catch(Exception ex)
                {
                    setAlert("Xảy ra lỗi: " + ex.Message, "error");
                }
               
            }
            else
            {
                setAlert("Không có dữ liệu để import!", "error");
            }
            return Redirect("/import-mlltb");
        }

        /// <summary>
        /// read file import to get data
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImportexcelToDb(HttpPostedFileBase file,string LoaiTB)
        {
            Session.Add("LoaiTB", LoaiTB);
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
                    return Redirect("/import-mlltb/doc-file");
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
            return Redirect("/import-mlltb");

        }

        public void DMLoaiTB(string selected = null)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "BTS,NodeB",
                Value = "BTS_NODEB"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Băng rộng",
                Value = "BR"
            });
            ViewBag.LoaiTB = new SelectList(listItems, "Value", "Text", selected);
        }
    }
}