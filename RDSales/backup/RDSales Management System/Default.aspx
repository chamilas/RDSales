<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RDSales_Management_System.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<link href="main.css" rel="stylesheet" type="text/css" />
<title>Login Box HTML Code - www.PSDGraphics.com</title>

<%--<link href="login-box.css" rel="stylesheet" type="text/css" />--%>
    <style type="text/css">
        .input-default
        {
            border: 1px solid #EDDEC5;
            padding: 4px;
            font-size: 1.0em;
            width: 150px;
        }
        .txtcss
        {}
        .newStyle1
        {
            background-image: url('images/leaves2.png');
        }
        .style2
        {
            font-size: 9pt;
            color: #333333;
            width: 100px;
            height: 2px;
            font-family: "Trebuchet MS";
            font-weight: bold;
        }
        .style4
        {
            border: 1px solid #EDDEC5;
            padding: 4px;
            font-size: small;
            width: 150px;
        }
        .style5
        {
            font-family: "Trebuchet MS";
            font-size: 9pt;
            color: #333333;
        }
        .style6
        {
            color: #333333;
            font-family: "Trebuchet MS";
            font-size: 18px;
        }
        #layer_ins_login1
        {
            text-align: center;
        }
        .style8
        {
            text-align: center;
            font-family: "Trebuchet MS";
            font-weight: 700;
            font-size: small;
        }
        .style9
        {
            color: #003366;
        }
        .style11
        {
            font-family: "Trebuchet MS";
            font-size: 9pt;
            color: #333333;
            width: 100px;
            font-weight: bold;
        }
        .style12
        {
            width: 100px;
            height: 2px;
            color: #333333;
        }
        .style13
        {
            width: 100px;
            color: #333333;
        }
        .style14
        {
            font-size: 9pt;
            font-weight: bold;
        }
      
        .loginbody
        {
            background-image: url('images/LinkBG_BW.png');
            background-repeat: no-repeat;
            
        }
    </style>
</head>


<body class = "loginbody">
    <form id="form1" runat="server">
    <div style="border: thin ridge #C0C0C0; margin-left:auto; margin-right:auto; width:641px; height:253px; margin-top:150px;background-image:url; background-repeat:no-repeat; background-position:50% top; ">
        <div style="background-position: right top; width:380px; height:250px; float:left; background-image: none; background-color: #F7F7F7; color: #EEEEEE;">
        <div style="width:300px;height:250px;margin-left:auto;margin-right:auto;margin-top:20px;">
            <table border="0" cellpadding="2" cellspacing="0">
                <tr>
                    <td colspan="3" style="font-weight:bold;" class="style6">
                        Link Natural Products (Pvt) Ltd.</td>
                </tr>
                <tr>
                    <td colspan="3">
                    <div style="width:100%;border-top:1px dotted gray;"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div id="layer_ins_login1" >
                        <br />
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo_gif.gif" 
                                Height="84px" Width="123px" />
                        </div>
                        <div class="style8">
                        <br />
                      
                            <span class="style9">RD SALES MANAGEMENT SYSTEM</span><br />
                        </div>
                        <div id="layer_ins_login3">
                            </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        &nbsp;</td>
                    <td colspan="2" align="right" valign="baseline">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        </div>
        <div style="width:261px; height:250px;float:right; ">
            <div style="width: 230px; height: 250px; margin-top:20px;margin-left:auto;margin-right:auto;">
                <table border="0" cellpadding="2" style="color: #3399FF">
                    <tr>
                        <td colspan="3">
                            <div style="width:100%;border-top:1px dotted gray;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td 
                            class="style2">
                            Username</td>
                        <td class="style12">
                            :<span class="style14"></span></span></td>
                        <td style="width: 100px; height: 2px">
                            <asp:TextBox ID="txt_username" runat="server" CssClass="style4" Height="20px" 
                                Width="140px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="style11">
                            Password</td>
                        <td class="style13">
                            :<span class="style14"></span></span></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txt_password" runat="server" CssClass="style4" 
                                TextMode="Password" Height="20px" Width="140px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 17px">
                        </td>
                        <td style="width: 100px; height: 17px">
                        </td>
                        <td style="width: 100px; height: 17px">
                              <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/images/login-btn1.png" onclick="ImageButton1_Click" Width="100px" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 17px">
                        </td>
                        <td style="width: 100px; height: 17px">
                        </td>
                        <td style="width: 100px; height: 17px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" class="style5" title="::: Welcome to Helitours LK :::"
                                        valign="bottom">
                                            Enter your username and password to login.</td>
                                </tr>
                                <tr>
                                    <td align="left" class="body-text" height="20" valign="bottom">
                                    </td>
                                </tr>
                            </table>
                            <div style="width:100%;border-top:1px dotted gray;">
                            <span id="spnMsg" runat="server"></span>
                                &nbsp;</div>
                        </td>
                    </tr>
                    </table>
                </div>
            
            
        </div>
        </div><div style="width: 640px; height: 50px; margin-top: 2px; margin-left: auto; margin-right: auto;color:Gray;text-align:right; " >
          
                        <asp:Label ID="lbl_status" runat="server" style="font-size: small"></asp:Label>
          
        </div>
    </form>
</body>
</html>
