<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/UZero.Master" AutoEventWireup="true" CodeBehind="SetCorpWeixinSettings.aspx.cs" Inherits="UZeroConsole.Web.UZero.Configuration.SetCorpWeixinSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
        <!-- Page Header -->
        <div class="content bg-gray-lighter">
            <div class="row items-push">
                <div class="col-sm-7">
                    <h1 class="page-heading">企业微信配置<small>配置是否开启并使用企业微信登录</small>
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
                                    <asp:DropDownList runat="server"  ID="ddlIsOpend" CssClass="form-control">
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                        <asp:ListItem Value="0">否</asp:ListItem>
                                    </asp:DropDownList>
                                    <label>是否开启企业微信</label>
                                </div>
                                <div class="help-block">
                                    后台帐号与企业微信打通，能企业微信扫码登录
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbCorpId" CssClass="form-control"></asp:TextBox>
                                    <label >企业Id</label>
                                </div>
                                <div class="help-block">
                                    配置的CorpId
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbAuthAgentId" CssClass="form-control"></asp:TextBox>
                                    <label >授权应用Id</label>
                                </div>
                                <div class="help-block">
                                    配置的AgentId
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbAuthSecret" CssClass="form-control"></asp:TextBox>
                                    <label >授权应用密钥</label>
                                </div>
                                <div class="help-block">
                                    配置的Secret
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
