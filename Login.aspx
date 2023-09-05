<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table align="center" border="1" width="80%" >
        <tr>
            <th colspan="2">
               
              <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                     User
                     Login</h1>
             
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                UserName</td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" ></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Password</td>
            <td  style="text-align: left">
                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False" 
                    TextMode="Password" ></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
            
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    OnClick="LinkButton1_Click" ForeColor="Maroon">Login</asp:LinkButton>

                    <span style ="float :right ;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" 
                    NavigateUrl="~/NewRegistration.aspx" ForeColor="Maroon">New Registration</asp:HyperLink>
                    </span>
              
                </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label></td>
        </tr>
    </table><br /><br /><br /><br /><br />
</asp:Content>



