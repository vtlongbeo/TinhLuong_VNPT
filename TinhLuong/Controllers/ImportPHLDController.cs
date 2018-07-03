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
using TinhLuongINFO;

namespace TinhLuong.Controllers
{
    public class ImportPHLDController : BaseController
    {
        SaveLog sv = new SaveLog();
        // GET: ImportPHLD
        public ActionResult Index()
        {
            return View();
        }


        [CheckCredential(RoleID = "IMPORT_EXCELPTTB_KDTM")]
        public ActionResult Success()
        {
            try
            {
                DataTable dt = (DataTable)Session["dtImport"];
                if (dt.Rows.Count > 0 || dt != null)
                {
                    //string cl8 = dt.Rows[0]["PhieuBaoHongID"].ToString();
                    //string cl9 = dt.Rows[0]["Nam"].ToString();
                    //string cl10 = dt.Rows[0]["Thang"].ToString();
                    return View(dt);
                }
                else if (dt.Rows.Count == 0 || dt == null)
                {
                    setAlert("Cấu trúc tệp không chính xác hoặc không có dữ liệu để import", "error");
                    return Redirect("/import-phlapdat");
                }
                else
                {
                    setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                    return Redirect("/import-phlapdat");
                }

            }
            catch
            {
                setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                return Redirect("/import-phlapdat");
            }

        }



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

