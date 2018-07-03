<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Shared/ReportSite.Master" CodeBehind="FrmViettinBank.aspx.cs" Inherits="TinhLuong.Reports.BaoCaoChung.FrmViettinBank" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
        .panelNavigatorItemImage,.leftPanel{
            display:none;
           
        }
    </style>
    <div class="fixedExport" style="position: fixed; right: 0; top: 7%; width: 8em; margin-top: -2.5em;">
        <p style="float: left; color: firebrick; font-weight: bold; font-size: 13px; margin-top: 3px">Export PDF:   </p>
        <input type="button" id="btnPrint" style="margin-top: -2px; margin-right: 5px; border: 1px solid firebrick; width: 25px; height: 24px; cursor: pointer; background-image: url(/Assets/FileReports/pdf24.png);" onclick="Print()" />
    </div>   <asp:Button ID="Button1" runat="server" Text="Print" OnClick="Button1_Click" style="display:none"/><br />
    <div id="dvReport" style="width: 100%">
        <CR:CrystalReportViewer ID="Rpt_Frm_AgriBank" runat="server" HasCrystalLogo="False"
            AutoDataBind="True" EnableDatabaseLogonPrompt="false" ToolPanelWidth="100px"
             ToolPanelView="None" BestFitPage="False" SeparatePages="False" ShowAllPageIds="True" ViewStateMode="Enabled" HasDrilldownTabs="False" HasDrillUpButton="False" HasPrintButton="False" />
    </div>
    <br />

    <script type="text/javascript">
        function Print() {
            document.getElementById('<%= Button1.ClientID %>').click()
            //var dvReport = document.getElementById("dvReport");
            //var frame1 = dvReport.getElementsByTagName("iframe")[0];
            //if (navigator.appName.indexOf("Internet Explorer") != -1 || navigator.appVersion.indexOf("Trident") != -1) {
            //    frame1.name = frame1.id;
            //    window.frames[frame1.id].focus();
            //    window.frames[frame1.id].print();
            //}
            //else {
            //    var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
            //    frameDoc.print();
            //}
        }
    </script>
</asp:Content>

