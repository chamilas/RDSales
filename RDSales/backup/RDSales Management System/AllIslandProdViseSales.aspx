<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AllIslandProdViseSales.aspx.cs" Inherits="RDSales_Management_System.AllIslandProdViseSales" %>
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
        .style4
        {
            width: 97px;
            font-size: 13px;
            font-weight: bold;
        }
        .style5
        {
            width: 395px;
        }
        .style6
        {
        }
        .style7
        {
            width: 195px;
            font-size: 12px;
        }
        
        
        </style>
        
         <script type="text/javascript">
             function PrintDivData(crtlid) {
                 var ctrlcontent = document.getElementById(crtlid);
                 var printscreen = window.open('', '', 'left=1,top=1,width=1250,height=800,toolbar=0,scrollbars=0,status=0​');
                 printscreen.document.write('<html><head><title>Print</title>');
                 printscreen.document.write('<style type="text/css"> .mGrid { width: 100%; background-color: #fff; margin: 5px 0 10px 0; border: solid 1px #525252; text-align: center;} .mGrid td { padding: 2px; border: solid 1px #c1c1c1; color: #5C5C5C; }</style>');
                 printscreen.document.write('</head><body >');

                 printscreen.document.write(ctrlcontent.innerHTML);
                 printscreen.document.write('</body></html>');
                 printscreen.document.close();
                 printscreen.focus();
                 printscreen.print();
                 printscreen.close();

                 return true;
             }
         
         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder5" runat="server"> All Island Product Vise Daily RD Sales
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="float: left; width: 60%;">
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
                Prooduct</td>
            <td class="style3">
                :</td>
            <td class="style5">
                <asp:TextBox ID="txt_product" runat="server" CssClass="input-default" 
                    Width="200px" AutoPostBack="True" ontextchanged="txt_product_TextChanged"></asp:TextBox>
                 <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                   CompletionInterval="10" CompletionSetCount="12" EnableCaching="true" 
                   MinimumPrefixLength="1" ServiceMethod="GetBasicProdctListOfRDsales" 
                   ServicePath="AutoComplete.asmx" TargetControlID="txt_product" 
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
                <asp:Button ID="bttn_print" runat="server" Text="Print" 
                    OnClientClick="javascript:PrintDivData('MainContent');" CssClass="Simbutton" 
                    Height="27px" Width="93px" />
            </td>
            <td class="style6" colspan="3">
                &nbsp;</td>
        </tr>
    </table>
    </div>
    <div style="float: left; width: 40%;">
                <asp:Accordion ID="Accordion1" runat="server" 
                    ContentCssClass="accordionContent" 
                    FadeTransitions="True" RequireOpenedPane="False" 
                    HeaderCssClass="accordionHeader" style="font-size: 12px">
                <Panes>
                <asp:AccordionPane runat ="server" ID="accPanel1">
                <Header></Header>
                <Content>
                    <asp:GridView ID="GridView5" runat="server" CssClass="mGrid" Font-Size="Smaller" OnRowDataBound="GridView5_RowDataBound">
                    
                    </asp:GridView>
                </Content>
                </asp:AccordionPane>
                </Panes>
                </asp:Accordion>
    </div>
    <div id = "MainContent" style="float: left; width: 100%;">

    <table class="style1">
        <tr>
            <td colspan="4" height="35px">
                <h1>
                    <asp:Label ID="lbl_header" runat="server" 
                        style="font-size: 14pt; color: #003366"></asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td width="37%">
                <asp:Label ID="lbl_prod1" runat="server" CssClass="style12" 
                    style="font-size: medium"></asp:Label>
            </td>
            <td width="21%">
                <asp:Label ID="lbl_prod2" runat="server" CssClass="style12" 
                    style="font-size: medium"></asp:Label>
            </td>
            <td width="21%">
                <asp:Label ID="lbl_prod3" runat="server" CssClass="style12" 
                    style="font-size: medium"></asp:Label>
            </td>
            <td width="21%">
                <asp:Label ID="lbl_prod4" runat="server" CssClass="style12" 
                    style="font-size: medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="38.5%">
                <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" 
                    onrowdatabound="GridView1_RowDataBound">
                </asp:GridView>
            </td>
            <td width="20.5%">
                <asp:GridView ID="GridView2" runat="server" CssClass="mGrid" 
                    onrowdatabound="GridView2_RowDataBound">
                </asp:GridView>
            </td>
            <td width="20.5%">
                <asp:GridView ID="GridView3" runat="server" CssClass="mGrid" 
                    onrowdatabound="GridView3_RowDataBound">
                </asp:GridView>
            </td>
            <td width="20.5%">
                <asp:GridView ID="GridView4" runat="server" CssClass="mGrid" 
                    onrowdatabound="GridView4_RowDataBound">
                </asp:GridView>
            </td>
        </tr>
    </table>

</div>

</asp:Content>
