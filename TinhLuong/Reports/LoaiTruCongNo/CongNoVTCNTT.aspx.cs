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

namespace TinhLuong.Reports.LoaiTruCongNo
{
    public partial class CongNoVTCNTT : System.Web.UI.Page
    {
        private ReportClass _rpt;
        [CheckCredential(RoleID = "VIEW_CONGNO")]
        protected void Page_Load(object sender, EventArgs e)
        {
            var credentials = (List<string>)HttpContext.Current.Session[SessionCommon.SESSION_CREDENTIALS];
            if (credentials.Contains("VIEW_CONGNO") || Session[SessionCommon.Username].ToString() == "admin")
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

            _rpt = new RptDSBangLuongCongno();
            // CrystalDecisions.Shared.ParameterDiscreteValue TenDV = new CrystalDecisions.Shared.ParameterDiscreteValue();
            object TenDVi = new LuongKKKTBLL().GetTenDVRptDS(Session[SessionCommon.DonViID].ToString());
            object TenDVCha = new LuongKKKTBLL().GetTenDVChaRptDS(Session[SessionCommon.DonViID].ToString());
            RptLoaiTruCongNo.ReportSource = null;
            //dete
            var table = new BangLuongDonViBLL().GetBangLuongDonVi(Session[SessionCommon.DonViID].ToString(), int.Parse(Session[SessionCommon.Thang].ToString()), int.Parse(Session[SessionCommon.nam].ToString()));
            int v = table.Rows.Count;
            var tblFooter = new LuongKKKTBLL().GetSourceFooterRptDS(Session[SessionCommon.DonViID].ToString(), int.Parse(Session[SessionCommon.nam].ToString()), int.Parse(Session[SessionCommon.Thang].ToString()));
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
            RptLoaiTruCongNo.ReportSource = _rpt;
            RptLoaiTruCongNo.DataBind();
            var fileName = "/Assets/FileReports/" + Session[SessionCommon.Username].ToString().ToLower() + "/LoaiTruCongNo-" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + "" + DateTime.Now.Hour + "" + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf";
            Session.Add("CongNoVTCNTT", fileName);
            _rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(fileName));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["CongNoVTCNTT"].ToString());
        }
    }
}
