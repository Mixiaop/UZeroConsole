<%@ Page Title="" Language="C#" MasterPageFile="~/UZero/Monitoring/Monitoring.master" AutoEventWireup="true" CodeBehind="Servers.aspx.cs" Inherits="UZeroConsole.Web.UZero.Monitoring.Redis.Servers" %>

<%@ Import Namespace="UZeroConsole" %>
<%@ Import Namespace="UZeroConsole.Monitoring" %>
<%@ Import Namespace="UZeroConsole.Web.UZero.Monitoring" %>
<asp:Content ID="Content1" ContentPlaceHolderID="monitoringHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="monitoringBody" runat="server">
    <div class="content">
        <div class="col-lg-12">
            <div class="underline-nav">
                <nav class="underline-nav-body">
                    <a href="#" class="underline-nav-item selected" aria-selected="false" role="tab" title="Stars">所有服务器</a>
                </nav>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <input type="hidden" class="js-refresh-time" value="<%= Model.Refresh? 5: 0 %>" />
    <div class="content js-refresh" data-name="sql">
        <div class="block">
            <div class="block-content table-responsive">
                <table class="table table-hover js-dataTable-full ">
                    <thead>
                        <tr>
                            <th class="text-center">Name</th>
                            <th class="text-center">Host(port)</th>
                            <th class="text-center">Role</th>
                            <th class="text-center">Slaves</th>
                            <th class="text-center">Ops(sec)</th>
                            <th class="text-center">Memory(used)</th>
                            <th class="text-center">Clients</th>
                            <th class="text-center">最后更新</th>
                        </tr>
                    </thead>

                    <% if (Model.Instances.Any())
                        {
                            foreach (var server in Model.Instances.OrderBy(m => m.Port).ThenBy(m => m.Name))
                            {
                                var info = server.Info.SafeData();
                    %>

                    <tbody>
                        <tr>
                            <td class="text-center"><%= server.ConnectionInfo.Name %></td>
                            <td class="text-center"><%=  server.Host%> <span class="text-muted small">(<%= server.Port.ToString() %>)</span></td>
                            <td class="text-center">
                                <strong>Master</strong>
                            </td>
                            <td class="text-center">0</td>
                            <td class="text-center"><%= GetAllOps() %> <span class="text-muted small">(<%= GetAllOpsPerSec()%>)</span></td>
                            <td class="text-center"><%= GetAllMemory() %><span class="text-muted small">(<%= GetAllMemoryUsed() %>)</span></td>
                            <td class="text-center"><%= GetAllClients() %></td>
                            <td class="text-center"><%= server.LastFetch.ToPollSpan() %></td>
                        </tr>
                    </tbody>
                    <%}
                        } %>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="monitoringFooter" runat="server">
</asp:Content>
