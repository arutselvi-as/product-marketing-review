<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TopKRankingProducts.aspx.cs" Inherits="TopKRankingProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table border="0" width ="80%">
            <tr>
                <th colspan ="2">
                  <h1  style =" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                        Top K Ranking Products</h1>
                </th>
            </tr>
            <tr>
                <td style ="text-align :right ;">
                    Category Name</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan ="2">
                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" 
            RepeatDirection="Horizontal" Width="875px" Height="452px" >
                        <ItemTemplate>
                            <table align="center" cellspacing="10" border="0">
                                <tr>
                                    <td rowspan="6">
                                        <img src='<%#Eval("pimage")%>' width="150" height="150"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <font color="red"><%#Eval("BName")%></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <font color="Green">
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("PName")%>'></asp:Label>
                                        </font>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <font color="Blue">Rs. 
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
                                        </font>
                                    </td>
                                </tr>
                                <tr><td><font color="Maroon">Rating :</font>
                                <img  src ='<%#Eval("img1")%>' id="i1" runat ="server"    />
                                 
                                </td>
                                </tr>
                                
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
            <tr>
                <td colspan ="2" style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

