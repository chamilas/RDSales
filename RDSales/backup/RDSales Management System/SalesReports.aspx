<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SalesReports.aspx.cs" Inherits="RDSales_Management_System.SalesReports" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style17
        {
            font-size: 10pt;
            width: 91px;
        }
        .style14
        {
            width: 202px;
        }
        .style19
        {
            font-size: 10pt;
            width: 62px;
        }
        .style15
        {
            width: 237px;
        }
        .style12
        {
            font-size: 10pt;
        }
        .style18
        {
            width: 91px;
        }
        .style20
    {
        width: 7px;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder5" runat="server"> Sales Reports
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td colspan="5" class="style20">
                <asp:Label ID="lbl_timeout" runat="server" style="font-size: 12px"></asp:Label>
            </td>
            <td colspan="6">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td class="style17">
                <strong>Region</strong></td>
            <td class="style14">
                <asp:DropDownList ID="cmb_Region" runat="server" Width="164px" 
                    AutoPostBack="True" onselectedindexchanged="cmb_Region_SelectedIndexChanged" 
                    style="font-family: 'Trebuchet MS'; font-size: 1em">
                </asp:DropDownList>
            </td>
            <td class="style19">
                <strong>Date</strong></td>
            <td class="style15">
                <asp:TextBox ID="txt_date" runat="server" CssClass="input-default" 
                        Width="228px" AutoPostBack="True" ontextchanged="txt_date_TextChanged"></asp:TextBox>
                <asp:CalendarExtender ID="txt_date_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txt_date">
                </asp:CalendarExtender>
            </td>
            <td class="style12" colspan="2">
                <strong>ASM</strong></td>
            <td>
                <asp:TextBox ID="txt_asm" runat="server" CssClass="input-default" 
                        Width="228px"></asp:TextBox>
            </td>
            <td  class="style12">
                    &nbsp;</td>
            <td>
                    &nbsp;</td>
            <td  class="style12">
                    &nbsp;</td>
            <td>
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style17">
                <strong>Report Type</strong></td>
            <td class="style14">
                <asp:RadioButton ID="Radio_daily" runat="server" GroupName="report" 
                    oncheckedchanged="Radio_daily_CheckedChanged" Text="Daily Report" 
                    AutoPostBack="True" Checked="True" />
            </td>
            <td class="style19">
                &nbsp;</td>
            <td class="style15">
                <asp:RadioButton ID="Radio_Cum" runat="server" GroupName="report" 
                    oncheckedchanged="Radio_Cum_CheckedChanged" Text="Cumulative Report" 
                    AutoPostBack="True" />
            </td>
            <td class="style12" colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td  class="style12">
                    &nbsp;</td>
            <td>
                    &nbsp;</td>
            <td  class="style12">
                    &nbsp;</td>
            <td>
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style18">
                &nbsp;</td>
            <td colspan="3">
                <asp:Label ID="lbl_status" runat="server"></asp:Label>
            </td>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
            Font-Names="Verdana" Font-Size="8pt" Height="700px" 
            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
            WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Reports\RegionalDailySales_PerDay.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
</asp:Content>
