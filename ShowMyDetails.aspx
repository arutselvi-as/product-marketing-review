<%@ Page Language="C#"  
 MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowMyDetails.aspx.cs" Inherits="ShowMyDetails" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table align="center" border="1"  width ="80%">
        <tr>
            <th >
               
             <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                    View Profile</h1>
                             
            </th>
        </tr>
        <tr>
            <td  style=" text-align: center">
                    <asp:DetailsView ID="DetailsView1" runat="server" Height="167px" 
                        Width="269px" AutoGenerateRows ="False" BackColor="#CCCCCC" 
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
                </asp:DetailsView>
            </td>
        </tr>
        <tr>
            <td  style="text-align: center">
               <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label></td>
        </tr>
    </table><br /><br /><br /><br /><br />
</asp:Content>




