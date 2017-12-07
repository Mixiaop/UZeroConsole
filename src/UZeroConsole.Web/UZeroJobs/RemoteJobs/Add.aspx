<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/UZero.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="UZeroConsole.Web.UZeroJobs.RemoteJobs.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <link href="/assets/js/plugins/jquery-tags-input/jquery.tagsinput.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
        <!-- Page Header -->
        <div class="content bg-gray-lighter">
            <div class="row items-push">
                <div class="col-sm-7">
                    <h1 class="page-heading">添加新任务<small></small>
                    </h1>
                </div>
                  <div class="col-sm-5 text-right hidden-xs">
                            <ol class="breadcrumb push-10-t">
                                <li><a class="link-effect" href="List.aspx">列表</a></li>
                                <li>添加新任务</li>
                            </ol>   
                        </div>
            </div>
        </div>
        <!-- END Page Header -->
        <!-- Page Content -->
        <div class="content">
            <!-- Dynamic Table Full -->
            <div class="block">
                <div class="block-content block-content-narrow">
                    <asp:Literal runat="server" ID="ltlMessage"></asp:Literal>
                    <div class="form-horizontal push-10-t">
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbName" CssClass="form-control" ></asp:TextBox>
                                    <label >任务名称</label>
                                </div>
                                <div class="help-block">
                                    如：保持活动
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbKey" CssClass="form-control"></asp:TextBox>
                                    <label >键名称</label>
                                </div>
                                <div class="help-block">
                                    唯一，如 Youzy.WebPC.KeepAlive
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbUrl" CssClass="form-control"></asp:TextBox>
                                    <label >任务链接</label>
                                </div>
                                <div class="help-block">
                                    触发的任务URL,如：http://www.youzy.cn/tasks/keepalive
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbDesc" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                    <label >简介</label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:DropDownList runat="server" ID="ddlType" CssClass="form-control">
                                        <asp:ListItem Text="普通" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="定时" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="循环" Value="30"></asp:ListItem>
                                    </asp:DropDownList>
                                    <label >任务类型</label>
                                </div>
                                <div class="help-block">
                                    【普通：开启即触发】【定时：特定时间】【重复：多久一次（秒)】
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbAtTime" CssClass="form-control"></asp:TextBox>
                                    <label >定时时间</label>
                                </div>
                                <div class="help-block">
                                    【定时任务时必填】，如：2017-11-11 12:22:22
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbRecurringTime" CssClass="form-control"></asp:TextBox>
                                    <label >循环时间（秒）</label>
                                </div>
                                <div class="help-block">
                                    【循环任务时必填】，如：300
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                                    <div class="col-xs-12">
                                        <div class="form-material">
                                            <asp:TextBox runat="server" ID="tbTags" CssClass="form-control"></asp:TextBox>
                                            <label>标签</label>
                                        </div>
                                        <div class="help-block">
                                            按“回车”添加新标签
                                        </div>
                                        <% if (Model.Tags.Count > 0)
                                           { %>
                                        <div class="tags">
                                            <% foreach (var tag in Model.Tags)
                                               { %>
                                            <a href="javascript:;"><%= tag.Name %></a> <%} %>
                                        </div>
                                        <%} %>
                                    </div>
                                </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary"  Text="添加"   />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END Dynamic Table Full -->
        </div>
        <!-- END Page Content -->
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="/assets/js/plugins/jquery-tags-input/jquery.tagsinput.min.js" type="text/javascript"></script>
    <script>
        $(function () {
            var $tags = $('.content .tags');
            var $tbTag = $('#<%= tbTags.ClientID %>');
            
            $tbTag.tagsInput({
                height: '36px',
                width: '100%',
                defaultText: '添加标签',
                removeWithBackspace: true,
                delimiter: [',']
            });

            $tags.find('a').on('click', function () {
                var val = $tbTag.val();
                var tag = $(this).text();

                if (val == '') {
                    $tbTag.addTag(tag);
                } else {
                    if (val.indexOf(tag) == -1) {
                        $tbTag.addTag(tag);
                    } else {
                        $tbTag.removeTag(tag);
                    }
                }
            });
        });
    </script>
</asp:Content>
