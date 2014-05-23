<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RangeProdViseSales.aspx.cs" Inherits="RDSales_Management_System.RangeProdViseSales" %>
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
            width: 305px;
        }
        .style4
        {
            width: 97px;
            font-size: 13px;
            font-weight: bold;
        }
        .style7
        {
            width: 20px;
            font-size: 12px;
        }
        
        
        .style8
        {
            width: 20px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder5" runat="server"> Periodic Cumulative Product Vise Sales
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
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                From</td>
            <td class="style3">
                :</td>
            <td class="style5">
                <asp:TextBox ID="txt_from" runat="server" CssClass="input-default" 
                    Width="200px" AutoPostBack="True" ontextchanged="txt_from_TextChanged"  ></asp:TextBox>
                <asp:CalendarExtender ID="txt_from_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txt_from">
                </asp:CalendarExtender>
            </td>
            <td class="style7">
                To:</td>
            <td>
                <%-- <asp:Image ID="img_magnify" runat="server" Height="37px" 
                    ImageUrl="~/images/magnify.png" Width="38px" 
                    ondatabinding="img_magnify_DataBinding" onload="img_magnify_Load" />
                <asp:PopupControlExtender ID="img_magnify_PopupControlExtender" runat="server" 
                    DynamicServicePath="" Enabled="True" Position ="Bottom" 
                    TargetControlID="img_magnify" PopupControlID="panel1" DynamicServiceMethod = "GetRegionalDataSubmissionStatus" DynamicContextKey = '<%# Eval("BatchID") %>'  >
                </asp:PopupControlExtender>--%>
                <asp:TextBox ID="txt_to" runat="server" CssClass="input-default" 
                    Width="200px" AutoPostBack="True" ontextchanged="txt_to_TextChanged"  ></asp:TextBox>
                <asp:CalendarExtender ID="txt_to_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txt_to">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Prooduct</td>
            <td class="style3">
                :</td>
            <td class="style5">
                <asp:TextBox ID="txt_product" runat="server" CssClass="input-default" 
                    Width="200px" AutoPostBack="True" ontextchanged="txt_product_TextChanged" ></asp:TextBox>
                 <asp:AutoCompleteExtender ID="txt_product_AutoCompleteExtender" runat="server" 
                   CompletionInterval="10" CompletionSetCount="12" EnableCaching="true" 
                   MinimumPrefixLength="1" ServiceMethod="GetBasicProdctListOfRDsales" 
                   ServicePath="AutoComplete.asmx" TargetControlID="txt_product" 
                   UseContextKey="True" DelimiterCharacters = ":">
                </asp:AutoCompleteExtender>
            </td>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style6" colspan="2">
                &nbsp;</td>
        </tr>
    </table>

</div>
<div id ="mainContent">

    <table width="60%">
        <tr>
            <td colspan="4" height="35px">
                <h1>
                    <asp:Label ID="lbl_header" runat="server" 
                        style="font-size: 14pt; color: #003366"></asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lbl_prod1" runat="server" CssClass="style12" 
                    style="font-size: 9pt"></asp:Label>
            </td>
            <td width="16%" align="right">
                <asp:Label ID="lbl_prod2" runat="server" CssClass="style12" 
                    style="font-size: 9pt"></asp:Label>
            </td>
            <td width="17%" align="right">
                <asp:Label ID="lbl_prod3" runat="server" CssClass="style12" 
                    style="font-size: 9pt"></asp:Label>
            </td>
            <td width="17%" align="right">
                <asp:Label ID="lbl_prod4" runat="server" CssClass="style12" 
                    style="font-size: 9pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="49%">
                <asp:GridView ID="GridView1" runat="server" CssClass="bGrid" onrowdatabound="GridView1_RowDataBound" 
                    >
                </asp:GridView>
            </td>
            <td width="16%">
                <asp:GridView ID="GridView2" runat="server" CssClass="bGrid" onrowdatabound="GridView2_RowDataBound" 
                   >
                </asp:GridView>
            </td>
            <td width="16%">
                <asp:GridView ID="GridView3" runat="server" CssClass="bGrid" onrowdatabound="GridView3_RowDataBound" 
                    >
                </asp:GridView>
            </td>
            <td  width="16%">
                <asp:GridView ID="GridView4" runat="server" CssClass="bGrid" onrowdatabound="GridView4_RowDataBound" 
                   >
                </asp:GridView>
            </td>
        </tr>
    </table>

    </div>
</asp:Content>
