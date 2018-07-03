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
using ClosedXML.Excel;
using System.Text;
using System.Web.UI.WebControls;
using TinhLuongINFO;

namespace TinhLuong.Controllers
{
    public class KKLDController : BaseController
    {
        SaveLog sv = new SaveLog();
        LuongKKKTBLL luongkkBLL = new LuongKKKTBLL();
        ChotSoBLL chotsoBLL = new ChotSoBLL();
        private string tempThang = "";
        private string tempNam = "";
        // GET: KKLD
        public ActionResult Index()
        {
            drpThang();
            drpNam();
            drpLoaiFile();
            return View();
        }

        public ActionResult IndexDetail(string Thang, string Nam)
        {
            drpNam(Nam.ToString());
            drpThang(Thang.ToString());


            var luong = new tempLuongKK();
            luong.LuongPH = luongkkBLL.GetLuongPHLD(Thang, Nam);

            DataTable dtPHLD = new DataTable();
            if (dtPHLD.Columns.Count == 0)
            {
                DataColumn c0 = new DataColumn("Thang", typeof(int));
                DataColumn c1 = new DataColumn("Nam", typeof(int));
                DataColumn c2 = new DataColumn("NhanSuID", typeof(string));
                DataColumn c3 = new DataColumn("LUONGKKLD", typeof(int));
                dtPHLD.Columns.Add(c0);
                dtPHLD.Columns.Add(c1);
                dtPHLD.Columns.Add(c2);
                dtPHLD.Columns.Add(c3);
            }
            for (int i = 0; i < luong.LuongPH.Rows.Count; i++)
            {
                DataRow drr = dtPHLD.NewRow();
                drr["Thang"] = int.Parse(Thang);
                drr["Nam"] = int.Parse(Nam);
                drr["NhanSuID"] = luong.LuongPH.Rows[i]["NhanSuID"].ToString();
                drr["LUONGKKLD"] = int.Parse(luong.LuongPH.Rows[i]["Luong"].ToString());
                dtPHLD.Rows.Add(drr);
            }
            Session["dtImportPHLD"] = dtPHLD;

            luong.LuongKKLD = luongkkBLL.GetLuongKKLD(Thang, Nam);
            DataTable dt = new DataTable();
            if (dt.Columns.Count == 0)
            {
                DataColumn c0 = new DataColumn("Thang", typeof(int));
                DataColumn c1 = new DataColumn("Nam", typeof(int));
                DataColumn c2 = new DataColumn("NhanSuID", typeof(string));
                DataColumn c3 = new DataColumn("LUONGKKLD", typeof(int));
                dt.Columns.Add(c0);
                dt.Columns.Add(c1);
                dt.Columns.Add(c2);
                dt.Columns.Add(c3);
            }
            for(int i=0; i < luong.LuongKKLD.Rows.Count; i++)
            {
                DataRow drr = dt.NewRow();
                drr["Thang"] = int.Parse(Thang);
                drr["Nam"] = int.Parse(Nam);
                drr["NhanSuID"] = luong.LuongKKLD.Rows[i]["NhanSuID"].ToString();
                drr["LUONGKKLD"] = int.Parse(luong.LuongKKLD.Rows[i]["Luong"].ToString());
                dt.Rows.Add(drr);
            }
            Session["dtImport"] = dt;
            luong.ChiTiet = luongkkBLL.GetChiTietLuongKKLD(Thang, Nam);
            return View(luong);
        }

        public void XacThucLuongKK(int ID, string Type)
        {
            luongkkBLL.XacThucLuongKK(ID, Type, Session[SessionCommon.Username].ToString());
        }


