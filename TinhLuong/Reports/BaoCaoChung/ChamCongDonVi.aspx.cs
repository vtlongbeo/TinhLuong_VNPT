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
    public partial class ChamCongDonVi : System.Web.UI.Page
    {
        private ReportClass _rpt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[SessionCommon.Username] != null)
                LoadReport();
            else
                Response.Redirect("/dang-nhap");
        }

        private void LoadReport()
        {


            // CrystalDecisions.Shared.ParameterDiscreteValue TenDV = new CrystalDecisions.Shared.ParameterDiscreteValue();
            //object TenDVi = new LuongKKKTBLL().GetTenDVRptDS(Session["DonVi_BaoCao"].ToString());
            //object TenDVCha = new LuongKKKTBLL().GetTenDVChaRptDS(Session["DonVi_BaoCao"].ToString());
            RptTongHop.ReportSource = null;
            //dete

            var Thang = Session[SessionCommon.Thang].ToString();
            if (Thang.Length < 2)
                Thang = "0" + Thang;
            var Nam = Session[SessionCommon.nam].ToString();
            var TrucDem = Session["TrucDem"].ToString();
            var DonViID = Session["DonVi_BaoCao"].ToString();
            if (TrucDem == "0")
            {
                _rpt = new rptBangChamCong();
                var table = new ChamCongBLL().GetChamCongDonVi(Thang, Nam, DonViID, "", Session[SessionCommon.Username].ToString());
                //int v = table.Rows.Count;
                //var tblFooter = new LuongKKKTBLL().GetSourceFooterRptDS(Session["DonVi_BaoCao"].ToString(), int.Parse(Session[SessionCommon.nam].ToString()), int.Parse(Session[SessionCommon.Thang].ToString()));
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
                //_rpt.ParameterFields["TenDV"].CurrentValues.AddValue(TenDVi);
                //_rpt.ParameterFields["TenDVCha"].CurrentValues.AddValue(TenDVCha);
                //_rpt.ParameterFields["NguoiLapBieu"].CurrentValues.AddValue(NgLapBieu);
                //_rpt.ParameterFields["PTKT"].CurrentValues.AddValue(PTKT);
                //_rpt.ParameterFields["LanhDao"].CurrentValues.AddValue(LanhDao);
                RptTongHop.ReportSource = _rpt;
                RptTongHop.DataBind();
            }
            else
            {
                _rpt = new rptBangChamTrucDem();
                var table = new ChamCongBLL().ChamCong_SelectByDonVi(Thang, Nam, DonViID, 1, Session[SessionCommon.Username].ToString());
                //int v = table.Rows.Count;
                //var tblFooter = new LuongKKKTBLL().GetSourceFooterRptDS(Session["DonVi_BaoCao"].ToString(), int.Parse(Session[SessionCommon.nam].ToString()), int.Parse(Session[SessionCommon.Thang].ToString()));
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
                //_rpt.ParameterFields["TenDV"].CurrentValues.AddValue(TenDVi);
                //_rpt.ParameterFields["TenDVCha"].CurrentValues.AddValue(TenDVCha);
                //_rpt.ParameterFields["NguoiLapBieu"].CurrentValues.AddValue(NgLapBieu);
                //_rpt.ParameterFields["PTKT"].CurrentValues.AddValue(PTKT);
                //_rpt.ParameterFields["LanhDao"].CurrentValues.AddValue(LanhDao);
                RptTongHop.ReportSource = _rpt;
                RptTongHop.DataBind();
            }
            var fileName = "/Assets/FileReports/" + Session[SessionCommon.Username].ToString().ToLower() + "/BangChamCong-" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + "" + DateTime.Now.Hour + "" + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf";
            Session.Add("BangChamCong", fileName);
            _rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(fileName));

        }
    }
}