<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewAccount.aspx.cs" Inherits="ViewAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><table border="1" style ="font-weight :normal ;" width="80%">
        <tr>
            <th >
                 
<h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                        &nbsp;My Account</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :center ;">
                <asp:DetailsView ID="DetailsView1" runat="server" Height="112px" Width="262px" 
                    AutoGenerateRows ="False" BackColor="#CCCCCC" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                    ForeColor="Black" >
                    <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="Black" />
                <Fields >
                <asp:BoundField DataField ="uname" HeaderText ="UserName" />
                <asp:BoundField DataField ="accno" HeaderText ="AccountNo" />
                <asp:BoundField DataField ="bname" HeaderText ="BankName" />
                <asp:BoundField DataField ="amount" HeaderText ="Amount" />
                <asp:BoundField DataField ="emailid" HeaderText ="EMailID" />
                <asp:BoundField DataField ="mnumber" HeaderText ="MobileNo" />
                <asp:BoundField DataField ="gender" HeaderText ="Gender" />
                </Fields>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="Black" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle Backcolor="white" />
                </asp:DetailsView>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table></center>
</asp:Content>

