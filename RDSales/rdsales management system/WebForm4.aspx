<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="RDSales_Management_System.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" OnClientClick="return confirm('Are you sure you want to delete time this record?');" />
        <br />
    </p>
</asp:Content>
