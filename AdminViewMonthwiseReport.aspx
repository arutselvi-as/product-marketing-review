<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewMonthwiseReport.aspx.cs" Inherits="AdminViewMonthwiseReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="80%"  >
        <tr>
            <th colspan ="2">
                <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                    Monthwise Purchased Product Details</h1>
            </th>
        </tr>
        <tr>
        <td style ="text-align :right ;">Select Month</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="94px"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem Value="1">Jan</asp:ListItem>
                <asp:ListItem Value="2">Feb</asp:ListItem>
                <asp:ListItem Value="3">Mar</asp:ListItem>
                <asp:ListItem Value="4">Apr</asp:ListItem>
                <asp:ListItem Value="5">May</asp:ListItem>
                <asp:ListItem Value="6">Jun</asp:ListItem>
                <asp:ListItem Value="7">Jul</asp:ListItem>
                <asp:ListItem Value="8">Aug</asp:ListItem>
                <asp:ListItem Value="9">Sep</asp:ListItem>
                <asp:ListItem Value="10">Oct</asp:ListItem>
                <asp:ListItem Value="11">Nov</asp:ListItem>
                <asp:ListItem Value="12">Dec</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th colspan ="2">
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
            <th colspan ="2" style ="text-align :center ;">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </th>
        </tr>
    </table>

</asp:Content>

