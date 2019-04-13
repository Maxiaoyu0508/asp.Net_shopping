<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pay.aspx.cs" Inherits="shopping.Pay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="支付页面"></asp:Label>
        </p>
        <p>
            订单号：<asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
        <p>
            日期：<asp:Label ID="Label3" runat="server"></asp:Label>
        </p>
        <p>
            收件人：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="TextBox2" SetFocusOnError="true" Display="static"
            ErrorMessage="收件人必须输入" ></asp:RequiredFieldValidator>
        </p>
        <p>
            联系电话：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="Validator7" runat="server" ControlToValidate="TextBox4" 
            ValidationExpression="0\d{3}-\d{8}" Display="Dynamic"   ErrorMessage="格式错误！"></asp:RegularExpressionValidator>
        </p>
        <p>
            收货地址：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox3" SetFocusOnError="true" Display="static"
            ErrorMessage="收货地址必须输入" ></asp:RequiredFieldValidator>
        </p>
        <p>
            邮编：<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TextBox5" SetFocusOnError="true" Display="static"
            ErrorMessage="邮箱必须输入" ></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="Validator71" runat="server" ControlToValidate="TextBox5" 
            ValidationExpression  ="\d{6}" Display="Dynamic"   ErrorMessage="格式错误！"></asp:RegularExpressionValidator>
        </p>
        <p>
            &nbsp;</p>
        <p>
            请输入支付密码：<asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Validator2" runat="server" 
             ControlToValidate="TextBox1" SetFocusOnError="true" Display="Dynamic"
             ErrorMessage="密码必须输入"  EnableClientScript="false"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确认支付" />
            <asp:Button ID="Button2" runat="server" CausesValidation="False" OnClick="Button2_Click" Text="放弃支付" />
        </p>
    </form>
</body>
</html>
