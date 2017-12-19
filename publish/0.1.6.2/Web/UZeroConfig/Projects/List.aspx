<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/UZero.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="UZeroConsole.Web.UZeroConfig.Projects.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="col-sm-12 col-lg-12">
        <!-- Page Header -->
        <div class="content bg-gray-lighter">
            <div class="row items-push">
                <div class="col-sm-7">
                    <h1 class="page-heading">项目列表 <small>配置对应的所有项目</small>
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
                            <input type="text" id="txtKeywords" placeholder="关键字" class="form-control" value="<%= Model.GetKeywords %>" />
                            <label class="col-xs-pull-1">
                                <input type="button" class="btn btn-primary btn-sm" id="btnSearch" value="搜索" />
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
                                <th width="10%"></th>
                                <th  width="15%">Name</th>
                                <th class="text-center">Code</th>
                                <th class="text-center">Desc</th>
                                <th class="text-center" width="5%">Key</th>
                                <th class="text-center" width="8%">Time</th>
                            </tr>
                        </thead>
                        <% foreach (var app in Model.Results.Items)
                               { %>
                        <tbody>
                            <tr>
                                <td >
                                    <%--<a class='btn btn-default btn-xs active-btn' href="Edit.aspx?appId=<%= app.Id %>&<%= GetBackUrlEncoded() %>" data-toggle="tooltip" title="编辑"><i class="fa fa-pencil"></i></a>--%>
                                </td>
                                <td ><%= app.Name %></td>
                                <td class="text-center"><%= app.Code %></td>
                                <td class="text-center"><%= app.Desc %></td>
                                <td class="text-center"><%= app.Key %> </td>
                                <td class="text-center"><%= app.CreationTime.ToString("yyyy-MM-dd HH:mm") %></td>
                            </tr>
                        </tbody>
                        <%} %>
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
            $('#btnSearch').click(function () {
                alert(1);
            });
        });
    </script>
</asp:Content>
