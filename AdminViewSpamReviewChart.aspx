<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewSpamReviewChart.aspx.cs" Inherits="AdminViewSpamReviewChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">





* { 
  margin: 0;
  padding: 0;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="80%">
        <tr>
            <th>
                <h1 style=" text-align :center ; line-height :50px; color :Maroon ; font-size :x-large ;">
                    Spam Review Chart</h1>
            </th>
        </tr>
        <tr>
            <td style="text-align :center ;">
                <b>
                <asp:Chart ID="Chart1" runat="server" BorderlineColor="DarkGreen" 
                    Height="417px" Palette="SemiTransparent" ViewStateContent="All" Width="614px">
                    <series>
                        <%--<asp:Series Name="LoginCount" YValueMembers="Expr1" Legend="Legend1"  
                ChartArea ="ChartArea1">
            </asp:Series>--%>
                        <asp:Series ChartArea="ChartArea1" Color="Blue" Legend="Legend1" Name="Count" 
                            YValueMembers="SCount">
                        </asp:Series>
                        <%--asp:Series ChartArea="ChartArea1" Name="SharedCount" YValueMembers="Expr4" 
                Legend="Legend1">
            </asp:Series>--%>
                    </series>
                    <chartareas>
                        <asp:ChartArea BackColor="HotPink" Name="ChartArea1">
                            <AxisY>
                                <MajorGrid LineColor="Transparent" />
                            </AxisY>
                            <AxisX>
                                <MajorGrid LineColor="Transparent" />
                            </AxisX>
                        </asp:ChartArea>
                    </chartareas>
                    <Legends>
                        <asp:Legend Name="Legend1" Title="Count">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Font="Microsoft Sans Serif, 15pt, style=Bold" Name="Spam Count" 
                            Text="Spam Count">
                        </asp:Title>
                    </Titles>
                    <BorderSkin BackColor="White" BorderColor="White" SkinStyle="Raised" />
                </asp:Chart>
                <br />
                <br />
               <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\ECSDB.mdf;Integrated Security=True;User Instance=True" 
                    
                    SelectCommand="SELECT        COUNT(*) AS Expr1
FROM            dstable
WHERE        (username='Diyaa')
UNION ALL
SELECT        COUNT(*) AS Expr1
FROM            logintable
WHERE        (username = 'Diyaa')
UNION ALL
SELECT        COUNT(*) AS Expr1
FROM            uploadtable
WHERE        (fileowner='Diyaa')" ProviderName="System.Data.SqlClient">--%>
                    <%--<SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="emailid" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>--%>
                </b>
            </td>
        </tr>
        <tr>
            <td style="text-align :center ;">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

