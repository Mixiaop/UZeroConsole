<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/UZero.Master" AutoEventWireup="true" CodeBehind="AppCreate.aspx.cs" Inherits="UZeroConsole.Web.UZero.Sso.AppCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
        <!-- Page Header -->
        <div class="content bg-gray-lighter">
            <div class="row items-push">
                <div class="col-sm-7">
                    <h1 class="page-heading">添加新应用<small></small>
                    </h1>
                </div>
                  <div class="col-sm-5 text-right hidden-xs">
                            <ol class="breadcrumb push-10-t">
                                <li><a class="link-effect" href="AppList.aspx">Sso应用列表</a></li>
                                <li>添加新应用</li>
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
                                    <asp:TextBox runat="server" ID="tbName" CssClass="form-control"></asp:TextBox>
                                    <label >名称</label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbRemark" TextMode="MultiLine" style="height:60px;" CssClass="form-control"></asp:TextBox>
                                    <label >备注</label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="form-material">
                                    <asp:TextBox runat="server" ID="tbReturnUrl" Text="http://" CssClass="form-control"></asp:TextBox>
                                    <div class="help-block">如 http://consovlev4.youzy.cn</div>
                                    <label >回调Url</label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary"  Text="提交"   />
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
</asp:Content>
