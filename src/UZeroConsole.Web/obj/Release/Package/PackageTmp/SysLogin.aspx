﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysLogin.aspx.cs" Inherits="UZeroConsole.Web.SysLogin" %>

<!DOCTYPE html>
<!--[if IE 9]>         <html class="ie9 no-focus"> <![endif]-->
<!--[if gt IE 9]><!-->
<html class="no-focus">
<!--<![endif]-->
<head>
    <meta charset="utf-8">

    <title><%= ConsoleSettings.Title %> login</title>
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0">
    <!-- Stylesheets -->
    <!-- OneUI CSS framework -->
    <link rel="stylesheet" id="css-main" href="assets/css/oneui.css">

    <style type="text/css">
        canvas {
            position:absolute;
            top:0px;
            z-index:10;
        }
        .content {
            z-index:100;
            position:relative;
        }
    </style>
</head>
<body>
    <!-- Login Content -->
    <div class="content overflow-hidden login">
        <div class="row">
            <div class="col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4">
                <!-- Login Block -->
                <div class="block block-themed animated fadeIn">
                    <div class="block-header bg-primary">

                        <h3 class="block-title"><%= ConsoleSettings.Title %></h3>
                    </div>
                    <div class="block-content block-content-full block-content-narrow">
                        <!-- Login Title -->
                        <h1 class="h2 font-w600 push-30-t push-5">Login</h1>
                        <p></p>
                        <!-- END Login Title -->
                        <asp:Literal runat="server" ID="ltlError"></asp:Literal>
                        <!-- Login Form -->
                        <!-- jQuery Validation (.js-validation-login class is initialized in js/pages/base_pages_login.js) -->
                        <!-- For more examples you can check out https://github.com/jzaefferer/jquery-validation -->
                        <form class="js-validation-login form-horizontal push-30-t push-50" runat="server">
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <div class="form-material  floating">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="tbUsername"></asp:TextBox>
                                        <label for="login-username">用户名</label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <div class="form-material floating">
                                        <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                        <label for="login-password">密 &nbsp;&nbsp;码</label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <div class="form-material  floating">
                                        <asp:TextBox ID="tbCaptchaCode" runat="server" CssClass="form-control" />
                                        <label for="login-captchaCode">验证码</label>
                                    </div>
                                    <div class="help-block">
                                        <BotDetect:Captcha ID="loginCaptcha" runat="server" />
                                    </div>
                                </div>
                            </div>
                             <div class="form-group">
                                    <div class="col-xs-12">
                                        <label class="css-input switch switch-sm switch-primary">
                                            <asp:CheckBox runat="server" ID="cbRememberMe" /><span></span> 记住用户名
                                        </label>
                                    </div>
                                </div>
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <div class="form-material  floating">
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <asp:Button runat="server" ID="btnLogin" Text="登录" CssClass="btn btn-block btn-primary" />
                                </div>
                            </div>
                        </form>
                        <!-- END Login Form -->
                    </div>
                </div>
                <!-- END Login Block -->
            </div>
        </div>
    </div>
    <!-- END Login Content -->
    <!-- Login Footer -->
    <div class="push-10-t text-center animated fadeInUp">
        <%--<small class="text-muted font-w600"><span class="js-year-copy"></span> &copy; youzy.cn</small>--%>
    </div>
    <!-- END Login Footer -->


    <!-- OneUI Core JS: jQuery, Bootstrap, slimScroll, scrollLock, Appear, CountTo, Placeholder, Cookie and App.js -->
    <script src="/assets/js/core/jquery.min.js"></script>
    <script src="/assets/js/core/bootstrap.min.js"></script>
    <script src="/assets/js/core/jquery.slimscroll.min.js"></script>
    <script src="/assets/js/core/jquery.scrollLock.min.js"></script>
    <script src="/assets/js/core/jquery.appear.min.js"></script>
    <script src="/assets/js/core/jquery.countTo.min.js"></script>
    <script src="/assets/js/core/jquery.placeholder.min.js"></script>
    <script src="/assets/js/core/js.cookie.min.js"></script>
    <script src="/assets/js/app.js"></script>

    <script src="/assets/js/core/three/three.min.js"></script>
    <script src="/assets/js/core/three/renderers/CanvasRenderer.js"></script>
    <script src="/assets/js/core/three/renderers/Projector.js"></script>
    <script src="/assets/js/core/three/effect/line.js"></script>

</body>
</html>
