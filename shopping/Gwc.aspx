<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gwc.aspx.cs" Inherits="shopping.Gwc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <!--
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1"
             OnRowCommand="GridView_OnRowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="pname" HeaderText="pname" SortExpression="pname" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:ButtonField HeaderText=""  ButtonType="Button" Text="删除"  CommandName="Bt_c" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:alimamaConnectionString %>" SelectCommand="SELECT [ID], [ProductID], [Price], [pname], [Quantity] FROM [OrderDetail] "></asp:SqlDataSource>
            -->
        <asp:Panel ID="Panel1" runat="server" Font-Size="XX-Large">
            购物车详情</asp:Panel>
        <br />
        <asp:GridView ID="GridView2" runat="server"  AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="GridView_OnRowCommand1">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="pname" HeaderText="pname" SortExpression="pname" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:ButtonField HeaderText=""  ButtonType="Button" Text="删除"  CommandName="Bt_c" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server" Text="合计："></asp:Label>
        <asp:Label ID="Label2" runat="server"></asp:Label>
          
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回购物页面" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="购买" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="合计"  Visible="false"/>


        
    </form>
</body>
</html>
