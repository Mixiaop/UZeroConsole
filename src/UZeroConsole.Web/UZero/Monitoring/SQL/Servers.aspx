<%@ Page Title="" Language="C#" MasterPageFile="~/UZero/Monitoring/Monitoring.master" AutoEventWireup="true" CodeBehind="Servers.aspx.cs" Inherits="UZeroConsole.Web.UZero.Monitoring.SQL.Servers" %>
<%@ Import Namespace="UZeroConsole" %>
<%@ Import Namespace="UZeroConsole.Monitoring" %>
<%@ Import Namespace="UZeroConsole.Web.UZero.Monitoring" %>
<asp:Content ID="Content1" ContentPlaceHolderID="monitoringHeader" runat="server">
    <style type="text/css">
        .progress {
            background: #666;
            margin-bottom: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="monitoringBody" runat="server">
    <div class="content">
        <div class="col-lg-12">
            <div class="underline-nav">
                <nav class="underline-nav-body">
                    <a href="#" class="underline-nav-item selected" aria-selected="false" role="tab" title="Stars">所有服务器</a>
                    <a href="#" class="underline-nav-item hide" aria-selected="false" role="tab" title="Stars">所有任务</a>
                    <a href="Databases.aspx" class="underline-nav-item" aria-selected="false" role="tab" title="Stars">数据库</a>
                    <a href="#" class="underline-nav-item hide" aria-selected="false" role="tab" title="Stars">TOP</a>
                </nav>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <input type="hidden" class="js-refresh-time" value="<%= Model.Refresh %>" />
    <div class="content js-refresh" data-name="sql">
        <div class="block">
            <div class="block-content">
                <table class="table table-hover js-dataTable-full">
                    <thead>
                        <tr>
                            <th class="text-center">Node</th>
                            <th class="text-center">CPU</th>
                            <th class="text-center">Memory</th>
                            <th class="text-center">容量</th>
                            <th class="text-center">数据库</th>
                            <th class="text-center">连接数 / Sessions</th>
                            <th class="text-center">Batches / 秒</th>
                            <th class="text-center">最后更新</th>
                        </tr>
                    </thead>
                    <% if (Model.StandaloneInstances.Any())
                        { %>
                    <tbody>
                        <%foreach (var server in Model.StandaloneInstances)
                            {
                                var dbs = server.Databases.SafeData(true);
                        %>
                        <tr>
                            <td class="text-center"><%= server.Name %></td>
                            <td class="text-center"><%= server.CurrentCPUPercent.HasValue? server.CurrentCPUPercent.ToString() + "%":"" %></td>
                            <%= HtmlSQLHelper.MemoryCell(server) %>
                            <td class="text-center">
                                <%  var volumes = server.Volumes.Data;
                                    if (volumes != null && volumes.Any())
                                    {
                                        foreach (var v in volumes.OrderBy(v => v.VolumeId))
                                        {
                                            var percentUsed = 100 * (v.TotalBytes - v.AvailableBytes) / (float)v.TotalBytes;
                                %>
                                <div class="progress">
                                    <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" style="width:<%= percentUsed.ToString() %>%">
                                        <%= (v.VolumeMountPoint.ToUpper() + "" + v.LogicalVolumeName) %> <%=((v.TotalBytes - v.AvailableBytes).ToSize()) %> / <%= v.TotalBytes.ToSize() %> ( <%= v.AvailableBytes.ToSize() %> 空闲 )
                                    </div>
                                </div>

                                <%}
                                } %>
                            </td>
                            <td class="text-center"><%= HtmlHelper.HealthDescription(dbs) %></td>
                            <%= HtmlSQLHelper.ConnectionsCell(server) %>
                            <%= HtmlSQLHelper.BatchesCell(server) %>
                            <td class="text-center"><%= server.LastFetch.ToPollSpan() %></td>
                        </tr>
                        <%} %>
                    </tbody>
                    <%} %>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="monitoringFooter" runat="server">
</asp:Content>
