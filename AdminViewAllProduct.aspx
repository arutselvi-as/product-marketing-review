<%@ Page Language="C#" MasterPageFile ="~/MasterPage.master"  AutoEventWireup="true" CodeFile="AdminViewAllProduct.aspx.cs" Inherits="AdminViewAllProduct" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" width ="80%">
    <tr><th colspan ="2">   <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">List of Products</h1></th></tr>
    <tr><td style ="text-align :right ;">Category Name</td><td>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        </td></tr>
    <tr><td colspan ="2">
   <center> <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" 
            RepeatDirection="Horizontal" Width="642px" Height="452px" 
            >
    <ItemTemplate>
    <table align="center" cellspacing="10" border="0">
    <tr><td rowspan="6"><img src='<%#Eval("pimage")%>' width="150" height="150"/></td></tr>
    <tr><td><font color="red"><%#Eval("BName")%></font></td></tr>
   
    <tr><td><font color="green" ><asp:Label ID="Label4" runat="server" Text='<%#Eval("PName")%>'></asp:Label></font></td></tr>
    <tr><td><font color="blue"><%#Eval("Description")%></font></td></tr>
    <tr><td><font color="Maroon">Rs. <asp:Label ID="Label1" runat="server" Text='<%#Eval("Price")%>'></asp:Label></font></td></tr>
    <tr><td><font color="purple" ><asp:Label ID="Label2" runat="server" Text='<%#Eval("udate","{0:dd-MMM-yyyy}") %>'></asp:Label></font></td></tr>
    
    </table>
    
    </ItemTemplate>
    
    

    </asp:DataList></center>
        </td></tr>
    <tr><td colspan ="2" style="text-align: center">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td></tr>
    </table>
    </asp:Content>
   
    

