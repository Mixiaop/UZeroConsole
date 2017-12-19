<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/UZero.Master" AutoEventWireup="true" CodeBehind="SetConsoleSettings.aspx.cs" Inherits="UZeroConsole.Web.UZero.Configuration.SetConsoleSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
        <!-- Page Header -->
        <div class="content bg-gray-lighter">
            <div class="row items-push">
                <div class="col-sm-7">
                    <h1 class="page-heading">控制台通用配置<small>通用的配置</small>
                    </h1>
                </div>
            </div>
        </div>
        <!-- END Page Header -->
        <!-- Page Content -->
        <div class="content">
            <!-- Dynamic Table Full -->
            <div class="block">
                <div class="block-content block-content-narrow">
                    <asp:Literal runat="server" ID="ltlMessage"></asp:Literal>
                    <div class="form-horizontal push-10-t">
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:DropDownList runat="server"  ID="ddlIsDebug" CssClass="form-control">
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                        <asp:ListItem Value="0">否</asp:ListItem>
                                    </asp:DropDownList>
                                    <label>IsDebug</label>
                                </div>
                                <div class="help-block">
                                    一般用于本地调试
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbTitle" CssClass="form-control"></asp:TextBox>
                                    <label >标题</label>
                                </div>
                                <div class="help-block">
                                    控制台的标题
                                </div>
                            </div>
                        </div>
                         <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:DropDownList runat="server"  ID="ddlUseJobs" CssClass="form-control">
                                        <asp:ListItem Value="1">开启</asp:ListItem>
                                        <asp:ListItem Value="0">不开启</asp:ListItem>
                                    </asp:DropDownList>
                                    <label>是否开启任务</label>
                                </div>
                                <div class="help-block">
                                    开启后可访问Hangfire控制台：/jobs 
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:DropDownList runat="server"  ID="ddlIsSsoOpened" CssClass="form-control">
                                        <asp:ListItem Value="1">开启</asp:ListItem>
                                        <asp:ListItem Value="0">不开启</asp:ListItem>
                                    </asp:DropDownList>
                                    <label>是否开启Sso</label>
                                </div>
                                <div class="help-block">
                                    多个控制台之间开启使用单点登录（开启之后关于Sso的其他配置才会生效）
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:DropDownList runat="server"  ID="ddlIsSsoServer" CssClass="form-control">
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                        <asp:ListItem Value="0">否</asp:ListItem>
                                    </asp:DropDownList>
                                    <label>IsSsoServer</label>
                                </div>
                                <div class="help-block">
                                    当前应用是SsoServer，用于单点登录。
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbSsoAuthExpiresMinutes" CssClass="form-control"></asp:TextBox>
                                    <label >Sso登录过期时间</label>
                                </div>
                                <div class="help-block">
                                    （秒）登录后的授权时间
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbSsoServerHost" CssClass="form-control"></asp:TextBox>
                                    <label >Sso服务地址</label>
                                </div>
                                <div class="help-block">
                                    如 http://uc.youzy.cn
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbSsoAppKey" CssClass="form-control"></asp:TextBox>
                                    <label >当前Sso应用密钥</label>
                                </div>
                                <div class="help-block">
                                    创建Sso应用后对应的密钥
                                </div>
                            </div>
                        </div>
                         <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:DropDownList runat="server"  ID="ddlUNoteExternalLoginOpened" CssClass="form-control">
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                        <asp:ListItem Value="0">否</asp:ListItem>
                                    </asp:DropDownList>
                                    <label>是否开启UNote登录</label>
                                </div>
                                <div class="help-block">
                                    UNote帐号打通自动登录
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbUNoteExternalLoginUrl" CssClass="form-control"></asp:TextBox>
                                    <label >UNote登录地址</label>
                                </div>
                                <div class="help-block">
                                    如 http://note.youzy.cn/externallogin.aspx
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbUNoteAppKey" CssClass="form-control"></asp:TextBox>
                                    <label >UNote密钥</label>
                                </div>
                                <div class="help-block">
                                    UNote加密验证
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary"  Text="保存"   />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END Dynamic Table Full -->
        </div>
        <!-- END Page Content -->
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
