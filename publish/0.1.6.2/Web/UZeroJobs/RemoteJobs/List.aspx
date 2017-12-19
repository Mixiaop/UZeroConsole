<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/UZero.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="UZeroConsole.Web.UZeroJobs.RemoteJobs.List" %>

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
            <style>
                .table td {
                    word-break:break-all;
                }
            </style>
            <!-- Dynamic Table Full -->
            <div class="block">
                <% if (Model.Tags != null && Model.Tags.Count > 0)
       { %>
    <div class="row filter-tags-wrapper">
        <div class="col-lg-8 col-xs-12">

            <ul class="filter-tags">
                <li><a href="List.aspx">全部</a></li>
                <% foreach (var tag in Model.Tags)
                   { %>
                <% if (Model.GetTags.Contains(tag.Name))
                   { %>
                <li><a class="active"><%= tag.Name %></a><a href="List.aspx" class="tag-close"><i class="fa fa-close"></i></a></li>
                <%}
                   else
                   { %>
                <li><a href="List.aspx?tags=<%= tag.Name  %>"><%= tag.Name %></a></li>
                <%} %>
                <%} %>
            </ul>

        </div>
    </div>
    <%} %>
                <div class="block-content table-responsive">
                    <asp:Literal runat="server" ID="ltlMessage"></asp:Literal>
                    <table class="table table-hover js-dataTable-full" style="table-layout:fixed" >
                        <thead>
                            <tr>
                                <th width="5%" ></th>
                                <th class="text-center" width="15%" >Name</th>
                                <th class="text-center" width="8%" >Type</th>
                                <th class="text-center" width="10%">Key</th>
                                <th class="text-center" width="19%" >Url</th>
                                <th class="text-center" width="10%">Desc</th>
                                <th class="text-center" width="6.5%">Last Success</th>
                                <th class="text-center" width="20%">Last Error </th>
                                <th class="text-center" width="6.5%">Time</th>
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
                                <td ><%= app.Name %> <% if (app.Opend)
                                                       { %>
                                    <label class="label label-success">已启动</label>
                                    <%}
                                                       else
                                                       { %><label class="label label-default">未启动</label><%} %> <% if (app.IsExecuting)
                                                                                                       { %>
                                    <label class="label label-success">运行中</label>
                                    <%}%>
                                    <% if (app.LastErrorTime.HasValue && app.LastSuccessTime.HasValue)
                                             {
                                                 if (app.LastErrorTime.Value > app.LastSuccessTime.Value)
                                                 {%>
                                    <label class="label label-danger">Error</label>
                                    <%}
                                             } %>
                                </td>
                                <td class="text-center">
                                    <% if (app.Type == UZeroConsole.Domain.Jobs.RemoteJobType.General)
                                             { %>
                                        普通
                                    <%}
                                             else if (app.Type == UZeroConsole.Domain.Jobs.RemoteJobType.AtTime)
                                             { %>
                                    定时(<%= app.AtTime %>)
                                    <%}
                                             else if (app.Type == UZeroConsole.Domain.Jobs.RemoteJobType.Recurring)
                                             { %>
                                    循环(<%= app.RecurringSeconds %> 秒)
                                    <%} %>
                                </td>
                                <td class="text-center"><%= app.Key %></td>
                                <td ><%= app.Url %></td>
                                <td ><%= app.Desc %> <% if (app.Tags.IsNotNullOrEmpty())
                                                         { %>（<%= app.Tags %>）<%} %></td>
                                <td class="text-center"><%if (app.LastSuccessTime.HasValue)
                                                          { %><%= app.LastSuccessTime.Value.ToString("yyyy-MM-dd hh:MM") %><%}
                                                          else
                                                          { %>-<%} %> </td>
                                <td class="text-center"><%if (app.LastErrorTime.HasValue)
                                                          { %><%= app.LastErrorTime.Value.ToString("yyyy-MM-dd hh:MM") %> <br /><span><%= app.LastErrorDesc %></span><%}
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
