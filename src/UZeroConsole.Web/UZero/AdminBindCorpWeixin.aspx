<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminBindCorpWeixin.aspx.cs" Inherits="UZeroConsole.Web.UZero.AdminBindCorpWeixin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title>绑定企业微信</title>
    <script src="http://rescdn.qqmail.com/node/ww/wwopenmng/js/sso/wwLogin-1.0.0.js"></script>
</head>
<body>
    <div id="login">
    
    </div>
    <% if(U.Utilities.Web.WebHelper.GetString("code").IsNullOrEmpty()) { %>
    <script>
        window.WwLogin({
            "id": "login",
            "appid": "<%= Model.Settings.CorpId %>",
            "agentid": "<%= Model.Settings.AuthAgentId %>",
            "redirect_uri": "<%=U.Utilities.Web.WebHelper.GetThisPageUrl(false) %>?adminId=<%= Model.GetAdminId %>",
            "state": "",
            "href": "",
        });
    </script>
    <%} %>
</body>
</html>
