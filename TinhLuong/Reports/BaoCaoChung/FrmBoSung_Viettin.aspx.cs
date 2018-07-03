using CrystalDecisions.CrystalReports.Engine;
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
    public partial class FrmBoSung_Viettin : System.Web.UI.Page
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

            _rptAgri = new RptBoSungVietComBank();
            Rpt_FrmBS_ViettinBank.ReportSource = null;
            var agri = new BaoCaoChungBLL().GetRptViettinBankBoSung(int.Parse(Session["NamBS"].ToString()), int.Parse(Session["LoaiBS"].ToString()));
            _rptAgri.SetDataSource(agri);
            Rpt_FrmBS_ViettinBank.ReportSource = _rptAgri;
            Rpt_FrmBS_ViettinBank.DataBind();
            var fileName = "/Assets/FileReports/" + Session[SessionCommon.Username].ToString().ToLower() + "/Rpt_ViettinBankBS-" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + "" + DateTime.Now.Hour + "" + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf";
            Session.Add("FrmBoSung_Viettin", fileName);
            _rptAgri.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(fileName));

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["FrmBoSung_Viettin"].ToString());
        }
    }
}