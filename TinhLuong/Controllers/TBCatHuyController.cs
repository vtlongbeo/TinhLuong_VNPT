﻿using System;
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
    public class TBCatHuyController : BaseController
    {
        SaveLog sv = new SaveLog();
        LuongKKKTBLL luongkkBLL = new LuongKKKTBLL();
        ChotSoBLL chotsoBLL = new ChotSoBLL();
        // GET: TBCatHuy
        public ActionResult Index()
        {
            drpThang();
            drpNam();
            return View();
        }
        public ActionResult IndexDetail(string Thang, string Nam)
        {
            drpThang(Thang);
            drpNam(Nam);
            var Luong = new tempLuongKK();
            Luong.ChiTiet = new LuongKKKTBLL().ChiTietCatHuy(Thang,Nam);
            Luong.TongHop = new LuongKKKTBLL().THCatHuy(Thang, Nam);
            DataTable dt = new DataTable();
            if (dt.Columns.Count == 0)
            {
                DataColumn c0 = new DataColumn("Thang", typeof(int));
                DataColumn c1 = new DataColumn("Nam", typeof(int));
                DataColumn c2 = new DataColumn("NhanSuID", typeof(string));
                DataColumn c3 = new DataColumn("Luong", typeof(int));
                dt.Columns.Add(c0);
                dt.Columns.Add(c1);
                dt.Columns.Add(c2);
                dt.Columns.Add(c3);
            }
            for (int i = 0; i < Luong.TongHop.Rows.Count; i++)
            {
                DataRow drr = dt.NewRow();
                drr["Thang"] = int.Parse(Thang);
                drr["Nam"] = int.Parse(Nam);
                drr["NhanSuID"] = Luong.TongHop.Rows[i]["NhanSuID"].ToString();
                drr["Luong"] = int.Parse(Luong.TongHop.Rows[i]["Luong"].ToString());
                dt.Rows.Add(drr);
            }
            Session["dtImport"] = dt;

            return View(Luong);
        }

        public ActionResult ExportToExcel(string Thang, string Nam, string Type)
        {
            string myName = "";
            DataTable dt = new DataTable();
            if (Type == "0")
            {
                myName = Server.UrlEncode("ChiTietGiamTruCatHuy" + "_" + Thang + "-" + Nam + ".xlsx");
                dt = new LuongKKKTBLL().ChiTietCatHuy(Thang, Nam);
            }

            else
            {
                myName = Server.UrlEncode("TongHopGiamTruCatHuy" + "_" + Thang + "-" + Nam + ".xlsx");
                dt = new LuongKKKTBLL().THCatHuy(Thang, Nam);

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

        public void ChotSoLieu(string Thang, string Nam)
        {
            DataTable dt = new ChotSoBLL().GetListChotso_BangID(int.Parse(Thang), int.Parse(Nam), "VTT", "GiamTruCatHuy");
            if (dt.Rows[0]["TinhTrang"].ToString() == "0")
            {
                new ChotSoBLL().CapnhatBangChotSo(int.Parse(Nam), int.Parse(Thang), "GiamTruCatHuy", "VTT", 1, Session[SessionCommon.Username].ToString());
                setAlert("Chốt lương số liệu giảm trừ cắt hủy", "success");
            }
            else
            {
                new ChotSoBLL().CapnhatBangChotSo(int.Parse(Nam), int.Parse(Thang), "GiamTruCatHuy", "VTT", 0, Session[SessionCommon.Username].ToString());
                setAlert("Hủy chốt lương số liệu giảm trừ cắt hủy", "success");
            }
        }


        public ActionResult ImportDB()
        {
            DataTable dt = (DataTable)Session["dtImport"];
            string rows = "";
            int dem = 0;
            string Thang = "";
            string Nam = "";


            if (dt.Rows.Count > 0)
            {
                if (new ImportExcelBLL().GetChotSo(int.Parse(dt.Rows[0]["Thang"].ToString()), int.Parse(dt.Rows[0]["Nam"].ToString()), Session[SessionCommon.DonViID].ToString(), "BangLuong") == false)
                {
                    sv.save(Session[SessionCommon.Username].ToString(), "Giảm trừ cắt hủy->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Do thang luong da chot");
                    setAlert("Dữ liệu đã chốt, không tiếp tục cập nhật được!", "error");
                }
                else
                {
                    new ImportExcelBLL().Delete_LuongKTP(int.Parse(dt.Rows[0]["Nam"].ToString()), int.Parse(dt.Rows[0]["Thang"].ToString()), Session[SessionCommon.Username].ToString(), 4, Session[SessionCommon.DonViID].ToString());
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            Thang = dt.Rows[i]["Thang"].ToString();
                            Nam = dt.Rows[i]["Nam"].ToString();

                            var rs = new ImportExcelBLL().Update_LUONGKTP(int.Parse(Nam), int.Parse(Thang), Session[SessionCommon.Username].ToString(), int.Parse(dt.Rows[i]["Luong"].ToString()), dt.Rows[i]["NhanSuID"].ToString(), "GiamTruCatHuy");
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
                        sv.save(Session[SessionCommon.Username].ToString(), "Giảm trừ cắt hủy->Import Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString());
                        setAlert("Import dữ liệu thành công", "success");
                        //bool updateLuongKKKT = new LuongKKKTBLL().UpdateLUONGDTTK(int.Parse(Thang), int.Parse(Nam));

                    }
                    else if (0 < dem && dem < dt.Rows.Count)
                    {
                        string msg1 = " Dòng " + rows.ToString() + " import không thành công do lỗi thực thi hoặc không tồn tại nhân sự trong bảng lương của tháng!";
                        setAlertTime(msg1, "error");
                        sv.save(Session[SessionCommon.Username].ToString(), "Giảm trừ cắt hủy->Import  khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString() + "-Dong khong import-" + rows);

                    }
                    else
                    {
                        sv.save(Session[SessionCommon.Username].ToString(), "Giảm trừ báo hỏng nhiều lần->Import khong Thanh Cong- Thang-" + dt.Rows[0]["Thang"].ToString() + "-nam-" + dt.Rows[0]["Nam"].ToString());
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

            return Redirect("/tbcathuy/thang-" + Thang + "-nam-" + Nam);
        }


        public void XacThuc(int ID, string Type)
        {
            new LuongKKKTBLL().XacThucCatHuy(ID, Type, Session[SessionCommon.Username].ToString());
        }
        public class tempLuongKK
        {
            private DataTable _TongHop;
            private DataTable _ChiTiet;

            public DataTable TongHop
            {
                get
                {
                    return _TongHop;
                }

                set
                {
                    _TongHop = value;
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
    }
}