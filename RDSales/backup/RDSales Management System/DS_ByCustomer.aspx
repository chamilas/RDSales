<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DS_ByCustomer.aspx.cs" Inherits="RDSales_Management_System.DS_ByCustomer" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 97px;
        }
        .style3
        {
            width: 7px;
        }
        .style5
        {
            width: 395px;
        }
        .style4
        {
            width: 97px;
            font-size: 13px;
            font-weight: bold;
        }
        .style7
        {
            width: 195px;
            font-size: 12px;
        }
        
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder5" runat="server"> Direct Sales By Customer
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Label ID="lbl_status" runat="server"></asp:Label>
            </td>
            <td class="style6">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Date</td>
            <td class="style3">
                :</td>
            <td class="style5">
                <asp:TextBox ID="txt_date" runat="server" CssClass="input-default" 
                    Width="200px" AutoPostBack="True" ontextchanged="txt_date_TextChanged" ></asp:TextBox>
                <asp:CalendarExtender ID="txt_date_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txt_date">
                </asp:CalendarExtender>
            </td>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
               
            </td>
        </tr>
        <tr>
            <td class="style4">
                Customer</td>
            <td class="style3">
                :</td>
            <td class="style5">
                <asp:TextBox ID="txt_customer" runat="server" CssClass="input-default" 
                    Width="200px" AutoPostBack="True" ontextchanged="txt_customer_TextChanged"></asp:TextBox>
                 <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                   CompletionInterval="10" CompletionSetCount="12" EnableCaching="true" 
                   MinimumPrefixLength="1" ServiceMethod="GetDirectSalesCustomers" 
                   ServicePath="AutoComplete.asmx" TargetControlID="txt_customer" 
                   UseContextKey="True" DelimiterCharacters = ":">
               </asp:AutoCompleteExtender>
            </td>
            <td class="style6">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style6" colspan="3">
                &nbsp;</td>
        </tr>
    </table>
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="bGrid" 
            onrowdatabound="GridView1_RowDataBound">
        </asp:GridView>
    </div>
</asp:Content>
