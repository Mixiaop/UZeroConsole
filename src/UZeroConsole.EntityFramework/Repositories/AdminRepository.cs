using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using UZeroConsole.Domain;

namespace UZeroConsole.EntityFramework.Repositories
{
    public class AdminRepository : UZeroConsoleRepositoryBase<Admin>, IAdminRepository
    {
        private RoleRepository _roleRepository;
        public AdminRepository(UZeroConsoleDbContext databaseProvider, RoleRepository roleRepository) : base(databaseProvider) {
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// 为管理员设置角色，设置时会清除原来的角色
        /// </summary>
        /// <param name="adminId">管理员Id</param>
        /// <param name="roleIds">角色Id列表</param>
        public void SetRoles(int adminId, List<int> roleIds)
        {
            _roleRepository.Context = this.Context;

            var admin = this.Get(adminId);
            if (admin != null) {
                if (admin.Roles != null)
                {
                    admin.Roles.Clear();
                    this.Update(admin); //clear all
                }
                else {
                    admin.Roles = new List<Role>();
                }

                var query = _roleRepository.GetAll().Where(x => roleIds.Contains(x.Id));
                var roleList = query.ToList();
                if (roleList != null) {
                    foreach (var role in roleList)
                        admin.Roles.Add(role);

                    this.Update(admin);
                }
            }
        }

        /// <summary>
        /// 执行.sql的文件
        /// </summary>
        /// <param name="connectionStr"></param>
        /// <param name="filePath"></param>
        public void ExecuteSqlFile(string connectionStr, string filePath) {

            //var statements = new List<string>();

            //using (var stream = File.OpenRead(filePath))
            //using (var reader = new StreamReader(stream))
            //{
            //    string statement;
            //    while ((statement = ReadNextStatementFromStream(reader)) != null)
            //        statements.Add(statement);
            //}

            //foreach (string stmt in statements)
            //    this.Context.ExecuteSqlCommand(stmt);

            FileInfo file = new FileInfo(filePath);
            string script = file.OpenText().ReadToEnd();
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandText = script.Replace("GO", ";");
            command.ExecuteNonQuery();
            conn.Close();
        }


        protected virtual string ReadNextStatementFromStream(StreamReader reader)
        {
            var sb = new StringBuilder();
            while (true)
            {
                var lineOfText = reader.ReadLine();
                if (lineOfText == null)
                {
                    if (sb.Length > 0)
                        return sb.ToString();

                    return null;
                }

                if (lineOfText.TrimEnd().ToUpper() == "GO")
                    break;

                sb.Append(lineOfText + Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
