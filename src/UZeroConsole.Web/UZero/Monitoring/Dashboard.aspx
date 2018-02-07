<%@ Page Title="" Language="C#" MasterPageFile="~/UZero/Monitoring/Monitoring.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="UZeroConsole.Web.UZero.Monitoring.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="monitoringHeader" runat="server">
    <style type="text/css">
        .progress {
            background: #666;
            margin-bottom: 5px;
        }
        .content {
            margin-top:0;
            margin-bottom:0;
            padding-top:0;
        }
            .content .col-lg-12 {
                padding-left:0;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="monitoringBody" runat="server">
    <div class="content">
        <div class="col-lg-12">
            <div class="underline-nav">
                <nav class="underline-nav-body">
                    <a class="underline-nav-item selected" aria-selected="false" role="tab" title="Stars">Web Servers</a>
                </nav>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="content js-dashboard-refresh" data-name="hosts" data-url="/UZero/Monitoring/Hosts/ClientHosts.aspx">
    </div>
    <div class="content">
        <div class="col-lg-12">
            <div class="underline-nav">
                <nav class="underline-nav-body">
                    <a class="underline-nav-item selected" aria-selected="false" role="tab" title="Stars">SQL</a>
                </nav>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="content js-dashboard-refresh" data-name="sql" data-url="/UZero/Monitoring/SQL/Servers.aspx">
    </div>
    <div class="content">
        <div class="col-lg-12">
            <div class="underline-nav">
                <nav class="underline-nav-body">
                    <a class="underline-nav-item selected" aria-selected="false" role="tab" title="Stars">Redis</a>
                </nav>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="content js-dashboard-refresh" data-name="redis" data-url="/UZero/Monitoring/Redis/Servers.aspx">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="monitoringFooter" runat="server">
    <script>
        var $datas = $('.js-dashboard-refresh');
        var refreshHosts = function () {
            var $block = $($datas[0]);
            var url = $block.data("url");
            var def = $.Deferred();

            $.ajax(url, { cache: false })
                .done(function (html) {
                    var $res = $(html);
                    $block.html($res.find('.js-refresh[data-name]').html());
                    def.resolve();
                }).fail(function () {
                });

            return def;
        }

        var refreshSQL = function () {
            var $block = $($datas[1]);
            var url = $block.data("url");
            var def = $.Deferred();

            $.ajax(url, { cache: false })
                .done(function (html) {
                    var $res = $(html);
                    $block.html($res.find('.js-refresh[data-name]').html());
                    def.resolve();
                }).fail(function () {
                });

            return def;
        }

        var refreshRedis = function () {
            var $block = $($datas[2]);
            var url = $block.data("url");
            var def = $.Deferred();

            $.ajax(url, { cache: false })
                .done(function (html) {
                    var $res = $(html);
                    $block.html($res.find('.js-refresh[data-name]').html());
                    def.resolve();
                }).fail(function () {
                });

            return def;
        }

        var refresh = function () {
            refreshHosts().then(refreshSQL).then(refreshRedis).then(function () {
                setTimeout(function () {
                    refresh();
                }, 3000);
            });
        }

        refresh();
    </script>
</asp:Content>
