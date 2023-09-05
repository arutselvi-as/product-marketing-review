<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewUnpopularProducts.aspx.cs" Inherits="AdminViewUnpopularProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center" width ="70%">
<tr>
<th colspan ="2"><h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">Unpopular Products</h1></th>
</tr>
<tr>
<td style ="text-align :right ;">Select </td>
<td>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>Select</asp:ListItem>
        <asp:ListItem>Review</asp:ListItem>
        <asp:ListItem>Purchase</asp:ListItem>
        <asp:ListItem >Review-Purchase</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        EmptyDataText ="Record Not Found!!!" DataKeyNames ="pid" 
        onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black">
    <Columns >
    <asp:BoundField DataField ="pid" HeaderText ="Product ID"  />
    <asp:BoundField DataField ="cname" HeaderText ="Category Name"  />
    <asp:BoundField DataField ="pname" HeaderText ="Product Name"  />
    <asp:BoundField DataField ="bname" HeaderText ="Brand Name"  />
    <asp:BoundField DataField ="price" HeaderText ="Price"  />
    <asp:BoundField DataField ="description" HeaderText ="Description"  />
    <asp:BoundField DataField ="udate" HeaderText ="Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}"  />
    <asp:ImageField DataImageUrlField ="pimage" DataImageUrlFormatString ="PImage/{0}" HeaderText ="Image">
    <ControlStyle Width ="100" Height ="100" />
    </asp:ImageField>
    <asp:ButtonField Text ="Delete" HeaderText ="Delete" CommandName ="dd" ControlStyle-ForeColor ="Maroon"  />



    
    </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
</table>
</asp:Content>

