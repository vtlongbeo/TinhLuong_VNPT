﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TinhLuong.Models;
using TinhLuong.Reports.CrystalReport;
using TinhLuongBLL;

namespace TinhLuong.Reports.BaoCaoChung
{
    public partial class FrmViettinBank : System.Web.UI.Page
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
            if (Session["LoaiLuong"].ToString() == "Ky1")
            {
                _rptAgri = new Rpt_Ky1_VietInBank();
                Rpt_Frm_AgriBank.ReportSource = null;
                var agri = new BaoCaoChungBLL().GetRptKy1_ViettinBank(int.Parse(Session[SessionCommon.nam].ToString()), int.Parse(Session[SessionCommon.Thang].ToString()));
                _rptAgri.SetDataSource(agri);
                Rpt_Frm_AgriBank.ReportSource = _rptAgri;
                Rpt_Frm_AgriBank.DataBind();
                var fileName = "/Assets/FileReports/" + Session[SessionCommon.Username].ToString().ToLower() + "/Rpt_ViettinBankKy1-" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + "" + DateTime.Now.Hour + "" + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf";
                Session.Add("FrmViettinBank", fileName);
                _rptAgri.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(fileName));
            }
            else
            {
                _rptAgri = new RptVietInBank();
                Rpt_Frm_AgriBank.ReportSource = null;
                var agri = new BaoCaoChungBLL().GetRpt_ViettinBank(int.Parse(Session[SessionCommon.nam].ToString()), int.Parse(Session[SessionCommon.Thang].ToString()));
                _rptAgri.SetDataSource(agri);
                Rpt_Frm_AgriBank.ReportSource = _rptAgri;
                Rpt_Frm_AgriBank.DataBind();
                var fileName = "/Assets/FileReports/" + Session[SessionCommon.Username].ToString().ToLower() + "/Rpt_ViettinBank-" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Millisecond + ".pdf";
                Session.Add("FrmViettinBank", fileName);
                _rptAgri.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(fileName));
            }
         

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["FrmViettinBank"].ToString());
        }
    }
}