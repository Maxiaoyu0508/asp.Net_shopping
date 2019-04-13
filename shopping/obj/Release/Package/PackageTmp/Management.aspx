<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Management.aspx.cs" Inherits="shopping.Management" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>
        
    </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Font-Size="XX-Large" Width="959px">
            管理员界面&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="注销" CausesValidation="False" />
            <asp:Button ID="Button3" runat="server" CausesValidation="False" OnClick="Button3_Click" style="height: 21px" Text="大文件上传" />
        </asp:Panel>
    </div>
        <div>
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                 OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" >
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="商品ID "  ReadOnly="True"/>
                <asp:BoundField DataField="Title" HeaderText="商品名 " />
                <asp:BoundField DataField="Price" HeaderText="商品价格 " />
                <asp:BoundField DataField="Num" HeaderText="商品数量 " />
                <asp:CommandField HeaderText="选择" ShowSelectButton="True" />
                <asp:CommandField HeaderText="编辑" ShowEditButton="True"   CausesValidation="false"/>
                 <asp:TemplateField HeaderText="删除 " ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="删除" OnClientClick="return confirm('你确定要删除吗？')"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                 <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>
        <asp:Panel ID="Panel2" runat="server">
            1.添加/修改商品信息</asp:Panel>
                    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true"  UpdateMode="Always">
                    <ContentTemplate>
            商品ID:<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="ID_ch" AutoPostBack="true"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                        
                        <br />
                        <br />
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TextBox1" />
                    </Triggers> 
                    </asp:UpdatePanel>
            
            商品名:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="Validator2" ControlToValidate="TextBox2" SetFocusOnError="true" Display="Dynamic"
        ErrorMessage="商品名必须输入"  EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        <br />
            商品价格:<asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="Validator3" ControlToValidate="TextBox3" SetFocusOnError="true" Display="Dynamic"
        ErrorMessage="商品价格必须输入"  EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        <br />
            商品数量:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="Validator4" ControlToValidate="TextBox4" SetFocusOnError="true" Display="Dynamic"
        ErrorMessage="商品数量必须输入"  EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator>
        
        <br />
        
        <p>
            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
        </p>

    </form>
</body>
</html>
