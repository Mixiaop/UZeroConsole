﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/UZero.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="UZeroConsole.Web.UZeroJobs.RemoteJobs.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server"></form>
    <div class="col-sm-12 col-lg-12">
        <!-- Page Header -->
        <div class="content bg-gray-lighter">
            <div class="row items-push">
                <div class="col-sm-7">
                    <h1 class="page-heading">远程任务列表 <small>查看所有任务的状态</small>
                    </h1>
                </div>
            </div>
        </div>
        <!-- END Page Header -->
        <!-- Page Content -->
        <div class="content">
            <div class="row items-push">
                <div class="col-xs-12">
                    <div class="form-inline">
                        <div class="form-group">
                            <label class="col-xs-pull-1">
                                <a href="Add.aspx?<%= GetBackUrlEncoded() %>" class="btn btn-primary btn-sm">添加</a>
                            </label>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Dynamic Table Full -->
            <div class="block">
                <div class="block-content table-responsive">
                    <asp:Literal runat="server" ID="ltlMessage"></asp:Literal>
                    <table class="table table-hover js-dataTable-full">
                        <thead>
                            <tr>
                                <td width="10%"></td>
                                <th width="15%">Name</th>
                                <th class="text-center">Key</th>
                                <th class="text-center">Url</th>
                                <th class="text-center">Desc</th>
                                <th class="text-center">Last Success</th>
                                <th class="text-center" width="18%">Last Error </th>
                                <th class="text-center" width="8%">Time</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (var app in Model.Results.Items)
                               { %>
                            <tr>
                                <td>
                                    <%--<a class='btn btn-default btn-xs active-btn' href="Edit.aspx?jobId=<%= app.Id %>&<%= GetBackUrlEncoded() %>" data-toggle="tooltip" title="编辑"><i class="fa fa-pencil"></i></a>--%>
                                    <a class='btn btn-default btn-xs active-btn btnRun' data-id="<%= app.Id %>" href="javascript:void(0);" data-toggle="tooltip" title="Run the job"><i class="fa fa-check"></i></a>
                                    <a class='btn btn-default btn-xs active-btn btnDelete' data-id="<%= app.Id %>" href="javascript:void(0);" data-toggle="tooltip" title="Delete the job"><i class="fa fa-remove"></i></a>
                                </td>
                                <td><%= app.Name %> <% if (app.Opend)
                                                       { %>
                                    <label class="label label-success">已启动</label>
                                    <%}
                                                       else
                                                       { %><label class="label label-default">未启动</label><%} %> <% if (app.IsExecuting)
                                                                                                       { %>
                                    <label class="label label-success">运行中</label>
                                    <%}%></td>
                                <td class="text-center"><%= app.Key %></td>
                                <td class="text-center"><%= app.Url %></td>
                                <td class="text-center"><%= app.Desc %> </td>
                                <td class="text-center"><%if (app.LastSuccessTime.HasValue)
                                                          { %><%= app.LastSuccessTime.Value.ToString("yyyy-MM-dd hh:MM:ss") %><%}
                                                          else
                                                          { %>-<%} %> </td>
                                <td class="text-center"><%if (app.LastErrorTime.HasValue)
                                                          { %><%= app.LastErrorTime.Value.ToString("yyyy-MM-dd hh:MM:ss") %> <span><%= app.LastErrorDesc %></span><%}
                                                          else
                                                          { %>-<%} %></td>
                                <td class="text-center"><%= app.CreationTime.ToString("yyyy-MM-dd HH:mm") %></td>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                </div>
                <div class="text-center">
                    <ul class="pagination">
                        <%= Model.PaginHTML %>
                    </ul>
                </div>
            </div>
            <!-- END Dynamic Table Full -->
        </div>
        <!-- END Page Content -->

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script>
        $(document).ready(function () {
            $('.btnRun').click(function () {
                if (confirm('Are you sure run the job?')) {
                    var jobId = $(this).data('id');
                    RemoteJobService.Run(jobId, function (res) {
                        notifyService.success("开启成功");
                        redirectService.refresh(500);
                    });
                }
            });

            $('.btnDelete').click(function () {
                if (confirm('Are you sure delete the job?')) {
                    var jobId = $(this).data('id');
                    RemoteJobService.Delete(jobId, function (res) {
                        notifyService.success("删除成功");
                        redirectService.refresh(500);
                    });
                }
            });
        });
    </script>
</asp:Content>
