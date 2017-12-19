<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/UZero.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="UZeroConsole.Web.UZero.Install.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server"></form>
        <!-- Page Header -->
        <div class="content bg-gray-lighter">
            <div class="row items-push">
                <div class="col-sm-7">
                    <h1 class="page-heading">UZeroConsole安装 <small>完成这个向导，你必须知道如何连接数据库（“即连接字符串”）。你可能还需要一些管理员的信息。</small>
                    </h1>
                </div>
            </div>
        </div>
        <!-- END Page Header -->
        <!-- Page Content -->
        <div class="content">
            <div class="block block-themed bg-rounded">
                <div class="block-header bg-muted"><h3 class="block-title">SqlServer 数据库信息</h3></div>
                <div class="block-content block-content-narrow">
                    <asp:Literal runat="server" ID="Literal1"></asp:Literal>
                    <div class="form-horizontal push-10-t">
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <input type="text" id="txtDbHost" class="form-control" />
                                    <label >服务器名称</label>
                                </div>
                                <div class="help-block">
                                    如 120.132.57.7,1444
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <input type="text" id="txtDbName" class="form-control" />
                                    <label >数据库名</label>
                                </div>
                                <div class="help-block">
                                    如 sa
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <input type="text" id="txtDbLoginName" class="form-control" />
                                    <label >登录名</label>
                                </div>
                                <div class="help-block">
                                    如 sa
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <input type="password" id="txtDbLoginPassword" class="form-control" />
                                    <label >密码</label>
                                </div>
                                <div class="help-block"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="block block-themed bg-rounded">
                <div class="block-header bg-muted"><h3 class="block-title">管理员信息</h3></div>
                <div class="block-content block-content-narrow">
                    <asp:Literal runat="server" ID="ltlMessage"></asp:Literal>
                    <div class="form-horizontal push-10-t">
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <input type="text" value="admin" disabled="disabled" class="form-control" />
                                    <label >用户名</label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <input type="text" value="超级管理员" disabled="disabled" class="form-control" />
                                    <label >昵称</label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <input type="password" id="txtAdminPassword" class="form-control" />
                                    <label >密码</label>
                                </div>
                                <div class="help-block">不填则为默认：123456</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="alert alert-danger hide">出错了：</div>
                            <div class="col-xs-12" style="padding-bottom:100px;">
                                <button class="btn btn-success btn-block">安装</button>
                            </div>
        </div>
        <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script>
        $(function () {
            var $commit = $('button');
            var $errorBox = $('.alert');

            $commit.click(function () {
                var $dbHost = $('#txtDbHost');
                var $dbName = $('#txtDbName');
                var $dbLoginName = $('#txtDbLoginName');
                var $dbLoginPassword = $('#txtDbLoginPassword');
                var $adminPassword = $('#txtAdminPassword');
                

                if ($dbHost.val() == '' ||
                    $dbName.val() == '' ||
                    $dbLoginName.val() == '' ||
                    $dbLoginPassword.val() == '') {
                    alert('请把input框填满好吗');
                    return;
                }

                if ($commit.text() == '安装') {
                    $errorBox.addClass('hide');
                    $commit.text('安装中..');
                    var input = {};
                    input.DbHost = $.trim($dbHost.val());
                    input.DbName = $.trim($dbName.val());
                    input.DbLoginName = $.trim($dbLoginName.val());
                    input.DbLoginPassword = $.trim($dbLoginPassword.val());
                    input.AdminPassword = $.trim($adminPassword.val());

                    InstallIndexPageService.Install(input, function (res) {
                        var json = res.value;
                        if (res.value != null && json.Success) {
                            window.location.href = "/Default.aspx";
                        } else {
                            $commit.text('安装');
                            $errorBox.removeClass('hide');
                            $errorBox.html('出错了：' + JSON.stringify(json.Errors));
                        }
                    });
                }
                
            });
        });
    </script>
</asp:Content>
