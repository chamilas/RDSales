 <%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeFile="RDSales_Edit_Target.aspx.cs" Inherits="RDSales_Management_System.RDSales_Edit_Target" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<script runat="server">

</script>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 26px;
        }
        .style3
        {
            width: 28px;
        }
        .style4
        {
            width: 49px;
        }
    </style>
    </asp:Content>--%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">    Daily RD Sales
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  
  <div>
      
  <table style="height: 80px; width: 817px;">
  <tr>
      <td ><asp:Label ID="lblRegion" runat="server" Text="Region"></asp:Label></td>
      <td class="style2"><asp:TextBox ID="txt_region" runat="server" Height="20px" Width="75px"></asp:TextBox></td>
      <td colspan="3"></td>
      <td rowspan="6">&nbsp;</td>
  </tr>
  <tr>
      <td><asp:Label ID="Label3" runat="server" Text="Territory"></asp:Label></td>
      <td>
          <asp:DropDownList ID="cmbTerritories" runat="server" Width="282px" 
              DataTextField="Name" DataValueField="TerritoryID" 
              onselectedindexchanged="cmbTerritories_SelectedIndexChanged" Height="28px"></asp:DropDownList></td>
              <td colspan="3"></td>
  </tr>
  <tr>
      <td><asp:Label ID="Label4" runat="server" Text="Date"></asp:Label></td>
      <td class="style2">
          <asp:Calendar ID="clnDate" runat="server" Height="107px" Width="147px">
          </asp:Calendar>
       </td>
      <td class="style1" colspan="3">
           <asp:GridView ID="dgvRegionSummary" runat="server" Height="224px" 
              style="margin-left: 0px" EnableViewState="True" Width="182px"></asp:GridView></td>
  
  </tr>
  
  <tr>
  <td colspan="5">&nbsp;</td>
  </tr>

  <tr>
      <td >Total (Rs.)</td>
      <td class="style2" >
          <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
      </td>
      <td>
           <asp:Button ID="btnView" runat="server" onclick="btnView_Click" Text="View" 
              Width="114px" Height="28px"/>
         </td>

              <td><asp:Button ID="btnUpdate" runat="server" 
               onclick="btnUpdate_Click" Text="Save" Height="28px" Width="113px" />
              </td>

              <td>  <asp:Button ID="btnConfirm" runat="server" Height="28px" 
              Text="Confirm" Width="104px" onclick="btnConfirm_Click" /></td>
  </tr>
  
  <tr>
      <td colspan="5">&nbsp;</td>
  </tr>
  
  <tr><td colspan="5"><br/></td></tr>
  <tr><td colspan="5"><br/></td></tr>

       </table>
  </div>

  <div>
  
    <asp:GridView ID="dvRDSales" runat="server" AutoGenerateColumns="False"
BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
CellPadding="3" DataKeyNames="ProductCode" Width="822px" Height="100px" 
          style="margin-top: 0px" >
<FooterStyle BackColor="White" ForeColor="#000066" />
<Columns>
<asp:BoundField DataField="ProductCode" HeaderText="ProductCode" 
        InsertVisible="False" ReadOnly="True" Visible="True"
SortExpression="ProductCode" />

<asp:BoundField DataField="ProductName" HeaderText="ProductName" 
        InsertVisible="False" ReadOnly="True"
SortExpression="ProductName" />

<asp:TemplateField HeaderText="Target" SortExpression="Target">
<ItemTemplate>
<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Target") %>'
 BorderStyle="None"></asp:TextBox>

</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="SubTotal(Rs.)" SortExpression="Value">
<ItemTemplate>
<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Value") %>'
 BorderStyle="None" ReadOnly="True"></asp:TextBox>

</ItemTemplate>
</asp:TemplateField>

</Columns>
<RowStyle ForeColor="#000066" />
<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
<PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
<HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
</asp:GridView>
    </div>

    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</asp:Content>
 <asp:Content ID="Content5" runat="server" contentplaceholderid="head">
     <style type="text/css">
         .style1
         {
             width: 355px;
         }
         .style2
         {
             width: 356px;
         }
     </style>
 </asp:Content>
