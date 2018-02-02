<%@ Page Title="" Language="C#" MasterPageFile="~/UZero/Monitoring/Monitoring.master" AutoEventWireup="true" CodeBehind="Databases.aspx.cs" Inherits="UZeroConsole.Web.UZero.Monitoring.SQL.Databases" %>
<%@ Import Namespace="U" %>
<%@ Import Namespace="UZeroConsole" %>
<%@ Import Namespace="UZeroConsole.Monitoring" %>
<%@ Import Namespace="UZeroConsole.Monitoring.SQL" %>
<%@ Import Namespace="UZeroConsole.Web.UZero.Monitoring" %>
<asp:Content ID="Content1" ContentPlaceHolderID="monitoringHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="monitoringBody" runat="server">
    <%
        var i = Model.CurrentInstance;
        if (i == null) { return; }
        var dbCache = i.Databases;
        var dbs = i.Databases.SafeData();
        var n = i as SQLNode;
        var replicationInfo = (n != null ? (n.AvailabilityGroups
            .SafeData(true)
            .Select(ag => ag.LocalReplica)
            .Where(r => r != null)
            .SelectMany(ag => ag.Databases)
            .ToDictionary(db => db.DatabaseName) ?? new Dictionary<string, SQLNode.AGDatabaseReplica>()) : new Dictionary<string, SQLNode.AGDatabaseReplica>());
    %>
    <div class="content">
        <div class="col-lg-12">
            <div class="underline-nav">
                <nav class="underline-nav-body">
                    <a href="Servers.aspx" class="underline-nav-item" aria-selected="false" role="tab" title="Stars">所有服务器</a>
                    <a href="#" class="underline-nav-item hide" aria-selected="false" role="tab" title="Stars">所有任务</a>
                    <a href="#" class="underline-nav-item selected" aria-selected="false" role="tab" title="Stars">数据库</a>
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
                <div class="panel">
                    <%= dbs.GetWorstStatus().IconSpan() %> <%= (dbs != null? dbs.Count: 0) %> Databases on <%= i.Name %>
                </div>
                <table class="table table-hover table-striped js-dataTable-full">
                    <thead>
                        <tr>
                            <th width="25%">名称</th>
                            <th class="text-center" >状态</th>
                            <th class="text-center" width="10%">Recovery</th>
                            <th class="text-center">Size / log</th>
                            <th class="text-center" colspan="2">最近一次备份 / Full</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%foreach (var db in dbs.OrderBy(b => b.IsSystemDatabase).ThenBy(b => b.Name))
                            {
                                var bkup = db.Backups != null ? db.Backups.FirstOrDefault() : null;
                                %>
                        <tr>
                            <td>
                                <i class="fa fa-database" aria-hidden="true"></i>
                                <%= db.Name %>
                                 <%if (db.IsReadOnly){ %>
                            <span class="text-warning">(read-only)</span>
                        <%} %>
                    </td>
                            <td class="text-center">
                                <%= db.State.ToAlias() %> <span class="text-muted">(<%= ((int)db.CompatibilityLevel).ToString() %>)</span>
                            </td>
                            <td class="text-center"><%= db.RecoveryModel.ToAlias()%></td>
                            <%if (db.LogSizeMB.HasValue && db.LogSizeUsedMB.HasValue)
                    { %>
                        <td class="text-center" >
                            <%= (db.TotalSizeMB * 1024 * 1024).ToSize()%> <span class="text-muted">/ <%=(db.LogSizeMB.Value * 1024 * 1024).ToSize() %></span>
                        </td>
                   <% }
                    else
                    {%>
                        <td class="text-center"><%=((db.TotalSizeMB * 1024 * 1024).ToSize()) %></td>
                    <%} %>
                            <%if (bkup != null && bkup.LastBackupSizeBytes != null)
                    { %>
                        <td class="text-center"><%=(bkup.LastBackupStartDate.HasValue?bkup.LastBackupStartDate.Value.ToRelativeTime():"") %></td>
                        <td class="text-center">
                            <%if (bkup.LastFullBackupCompressedSizeBytes.HasValue)
                            {%>
                                <%= (bkup.LastFullBackupStartDate.HasValue? bkup.LastFullBackupStartDate.Value.ToRelativeTime(): "")%>
                                <span class="text-muted"><%= ((double)bkup.LastFullBackupCompressedSizeBytes.Value).ToSize() %></span>
                            <%} %>
                        </td>
                            <%
                    }
                    else
                    { %>
                        <td class="text-center text-warning">Not found</td>
                        <td class="text-center text-warning">Not found</td>
                    <%} %>
                        </tr>
                        <%} %>
                    </tbody>
                    <%--<% if (Model.StandaloneInstances.Any())
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
                            <td class="text-center"><%= HtmlHelper.HealthDescription(dbs) %></td>
                            <%= HtmlSQLHelper.ConnectionsCell(server) %>
                            <%= HtmlSQLHelper.BatchesCell(server) %>
                            <td class="text-center"><%= server.LastFetch.ToPollSpan() %></td>
                        </tr>
                        <%} %>
                    </tbody>
                    <%} %>--%>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="monitoringFooter" runat="server">
</asp:Content>
