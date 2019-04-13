<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="shopping.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script type="text/JavaScript">
    function reloadCode() {
    var obj=document.getElementById('ImageCode');
    obj.src = "CreateCode.aspx?" + Math.random();

    } 
    </script>
    <style type="text/css">
        *{
            margin:0;
            padding:0;
        }
        div.container{
            background-color:aqua;
            border:2px solid #000;
            width:500px;
            height:350px;
            margin:50px auto;
            display:table;    
        }
        div.wrapper{
            text-align:center;
            display:table-cell;
            vertical-align:middle;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="wrapper">
        <p>
            登录</p>
            <p>
                &nbsp;</p>
        <p>
            用户名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        </p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
        <p>
            密 码：<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        </p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
        <p>
            验证码：<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <!--<asp:Image ID="Image1" runat="server"  ImageUrl="~/CreateCode.aspx" />-->
            <img id="ImageCode" src="CreateCode.aspx" alt="验证码" onclick="reloadCode();" style="Cursor:pointer;padding-left:2px;"/>
        </p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
        <p>
            <asp:Button ID="Button1" runat="server" CausesValidation="False" Text="登录" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" CausesValidation="False" OnClick="Button2_Click" Text="注册" />
        </p>
                </div>
            </div>
    </form>
</body>
</html>
