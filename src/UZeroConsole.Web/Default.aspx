<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UZeroConsole.Web.Default" %>
<!DOCTYPE html>
<!--[if IE 9]>         <html class="ie9 no-focus"> <![endif]-->
<!--[if gt IE 9]><!-->
<html class="no-focus">
<!--<![endif]-->
<head>
    <meta charset="utf-8">
    <title><%= this.Settings.Title %></title>
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0">
    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <link rel="shortcut icon" href="/assets/img/favicons/favicon.png">
    <!-- END Icons -->
    <!-- Stylesheets -->
    <!-- Page JS Plugins CSS -->
    <link rel="stylesheet" href="/assets/js/plugins/datatables/jquery.dataTables.min.css">

    <!-- OneUI CSS framework -->
    <link rel="stylesheet" id="css-main" href="/assets/css/oneui.css">

    <!-- You can include a specific file from css/themes/ folder to alter the default color theme of the template. eg: -->
    <!-- <link rel="stylesheet" id="css-theme" href="/assets/css/themes/flat.min.css"> -->
    <style type="text/css">
        
        #main-container {
            position:relative;
            z-index:100;
            background:none;
        }
        #page-container {
            background:none;
        }
        .side-teambar {
            margin: 0 auto;
            padding:13px 20px 1px;
            max-width: 100%;
        }
        .teambar{
            width:100%;
            margin: 0 -20px;
            border-left:3px solid #BD4A39;
            padding-left:10px;
        }
            .teambar>button {
                background:#212330;
                font-weight:normal;
                font-size:15px !important;
                font-family:'Microsoft YaHei';
                border:0;
                color:#666 !important;
                text-align:left;
            }
                .teambar>button i {
                    font-size:15px !important;
                    color:#666;
                    margin-left:5px;
                }
    </style>
    <!-- END Stylesheets -->
