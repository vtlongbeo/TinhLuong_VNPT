﻿using System;
using System.Collections.Generic;
using System.Linq;
using CrystalDecisions.CrystalReports.Engine;
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
using CrystalDecisions.Web;
using CrystalDecisions.Shared;

namespace TinhLuong.Reports.BaoCaoChung
{
    public partial class Frm_BangLuongBoSung : System.Web.UI.Page
    {
        private ReportClass _rpt;
        protected void Page_Load(object sender, EventArgs e)
        {
            var credentials = (List<string>)HttpContext.Current.Session[SessionCommon.SESSION_CREDENTIALS];
            if (Session[SessionCommon.Username]!=null)
            {
                if (credentials.Contains("VIEW_EXCEL_DS") || Session[SessionCommon.Username].ToString() == "admin")
                {
                    LoadReport();
                }
                else Response.Redirect("/Home/RoleLimit");
            }
            else
            {
                Response.Redirect("/dang-nhap");
            }
           

        }
        //protected void Preview_Click(object sender, EventArgs e)
        //{
        //    LoadReport();
        //}
        private void LoadReport()
        {

            _rpt = new RptDSBangLuongBoSung();
            // CrystalDecisions.Shared.ParameterDiscreteValue TenDV = new CrystalDecisions.Shared.ParameterDiscreteValue();
            object TenDVi = new LuongKKKTBLL().GetTenDVRptDS(Session["DonVi_BaoCao_BS"].ToString());
            object TenDVCha = new LuongKKKTBLL().GetTenDVChaRptDS(Session["DonVi_BaoCao_BS"].ToString());
            RptBangLuongBoSung.ReportSource = null;
            //dete
            var table = new BaoCaoChungBLL().GetSourceRptDSBS(Session["DonVi_BaoCao_BS"].ToString(), int.Parse(Session["NamBS"].ToString()), int.Parse(Session["LoaiBS"].ToString()));
            //int v = table.Rows.Count;
            //var tblFooter = new LuongKKKTBLL().GetSourceFooterRptDS(Session["DonVi_BaoCao"].ToString(), int.Parse(Session[SessionCommon.nam].ToString()), int.Parse(Session["LoaiBS"].ToString()));
            //int v1 = tblFooter.Rows.Count;
            //object NgLapBieu = "";
            //object PTKT = "";
            //object LanhDao = "";
            //foreach (DataRow row in tblFooter.Rows)
            //{
            //    NgLapBieu = row["NguoiLapBieu"];
            //    PTKT = row["PTKeToan"];
            //    LanhDao = row["TruongDonVi"];
            //}
            _rpt.SetDataSource(table);
            _rpt.ParameterFields["TenDV"].CurrentValues.AddValue(TenDVi);
            _rpt.ParameterFields["TenDVCha"].CurrentValues.AddValue(TenDVCha);
            //_rpt.ParameterFields["NguoiLapBieu"].CurrentValues.AddValue(NgLapBieu);
            //_rpt.ParameterFields["PTKT"].CurrentValues.AddValue(PTKT);
            //_rpt.ParameterFields["LanhDao"].CurrentValues.AddValue(LanhDao);
            RptBangLuongBoSung.ReportSource = _rpt;
            RptBangLuongBoSung.DataBind();
            var fileName = "/Assets/FileReports/" + Session[SessionCommon.Username].ToString().ToLower() + "/RptLuongBS-" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + "" + DateTime.Now.Hour + "" + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf";
            Session.Add("Frm_BangLuongBoSung", fileName);
            _rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(fileName));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["Frm_BangLuongBoSung"].ToString());
        }
    }
}