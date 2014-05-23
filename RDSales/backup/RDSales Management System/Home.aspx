<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RDSales_Management_System.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 177px;
        }
        .style3
        {
            width: 174px;
        }
        .style4
        {
            width: 228px;
        }
        .style5
        {
            color: #003366;
            font-size: 15px;
        }
        .style6
        {
            width: 228px;
            height: 177px;
        }
        .style7
        {
            width: 177px;
            height: 177px;
        }
        .style8
        {
            width: 174px;
            height: 177px;
        }
        .style9
        {
            height: 177px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">Home
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td class="style5" colspan="4">
                Select your Option from the Menu</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
            </td>
            <td class="style7">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="132px" 
                    ImageUrl="~/images/enter.png" onclick="ImageButton1_Click" Width="136px" />
            </td>
            <td class="style8">
                <asp:ImageButton ID="ImageButton2" runat="server" Height="132px" 
                    ImageUrl="~/images/edit.png" onclick="ImageButton2_Click" />
            </td>
            <td class="style9">
                <asp:ImageButton ID="ImageButton3" runat="server" Height="132px" 
                    ImageUrl="~/images/sales.png" onclick="ImageButton3_Click" />
            &nbsp;</td>
            <td class="style9">
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>
</asp:Content>