        public void ChotLuongLapDat (string Thang,string Nam)
        {
            DataTable dt = chotsoBLL.GetListChotso_BangID(int.Parse(Thang),int.Parse(Nam),"VTT","LuongLapDat");
            if(dt.Rows[0]["TinhTrang"].ToString() == "0")
            {
                chotsoBLL.CapnhatBangChotSo(int.Parse(Nam), int.Parse(Thang), "LuongLapDat", "VTT", 1, Session[SessionCommon.Username].ToString());
                setAlert("Chốt lương lắp đặt thành công", "success");
            }
            else
            {
                chotsoBLL.CapnhatBangChotSo(int.Parse(Nam), int.Parse(Thang), "LuongLapDat", "VTT", 0, Session[SessionCommon.Username].ToString());
                setAlert("Hủy chốt lương lắp đặt thành công", "success");
            }
        }


        public class tempLuongKK
        {
            private DataTable _LuongPH;
            private DataTable _LuongKKLD;
            private DataTable _ChiTiet;

            public DataTable LuongPH
            {
                get
                {
                    return _LuongPH;
                }

                set
                {
                    _LuongPH = value;
                }
            }

            public DataTable LuongKKLD
            {
                get
                {
                    return _LuongKKLD;
                }

                set
                {
                    _LuongKKLD = value;
                }
            }

            public DataTable ChiTiet
            {
                get
                {
                    return _ChiTiet;
                }

                set
                {
                    _ChiTiet = value;
                }
            }
        }

