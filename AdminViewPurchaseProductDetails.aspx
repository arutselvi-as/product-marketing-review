<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewPurchaseProductDetails.aspx.cs" Inherits="AdminViewPurchaseProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="80%"  >
        <tr>
            <th>
                <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                    Purchased Product Details</h1>
            </th>
        </tr>
        <tr>
            <th>
                <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                    CellSpacing="2" ForeColor="Black" AutoGenerateColumns ="false"  EmptyDataText ="Record Not Found!!!">
                    <Columns >
                  <asp:BoundField DataField ="uname" HeaderText ="User Name" />
                  <asp:BoundField DataField ="pid" HeaderText ="Product ID" />
                  <asp:BoundField DataField ="price" HeaderText ="Price" />
                  <asp:BoundField DataField ="pdate" HeaderText ="Purchase Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
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
            </th>
        </tr>
        <tr>
            <th>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </th>
        </tr>
    </table>
</asp:Content>

