<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewRegistration.aspx.cs" Inherits="NewRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><table border="1" width ="80%">
        <tr>
            <th colspan ="2">
                <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                    User Registration</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :right;">
                User Name</td>
            <td class="style1">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td style ="text-align :right;">
                Email Address</td>
            <td class="style1">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Mobile Number</td>
            <td class="style1">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Address</td>
            <td class="style1">
                <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Gender</td>
            <td class="style1">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Pincode</td>
            <td class="style1">
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Select Profile Picture</td>
            <td class="style1">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click" 
                    ForeColor="Maroon">View</asp:LinkButton>
                <br />
                <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
                <br />
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
        </tr>
         <tr>
            <td style ="text-align :right;">
                Password</td>
            <td class="style1">
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                    ForeColor="Maroon">Insert</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
                    ForeColor="Maroon">Clear</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table></center>
</asp:Content>