</head>
<body style="overflow:hidden;">
    <form runat="server"></form>
    <!-- Page Container -->
    <!--
            Available Classes:

            'sidebar-l'                  Left Sidebar and right Side Overlay
            'sidebar-r'                  Right Sidebar and left Side Overlay
            'sidebar-mini'               Mini hoverable Sidebar (> 991px)
            'sidebar-o'                  Visible Sidebar by default (> 991px)
            'sidebar-o-xs'               Visible Sidebar by default (< 992px)

            'side-overlay-hover'         Hoverable Side Overlay (> 991px)
            'side-overlay-o'             Visible Side Overlay by default (> 991px)

            'side-scroll'                Enables custom scrolling on Sidebar and Side Overlay instead of native scrolling (> 991px)

            'header-navbar-fixed'        Enables fixed header
        -->
    <div id="page-container" class="sidebar-l sidebar-o side-scroll">
        <!-- Sidebar -->
        <nav id="sidebar">
            <!-- Sidebar Scroll Container -->
            <div id="sidebar-scroll">
                <!-- Sidebar Content -->
                <!-- Adding .sidebar-mini-hide to an element will hide it when the sidebar is in mini mode -->
                <div class="sidebar-content">
                    <!-- Side Header -->
                    <div class="side-header side-content bg-white-op">
                        <!-- Layout API, functionality initialized in App() -> uiLayoutApi() -->
                        <button class="btn btn-link text-gray pull-right hidden-md hidden-lg" type="button" data-toggle="layout" data-action="sidebar_close">
                            <i class="fa fa-times"></i>
                        </button>
                        <!-- Themes functionality initialized in App() -> uiHandleTheme() -->
                        <a class="h5 text-white" href="/">
                            <img src="/assets/img/logo.png" />
                        </a>
                    </div>
                    <!-- END Side Header -->
                    <% if (Model.IsOpendSso)
                        { %>
                    <div class="side-teambar">
                            <div class="btn-group btn-group-xs teambar">
                                            <button class="btn btn-default title" data-toggle="dropdown" type="button"><%= Model.CurrentApp!=null?Model.CurrentApp.Name:"" %> <i class="fa fa-caret-down"></i></button>
                                <%if (Model.Apps != null)
                                                         { %>
                                            <ul class="dropdown-menu dropdown-menu-left">
                                                <% 
                                                             foreach (var app in Model.Apps)
                                                             {
                                                                 if (app.Id != Model.CurrentApp.Id)
                                                                 {
                                                       %>
                                                <li>
                                                    <a tabindex="-1" href="<%= app.ReturnUrl %>"  class="btnUsedTeam"><i class="si si-cup"></i> &nbsp;<%= app.Name %></a>
                                                </li>
                                                <%}
                                                             }
                                                        %>
                                                <%--<li class="divider"></li>--%>
                                                <% if(this.Settings.UNoteExternalLoginOpened && this.CurrentAdmin.UNoteUsername.IsNotNullOrEmpty()) { %>
                                                <li class="divider"></li>
                                                <li>
                                                    <a tabindex="-1" href="<%= string.Format("{0}?appkey={1}&username={2}", this.Settings.UNoteExternalLoginUrl, this.Settings.UNoteAppKey, this.CurrentAdmin.UNoteUsername) %>" target="_blank"  class="btnUsedTeam"><i class="si si-cup"></i> &nbsp;UNote 笔记</a>
                                                </li>
                                                <%} %>
                                            </ul>
                                <%} %>
                                        </div>
                        </div>
                    <%} %>
                    <% var Permissions = Model.Permissions; %>
                    <!-- Side Content -->
                    <div class="side-content" id="leftmenu">
                        <ul class="nav-main">
                            <% foreach (var level1 in Permissions.Where(x => x.Level == 1))
                               {
                                   var level2List = Permissions.Where(x => x.ParentId == level1.Id);
                            %>
                            <li>
                                <a <%= level2List.Count()>0?"class=\"nav-submenu\" data-toggle=\"nav-submenu\"":"" %> href="#" <%= string.IsNullOrEmpty(level1.Url)?"":"data-url=\""+level1.Url+"\"" %>>
                                    <i class="si <%= level1.Icon  %>"></i><span class="sidebar-mini-hide"><%= level1.Name %></span></a>
                                <% if(level2List.Count()>0){ %>
                                <ul>
                                    <%     
                                        foreach (var level2 in level2List)
                                        {
                                            var level3List = Permissions.Where(x => x.ParentId == level2.Id);
                                    %>
                                    <li>
                                        <a <%= level3List.Count()>0?"class=\"nav-submenu\" data-toggle=\"nav-submenu\"":"" %> href="#" <%= string.IsNullOrEmpty(level2.Url)?"":"data-url=\""+level2.Url+"\"" %>><%= level2.Name %></a>
                                        <% if(level3List.Count()>0){ %>
                                        <ul>
                                            <% foreach(var level3 in level3List){ %>
                                            <li><a href="#" <%= string.IsNullOrEmpty(level3.Url)?"":"data-url=\""+level3.Url+"\"" %>><%= level3.Name %></a></li>
                                            <%} %>
                                        </ul>
                                        <%} %>
                                    </li>
                                    <%} %>
                                </ul>
                                <%} %>
                            </li>
                            <%} %>
                        </ul>
                    </div>
                    <!-- END Side Content -->
                </div>
                <!-- Sidebar Content -->
            </div>
            <!-- END Sidebar Scroll Container -->
        </nav>
        <!-- END Sidebar -->

        <!-- Header -->
        <header id="header-navbar" class="content-mini content-mini-full">
            <!-- Header Navigation Right -->
                <ul class="nav-header pull-right">
                    <li>
                        <div class="btn-group">
                            <button class="btn btn-default btn-image dropdown-toggle" data-toggle="dropdown" type="button">
                                <img src="/assets/img/favicons/favicon.png" alt="Avatar">
                                <%= CurrentAdmin.Name %>
                                <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu dropdown-menu-right">
                               <%-- <li class="dropdown-header">个人信息</li>--%>
                                <li>
                                    <a tabindex="-1" href="javascript:void(0)" data-toggle="modal" data-target="#modalChangePassword">
                                        <i class="si si-key pull-right"></i>修改密码
                                    </a>
                                </li>
                                <li class="divider"></li>
                                <li>
                                    <a tabindex="-1" href="/Logout.aspx">
                                        <i class="si si-logout pull-right"></i>退出
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </li>
                </ul>
                <!-- END Header Navigation Right -->

            <!-- Header Navigation Left -->
                <ul class="nav-header pull-left">
                <li class="hidden-md hidden-lg">
                    <!-- Layout API, functionality initialized in App() -> uiLayoutApi() -->
                    <button class="btn btn-default" data-toggle="layout" data-action="sidebar_toggle" type="button">
                        <i class="fa fa-navicon"></i>
                    </button>
                </li>
                <li class="hidden-xs hidden-sm">
                    <!-- Layout API, functionality initialized in App() -> uiLayoutApi() -->
                    <button class="btn btn-default" data-toggle="layout" data-action="sidebar_mini_toggle" type="button" id="hiddenMenu">
                        <i class="fa fa-ellipsis-v"></i>
                    </button>
                </li>
            </ul>
            <!-- END Header Navigation Left -->
        </header>
        <!-- END Header -->
        <!-- Main Container -->
        <main id="main-container"   >
            <iframe id="mainFrame" frameborder="0" style="height:500px;"  name="mainFrame" src="UZero/Dashboard.aspx"></iframe>
            </main>
        <!-- END Main Container -->
    </div>
    <!-- END Page Container -->

    <!-- Modal -->
    <div class="modal fade" id="modalChangePassword" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-popin">
            <div class="modal-content">
                <div class="block block-themed block-transparent remove-margin-b">
                    <div class="block-header bg-primary-dark">
                        <ul class="block-options">
                            <li>
                                <button data-dismiss="modal" type="button"><i class="si si-close"></i></button>
                            </li>
                        </ul>
                        <h3 class="block-title"><i class="fa fa-key"></i> 修改密码</h3>
                    </div>
                    <div class="block-content">
                        <div class="form-horizontal push-10-t">
                            <div class="alert alert-danger hide">
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <div class="form-material ">
                                        <input class="form-control" type="password" name="oldPassword">
                                        <label >原密码</label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <div class="form-material">
                                        <input class="form-control" type="password" name="newPassword">
                                        <label >新密码</label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <div class="form-material">
                                        <input class="form-control" type="password" name="newPassword2">
                                        <label >确认密码</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <input type="hidden" id="hfAdminId" value="<%= CurrentAdmin.Id %>" />
                </div>
                <div class="modal-footer">
                    <button class="btn  btn-primary" type="button" >确认修改</button>
                    <button class="btn  btn-default" type="button" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>
    <!-- END Modal-->
    <!-- OneUI Core JS: jQuery, Bootstrap, slimScroll, scrollLock, Appear, CountTo, Placeholder, Cookie and App.js -->
    <script src="/assets/js/core/jquery.min.js"></script>
    <script src="/assets/js/core/bootstrap.min.js"></script>
    <script src="/assets/js/core/jquery.slimscroll.min.js"></script>
    <script src="/assets/js/core/jquery.scrollLock.min.js"></script>
    <script src="/assets/js/core/jquery.appear.min.js"></script>
    <script src="/assets/js/core/jquery.countTo.min.js"></script>
    <script src="/assets/js/core/jquery.placeholder.min.js"></script>
    <script src="/assets/js/core/js.cookie.min.js"></script>
    <script src="/assets/js/plugins/bootstrap-notify/bootstrap-notify.min.js"></script>
    <script src="/assets/js/notify.service.js"></script>
    <script src="/assets/js/app.js"></script>
    <script src="default.js?time=<%= DateTime.Now.Ticks %>"></script>
</body>
</html>