                        DataTable dtPHLD = new DataTable();
                        if (dtPHLD.Columns.Count == 0)
                        {
                            DataColumn c0 = new DataColumn("Nam", typeof(int));
                            DataColumn c1 = new DataColumn("Thang", typeof(int));
                            DataColumn c2 = new DataColumn("NhanSuID", typeof(string));
                            DataColumn c3 = new DataColumn("Luong", typeof(int));
                            dtPHLD.Columns.Add(c0);
                            dtPHLD.Columns.Add(c1);
                            dtPHLD.Columns.Add(c2);
                            dtPHLD.Columns.Add(c3);
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow drr = dtPHLD.NewRow();
                            drr["Thang"] = int.Parse(dt.Rows[i]["Thang"].ToString());
                            drr["Nam"] = int.Parse(dt.Rows[i]["Nam"].ToString());
                            drr["NhanSuID"] = dt.Rows[i]["NhanSuID"].ToString();
                            drr["Luong"] = int.Parse(dt.Rows[i]["Luong"].ToString());
                            dtPHLD.Rows.Add(drr);
                        }
                        Session["dtImport"] = dtPHLD;
                    }
                    //Connection String to Excel Workbook  
                    else if (extension == ".xls")
                    {
                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 8.0;";
                        //connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path1 + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        try
                        {

                            dt = Utility.ConvertXSLXtoDataTable(path1, connString);
                            DataTable dtPHLD = new DataTable();
                            if (dtPHLD.Columns.Count == 0)
                            {
                                DataColumn c0 = new DataColumn("Nam", typeof(int));
                                DataColumn c1 = new DataColumn("Thang", typeof(int));
                                DataColumn c2 = new DataColumn("NhanSuID", typeof(string));
                                DataColumn c3 = new DataColumn("Luong", typeof(int));
                                dtPHLD.Columns.Add(c0);
                                dtPHLD.Columns.Add(c1);
                                dtPHLD.Columns.Add(c2);
                                dtPHLD.Columns.Add(c3);
                            }
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DataRow drr = dtPHLD.NewRow();
                                drr["Thang"] = int.Parse(dt.Rows[i]["Thang"].ToString());
                                drr["Nam"] = int.Parse(dt.Rows[i]["Nam"].ToString());
                                drr["NhanSuID"] = dt.Rows[i]["NhanSuID"].ToString();
                                drr["Luong"] = int.Parse(dt.Rows[i]["Luong"].ToString());
                                dtPHLD.Rows.Add(drr);
                            }
                            Session["dtImport"] = dtPHLD;
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
                        DataTable dtPHLD = new DataTable();
                        if (dtPHLD.Columns.Count == 0)
                        {
                            DataColumn c0 = new DataColumn("Nam", typeof(int));
                            DataColumn c1 = new DataColumn("Thang", typeof(int));
                            DataColumn c2 = new DataColumn("NhanSuID", typeof(string));
                            DataColumn c3 = new DataColumn("Luong", typeof(int));
                            dtPHLD.Columns.Add(c0);
                            dtPHLD.Columns.Add(c1);
                            dtPHLD.Columns.Add(c2);
                            dtPHLD.Columns.Add(c3);
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow drr = dtPHLD.NewRow();
                            drr["Thang"] = int.Parse(dt.Rows[i]["Thang"].ToString());
                            drr["Nam"] = int.Parse(dt.Rows[i]["Nam"].ToString());
                            drr["NhanSuID"] = dt.Rows[i]["NhanSuID"].ToString();
                            drr["Luong"] = int.Parse(dt.Rows[i]["Luong"].ToString());
                            dtPHLD.Rows.Add(drr);
                        }
                        Session["dtImport"] = dtPHLD;
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
                    return Redirect("/import-phlapdat/doc-file");
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

        public ActionResult ImportDB()
        {
            DataTable dtPH = (DataTable)Session["dtImport"];
            string rows = "";
            int demPH = 0;
            int Thang = 1;
            int Nam = 2018;

            if (dtPH.Rows.Count > 0)
            {
                if (new ImportExcelBLL().GetChotSo(int.Parse(dtPH.Rows[0]["Thang"].ToString()), int.Parse(dtPH.Rows[0]["Nam"].ToString()), Session[SessionCommon.DonViID].ToString(), "BangLuong") == false)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Khuyen khich lap dat->Import khong Thanh Cong- Thang-" + dtPH.Rows[0]["Thang"].ToString() + "-nam-" + dtPH.Rows[0]["Nam"].ToString() + "-Do thang luong da chot");
                    setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
                }
                else
                {
                    new ImportExcelBLL().Delete_KKLD(int.Parse(dtPH.Rows[0]["Nam"].ToString()), int.Parse(dtPH.Rows[0]["Thang"].ToString()), Session[SessionCommon.Username].ToString(), 2);
                    for (int i = 0; i < dtPH.Rows.Count; i++)
                    {
                        try
                        {
                            Thang =int.Parse(dtPH.Rows[i]["Thang"].ToString());
                            Nam = int.Parse(dtPH.Rows[i]["Nam"].ToString());
                            BangLuongLapDat bl = new BangLuongLapDat();
                            bl.LUONGPHLD = !string.IsNullOrWhiteSpace(dtPH.Rows[i]["Luong"].ToString()) ? decimal.Parse(dtPH.Rows[i]["Luong"].ToString()) : 0;
                            bl.LUONGKKLD = 0;
                            bl.LUONGSPITTER = 0;
                            bl.NhanSuID = dtPH.Rows[i]["NhanSuID"].ToString();
                            bl.Thang = decimal.Parse(dtPH.Rows[i]["Thang"].ToString());
                            bl.Nam = decimal.Parse(dtPH.Rows[i]["Nam"].ToString());
                            bl.UserName = Session[SessionCommon.Username].ToString();
                            var rs = new ImportExcelBLL().UpdateLAPDAT(bl);
                            if (rs) demPH++;
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
                    if (demPH == dtPH.Rows.Count)
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Phoi hop lap dat->Import Thanh Cong- Thang-" + dtPH.Rows[0]["Thang"].ToString() + "-nam-" + dtPH.Rows[0]["Nam"].ToString());
                        setAlert("Import dữ liệu thành công", "success");
                        //if (Thang.Length == 1)
                        //    Thang = "0" + Thang;

                        bool updateLuongKKKT = new LuongKKKTBLL().UpdateLUONGDTTK(Thang,Nam);


                        return Redirect("/import-phlapdat");
                    }
                    else if (0 < demPH && demPH < dtPH.Rows.Count)
                    {
                        string msg1 = " Dòng " + rows.ToString() + " import không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng!";
                        setAlertTime(msg1, "error");
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Phoi hop lap dat->Import  khong Thanh Cong- Thang-" + dtPH.Rows[0]["Thang"].ToString() + "-nam-" + dtPH.Rows[0]["Nam"].ToString() + "-Dong khong import-" + rows);
                        //if (Thang.Length == 1)
                        //    Thang = "0" + Thang;
                        return Redirect("/import-phlapdat");
                    }
                    else
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Phoi hop lap dat->Import khong Thanh Cong- Thang-" + dtPH.Rows[0]["Thang"].ToString() + "-nam-" + dtPH.Rows[0]["Nam"].ToString());
                        setAlert("Import dữ liệu không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng", "error");
                        return Redirect("/import-phlapdat");
                    }

                }
            }
            else
            {
                setAlert("Không có dữ liệu để import!", "error");
            }
            return Redirect("/import-phlapdat");
        }
    }
}