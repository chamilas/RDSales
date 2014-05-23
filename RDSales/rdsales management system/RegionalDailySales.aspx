<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RegionalDailySales.aspx.cs" Inherits="RDSales_Management_System.RegionalDailySales" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-size: small;
            color: #003366;
            width: 71px;
        }
        .style3
        {
            font-size: small;
            color: #003366;
            width: 924px;
        }
        .style4
        {
            width: 924px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder5" runat="server"> Regional 
    CUMULATIVE Sales 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td class="style2">
                <strong>Date</strong></td>
            <td class="style3">
                <asp:TextBox ID="txt_date" runat="server" Width="261px" AutoPostBack="True" 
                    ontextchanged="txt_date_TextChanged"></asp:TextBox>
                <asp:CalendarExtender ID="txt_date_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txt_date">
                </asp:CalendarExtender>
                <asp:Label ID="lbl_status" runat="server" style="font-size: 11px"></asp:Label>
            </td>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <strong>Region</strong></td>
            <td class="style4">
                <asp:Label ID="lbl_region" runat="server" 
                    style="font-size: large; color: #999999"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
            Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="700px">
            <LocalReport ReportPath="Reports\RegionalDailySales.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
</asp:Content>
