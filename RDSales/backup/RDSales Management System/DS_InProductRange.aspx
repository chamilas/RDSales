<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DS_InProductRange.aspx.cs" Inherits="RDSales_Management_System.DS_InProductRange" %>
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
            height: 30px;
        }
        
        
        .style8
        {
            width: 97px;
            font-size: 13px;
            font-weight: bold;
            height: 30px;
        }
        .style9
        {
            width: 7px;
            height: 30px;
        }
        .style10
        {
            width: 395px;
            height: 30px;
        }
        .style11
        {
            height: 30px;
        }
        
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder5" runat="server"> Direct Sales By Product Range and Customer
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
            <td class="style8">
                Date</td>
            <td class="style9">
                :</td>
            <td class="style10">
                <asp:TextBox ID="txt_date" runat="server" CssClass="input-default" 
                    Width="200px" AutoPostBack="True" ontextchanged="txt_date_TextChanged" ></asp:TextBox>
                <asp:CalendarExtender ID="txt_date_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txt_date">
                </asp:CalendarExtender>
            </td>
            <td class="style7">
                </td>
            <td class="style11">
                </td>
            <td class="style11">
               <%-- <asp:Image ID="img_magnify" runat="server" Height="37px" 
                    ImageUrl="~/images/magnify.png" Width="38px" 
                    ondatabinding="img_magnify_DataBinding" onload="img_magnify_Load" />
                <asp:PopupControlExtender ID="img_magnify_PopupControlExtender" runat="server" 
                    DynamicServicePath="" Enabled="True" Position ="Bottom" 
                    TargetControlID="img_magnify" PopupControlID="panel1" DynamicServiceMethod = "GetRegionalDataSubmissionStatus" DynamicContextKey = '<%# Eval("BatchID") %>'  >
                </asp:PopupControlExtender>--%>
            </td>
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
        <asp:GridView ID="GridView1" runat="server" CssClass="bGrid" 
            onrowdatabound="GridView1_RowDataBound" Width="100%">
        </asp:GridView>
    </div>
</asp:Content>
