using CrystalDecisions.CrystalReports.Engine;
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

namespace TinhLuong.Reports.TBLuongDV
{
    public partial class TBLuongCacDV : System.Web.UI.Page
    {
        private ReportClass _rpt;
        protected void Page_Load(object sender, EventArgs e)
        {
            var credentials = (List<string>)HttpContext.Current.Session[SessionCommon.SESSION_CREDENTIALS];
            if (credentials.Contains("VIEW_THONGBAODV") || Session[SessionCommon.Username].ToString() == "admin")
            {
                LoadReport();
            }
            else Response.Redirect("/Home/RoleLimit");

        }
        //protected void Preview_Click(object sender, EventArgs e)
        //{
        //    LoadReport();
        //}
        private void LoadReport()
        {

            _rpt = new RP_ThongBao();
            // CrystalDecisions.Shared.ParameterDiscreteValue TenDV = new CrystalDecisions.Shared.ParameterDiscreteValue();
            RptLuongCacDV.ReportSource = null;
            //dete
            var table = new LuongLanhDaoBLL().GetSourceRpt(int.Parse(Session[SessionCommon.nam].ToString()), int.Parse(Session[SessionCommon.Thang].ToString()));
            _rpt.SetDataSource(table);
            RptLuongCacDV.ReportSource = _rpt;
            RptLuongCacDV.DataBind();
            var fileName = "/Assets/FileReports/" + Session[SessionCommon.Username].ToString().ToLower() + "/LuongCacDonVi-" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + "" + DateTime.Now.Hour + "" + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf";
            Session.Add("LuongCacDonVi", fileName);
            _rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(fileName));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["LuongCacDonVi"].ToString());
        }
    }
}