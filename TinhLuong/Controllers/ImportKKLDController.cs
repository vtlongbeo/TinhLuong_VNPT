using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using TinhLuong.Models;
using TinhLuongBLL;
using TinhLuongINFO;

namespace TinhLuong.Controllers
{
    public class ImportKKLDController : BaseController
    {
        // GET: Import khuyến khích lắp đặt
        SaveLog sv = new SaveLog();
        [CheckCredential(RoleID = "IMPORT_KKLAPDAT")]
        public ActionResult Index()
        {
            drpNam(DateTime.Now.Year.ToString());
            drpThang(DateTime.Now.Month.ToString());
            drpLoaiFile();
           // sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Khuyen khich lap dat");
            return View();
        }

        [CheckCredential(RoleID = "IMPORT_KKLAPDAT")]
        public ActionResult Success()
        {
            try
            {
                DataTable dt = (DataTable)Session["dtImport"];
                if (dt.Rows.Count > 0)
                {
                    string cl1 = dt.Rows[0]["NhanSuID"].ToString();
                    string cl11 = dt.Rows[0]["LUONGKKLD"].ToString();
                    string cl9 = dt.Rows[0]["Nam"].ToString();
                    string cl10 = dt.Rows[0]["Thang"].ToString();
                    return View(dt);
                }
                else if (dt.Rows.Count == 0 || dt == null)
                {
                    setAlert("Cấu trúc tệp không chính xác hoặc không có dữ liệu để import", "error");
                    return Redirect("/import-kkld");
                }
                else
                {
                    setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                    return Redirect("/import-kkld");
                }

            }
            catch
            {
                setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp", "error");
                return Redirect("/import-kkld");
            }
           
        }

