<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewAllCategory.aspx.cs" Inherits="AdminViewAllCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="80%"  >
        <tr>
            <th>
              <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                    View
                    Category Details</h1>
            </th>
        </tr>
        <tr>
            <th>
                <center>
                    <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False" PageSize="5" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black" EmptyDataText="Record Not Found" 
                        Width="404px">
                        <Columns >
                            <asp:BoundField DataField ="cname" HeaderText ="Category Name" />
                           
                           
                        </Columns>
                        <EmptyDataRowStyle Font-Size="XX-Large" />
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
                </center>
            </th>
        </tr>
        <tr>
            <th>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </th>
        </tr>
    </table>
</asp:Content>

