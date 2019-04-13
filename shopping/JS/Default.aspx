<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>基于Ajax的用户验证&登录</title>
    
    <script language="javascript" type="text/javascript" src="Check.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table>
            <tr>
                <td style="width: 100px">
                    用户名:</td>
                <td style="width: 100px">
                    <input id="UserName" type="text" onkeyup="CheckUserName(document.getElementById('UserName').value)" /></td>
                <td style="width: 100px">
                    <img src="image/load.gif" id="imgflag" /></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    密<span style="color: #ffffff">__</span>码:</td>
                <td style="width: 100px">
                    <input id="Password" type="password" /></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    确认密码:</td>
                <td style="width: 100px">
                    <input id="Password1" type="password" /></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 26px">
                    <input id="btnReg" type="button" value="注册" onclick="RegUser();" />
                    <input id="btnlogin" type="button" value="登录" onclick="login();" />
                    <input id="Reset1" type="reset" value="重置" onclick="Set();" /></td>
            </tr>
        </table>
    <!--download from 51aspx.com(５１ａｓｐｘ．ｃｏｍ)-->

    </div>
    </form>
<a href="http://www.51aspx.com/" target="_blank" title="Asp.net源码下载专业站">download from 51aspx.com</a>

</body>
</html>
