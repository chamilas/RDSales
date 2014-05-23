<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ConfirmOutlets.aspx.cs" Inherits="RDSales_Management_System.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">Outlet Confirmation
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:GridView ID="gdvOutlets" runat="server" AllowPaging="True" BorderColor="#666C6F" BorderStyle="Outset" DataKeyNames="OutletID" OnRowCommand="gdvOutlets_RowCommand" Width="814px" PagerSettings-Mode="NextPreviousFirstLast" HorizontalAlign="Center">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="selectRow" Text="Confirm" >
                <ControlStyle Width="90px" />
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:ButtonField>
            </Columns>

<PagerSettings Mode="NextPreviousFirstLast"></PagerSettings>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
    </p>
</asp:Content>
