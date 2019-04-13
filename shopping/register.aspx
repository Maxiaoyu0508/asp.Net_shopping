<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="shopping.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
</head>
<body  >

<form id="form1" runat="server" >
<p>
        <asp:Panel ID="Panel1" runat="server" Font-Size="XX-Large">
            AIMAMA购物网站用户注册</asp:Panel>
    </p>
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true"  UpdateMode="Always">
        <ContentTemplate>
用户名：<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="name_ch" AutoPostBack="true"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="TextBox1" />
        </Triggers> 
        </asp:UpdatePanel>
<p>
    密码&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server" 
        TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="Validator2" runat="server" 
        ControlToValidate="TextBox2" SetFocusOnError="true" Display="Dynamic"
        ErrorMessage="密码必须输入" ForeColor="Red" EnableClientScript="true"></asp:RequiredFieldValidator>
    
</p>
<p>
    确认密码<asp:TextBox ID="TextBox3" runat="server" 
            TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Validator3" runat="server" 
            ControlToValidate="TextBox3" SetFocusOnError="true" Display="Dynamic"
            ErrorMessage="确认密码必须输入" ForeColor="Red" EnableClientScript="true"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="Validator4" runat="server"
            ControlToValidate="TextBox3" ControlToCompare="TextBox2" Type="String" Operator="Equal"  Display="static"
            ErrorMessage="确认密码必须密码一致" EnableClientScript="true" ForeColor="Red">
            </asp:CompareValidator>
</p>
<p>
电话号码<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="Validator7" runat="server" ControlToValidate="TextBox5" 
         ValidationExpression="0\d{3}-\d{8}" Display="Dynamic"   ErrorMessage="格式错误！" EnableClientScript="true" ForeColor="Red"></asp:RegularExpressionValidator>
</p>
<p>
    邮箱&nbsp;&nbsp; <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="Validator6" runat="server" 
        ControlToValidate="TextBox6" SetFocusOnError="true" Display="static"
        ErrorMessage="邮箱必须输入" ForeColor="Red" EnableClientScript="true"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="Validator8" runat="server" ControlToValidate="TextBox6"  
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"  EnableClientScript="true" ForeColor="Red" ErrorMessage="请输入合法的邮箱地址"></asp:RegularExpressionValidator>
</p>
<p>
        地址：&nbsp; <asp:TextBox ID="TextBox8" runat="server" Width="373px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox8" SetFocusOnError="true" Display="static"
        ErrorMessage="地址必须输入" ForeColor="Red" EnableClientScript="true"></asp:RequiredFieldValidator>
</p>
<p>
邮编：&nbsp; <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
       ControlToValidate="TextBox7" SetFocusOnError="true" Display="static"
       ErrorMessage="邮箱必须输入" ForeColor="Red" EnableClientScript="true"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ID="Validator71" runat="server" ControlToValidate="TextBox7" 
      ValidationExpression  ="\d{6}" Display="Dynamic"   ErrorMessage="格式错误！" ForeColor="Red" EnableClientScript="true"></asp:RegularExpressionValidator>
</p>
    <p>
        &nbsp;</p>
    <asp:Panel ID="Panel2" runat="server" Font-Size="Smaller">
        *以上内容都需要输入</asp:Panel>
<p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="Button2" runat="server" Text="注册" onclick="Button2_Click" />
</p>

</form>
</body>
</html>
