using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TinhLuong.Models;
using TinhLuong.Reports.CrystalReport;
using TinhLuongBLL;

namespace TinhLuong.Reports.BaoCaoChung
{
    public partial class PhatTrienThueBao : System.Web.UI.Page
    {
        private ReportClass _rpt;

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

            _rpt = new RptDSChiTiet_CSHT();
            // CrystalDecisions.Shared.ParameterDiscreteValue TenDV = new CrystalDecisions.Shared.ParameterDiscreteValue();
            object TenDVi = new LuongKKKTBLL().GetTenDVRptDS(Session["DonVi_BaoCao"].ToString());
            object TenDVCha = new LuongKKKTBLL().GetTenDVChaRptDS(Session["DonVi_BaoCao"].ToString());
            RptTongHop.ReportSource = null;
            //dete
            var table = new BaoCaoChungBLL().GetSourceRptDSChiTiet_CSHT(Session["DonVi_BaoCao"].ToString(), int.Parse(Session[SessionCommon.nam].ToString()), int.Parse(Session[SessionCommon.Thang].ToString()));
            int v = table.Rows.Count;
            var tblFooter = new LuongKKKTBLL().GetSourceFooterRptDS(Session["DonVi_BaoCao"].ToString(), int.Parse(Session[SessionCommon.nam].ToString()), int.Parse(Session[SessionCommon.Thang].ToString()));
            int v1 = tblFooter.Rows.Count;
            object NgLapBieu = "";
            object PTKT = "";
            object LanhDao = "";
            foreach (DataRow row in tblFooter.Rows)
            {
                NgLapBieu = row["NguoiLapBieu"];
                PTKT = row["PTKeToan"];
                LanhDao = row["TruongDonVi"];
            }
            _rpt.SetDataSource(table);
            _rpt.ParameterFields["TenDV"].CurrentValues.AddValue(TenDVi);
            _rpt.ParameterFields["TenDVCha"].CurrentValues.AddValue(TenDVCha);
            _rpt.ParameterFields["NguoiLapBieu"].CurrentValues.AddValue(NgLapBieu);
            _rpt.ParameterFields["PTKT"].CurrentValues.AddValue(PTKT);
            _rpt.ParameterFields["LanhDao"].CurrentValues.AddValue(LanhDao);
            RptTongHop.ReportSource = _rpt;
            RptTongHop.DataBind();
            var fileName = "/Assets/FileReports/admin/PhatTrienThuBao-" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + "" + DateTime.Now.Hour + "" + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf";
            Session.Add("PhatTrienThueBao", fileName);
            _rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(fileName));
        }
        private ReportDocument rptDocument;
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["PhatTrienThueBao"].ToString());
            //rptDocument = new ReportDocument();
            //rptDocument.Load(RptDSChiTiet_CSHT, OpenReportMethod.OpenReportByDefault);
            //PrinterSettings printsettings = new PrinterSettings();
            //string str = printsettings.PrinterName;
            //rptDocument.PrintOptions.PrinterName = "hp LaserJet 1010 HB";

            //rptDocument.SetDataSource();
            //rptDocument.PrintOptions.PaperOrientation = PaperOrientation.Landscape;

            //rptDocument.PrintToPrinter(1, false, 0, 0);
        }
    }
}