<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditRDTargerts.aspx.cs" Inherits="RDSales_Management_System.EditRDTargerts" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style8
        {
            font-size: 9pt;
        }
        .style10
        {
            width: 188px;
            font-size: 12px;
            font-weight: bold;
            color: #000000;
        }
        .style13
        {
            height: 30px;
            text-align: center;
            background-color: #F4F4F4;
            }
        .style14
        {
            font-weight: bold;
        }
        .style15
        {
            background-color: #FBFDFF;
        }
        .style17
        {
            width: 188px;
            font-size: 12px;
            font-weight: bold;
            color: #000000;
            background-color: #FBFDFF;
        }
        .style18
        {
            background-color: #F3FCF4;
        }
        .style20
        {
            width: 188px;
            font-size: 12px;
            font-weight: bold;
            color: #000000;
            background-color: #F3FCF4;
        }
        .style21
        {
            background-color: #FFF9F2;
        }
        .style23
        {
            width: 188px;
            font-size: 12px;
            font-weight: bold;
            color: #000000;
            background-color: #FFF9F2;
        }
        .style24
        {
            background-color: #F9F9F9;
        }
        .style26
        {
            width: 188px;
            font-size: 12px;
            font-weight: bold;
            color: #000000;
            background-color: #F9F9F9;
        }
        .style27
        {
            width: 179px;
        }
        .style29
        {
            width: 207px;
        }
        .style30
        {
            width: 253px;
        }
        .style31
        {
            width: 175px;
        }
        .style32
        {
            width: 1021px;
        }
        .style33
        {
            font-family: "Trebuchet MS";
            color: #333333;
            font-size: 10pt;
            width: 276px;
        }
        .style34
        {
            width: 176px;
        }
        .style35
        {
            font-family: "Trebuchet MS";
            color: #333333;
            font-size: 10pt;
            width: 176px;
        }
        .style38
        {
            width: 47px;
        }
        .style39
        {
            font-family: "Trebuchet MS";
            color: #333333;
            font-size: 10pt;
            width: 78px;
        }
        .style40
        {
            width: 78px;
        }
        .style44
        {
            font-family: "Trebuchet MS";
            color: #333333;
            font-size: 10pt;
            width: 52px;
        }
        .style45
        {
            font-family: "Trebuchet MS";
            color: #333333;
            font-size: 10pt;
            width: 47px;
        }
        .style47
        {
            width: 95px;
        }
        .style48
        {
            background-color: #FBFDFF;
            width: 95px;
        }
        .style49
        {
            background-color: #F3FCF4;
            width: 95px;
        }
        .style50
        {
            background-color: #FFF9F2;
            width: 95px;
        }
        .style51
        {
            background-color: #F9F9F9;
            width: 95px;
        }
        
         .styleRoute
        {
            height: 29px;
            font-weight: bold;
            background-color: #F4F4F4;
            text-align: center;
        }
            .watermarked {
      height:20px;
      width:150px;
      padding:2px 0 0 2px;
      border:1px solid #BEBEBE;
      font-style:italic;
      color:gray;
      font-size: small;
}
        .watermarkBox
        {
            height:20px;
            width:150px;
            padding:2px 0 0 2px;
           border:1px solid #BEBEBE;
            font-family: "Trebuchet MS";
            font-size: small;
            background-color :#F4F4F4;
        }
        .style52
        {
            width: 188px;
            height: 30px;
            color: #003366;
            font-weight: 700;
            text-align: center;
            background-color: #F4F4F4;
            font-size: small;
        }
        .style53
        {
            background-color: #FFFFFF;
        }
        .style54
        {
            background-color: #FFFFFF;
            width: 95px;
        }
        .style55
        {
            width: 188px;
            font-size: 12px;
            font-weight: bold;
            color: #003366;
            background-color: #FFFFFF;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder5" runat="server"> 
    Edit Targets 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
  <div>
        <table style="background-color: #FFFFFF" width="100%">
            <tr>
                <td class="style40">
                    &nbsp;</td>
                <td class="style29">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
                <td class="style38">
                    &nbsp;</td>
                <td class="style30">
                    &nbsp;</td>
                <td class ="style44">
                    &nbsp;</td>
                <td class="style31">
                    &nbsp;</td>
                <td class="style31">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style39">
                    <strong>Date</strong></td>
                <td class="style29">
                    <asp:TextBox ID="txt_date" runat="server" CssClass="datebox" 
                        Width="198px"  AutoPostBack="True" ontextchanged="txt_date_TextChanged"></asp:TextBox>
                    <asp:CalendarExtender ID="txt_date_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txt_date" Format="MM/dd/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td class="style45">
                    <strong>ASM</strong></td>
                <td class="style30">
                    <asp:TextBox ID="txt_asm" runat="server" CssClass="input-default" Width="242px"></asp:TextBox>
                </td>
                <td class ="style44">
                    <strong>Region</strong></td>
                <td class="style31">
                    <asp:TextBox ID="txt_region" runat="server" CssClass="input-default" 
                        Width="198px"></asp:TextBox>
                </td>
                <td class="style31">
                    &nbsp;</td>
            </tr>
            </table>
    </div>
    <table class="style8">
       
        <tr>
            <td colspan="9">
                <asp:Label ID="lbl_status" runat="server" 
                    style="font-size: 1em; font-weight: 700"></asp:Label>
            </td>
        </tr>
       
        <tr>
            <td colspan="9">
                &nbsp;</td>
        </tr>
        <tr class="style8">
            <td class="style52">
                Product/Territory </td>
            <td class="style13" >
                <asp:Label ID="lbl_Terr1" runat="server" CssClass="style14"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lbl_Terr2" runat="server" CssClass="style14"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lbl_Terr3" runat="server" CssClass="style14"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lbl_Terr4" runat="server" CssClass="style14"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lbl_Terr5" runat="server" CssClass="style14"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lbl_Terr6" runat="server" CssClass="style14"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lbl_Terr7" runat="server" CssClass="style14"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="lbl_Terr8" runat="server" CssClass="style14"></asp:Label>
            </td>
        </tr>
        <tr class="style8">
            <td class="style52">
                &nbsp;</td>
            <td class="style13" >
             
                &nbsp;</td>
            <td class="style13">
                   
                   
                    &nbsp;</td>
            <td class="style13">
                    
                   
                    &nbsp;</td>
            <td class="style13">
                    
                   
                    &nbsp;</td>
            <td class="style13">
                   
                   
                    &nbsp;</td>
            <td class="style13">
                   
                   
                    &nbsp;</td>
            <td class="style13">
                   
                   
                    &nbsp;</td>
            <td class="style13">
                  
                   
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                Samahan</td>
            <td>
                    <asp:TextBox ID="txt_samahan_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txt_samahan_1" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style47">
                    <asp:TextBox ID="txt_samahan_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" 
                        ControlToValidate="txt_samahan_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_samahan_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" 
                        ControlToValidate="txt_samahan_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_samahan_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator43" runat="server" 
                        ControlToValidate="txt_samahan_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_samahan_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator57" 
                        runat="server" ControlToValidate="txt_samahan_5" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_samahan_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator71" 
                        runat="server" ControlToValidate="txt_samahan_6" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_samahan_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator85" 
                        runat="server" ControlToValidate="txt_samahan_7" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_samahan_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator99" 
                        runat="server" ControlToValidate="txt_samahan_8" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style17">
                Kesha Normal</td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaN_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txt_keshaN_1" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style48">
                    <asp:TextBox ID="txt_keshaN_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" 
                        ControlToValidate="txt_keshaN_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaN_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" 
                        ControlToValidate="txt_keshaN_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaN_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator44" runat="server" 
                        ControlToValidate="txt_keshaN_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaN_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator58" 
                        runat="server" ControlToValidate="txt_keshaN_5" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaN_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator72" 
                        runat="server" ControlToValidate="txt_keshaN_6" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaN_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator86" 
                        runat="server" ControlToValidate="txt_keshaN_7" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaN_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator100" 
                        runat="server" ControlToValidate="txt_keshaN_8" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style17">
                Kesha Jusmine</td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaJ_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="txt_keshaJ_1" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style48">
                    <asp:TextBox ID="txt_keshaJ_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" 
                        ControlToValidate="txt_keshaJ_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaJ_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server" 
                        ControlToValidate="txt_keshaJ_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaJ_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator45" runat="server" 
                        ControlToValidate="txt_keshaJ_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaJ_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator59" 
                        runat="server" ControlToValidate="txt_keshaJ_5" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaJ_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator73" 
                        runat="server" ControlToValidate="txt_keshaJ_6" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaJ_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator87" 
                        runat="server" ControlToValidate="txt_keshaJ_7" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_keshaJ_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator101" 
                        runat="server" ControlToValidate="txt_keshaJ_8" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style17">
                HCC</td>
            <td class="style15">
                    <asp:TextBox ID="txt_HCC_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ControlToValidate="txt_HCC_1" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style48">
                    <asp:TextBox ID="txt_HCC_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" 
                        ControlToValidate="txt_HCC_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_HCC_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server" 
                        ControlToValidate="txt_HCC_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_HCC_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator46" runat="server" 
                        ControlToValidate="txt_HCC_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_HCC_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator60" 
                        runat="server" ControlToValidate="txt_HCC_5" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_HCC_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator74" 
                        runat="server" ControlToValidate="txt_HCC_6" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_HCC_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator88" 
                        runat="server" ControlToValidate="txt_HCC_7" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style15">
                    <asp:TextBox ID="txt_HCC_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator102" 
                        runat="server" ControlToValidate="txt_HCC_8" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
              <td class="style10">
                  Muscleguard</td>
            <td>
                    <asp:TextBox ID="txt_MG_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator113" runat="server" 
                        ControlToValidate="txt_HCC_1" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style47" >
                    <asp:TextBox ID="txt_MG_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator114" runat="server" 
                        ControlToValidate="txt_HCC_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_MG_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator115" runat="server" 
                        ControlToValidate="txt_HCC_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_MG_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator116" runat="server" 
                        ControlToValidate="txt_HCC_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_MG_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator117" 
                        runat="server" ControlToValidate="txt_HCC_5" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_MG_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator118" 
                        runat="server" ControlToValidate="txt_HCC_6" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_MG_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator119" 
                        runat="server" ControlToValidate="txt_HCC_7" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_MG_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator120" 
                        runat="server" ControlToValidate="txt_HCC_8" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style10">
                Paspanguwa</td>
            <td>
                    <asp:TextBox ID="txt_Paspangu_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                        ControlToValidate="txt_Paspangu_1" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style47">
                    <asp:TextBox ID="txt_Paspangu_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" 
                        ControlToValidate="txt_Paspangu_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_Paspangu_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server" 
                        ControlToValidate="txt_Paspangu_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_Paspangu_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator47" runat="server" 
                        ControlToValidate="txt_Paspangu_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_Paspangu_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator61" 
                        runat="server" ControlToValidate="txt_Paspangu_5" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_Paspangu_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator75" 
                        runat="server" ControlToValidate="txt_Paspangu_6" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_Paspangu_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator89" 
                        runat="server" ControlToValidate="txt_Paspangu_7" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td>
                    <asp:TextBox ID="txt_Paspangu_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator103" 
                        runat="server" ControlToValidate="txt_Paspangu_8" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style20">
                Sudantha 45g</td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud45_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                        ControlToValidate="txt_Sud45_1" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style49">
                    <asp:TextBox ID="txt_Sud45_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" 
                        ControlToValidate="txt_Sud45_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud45_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator34" runat="server" 
                        ControlToValidate="txt_Sud45_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud45_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator48" runat="server" 
                        ControlToValidate="txt_Sud45_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud45_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator62" 
                        runat="server" ControlToValidate="txt_Sud45_5" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud45_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator76" 
                        runat="server" ControlToValidate="txt_Sud45_6" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud45_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator90" 
                        runat="server" ControlToValidate="txt_Sud45_7" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud45_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator104" 
                        runat="server" ControlToValidate="txt_Sud45_8" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style20">
                Sudantha 80g</td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud80_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                        ControlToValidate="txt_Sud80_1" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style49">
                    <asp:TextBox ID="txt_Sud80_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" 
                        ControlToValidate="txt_Sud80_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud80_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator35" runat="server" 
                        ControlToValidate="txt_Sud80_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud80_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator49" runat="server" 
                        ControlToValidate="txt_Sud80_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud80_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator63" 
                        runat="server" ControlToValidate="txt_Sud80_5" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud80_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator77" 
                        runat="server" ControlToValidate="txt_Sud80_6" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud80_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator91" 
                        runat="server" ControlToValidate="txt_Sud80_7" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style18">
                    <asp:TextBox ID="txt_Sud80_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator105" 
                        runat="server" ControlToValidate="txt_Sud80_8" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style23">
                Samahan Balm 3g</td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm3_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                        ControlToValidate="txt_balm3_1" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style50">
                    <asp:TextBox ID="txt_balm3_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" 
                        ControlToValidate="txt_balm3_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm3_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator36" runat="server" 
                        ControlToValidate="txt_balm3_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm3_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator50" runat="server" 
                        ControlToValidate="txt_balm3_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm3_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator64" 
                        runat="server" ControlToValidate="txt_balm3_5" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm3_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator78" 
                        runat="server" ControlToValidate="txt_balm3_6" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm3_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator92" 
                        runat="server" ControlToValidate="txt_balm3_7" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm3_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator106" 
                        runat="server" ControlToValidate="txt_balm3_8" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style23">
                Samahan Balm 7g</td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm7_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                        ControlToValidate="txt_balm7_1" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style50">
                    <asp:TextBox ID="txt_balm7_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" 
                        ControlToValidate="txt_balm7_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm7_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator37" runat="server" 
                        ControlToValidate="txt_balm7_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm7_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator51" runat="server" 
                        ControlToValidate="txt_balm7_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm7_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator65" 
                        runat="server" ControlToValidate="txt_balm7_5" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm7_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator79" 
                        runat="server" ControlToValidate="txt_balm7_6" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm7_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator93" 
                        runat="server" ControlToValidate="txt_balm7_7" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm7_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator107" 
                        runat="server" ControlToValidate="txt_balm7_8" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style23">
                Samahan Balm 25g</td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm25_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                        runat="server" ControlToValidate="txt_balm25_1" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style50">
                    <asp:TextBox ID="txt_balm25_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" 
                        ControlToValidate="txt_balm25_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm25_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator38" runat="server" 
                        ControlToValidate="txt_balm25_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm25_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator52" runat="server" 
                        ControlToValidate="txt_balm25_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm25_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator66" 
                        runat="server" ControlToValidate="txt_balm25_5" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm25_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator80" 
                        runat="server" ControlToValidate="txt_balm25_6" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm25_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator94" 
                        runat="server" ControlToValidate="txt_balm25_7" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm25_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator108" 
                        runat="server" ControlToValidate="txt_balm25_8" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style23">
                Samahan Balm 50g</td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm50_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" 
                        runat="server" ControlToValidate="txt_balm50_1" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style50">
                    <asp:TextBox ID="txt_balm50_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" 
                        ControlToValidate="txt_balm50_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm50_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator39" runat="server" 
                        ControlToValidate="txt_balm50_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm50_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator53" runat="server" 
                        ControlToValidate="txt_balm50_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm50_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator67" 
                        runat="server" ControlToValidate="txt_balm50_5" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm50_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator81" 
                        runat="server" ControlToValidate="txt_balm50_6" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm50_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator95" 
                        runat="server" ControlToValidate="txt_balm50_7" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style21">
                    <asp:TextBox ID="txt_balm50_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator109" 
                        runat="server" ControlToValidate="txt_balm50_8" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style26">
                Swastha 30T</td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws30_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" 
                        runat="server" ControlToValidate="txt_sws30_1" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style51">
                    <asp:TextBox ID="txt_sws30_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server" 
                        ControlToValidate="txt_sws30_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws30_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator40" runat="server" 
                        ControlToValidate="txt_sws30_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws30_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator54" runat="server" 
                        ControlToValidate="txt_sws30_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws30_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator68" runat="server" 
                        ControlToValidate="txt_sws30_5" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws30_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator82" runat="server" 
                        ControlToValidate="txt_sws30_6" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws30_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator96" runat="server" 
                        ControlToValidate="txt_sws30_7" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws30_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator110" runat="server" 
                        ControlToValidate="txt_sws30_8" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style26">
                Swastha 60T</td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws60_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" 
                        runat="server" ControlToValidate="txt_sws60_1" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style51">
                    <asp:TextBox ID="txt_sws60_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" 
                        ControlToValidate="txt_sws60_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws60_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator41" runat="server" 
                        ControlToValidate="txt_sws60_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws60_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator55" runat="server" 
                        ControlToValidate="txt_sws60_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws60_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator69" runat="server" 
                        ControlToValidate="txt_sws60_5" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws60_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>   <asp:RegularExpressionValidator ID="RegularExpressionValidator83" runat="server" 
                        ControlToValidate="txt_sws60_6" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws60_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator97" runat="server" 
                        ControlToValidate="txt_sws60_7" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws60_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator111" runat="server" 
                        ControlToValidate="txt_sws60_8" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style26">
                Swastha 120T</td>
            <td class="style24">
                    <asp:TextBox ID="txt_sws120_1" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" 
                        runat="server" ControlToValidate="txt_sws120_1" ErrorMessage="Enter a number" 
                        ForeColor="Red" style="font-size: 12px" 
                        ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" ValidationGroup="num">*</asp:RegularExpressionValidator>
                </td>
            <td class="style51">
                 <asp:TextBox ID="txt_sws120_2" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server" 
                        ControlToValidate="txt_sws120_2" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator></td>
            <td class="style24">
                 <asp:TextBox ID="txt_sws120_3" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator42" runat="server" 
                        ControlToValidate="txt_sws120_3" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator></td>
            <td class="style24">
                 <asp:TextBox ID="txt_sws120_4" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="4"></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator56" runat="server" 
                        ControlToValidate="txt_sws120_4" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                    </td>
            <td class="style24">
                 <asp:TextBox ID="txt_sws120_5" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="5"></asp:TextBox>   <asp:RegularExpressionValidator ID="RegularExpressionValidator70" runat="server" 
                        ControlToValidate="txt_sws120_5" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator></td>
            <td class="style24">
                 <asp:TextBox ID="txt_sws120_6" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="6"></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator84" runat="server" 
                        ControlToValidate="txt_sws120_6" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator>
                    </td>
            <td class="style24">
                 <asp:TextBox ID="txt_sws120_7" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="7"></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator98" runat="server" 
                        ControlToValidate="txt_sws120_7" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator></td>
            <td class="style24">
                <asp:TextBox ID="txt_sws120_8" runat="server" CssClass="input-default" 
                    Width="74px" TabIndex="8"></asp:TextBox>   <asp:RegularExpressionValidator ID="RegularExpressionValidator112" runat="server" 
                        ControlToValidate="txt_sws120_8" ErrorMessage="Enter a number" ForeColor="Red" 
                        style="font-size: 12px" ValidationExpression="^([0-9]*)(\.[0-9]{0,2})?$" 
                        ValidationGroup="num">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td class="style55">
                Total</td>
            <td class="style53">
                    <asp:TextBox ID="txt_totalT1" runat="server" CssClass="input-total" 
                    Width="74px"></asp:TextBox>
                </td>
            <td class="style54">
                    <asp:TextBox ID="txt_totalT2" runat="server" CssClass="input-total" 
                    Width="74px" ReadOnly="True"></asp:TextBox>
                    </td>
            <td class="style53">
                    <asp:TextBox ID="txt_totalT3" runat="server" CssClass="input-total" 
                    Width="74px" ReadOnly="True"></asp:TextBox>
                    </td>
            <td class="style53">
                    <asp:TextBox ID="txt_totalT4" runat="server" CssClass="input-total" 
                    Width="74px" ReadOnly="True"></asp:TextBox>
                    </td>
            <td class="style53">
                    <asp:TextBox ID="txt_totalT5" runat="server" CssClass="input-total" 
                    Width="74px" ReadOnly="True"></asp:TextBox>
                    </td>
            <td class="style53">
                    <asp:TextBox ID="txt_totalT6" runat="server" CssClass="input-total" 
                    Width="74px" ReadOnly="True"></asp:TextBox>
                    </td>
            <td class="style53">
                    <asp:TextBox ID="txt_totalT7" runat="server" CssClass="input-total" 
                    Width="74px" ReadOnly="True"></asp:TextBox>
                    </td>
            <td class="style53">
                    <asp:TextBox ID="txt_totalT8" runat="server" CssClass="input-total" 
                    Width="74px" ReadOnly="True"></asp:TextBox>
                    </td>
        </tr>
          </table>
    </div>
    <div>
        <table class="style32">
            <tr>
                <td class="style27">
                    &nbsp;</td>
                <td class="style33">
                    <asp:Button ID="bttn_edit" runat="server" CssClass="ui-button" 
                        Text="Edit"  Width="80px" TabIndex="9" onclick="bttn_edit_Click" />
                 <asp:Button ID="bttn_confirm" runat="server" CssClass="ui-button" 
                     Text="Confirm" Width="80px"  TabIndex="11" onclick="bttn_confirm_Click"  />
                </td>
                <td>
                    &nbsp;</td>
                <td class="style34">
                    &nbsp;</td>
                <td class="style35">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style27">
                    &nbsp;</td>
                <td class="style33">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style34">
                    &nbsp;</td>
                <td class="style35">
                    &nbsp;</td>
            </tr>
        </table>
      </div>
    
</asp:Content>