        public ActionResult ImportDB()
        {
            DataTable dt = (DataTable)Session["dtImport"];
            DataTable dtPH = (DataTable)Session["dtImportPHLD"];
            string rows = "";
            int dem = 0;
            int demPH = 0;
            string Thang = "";
            string Nam = "";


            if (dt.Rows.Count > 0)
            {
                if (new ImportExcelBLL().GetChotSo(int.Parse(dt.Rows[0]["Thang"].ToString()), int.Parse(dt.Rows[0]["Nam"].ToString()), Session[SessionCommon.DonViID].ToString(), "BangLuong") == false)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Khuyen khich lap dat->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Do thang luong da chot");
                    setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
                }
                else
                {
                    new ImportExcelBLL().Delete_KKLD(int.Parse(dt.Rows[0]["Nam"].ToString()), int.Parse(dt.Rows[0]["Thang"].ToString()), Session[SessionCommon.Username].ToString(),1);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            Thang = dt.Rows[i]["Thang"].ToString();
                            Nam = dt.Rows[i]["Nam"].ToString();
                            BangLuongLapDat bl = new BangLuongLapDat();
                            bl.LUONGKKLD = !string.IsNullOrWhiteSpace(dt.Rows[i]["LUONGKKLD"].ToString()) ? decimal.Parse(dt.Rows[i]["LUONGKKLD"].ToString()) : 0;
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
                        bool updateLuongKKKT = new LuongKKKTBLL().UpdateLUONGDTTK(int.Parse(Thang),int.Parse(Nam));
                        //if (Thang.Length == 1)
                        //    Thang = "0" + Thang;
                        //return Redirect("/KKLD/thang-" + Thang + "-nam-" + Nam);
                    }
                    else if (0 < dem && dem < dt.Rows.Count)
                    {
                        string msg1 = " Dòng " + rows.ToString() + " import không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng!";
                        setAlertTime(msg1, "error");
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Khuyen khich lap dat->Import  khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Dong khong import-" + rows);
                        //if (Thang.Length == 1)
                        //    Thang = "0" + Thang;
                        //return Redirect("/KKLD/thang-" + Thang + "-nam-" + Nam);
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
                            Thang = dtPH.Rows[i]["Thang"].ToString();
                            Nam = dtPH.Rows[i]["Nam"].ToString();
                            BangLuongLapDat bl = new BangLuongLapDat();
                            bl.LUONGPHLD = !string.IsNullOrWhiteSpace(dtPH.Rows[i]["LUONGKKLD"].ToString()) ? decimal.Parse(dtPH.Rows[i]["LUONGKKLD"].ToString()) : 0;
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
                        sv.save(Session[SessionCommon.Username].ToString(), "Cap Nhat tu file->Khuyen khich lap dat->Import Thanh Cong- Thang-" + dtPH.Rows[0]["Thang"].ToString() + "-nam-" + dtPH.Rows[0]["Nam"].ToString());
                        setAlert("Import dữ liệu thành công", "success");
                        bool updateLuongKKKT = new LuongKKKTBLL().UpdateLUONGDTTK(int.Parse(Thang), int.Parse(Nam));
                        //if (Thang.Length == 1)
                        //    Thang = "0" + Thang;
                        //return Redirect("/KKLD/thang-" + Thang + "-nam-" + Nam);
                    }
                    //else if (0 < dem && dem < dt.Rows.Count)
                    //{
                    //    string msg1 = " Dòng " + rows.ToString() + " import không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng!";
                    //    setAlertTime(msg1, "error");
                    //    sv.save(Session[SessionCommon.Username].ToString(), "Phoi hop lap dat->Import  khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Dong khong import-" + rows);
                    //    //if (Thang.Length == 1)
                    //    //    Thang = "0" + Thang;
                    //    //return Redirect("/KKLD/thang-" + Thang + "-nam-" + Nam);
                    //}
                    else
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Phoi hop lap dat->Import khong Thanh Cong- Thang-" + dtPH.Rows[0]["Thang"].ToString() + "-nam-" + dtPH.Rows[0]["Nam"].ToString());
                        setAlert("Import dữ liệu không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng", "error");
                    }

                }
            }
            else
            {
                setAlert("Không có dữ liệu để import!", "error");
            }







            if (Thang.Length == 1)
                Thang = "0" + Thang;

            return Redirect("/KKLD/thang-"+Thang+"-nam-"+Nam);
        }



        public void drpThang(string selected = null)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "01",
                Value = "01"
            });
            listItems.Add(new SelectListItem
            {
                Text = "02",
                Value = "02",
            });
            listItems.Add(new SelectListItem
            {
                Text = "03",
                Value = "03"
            });
            listItems.Add(new SelectListItem
            {
                Text = "04",
                Value = "04"
            });
            listItems.Add(new SelectListItem
            {
                Text = "05",
                Value = "05"
            });
            listItems.Add(new SelectListItem
            {
                Text = "06",
                Value = "06"
            });
            listItems.Add(new SelectListItem
            {
                Text = "07",
                Value = "07"
            });
            listItems.Add(new SelectListItem
            {
                Text = "08",
                Value = "08"
            });

            listItems.Add(new SelectListItem
            {
                Text = "09",
                Value = "09"
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
                Text = (DateTime.Now.Year - 1).ToString(),
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
                Text = "Khuyến khích lắp đặt",
                Value = "KKLD"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Phối hợp lắp đặt",
                Value = "PHLD"
            });

            ViewBag.drpLoaiFile = new SelectList(listItems, "Value", "Text", selected);
        }

        public ActionResult ExportToExcel(string Thang, string Nam,string Type)
        {
            string myName = "";
            DataTable dt = new DataTable();
           if(Type == "0")
            {
                myName = Server.UrlEncode("ChiTietLapDat" + "_" + Thang + "-" + Nam + ".xlsx");
                dt = luongkkBLL.GetChiTietLuongKKLD(Thang, Nam);
            }
           
           else if(Type == "1")
            {
                myName = Server.UrlEncode("LuongKK" + "_" + Thang + "-" + Nam + ".xlsx");
                dt = luongkkBLL.GetLuongKKLD(Thang, Nam);

            }

            else
            {
                myName = Server.UrlEncode("LuongPH" + "_" + Thang + "-" + Nam + ".xlsx");
                dt = luongkkBLL.GetLuongPHLD(Thang, Nam);
            }
                

            var grid = new GridView();
            grid.DataSource = dt;
            grid.DataBind();

            //Exporting to Excel
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Sheet1");

                //wb.SaveAs(folderPath + "DataGridViewExport.xlsx");
                
                MemoryStream stream = GetStream(wb);// The method is defined below
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=" + myName);
                Response.ContentType = "application/vnd.ms-excel";
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
            return RedirectToAction("Index");
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