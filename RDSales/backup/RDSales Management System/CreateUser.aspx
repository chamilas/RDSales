<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="RDSales_Management_System.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
        width: 107px;
    }
        .style4
        {
        height: 20px;
        width: 327px;
    }
        .style5
        {
        width: 145px;
        height: 20px;
        color: #CC0000;
    }
        .style6
    {
        width: 10px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder5" runat="server"> Create New User
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    
        <table class="style1">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                First Name</td>
            <td class="style6">
                :</td>
            <td>
                <asp:TextBox ID="txt_fname" runat="server" class="input-default" Height="14px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                E.P.F Number</td>
            <td class="style6">
                :</td>
            <td>
                <asp:TextBox ID="txt_EmpNum" runat="server" class="input-default" Height="14px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txt_EmpNum" ErrorMessage="EPF Number not valid" 
                    style="color: #FF0000" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txt_EmpNum" ErrorMessage="E.P.F Number required" 
                    style="color: #FF0000"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                Username</td>
            <td class="style6">
                :</td>
            <td>
                <asp:TextBox ID="txt_Username" runat="server" class="input-default" 
                    Height="14px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txt_Username" CssClass="style5" 
                    ErrorMessage="Username required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                Password</td>
            <td class="style6">
                :</td>
            <td>
                <asp:TextBox ID="txt_password" runat="server" class="input-default" 
                    Height="14px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txt_password" CssClass="style5" 
                    ErrorMessage="Password required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                Confirm Password</td>
            <td class="style6">
                :</td>
            <td>
                <asp:TextBox ID="txt_Conpass" runat="server" class="input-default" 
                    Height="14px" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txt_Conpass" ControlToValidate="txt_password" 
                    ErrorMessage="Password mismatch!" style="color: #FF0000"></asp:CompareValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                Designation</td>
            <td class="style6">
                :</td>
            <td>
                <asp:TextBox ID="txt_Designation" runat="server" class="input-default" 
                    Height="14px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                RoleRole</td>
            <td class="style6">
                :</td>
            <td>
                <asp:DropDownList ID="DropD_Role" runat="server" 
                    style="font-family: 'Trebuchet MS'" Width="150px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:Label ID="lbl_Result" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:Button ID="bttn_Create" runat="server" onclick="bttn_Create_Click" 
                    Text="Create" CssClass="ui-button" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
    </div>
</asp:Content>
