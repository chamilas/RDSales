 <%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeFile="RDSales_Data.aspx.cs" Inherits="RDSales_Management_System.RDSales_Data" %>
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
      <td class="style3"><asp:TextBox ID="txt_region" runat="server" Height="20px" Width="75px"></asp:TextBox></td>
      <td colspan="2"></td>
      <td rowspan="6"><asp:GridView ID="dgvRegionSummary" runat="server" Height="224px" 
              style="margin-left: 0px" EnableViewState="True" Width="182px"></asp:GridView></td>
  </tr>
  <tr>
      <td><asp:Label ID="Label3" runat="server" Text="Territory"></asp:Label></td>
      <td colspan="3">
          <asp:DropDownList ID="cmbTerritories" runat="server" Width="512px" 
              DataTextField="Name" DataValueField="TerritoryID" 
              onselectedindexchanged="cmbTerritories_SelectedIndexChanged" Height="30px"></asp:DropDownList></td>
  </tr>
  <tr>
      <td><asp:Label ID="Label4" runat="server" Text="Date"></asp:Label></td>
      <td class="style3"><asp:DropDownList ID="cmbYear" runat="server" Height="30px" Width="80px" onselectedindexchanged="cmbYear_SelectedIndexChanged">
               <asp:ListItem Value="2010"></asp:ListItem>
               <asp:ListItem Value="2011"></asp:ListItem>
               <asp:ListItem Value="2012"></asp:ListItem>
               <asp:ListItem Value="2013"></asp:ListItem>
               <asp:ListItem Value="2014"></asp:ListItem>
               <asp:ListItem Value="2015"></asp:ListItem>
               <asp:ListItem Value="2016"></asp:ListItem>
               <asp:ListItem Value="2017"></asp:ListItem>
               <asp:ListItem Value="2018"></asp:ListItem>
               <asp:ListItem Value="2019"></asp:ListItem>
               <asp:ListItem Value="2020"></asp:ListItem>
           </asp:DropDownList>
       </td>
      <td class="style1">
           <asp:DropDownList ID="cmbMonth" runat="server" Height="30px" Width="327px"   AutoPostBack="true"
               onselectedindexchanged="cmbMonth_SelectedIndexChanged">
               <asp:ListItem Value="1">January</asp:ListItem>
               <asp:ListItem Value="2">February</asp:ListItem>
               <asp:ListItem Value="3">March</asp:ListItem>
               <asp:ListItem Value="4">April</asp:ListItem>
               <asp:ListItem Value="5">May</asp:ListItem>
               <asp:ListItem Value="6">June</asp:ListItem>
               <asp:ListItem Value="7">July</asp:ListItem>
               <asp:ListItem Value="8">August</asp:ListItem>
               <asp:ListItem Value="9">September</asp:ListItem>
               <asp:ListItem Value="10">October</asp:ListItem>
               <asp:ListItem Value="11">November</asp:ListItem>
               <asp:ListItem Value="12">December</asp:ListItem>
           </asp:DropDownList>
       </td>
      <td class="style2">
           <asp:DropDownList ID="cmbDay" runat="server" Height="30px" Width="75px" AutoPostBack="true"
           onselectedindexchanged="cmbDay_SelectedIndexChanged" 
          >
           <asp:ListItem Value="1"></asp:ListItem>
           <asp:ListItem Value="2"></asp:ListItem>
           <asp:ListItem Value="3"></asp:ListItem>
           <asp:ListItem Value="4"></asp:ListItem>
           <asp:ListItem Value="5"></asp:ListItem>
           <asp:ListItem Value="6"></asp:ListItem>
           <asp:ListItem Value="7"></asp:ListItem>
           <asp:ListItem Value="8"></asp:ListItem>
           <asp:ListItem Value="9"></asp:ListItem>
           <asp:ListItem Value="10"></asp:ListItem>
           <asp:ListItem Value="11"></asp:ListItem>
           <asp:ListItem Value="12"></asp:ListItem>
           <asp:ListItem Value="13"></asp:ListItem>
           <asp:ListItem Value="14"></asp:ListItem>
           <asp:ListItem Value="15"></asp:ListItem>
           <asp:ListItem Value="16"></asp:ListItem>
           <asp:ListItem Value="17"></asp:ListItem>
           <asp:ListItem Value="18"></asp:ListItem>
           <asp:ListItem Value="19"></asp:ListItem>
           <asp:ListItem Value="20"></asp:ListItem>
           <asp:ListItem Value="21"></asp:ListItem>
           <asp:ListItem Value="22"></asp:ListItem>
           <asp:ListItem Value="23"></asp:ListItem>
           <asp:ListItem Value="24"></asp:ListItem>
           <asp:ListItem Value="25"></asp:ListItem>
           <asp:ListItem Value="26"></asp:ListItem>
           <asp:ListItem Value="27"></asp:ListItem>
           <asp:ListItem Value="28"></asp:ListItem>
           <asp:ListItem Value="29"></asp:ListItem>
           <asp:ListItem Value="30"></asp:ListItem>
           <asp:ListItem Value="31"></asp:ListItem>
       </asp:DropDownList>
       </td>
  
  </tr>
  
  <tr>
  <td >Total PC</td>
  <td class="style3" ><asp:TextBox ID="txtTotalPC" runat="server" Height="20px" Width="75px"></asp:TextBox></td>
  <td colspan="2" ></td>
  
  <tr>
      <td ><asp:Label ID="Label5" runat="server" Text="Day No"></asp:Label></td>
      <td class="style3" ><asp:TextBox ID="txt_DayNo" runat="server" Height="20px" Width="75px"></asp:TextBox></td>
      <td colspan="2" ></td>
  </tr>
  
  <tr>
      <td ><asp:Button ID="btnView" runat="server" onclick="btnView_Click" Text="View" 
              Width="85px" Height="28px"/></td>
      <td class="style3" ><asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" Text="Save" Height="28px" Width="75px" /></td>
      <td colspan="2"><asp:Button ID="btnConfirm" runat="server" Height="28px" 
              Text="Confirm" Width="82px" onclick="btnConfirm_Click" /></td>
  </tr>
  
  <tr><td colspan="5"><br/></td></tr>
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

<asp:TemplateField HeaderText="Achievement" SortExpression="Achievement">
<ItemTemplate>
<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Acheivement") %>'
 BorderStyle="None"></asp:TextBox>

</ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="Brand" HeaderText="Brand" 
        InsertVisible="False" ReadOnly="True"
SortExpression="Brand" />

<asp:TemplateField HeaderText="PC" SortExpression="PC">
<ItemTemplate>
<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PC") %>'
 BorderStyle="None"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="PC New" SortExpression="PC_New">
<ItemTemplate>
<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PC_New") %>'
 BorderStyle="None"></asp:TextBox>
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
             width: 333px;
         }
         .style2
         {
             width: 74px;
         }
     </style>
 </asp:Content>
