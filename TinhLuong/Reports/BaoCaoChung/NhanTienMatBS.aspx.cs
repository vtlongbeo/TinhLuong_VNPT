﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TinhLuong.Models;
using TinhLuong.Reports.CrystalReport;
using TinhLuongBLL;
namespace TinhLuong.Reports.BaoCaoChung
{
    public partial class NhanTienMatBS : System.Web.UI.Page
    {
        private ReportClass _rptAgri;

        protected void Page_Load(object sender, EventArgs e)
        {
            var credentials = (List<string>)HttpContext.Current.Session[SessionCommon.SESSION_CREDENTIALS];
            if (Session[SessionCommon.Username] != null)
            {
                if (credentials.Contains("VIEW_EXCEL_DS") || Session[SessionCommon.Username].ToString() == "admin")
                {
                    LoadReport();
                }
                else Response.Redirect("/Home/RoleLimit");
            }
            else
                Response.Redirect("/dang-nhap");
           

        }
        //protected void Preview_Click(object sender, EventArgs e)
        //{
        //    LoadReport();
        //}
        private void LoadReport()
        {
            _rptAgri = new RptDS_BSNhanTrucTiep();
            Rpt_FrmBS_NhanTienMat.ReportSource = null;
            var agri = new BaoCaoChungBLL().GetRptNhanTienMatBoSung(int.Parse(Session["NamBS"].ToString()), int.Parse(Session["LoaiBS"].ToString()));
            _rptAgri.SetDataSource(agri);
            Rpt_FrmBS_NhanTienMat.ReportSource = _rptAgri;
            Rpt_FrmBS_NhanTienMat.DataBind();
            var fileName = "/Assets/FileReports/" + Session[SessionCommon.Username].ToString().ToLower() + "/NhanTienMat-" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + "" + DateTime.Now.Hour + "" + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf";
            Session.Add("NhanTienMat", fileName);
            _rptAgri.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(fileName));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["NhanTienMat"].ToString());
        }
    }
}