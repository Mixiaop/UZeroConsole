using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U;
using U.Utilities.Web;
using U.Utilities.Security;
using U.Settings;
using U.Application.Services.Dto;
using UZeroConsole.Configuration;
using UZeroConsole.Domain;
using UZeroConsole.Domain.Sso;
using UZeroConsole.Domain.Sso.Repositories;

namespace UZeroConsole.Services.Installation
{
    public class SqlServerInstallationService : ApplicationServiceBase, IInstallationService
    {
        DatabaseSettings _settings;
        ISettingsManager _settingsManager;
        
        public SqlServerInstallationService(DatabaseSettings settings, ISettingsManager settingsManager) {
            _settings = settings;
            _settingsManager = settingsManager;
        }

        /// <summary>
        /// 是否已安装
        /// </summary>
        /// <returns></returns>
        public bool IsInstalled() {
            return _settings.Installed;
        }

        /// <summary>
        /// 启动安装，初始化数据库表并创建管理员帐号（admin）等权限信息
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="adminPassword">管理员密码</param>
        /// <returns></returns>
        public StateOutput Install(string connectionString, string adminPassword) {
            StateOutput res = new StateOutput();

            if (!IsInstalled())
            {
                try
                {
                    _settings.ReadonlySqlConnectionString = connectionString;
                    _settings.SqlConnectionString = connectionString;
                    _settingsManager.SaveSettings(_settings);

                    IAdminRepository adminRepository = UPrimeEngine.Instance.Resolve<IAdminRepository>();
                    adminRepository.ExecuteSqlFile(connectionString, WebHelper.MapPath("~/App_Data/Install/create_tables.sql"));

                    #region 初始化数据
                    IAppRepository appRepository = UPrimeEngine.Instance.Resolve<IAppRepository>();
                    IPermissionRepository permissionRepository = UPrimeEngine.Instance.Resolve<IPermissionRepository>();
                    var app = new App();
                    app.IsSystem = true;
                    app.AppKey = Guid.NewGuid().ToString().Replace("-", "").Trim();
                    app.SecretKey = Guid.NewGuid().ToString().Replace("-", "").Trim();
                    app.Name = "默认控制台";
                    app.Id = appRepository.InsertAndGetId(app);

                    #region Create permissions
                    var root = new Permission();
                    root.SsoAppId = app.Id;
                    root.IsSystem = true;
                    root.Name = "控制台 UZero";
                    root.ParentId = 0;
                    root.Level = 1;
                    root.Order = -100;
                    root.Id = permissionRepository.InsertAndGetId(root);

                    var menu1 = new Permission();
                    menu1.SsoAppId = app.Id;
                    menu1.IsSystem = true;
                    menu1.Name = "权限";
                    menu1.Url = "/UZero/PermissionList.aspx";
                    menu1.ParentId = root.Id;
                    menu1.Level = 2;
                    menu1.Order = 1;
                    menu1.Id = permissionRepository.InsertAndGetId(menu1);

                    var menu2 = new Permission();
                    menu2.SsoAppId = app.Id;
                    menu2.IsSystem = true;
                    menu2.Name = "角色";
                    menu2.Url = "/UZero/RoleList.aspx";
                    menu2.ParentId = root.Id;
                    menu2.Level = 2;
                    menu2.Order = 2;
                    menu2.Id = permissionRepository.InsertAndGetId(menu2);

                    var menu3 = new Permission();
                    menu3.SsoAppId = app.Id;
                    menu3.IsSystem = true;
                    menu3.Name = "管理员";
                    menu3.Url = "/UZero/AdminList.aspx";
                    menu3.ParentId = root.Id;
                    menu3.Level = 2;
                    menu3.Order = 3;
                    menu3.Id = permissionRepository.InsertAndGetId(menu3);

                    var menu4 = new Permission();
                    menu4.SsoAppId = app.Id;
                    menu4.IsSystem = true;
                    menu4.Name = "单点登录 Sso";
                    menu4.ParentId = root.Id;
                    menu4.Level = 2;
                    menu4.Order = 0;
                    menu4.Id = permissionRepository.InsertAndGetId(menu4);

                    var menu5 = new Permission();
                    menu5.SsoAppId = app.Id;
                    menu5.IsSystem = true;
                    menu5.Name = "应用列表";
                    menu5.Url = "/UZero/Sso/AppList.aspx";
                    menu5.ParentId = menu4.Id;
                    menu5.Level = 3;
                    menu5.Order = 1;
                    menu5.Id = permissionRepository.InsertAndGetId(menu5);

                    var menu6 = new Permission();
                    menu6.SsoAppId = app.Id;
                    menu6.IsSystem = true;
                    menu6.Name = "日志 Logs";
                    menu6.Url = "";
                    menu6.ParentId = root.Id;
                    menu6.Level = 2;
                    menu6.Order = 21;
                    menu6.Id = permissionRepository.InsertAndGetId(menu6);

                    var menu7 = new Permission();
                    menu7.SsoAppId = app.Id;
                    menu7.IsSystem = true;
                    menu7.Name = "所有应用";
                    menu7.Url = "/UZeroLogging/LogApps/List.aspx";
                    menu7.ParentId = menu6.Id;
                    menu7.Level = 3;
                    menu7.Order = 1;
                    menu7.Id = permissionRepository.InsertAndGetId(menu7);

                    var menu8 = new Permission();
                    menu8.SsoAppId = app.Id;
                    menu8.IsSystem = true;
                    menu8.Name = "任务 Jobs";
                    menu8.Url = "";
                    menu8.ParentId = root.Id;
                    menu8.Level = 2;
                    menu8.Order = 20;
                    menu8.Id = permissionRepository.InsertAndGetId(menu8);

                    var menu9 = new Permission();
                    menu9.SsoAppId = app.Id;
                    menu9.IsSystem = true;
                    menu9.Name = "所有任务";
                    menu9.Url = "/UZeroJobs/RemoteJobs/List.aspx";
                    menu9.ParentId = menu8.Id;
                    menu9.Level = 3;
                    menu9.Order = 1;
                    menu9.Id = permissionRepository.InsertAndGetId(menu9);

                    var menu10 = new Permission();
                    menu10.SsoAppId = app.Id;
                    menu10.IsSystem = true;
                    menu10.Name = "监控台";
                    menu10.Url = "/jobs";
                    menu10.ParentId = menu8.Id;
                    menu10.Level = 3;
                    menu10.Order = 2;
                    menu10.Id = permissionRepository.InsertAndGetId(menu10);

                    var menu11 = new Permission();
                    menu11.SsoAppId = app.Id;
                    menu11.IsSystem = true;
                    menu11.Name = "配置 Settings";
                    menu11.Url = "";
                    menu11.ParentId = root.Id;
                    menu11.Level = 2;
                    menu11.Order = -1;
                    menu11.Id = permissionRepository.InsertAndGetId(menu11);

                    var menu12 = new Permission();
                    menu12.SsoAppId = app.Id;
                    menu12.IsSystem = true;
                    menu12.Name = "通用";
                    menu12.Url = "/UZero/Configuration/SetConsoleSettings.aspx";
                    menu12.ParentId = menu11.Id;
                    menu12.Level = 3;
                    menu12.Order = 1;
                    menu12.Id = permissionRepository.InsertAndGetId(menu12);

                    var menu13 = new Permission();
                    menu13.SsoAppId = app.Id;
                    menu13.IsSystem = true;
                    menu13.Name = "企业微信";
                    menu13.Url = "/UZero/Configuration/SetCorpWeixinSettings.aspx";
                    menu13.ParentId = menu11.Id;
                    menu13.Level = 3;
                    menu13.Order = 2;
                    menu13.Id = permissionRepository.InsertAndGetId(menu13);

                    //var menu14 = new Permission();
                    //menu14.SsoAppId = app.Id;
                    //menu14.IsSystem = true;
                    //menu14.Name = "日志";
                    //menu14.Url = "/UZero/Configuration/SetLoggingSettings.aspx";
                    //menu14.ParentId = menu11.Id;
                    //menu14.Level = 3;
                    //menu14.Order = 3;
                    //menu14.Id = permissionRepository.InsertAndGetId(menu14);
                    #endregion

                    #region Create admin
                    if (adminPassword.IsNullOrEmpty())
                        adminPassword = Admin.AdminDefaultPassword;

                    Admin admin = new Admin();
                    admin.Username = Admin.AdminUserName;
                    admin.Password = EncriptionHelper.MD5(adminPassword);
                    admin.Name = "超级管理员";
                    admin.CreationTime = DateTime.Now;
                    admin.LastLoginTime = DateTime.Now;
                    adminRepository.Insert(admin);

                    #endregion

                    #endregion

                    _settings.Installed = true;
                    _settingsManager.SaveSettings(_settings);
                }
                catch (Exception ex) {
                    res.AddError("连接字符串有问题请检查【" + ex.Message + "】");
                }
            }
            else {
                res.AddError("已被初始化安装过。");
            }
            
            return res;
        }
    }
}
