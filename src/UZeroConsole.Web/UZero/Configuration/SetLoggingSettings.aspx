<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/UZero.Master" AutoEventWireup="true" CodeBehind="SetLoggingSettings.aspx.cs" Inherits="UZeroConsole.Web.UZero.Configuration.SetLoggingSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
        <!-- Page Header -->
        <div class="content bg-gray-lighter">
            <div class="row items-push">
                <div class="col-sm-7">
                    <h1 class="page-heading">日志应用配置<small>配置当前控制台用的日志应用地址</small>
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
                                    <asp:TextBox runat="server" ID="tbSOAHost" CssClass="form-control"></asp:TextBox>
                                    <label >应用Url</label>
                                </div>
                                <div class="help-block">
                                    接口URL，如：http://log.youzy.cn
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbDefaultKey" CssClass="form-control"></asp:TextBox>
                                    <label >默认密钥</label>
                                </div>
                                <div class="help-block">
                                    日志应用创建时给予的应用Key
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
