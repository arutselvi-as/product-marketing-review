<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewSpamReviewer.aspx.cs" Inherits="AdminViewSpamReviewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="80%"  >
        <tr>
            <th>
                <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                    Spam Reviewer</h1>
            </th>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                    CellSpacing="2" ForeColor="Black" AutoGenerateColumns ="false"  EmptyDataText ="Record Not Found!!!">
                    <Columns >
                    <asp:BoundField DataField ="uname" HeaderText ="User Name" />
                    <asp:BoundField DataField ="pid" HeaderText ="Product ID" />
                    <asp:BoundField DataField ="srating" HeaderText ="Security Rating" />
                    <asp:BoundField DataField ="rrating" HeaderText ="Reliability Rating" />
                    <asp:BoundField DataField ="erating" HeaderText ="Economic Rating" />
                    <asp:BoundField DataField ="urating" HeaderText ="User Friendly Rating" />
                    
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
            <td style="text-align :center ;">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" ForeColor ="Maroon" >Delete Spammer</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" ForeColor ="Maroon" >Delete Spammer and Review</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </th>
        </tr>
    </table>
</asp:Content>

