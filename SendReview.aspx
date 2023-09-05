<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SendReview.aspx.cs" Inherits="SendReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" align ="center" width ="80%">
        <tr>
            <th colspan ="2">
                <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                    Send Review</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :right;">
                User Name</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Product ID</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Review Date</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td style ="text-align :right;" >
                Security Rating</td>
            <td >
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;" >
                Reliability Rating</td>
            <td >
                <asp:DropDownList ID="DropDownList2" runat="server">
                 <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td style ="text-align :right;" >
                Economic Rating</td>
            <td >
                <asp:DropDownList ID="DropDownList3" runat="server">
                 <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td style ="text-align :right;" >
                User Friendly Rating</td>
            <td >
                <asp:DropDownList ID="DropDownList4" runat="server">
                 <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
               </td>
        </tr>
        <tr>
            <td style ="text-align :center;" colspan="2">
&nbsp;&nbsp;<asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click" 
                    ForeColor="Maroon">Send</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click" 
                    ForeColor="Maroon">Clear</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

