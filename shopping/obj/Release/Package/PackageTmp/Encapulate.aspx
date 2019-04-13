<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encapulate.aspx.cs" Inherits="shopping.Encapulate" %>
<%@ Register TagPrefix="ucasp" TagName="login" Src="~/WebUserControl1.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ucasp:login id="login" runat="server" />
    </div>
    </form>
</body>
</html>
