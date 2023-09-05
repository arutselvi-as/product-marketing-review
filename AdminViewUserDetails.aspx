<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewUserDetails.aspx.cs" Inherits="AdminViewUserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br /><br />
<table align="center" border="1" width="80%"  >
        <tr>
            <th>
               
                  <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                    View
                    User Details</h1>
            
            </th>
        </tr>
        <tr>
            <th>
                
                <center>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" PageSize="5" DataKeyNames="uname" 
                        onpageindexchanging="GridView1_PageIndexChanging" 
                        onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black" EmptyDataText="Record Not Found" 
                        Width="522px">
                    <Columns >
                    <asp:BoundField DataField ="uname" HeaderText ="UserName" />
                    <asp:ImageField DataImageUrlField ="uimage" HeaderText ="Profile Photo" DataImageUrlFormatString ="UImage/{0}">
                    <ControlStyle Width ="100" Height ="100" />
                    </asp:ImageField>
                    <asp:ButtonField Text ="ViewStatus" HeaderText ="Status" CommandName ="ss" 
                            ItemStyle-ForeColor ="#516C00" >
<ItemStyle ForeColor="Maroon"></ItemStyle>
                        </asp:ButtonField>
                    </Columns>
                        <EmptyDataRowStyle Font-Size="XX-Large" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="Black" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle Backcolor="white" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="Black" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView></center>
            
            </th>
        </tr>
        <tr>
            <th>
                
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            
            </th>
        </tr>
        </table> 
</asp:Content>

