using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using U;
using UZeroConsole.Domain;
using UZeroConsole.Services;
using UZeroConsole.EntityFramework.Repositories;

namespace UZeroConsole.Web._Tests
{
    public partial class RepositoryTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var adminRepository = UPrimeEngine.Instance.Resolve<AdminRepository>();
            var roleRepository = UPrimeEngine.Instance.Resolve<RoleRepository>();

            //roleRepository.Context = adminRepository.Context;
            
            var admin = adminRepository.Get(5);
            //var role = roleRepository.Get(5);

            //admin.Roles.Add(role);


            //admin.Roles.Clear();
            //adminRepository.Update(admin);
            //Response.Write(JsonConvert.SerializeObject(admin));

            //List<int> roleList = new List<int>();
            //roleList.Add(4);
            //roleList.Add(6);

            //var service = UPrimeEngine.Instance.Resolve<IAdminService>();
            //service.SetRoles(5, roleList);

        }
    }
}