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
    public class ImportHeSoP3Controller : BaseController
    {
        // GET: ImportHeSoP3
        /// <summary>
        /// import HSCN and HSBP
        /// </summary>
        /// <returns></returns>
        /// s
        /// 
        SaveLog sv = new SaveLog();
        [CheckCredential(RoleID = "IMPORT_EXCELTAMUNG")]
        public ActionResult Index()
        {
            //sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->He so p3 Ca nhan, tap the" );
            drpNam();
            drpThang();
            return View();
        }


        [CheckCredential(RoleID = "IMPORT_EXCELTAMUNG")]
        public ActionResult Success()
        {
            try
            {
                drpNam();
                drpThang();
                DataTable dt = (DataTable)Session["dtImport"];
                if (dt.Rows.Count > 0)
                {
                    string cl1 = dt.Rows[0]["NhanSuID"].ToString();
                    string cl11 = dt.Rows[0]["Nam"].ToString();
                    string cl2 = dt.Rows[0]["Thang"].ToString();
                    string cl3 = dt.Rows[0]["HSBP"].ToString();
                    string cl4 = dt.Rows[0]["HSCN"].ToString();
                    return View(dt);
                }
                else if (dt.Rows.Count == 0 || dt == null)
                {
                    setAlert("Cấu trúc tệp không chính xác hoặc không có dữ liệu để import", "error");
                    return Redirect("/import-doanh-thu");
                }
                else
                {
                    setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                    return Redirect("/import-doanh-thu");
                }


            }
            catch
            {
                setAlert("Cấu trúc tệp không chính xác. Vui lòng chọn lại tệp!", "error");
                return Redirect("/import-hsp3");
            }
            
        }


        [CheckCredential(RoleID = "IMPORT_EXCELTAMUNG")]
        public ActionResult GetDataBSC(int thang, int nam)
        {
            if (new ImportExcelBLL().GetChotSo(thang, nam, Session[SessionCommon.DonViID].ToString(), "BangLuong") == false)
            {
                sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->He so p3 Ca nhan, tap the->Import BSC CSHT khong Thanh Cong- Thang-" + thang + "-nam-" + nam + "-Do thang luong da chot");
                setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!","error");
            }
            else
            {
                bool outPut1 = new ImportExcelBLL().Update_BSC(nam, thang, Session[SessionCommon.Username].ToString());
                if (outPut1 == false)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->He so p3 Ca nhan, tap the->Import BSC CSHT khong Thanh Cong- Thang-" + thang + "-nam-" + nam);
                    setAlert("Cập nhật thất bại!", "error");
                }
                else
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->He so p3 Ca nhan, tap the->Import BSC CSHT Thanh Cong- Thang-" + thang + "-nam-" + nam);
                    setAlert("Cập nhật thành công!", "success");
                }
            }
            return Redirect("/import-hsp3");
        }

        public ActionResult ImportDB()
        {
            DataTable dt = (DataTable)Session["dtImport"];
            string rows = "";
            int dem = 0;

            if (dt.Rows.Count > 0)
            {
                if (new ImportExcelBLL().GetChotSo(int.Parse(dt.Rows[0]["Thang"].ToString()), int.Parse(dt.Rows[0]["Nam"].ToString()), Session[SessionCommon.DonViID].ToString(), "BangLuong") == false)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->He so p3 Ca nhan, tap the->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString()+"-Do thang luong da chot");
                    setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            BangLuong bl = new BangLuong();
                            bl.UserName = Session[SessionCommon.Username].ToString();
                            bl.DonViID = Session[SessionCommon.DonViID].ToString();
                            bl.Thang =decimal.Parse(dt.Rows[i]["Thang"].ToString());
                            bl.Nam = decimal.Parse(dt.Rows[i]["Nam"].ToString());
                            bl.HSCN = !string.IsNullOrWhiteSpace(dt.Rows[i]["HSCN"].ToString()) ? decimal.Parse(dt.Rows[i]["HSCN"].ToString()):0;
                            bl.HSBP = !string.IsNullOrWhiteSpace(dt.Rows[i]["HSBP"].ToString()) ? decimal.Parse(dt.Rows[i]["HSBP"].ToString()):0;
                            bl.NhanSuID = dt.Rows[i]["NhanSuID"].ToString();
                            var rs = new ImportExcelBLL().UpdateTAMUNGKTP(bl);
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
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->He so p3 Ca nhan, tap the->Import Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString());
                        setAlert("Import dữ liệu thành công", "success");
                    }
                    else if (0 < dem && dem < dt.Rows.Count)
                    {
                        string msg1 = " Dòng " + rows.ToString() + " import không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng!";
                        setAlertTime(msg1, "error");
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->He so p3 Ca nhan, tap the->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Dong khong import-"+rows);
                        return Redirect("/import-hsp3/doc-file");
                    }
                    else
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->He so p3 Ca nhan, tap the->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString());
                        setAlert("Import dữ liệu không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng", "error");
                    }

                }
            }
            else
            {
                setAlert("Không có dữ liệu để import!", "error");
            }
            return Redirect("/import-hsp3");
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
                            if (!(nhansu.Contains(dt1.Rows[i]["NhanSuID"].ToString()))&& !string.IsNullOrWhiteSpace(dt1.Rows[i]["NhanSuID"].ToString()))
                            {
                                rows = rows == "" ? rows + " " + dt1.Rows[i]["NhanSuID"].ToString() : rows + ", " + dt1.Rows[i]["NhanSuID"].ToString();
                            }
                        }
                        if (rows != "") setAlertTime("Nhân viên có mã " + rows + " không có trong bảng lương đề nghị xem lại trước khi import dữ liệu", "error");
                    }
                    System.IO.File.Delete(path1 + "" + extension);
                    return Redirect("/import-hsp3/doc-file");
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
            return Redirect("/import-hsp3");

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
                Text = "2016",
                Value = "2016"
            });
            listItems.Add(new SelectListItem
            {
                Text = "2017",
                Value = "2017",
            });
            listItems.Add(new SelectListItem
            {
                Text = "2018",
                Value = "2018"
            });
            listItems.Add(new SelectListItem
            {
                Text = "2019",
                Value = "2019"
            });
            listItems.Add(new SelectListItem
            {
                Text = "2020",
                Value = "2020"
            });


            ViewBag.drpNam = new SelectList(listItems, "Value", "Text", selected);
        }
    }
}