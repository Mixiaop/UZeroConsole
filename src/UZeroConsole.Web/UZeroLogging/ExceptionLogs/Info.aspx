<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/UZero.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="UZeroConsole.Web.UZeroLogging.ExceptionLogs.Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <!-- Page Header -->
    <div class="content bg-gray-lighter">
        <div class="row items-push">
            <div class="col-sm-7">
                <h1 class="page-heading"><%= Model.Log.App.Name %>的异常信息 <small><%= Model.Log.CreationTime.ToString("yyyy-MM-dd HH:mm:ss") %></small>
                </h1>
            </div>
            <div class="col-sm-5 text-right hidden-xs">
                <ol class="breadcrumb push-10-t">
                    <li><a class="link-effect" href="List.aspx?appId=<%= Model.Log.AppId %>">薪资列表</a></li>
                    <li>异常信息</li>
                </ol>
            </div>
        </div>
    </div>
    <!-- END Page Header -->
    <!-- Page Content -->
    <div class="content pt0" >
        <!-- Addresses -->
        <div class="block">

            <div class="block-content">
                <div class="row">
                    <div class="col-lg-12">
                        <!-- Billing Address -->
                        <div class="block block-bordered">
                            <div class="block-header">
                                <h3 class="block-title">异常 Exception</h3>
                            </div>
                            <div class="block-content block-content-full">
                                <div>
                                    <span class="text-gray-dark">Machine：</span><%= Model.Log.MachineName %><br />
                                    <span class="text-gray-dark">Type：</span><%= Model.Log.Type %><br>
                                    <span class="text-gray-dark">IP：</span><%= Model.Log.IpAddress %><br>
                                    <span class="text-gray-dark">Host：</span><%= Model.Log.Host %><br>
                                    <span class="text-gray-dark">Url：</span><%= Model.Log.Url %><br>
                                    <span class="text-gray-dark">User Agent：</span><%= Model.Log.UserAgent %><br>
                                    <span class="text-gray-dark">HttpMethod：</span><%= Model.Log.HttpMethod %><br>
                                    <span class="text-gray-dark">StatusCode：</span><%= Model.Log.StatusCode %><br>
                                    <br>
                                   
                                </div>
                            </div>

                            <div class="block-content block-content-full">
                                <div class="h4 push-5">详细信息</div>
                                <span class="text-gray-dark" >Message：</span><%= Model.Log.ShortMessage %><br><br />
                                <div style="background:#FFFFCC;">
                                    <%= Model.Log.FullMessage %>
                                <br>
                                    </div>
                            </div>
                        </div>
                        <!-- END Billing Address -->
                    </div>
                </div>
            </div>
        </div>
        <!-- END Addresses -->
    </div>
    <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
