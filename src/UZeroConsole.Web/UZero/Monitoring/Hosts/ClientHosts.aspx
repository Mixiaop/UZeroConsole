<%@ Page Title="" Language="C#" MasterPageFile="~/UZero/Monitoring/Monitoring.master" AutoEventWireup="true" CodeBehind="ClientHosts.aspx.cs" Inherits="UZeroConsole.Web.UZero.Monitoring.Hosts.ClientHosts" %>
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
                    <a href="#" class="underline-nav-item selected" aria-selected="false" role="tab" title="Stars">所有主机</a>
                </nav>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <input type="hidden" class="js-refresh-time" value="3" />
    <div class="content js-refresh" data-name="hosts">
        <div class="block">
            <div class="block-content table-responsive">
                <table class="table table-hover js-dataTable-full">
                    <thead>
                        <tr>
                            <th class="text-center">Id</th>
                            <th class="text-center">Name</th>
                            <th class="text-center">Ip</th>
                            <th class="text-center">CPU</th>
                            <th class="text-center">Memory</th>
                            <th class="text-center">容量</th>
                            <th class="text-center">当前连接数（Web)</th>
                            <th class="text-center">最后更新</th>
                        </tr>
                    </thead>
                    <% if (Hosts.Any())
                        { %>
                    <tbody>
                        <%foreach (var host in Hosts)
                            {
                        %>
                        <tr>
                            <td class="text-center"><%= host.Id %></td>
                            <td class="text-center"><%= host.Name %></td>
                            <td class="text-center"><%= host.Ip %></td>
                            <td class="text-center"><%= host.CPUUsagePercent + "%" %></td>
                            <td class="text-center"><%= host.RAMUsedPercent + "%" %></td>
                            <td class="text-center">
                                <%  var volumes = host.Disks;
                                    if (volumes != null && volumes.Any())
                                    {
                                        foreach (var v in volumes)
                                        {
                                            v.TotalSize = v.TotalSize / 1024;
                                            v.UsedSpace = v.UsedSpace / 1024;
                                            v.FreeTotalSpace = v.FreeTotalSpace / 1024;
                                            var percentUsed = 100 * (v.UsedSpace / 1024) / (v.TotalSize / 1024);
                                %>
                                <span><%= v.Name %>：<%= Math.Round(v.FreeTotalSpace,1) + "GB" %> 空闲</span>&nbsp;&nbsp;&nbsp;
                                <%--<div class="progress">
                                    <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" style="width:<%= percentUsed.ToString() %>%">
                                        <%= (v.Name) %> <%= (Math.Round(v.TotalSize, 1)) + "GB" %> / <%= Math.Round(v.UsedSpace, 1) + "GB" %> ( <%= Math.Round(v.FreeTotalSpace,1) + "GB" %> 空闲 )
                                    </div>
                                </div>--%>

                                <%}
                                } %>
                            </td>
                            <td class="text-center"><%= (int)host.WebService_CurrentConnections %></td>
                            <td class="text-center"><%= host.LastUpdate.ToDateTime().ToRelativeTime() %></td>
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
