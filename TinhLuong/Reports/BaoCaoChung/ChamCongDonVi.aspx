<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ReportSite.Master" AutoEventWireup="true" CodeBehind="ChamCongDonVi.aspx.cs" Inherits="TinhLuong.Reports.BaoCaoChung.ChamCongDonVi" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .panelNavigatorItemImage,.leftPanel{
            display:none;
           
        }
    </style>
    <div class="fixedExport" style="position: fixed; right: 0; top: 7%; width: 8em; margin-top: -2.5em;">
        <p style="float: left; color: firebrick; font-weight: bold; font-size: 13px; margin-top: 3px">Export PDF:   </p>
        <input type="button" id="btnPrint" style="margin-top: -2px; margin-right: 5px; border: 1px solid firebrick; width: 25px; height: 24px; cursor: pointer; background-image: url(/Assets/FileReports/pdf24.png);" onclick="Print()" />
    </div>  <asp:Button ID="Button1" runat="server" Text="Print"  style="display:none" /><br />
      <div id="dvReport" style="width:100%">
   <CR:CrystalReportViewer ID="RptTongHop"   runat="server" HasCrystalLogo="False"
                AutoDataBind="True"  EnableDatabaseLogonPrompt="false" ToolPanelWidth="100px"
                 ToolPanelView="None" BestFitPage="False" SeparatePages="False" ShowAllPageIds="True" ViewStateMode="Enabled" HasDrilldownTabs="False" HasDrillUpButton="False" HasPrintButton="False" />
      </div>
        <br />
        <script type="text/javascript">
            function Print() {
                document.getElementById('<%= Button1.ClientID %>').click()
               
            }
        </script>
</asp:Content>
