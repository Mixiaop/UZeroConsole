<%@ Page Title="" Language="C#" MasterPageFile="~/UZero/Monitoring/Monitoring.master" AutoEventWireup="true" CodeBehind="Servers.aspx.cs" Inherits="UZeroConsole.Web.UZero.Monitoring.SQL.Servers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="monitoringHeader" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="monitoringBody" runat="server">
    <div class="content">
        <div class="col-lg-12">
            <div class="underline-nav">
                <nav class="underline-nav-body">
                    <a href="/Mixiaop?tab=stars" class="underline-nav-item selected" aria-selected="false" role="tab" title="Stars">所有服务器</a>
                    <a href="/Mixiaop?tab=stars" class="underline-nav-item " aria-selected="false" role="tab" title="Stars">数据库</a>
                </nav>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="content">
        <div class="block">
                <div class="block-content">
                    <table class="table table-hover js-dataTable-full">
                        <thead>
                            <tr>
                                <th class="text-center">Node</th>
                                <th class="text-center">CPU</th>
                                <th class="text-center">Memory</th>
                                <th class="text-center">数据库</th>
                                <th class="text-center">连接数 / Sess</th>
                                <th class="text-center">Batches / 秒</th>
                                <th class="text-center">最后更新</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="monitoringFooter" runat="server">
</asp:Content>
