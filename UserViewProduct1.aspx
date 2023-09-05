<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserViewProduct1.aspx.cs" Inherits="UserViewProduct1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table border="0" width ="70%">
            <tr>
                <th>
               <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                       View Product</h1>
                </th>
            </tr>
            <tr><td style="text-align: center">
            <center>
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                    Height="50px" Width="287px" BackColor="#CCCCCC" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                    ForeColor="Black">
                    <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="Black" />
                    <Fields >
                    <asp:BoundField DataField ="cname" HeaderText ="Category Name" />
                        <asp:BoundField DataField ="pname" HeaderText ="Product Name" />
                           <asp:BoundField DataField ="bname" HeaderText ="Brand Name" />
                           <asp:ImageField DataImageUrlField ="pimage" DataImageUrlFormatString ="PImage/{0}" HeaderText ="Image">
                           <ControlStyle Width ="200" Height ="200" />
                           </asp:ImageField>
                                <asp:BoundField DataField ="price" HeaderText ="Price" />
                                    <asp:BoundField DataField ="description" HeaderText ="Description" />
                               <asp:HyperLinkField Text ="Confirm My Purchase" DataNavigateUrlFields ="pid,price" DataNavigateUrlFormatString ="Purchase.aspx?pid={0}&price={1}" ControlStyle-ForeColor ="Maroon"  />
                    </Fields>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="Black" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle Backcolor="white" />
                </asp:DetailsView>
                </center>
            </td></tr>
            <tr><td style="text-align: center">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                    ForeColor="Maroon">Related Review</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
                </td></tr>
            <tr><td style="text-align: center">
                <center>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
                        EmptyDataText="Record Not Found!!" Width="758px" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black" >
                <Columns >
           <asp:BoundField DataField ="uname" HeaderText ="User Name" />
              <asp:BoundField DataField ="srating" HeaderText ="Security Rating" />
                            <asp:BoundField DataField ="rrating" HeaderText ="Reliability Rating" />
                        <asp:BoundField DataField ="erating" HeaderText ="Economic Rating" />
                        <asp:BoundField DataField ="urating" HeaderText ="User Friendly Rating" />   </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle Backcolor="white" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="Black" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView></center>
            </td></tr>
            <tr><td style="text-align: center">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td></tr>
            </table> 
</asp:Content>

