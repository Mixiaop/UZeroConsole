<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/UZero.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="UZeroConsole.Web.UZeroLogging.ActionLogs.List" %>
<%@ Import Namespace="U" %>
<%@ Import Namespace="UZeroConsole.Domain.Logging" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <link href="/assets/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <style>
        .table {
            table-layout: fixed;
        }

        th, td {
            word-wrap: break-word;
            overflow: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
        <!-- Page Header -->
        <div class="content bg-gray-lighter">
            <div class="row items-push">
                <div class="col-sm-7">
                    <h1 class="page-heading"><%= Model.App.Name %><small> <%= Model.App.Description %> - 所有的活动日志</small>
                    </h1>
                </div>
            </div>
        </div>
        <!-- END Page Header -->
        <!-- Page Content -->
        <div class="content ">
            <div class="row items-push">
                <div class="col-xs-12">
                    <div class="form-inline">
                        <div class="form-group ">
                            <select class="form-control" id="ddlModules">
                                <option value="">全部模块</option>
                                <% foreach(var m in Model.Modules){%>
                                <option value="<%= m.ModuleName %>" <%= Model.GetModule == m.ModuleName?"selected='selected'":"" %>><%= m.ModuleName %></option>
                                <%} %>
                            </select>
                            <div class="form-control date" id="dtpStartDate" data-date-format="yyyy-mm-dd hh:i">
                                <input type="text" value="<%= Model.GetFromTime %>" readonly="readonly"  id="txtStartDate" placeholder="开始时间"  style="border: 0;" />
                                <span class="add-on"><i class="icon-th"></i></span>
                            </div>
                            <div class="form-control date" id="dtpEndDate" data-date-format="yyyy-mm-dd hh:i">
                                <input type="text" value="<%= Model.GetToTime %>" readonly="readonly"  id="txtEndDate" placeholder="结束时间" style="border: 0;" />
                                <span class="add-on"><i class="icon-th"></i></span>
                            </div>
                            <label>
                                <input type="text" id="tbKeywords" class="form-control" placeholder="关键字.." value="<%= Model.GetKeywords %>" />
                                </label>
                            <label class="col-xs-pull-1">
                                <button class="btn btn-primary" id="btnSearch">搜索</button>
                                <button class="btn btn-primary" id="btnClearDate">清除日期</button>
                                <button class="btn btn-danger" id="btnClearAll">清除日志</button>
                            </label>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Dynamic Table Full -->
            <div class="block">
                <div class="block-content table-responsive">
                    <!-- DataTables init on table by adding .js-dataTable-full class, functionality initialized in js/pages/base_tables_datatables.js -->
                    <asp:Literal runat="server" ID="ltlErrorMessage"></asp:Literal>
                    <asp:Literal runat="server" ID="ltlSuccessMessage"></asp:Literal>
                    <table class="table table-hover js-dataTable-full">
                        <thead>
                            <tr>
                                <th  style="width: 5%"></th>
                                <th class="text-center" style="width: 13%">模块名</th>
                                <th class="text-center" style="width: 10%">操作者（标识）</th>
                                <th class="text-center" style="width: 22%">短消息</th>
                                <th class="text-center" style="width: 32%">Url</th>
                                <th class="text-center" style="width: 8%">类型</th>
                                <th class="text-center" style="width: 10%">时间</th>
                            </tr>
                        </thead>
                        <asp:Repeater runat="server" ID="rptDatas">
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td ><a class='btn btn-xs btn-default' target="_" href="Info.aspx?logId=<%# Eval("Id") %>" data-toggle="tooltip" title="详情"><i class="fa fa-search"></i></a></td>
                                        <td class="text-center"><%# Eval("ModuleName")%></td>
                                        <td class="text-center"><%# Eval("Operator")%> <%# Eval("OperatorId").ToString().IsNotNullOrEmpty()?"【"+Eval("OperatorId").ToString()+"】":Eval("OperatorId").ToString()%> </td>
                                        <td class="text-center"><%# Eval("ShortMessage")%></td>
                                        <td class="text-center"><%# Eval("Url")%></td>
                                        <td class="text-center"><%# ((ActionLogOperateType)Eval("OperateType")).ToAlias() %></td>
                                        <td class="text-center"><%# Eval("CreationTime","{0:yyyy-MM-dd HH:mm:ss}")%></td>
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <div class="text-center">
                    <ul class="pagination">
                        <%= Model.PagingHTML %>
                    </ul>
                </div>
            </div>
            <!-- END Dynamic Table Full -->
        </div>
        <!-- END Page Content -->
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="/assets/js/plugins/bootstrap-datepicker/bootstrap-datetimepicker.js"></script>
    <script src="/assets/js/plugins/bootstrap-datepicker/bootstrap-datetimepicker.min.js"></script>
    <script src="/assets/js/plugins/bootstrap-datepicker/bootstrap-datetimepicker.zh-CN.js" type="text/javascript" charset="UTF-8"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dtpStartDate').datetimepicker({ language: "zh-CN" });
            $('#dtpEndDate').datetimepicker({ language: "zh-CN" });

            $('form').submit(function () { return false; });

            var $from = $('#txtStartDate'), $to = $('#txtEndDate');
            var search = function () {
                var appId = parseInt('<%= Model.GetAppId %>');


                var url = "List.aspx?appid=" + appId;
                url += '&from=' + $from.val();
                url += '&to=' + $to.val();
                url += '&module=' + $('#ddlModules').val();
                url += '&wd=' + $('#tbKeywords').val();
                window.location.href = url;
            }

            $('#btnSearch').click(search);
            $('#btnClearDate').click(function () {
                $from.val('');
                $to.val('');
                search();
            })

            $('#btnClearAll').click(function () {
                if (confirm('你确定清除【<%= Model.App.Name%>】的所有日志吗？')) {
                    var appId = parseInt("<%= Model.GetAppId %>");
                    ActionLogService.ClearAll(appId, function (res) {
                        notifyService.success("清空成功");
                        redirectService.refresh(500);
                    });
                }
            });
        });
    </script>
</asp:Content>
