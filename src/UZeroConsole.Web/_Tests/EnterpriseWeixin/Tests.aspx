<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tests.aspx.cs" Inherits="UZeroConsole.Web.External.EnterpriseWeixin.Tests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <script src="http://rescdn.qqmail.com/node/ww/wwopenmng/js/sso/wwLogin-1.0.0.js"></script>
</head>
<body>
    <div id="weixinLogin"></div>
    <script>
        window.WwLogin({
            "id": "weixinLogin",
            "appid": "ww9f73503571cc9552",
            "agentid": "1000002",
            "redirect_uri": "http://sso.mbjuan.com/_Tests/EnterpriseWeixin/CallbackTests.aspx?adminId=1",
            "state": "",
            "href": "",
        });
    </script>
</body>
</html>
