<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="shoppings.aspx.cs" Inherits="shopping.shoppings" %>

<!DOCTYPE html>
<script src="JS/jquery-3.1.1.slim.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 </head>
   <body>
        <form id="form1" runat="server">
        <div id="des">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="注销" />
            <br />
            <asp:Button ID="Button1" runat="server" Height="60px" Text="电脑" Width="129px" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Height="60px" Text="手机" Width="129px" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Height="60px" Text="食品" Width="129px" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Height="60px" Text="衣服" Width="129px" OnClick="Button4_Click" />
            <asp:Button ID="Button5" runat="server" Height="60px" Text="首页" Width="129px" OnClick="Button5_Click" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" Height="186px" Width="468px" AllowPaging="True" PageSize="5"  
                   OnRowCommand="GridView_OnRowCommand">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:TemplateField HeaderText="下拉框">
                        <ItemTemplate>
                            <asp:DropDownList ID="CallInIdSelControl" runat="server" Visible="true" >
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField HeaderText=""  ButtonType="Button" Text="加入购物车"  CommandName="Bt_c" />
                </Columns>
            </asp:GridView>
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:alimamaConnectionString %>" 
                SelectCommand="SELECT [ID], [Title], [Price], [CategoryID] FROM [Product] "></asp:SqlDataSource>
            <p>
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="购物车" />
            </p>
        </form>

     
</body>
</html>
