<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewUserStatus.aspx.cs" Inherits="AdminViewUserStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br />
    <table align="center" border="1" width="80%"  >
        <tr>
            <th colspan ="2">
                <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                    View
                    User Status</h1>
            </th>
        </tr>
        <tr>
            <th colspan ="2">
                <center>
                    <asp:DetailsView ID="DetailsView1" runat="server" Height="138px" 
                        Width="273px" AutoGenerateRows ="False" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black" >
                    <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="Black" />
                <Fields >
                
                <asp:BoundField DataField ="uname" HeaderText ="UserName" />
                <asp:BoundField DataField ="emailid" HeaderText ="EMailID" />
                <asp:BoundField DataField ="mnumber" HeaderText ="MobileNo" />
                <asp:BoundField DataField ="address" HeaderText ="Address" />
               
                   <asp:BoundField DataField ="gender" HeaderText ="Gender" />
               <asp:BoundField DataField ="pincode" HeaderText ="PinCode" />
                            <asp:ImageField DataImageUrlField ="uimage" HeaderText ="Profile Photo" DataImageUrlFormatString ="UImage/{0}">
                    <ControlStyle Width ="100" Height ="100" />
                    </asp:ImageField>
                </Fields>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="Black" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle HorizontalAlign="Left" Backcolor="white" />
                </asp:DetailsView></center>
            </th>
        </tr>
        <tr>
        <td style ="text-align :right ;">Status
        </td> 
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" 
                AutoPostBack="True" 
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem>Accept</asp:ListItem>
                <asp:ListItem>Reject</asp:ListItem>
            </asp:RadioButtonList>
            </td>
        </tr>

        <tr>
            <td colspan ="2" style ="text-align :center ;">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