        [CheckCredential(RoleID = "IMPORT_KKLAPDAT")]
        public ActionResult ImportDB()
        {
            DataTable dt = (DataTable)Session["dtImport"];
            string rows = "";
            int dem = 0;
            int Thang = 1;
            int Nam = 2018;

            if (dt.Rows.Count > 0)
            {
                if (new ImportExcelBLL().GetChotSo(int.Parse(dt.Rows[0]["Thang"].ToString()), int.Parse(dt.Rows[0]["Nam"].ToString()), Session[SessionCommon.DonViID].ToString(), "BangLuong") == false)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Khuyen khich lap dat->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Do thang luong da chot");
                    setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
                }
                else
                {
                    new ImportExcelBLL().Delete_KKLD(int.Parse(dt.Rows[0]["Nam"].ToString()), int.Parse(dt.Rows[0]["Thang"].ToString()), Session[SessionCommon.Username].ToString(),1);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {

                            Thang = int.Parse(dt.Rows[i]["Thang"].ToString());
                            Nam = int.Parse(dt.Rows[i]["Nam"].ToString());
                            BangLuongLapDat bl = new BangLuongLapDat();
                            bl.LUONGKKLD = !string.IsNullOrWhiteSpace(dt.Rows[i]["LUONGKKLD"].ToString()) ? decimal.Parse(dt.Rows[i]["LUONGKKLD"].ToString()) : 0;
                            bl.LUONGPHLD = 0;
                            bl.LUONGSPITTER = 0;
                            bl.NhanSuID = dt.Rows[i]["NhanSuID"].ToString();
                            bl.Thang = decimal.Parse(dt.Rows[i]["Thang"].ToString());
                            bl.Nam = decimal.Parse(dt.Rows[i]["Nam"].ToString());
                            bl.UserName = Session[SessionCommon.Username].ToString();
                            var rs = new ImportExcelBLL().UpdateLAPDAT(bl);
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
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Khuyen khich lap dat->Import Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString());
                        setAlert("Import dữ liệu thành công", "success");
                        bool updateLuongKKKT = new LuongKKKTBLL().UpdateLUONGDTTK(Thang, Nam);
                        return Redirect("/import-kkld");
                    }
                    else if (0 < dem && dem < dt.Rows.Count)
                    {
                        string msg1 = " Dòng " + rows.ToString() + " import không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng!";
                        setAlertTime(msg1, "error");
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Khuyen khich lap dat->Import  khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Dong khong import-"+rows);
                        return Redirect("/import-kkld/doc-file");
                    }
                    else
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Khuyen khich lap dat->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString());
                        setAlert("Import dữ liệu không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng", "error");
                    }

                }
            }
            else
            {
                setAlert("Không có dữ liệu để import!", "error");
            }
            return Redirect("/import-kkld");
        }
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
                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path1+";Extended Properties=Excel 8.0;";
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
                    return Redirect("/import-kkld/doc-file");
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
            return Redirect("/import-kkld");

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
                Text = (DateTime.Now.Year-1).ToString(),
                Value = (DateTime.Now.Year - 1).ToString()
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
           
            ViewBag.drpNam = new SelectList(listItems, "Value", "Text", selected);
        }
        public void drpLoaiFile(string selected = null)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "Thuê bao duy trì",
                Value = "TBDuyTri"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Danh sách hợp đồng",
                Value = "LAPDAT"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Lương +/- theo TGMLL",
                Value = "TGMLL"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Tỷ lệ MLL",
                Value = "MLL"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Danh sách MLL",
                Value = "BH"
            });

            listItems.Add(new SelectListItem
            {
                Text = "Lương lắp đặt",
                Value = "LUONGLAPDAT"
            });

            ViewBag.drpLoaiFile = new SelectList(listItems, "Value", "Text", selected);
        }
        public ActionResult ExportExcel(int thang, int nam, string type)
        {
            ImportExcelBLL bll = new ImportExcelBLL();
            DataTable rs = new DataTable();
            if (type == "TBDuyTri")
            {
                rs = bll.GetLuongTBDuyTri(thang, nam);

                int TBDuyTri = 0, TBMLL = 0, TBGiamTru = 0, TBTinhMLL = 0;
                float TyLeMLLQuyDinh = 0, SoTien = 0, SoThuBaoMLLDamBaoQuyDinh = 0, TBNgoaiDinhMuc = 0;
                for (int i = 0; i <rs.Rows.Count; i++)
                {
                    TBDuyTri = TBDuyTri + int.Parse(rs.Rows[i]["TBDuyTri"].ToString());
                    TBMLL = TBMLL + int.Parse(rs.Rows[i]["TBMLL"].ToString());
                    TBGiamTru = TBGiamTru + int.Parse(rs.Rows[i]["TBGiamTru"].ToString());
                    TBTinhMLL = TBTinhMLL + int.Parse(rs.Rows[i]["TBTinhMLL"].ToString());
                    TyLeMLLQuyDinh = TyLeMLLQuyDinh + float.Parse(rs.Rows[i]["TyLeMLLQuyDinh"].ToString());
                    SoThuBaoMLLDamBaoQuyDinh = SoThuBaoMLLDamBaoQuyDinh + float.Parse(rs.Rows[i]["SoThuBaoMLLDamBaoQuyDinh"].ToString());
                    TBNgoaiDinhMuc = TBNgoaiDinhMuc + float.Parse(rs.Rows[i]["TBNgoaiDinhMuc"].ToString());
                    SoTien = SoTien + float.Parse(rs.Rows[i]["SoTien"].ToString());
                }
                DataRow newRow = rs.NewRow();

                newRow["DonViID"] = "VTTN";
                newRow["TenDonVi"] = "Viễn Thông Thái Nguyên";
                newRow["TBDuyTri"] = TBDuyTri;
                newRow["TBMLL"] = TBMLL;
                newRow["TBGiamTru"] = TBGiamTru;
                newRow["TBTinhMLL"] = TBTinhMLL;
                newRow["TyLeMLLQuyDinh"] = Math.Round(Decimal.Parse(TyLeMLLQuyDinh.ToString()),2);
                newRow["SoThuBaoMLLDamBaoQuyDinh"] =SoThuBaoMLLDamBaoQuyDinh;
                newRow["TBNgoaiDinhMuc"] = TBNgoaiDinhMuc;
                newRow["SoTien"] = SoTien;
                rs.Rows.Add(newRow);
            }else if (type == "TGMLL")
                rs = bll.TinhLuong_MLLTB(thang, nam);
            else
             rs = bll.GetKKLapDat(thang, nam, type);
            string fileName = "";
            if (type == "MLL") fileName = "TyLeMLL_TheoNhanVien_" + thang + "-" + nam;
            else if (type == "BH") fileName = "DSBAOHONG_" + thang + "-" + nam;
            else if (type == "LAPDAT") fileName = "DSKKLD_" + thang + "-" + nam;
            else if(type=="LUONGLAPDAT") fileName = "LUONGLAPDAT_" + thang + "-" + nam;
            else if(type=="TGMLL")
                fileName="LUONGTANGGIAMMLL-" + thang + "-" + nam;
            else fileName = "TienLuongTangThem_GiamTruTheoTyle_MLL_" + thang + "-" + nam;
            if (rs.Rows.Count > 0)
            {
                var grid = new GridView();
                grid.DataSource = rs;
                grid.DataBind();
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(rs, "Customers");

                    //wb.SaveAs(folderPath + "DataGridViewExport.xlsx");

                    MemoryStream stream = GetStream(wb);// The method is defined below
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment; filename=" + fileName+".xls");
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.BinaryWrite(stream.ToArray());
                    Response.End();
                }
            }
            else
            {
                setAlert("Không có dữ liệu để xuất file", "error");
            }
           return Redirect("/import-kkld");
        }

        public MemoryStream GetStream(XLWorkbook excelWorkbook)
        {
            MemoryStream fs = new MemoryStream();
            try
            {

                excelWorkbook.SaveAs(fs);
                fs.Position = 0;
            }
            catch (Exception ex)
            {
                //return fs;
            }


            return fs;
        }
    }
}