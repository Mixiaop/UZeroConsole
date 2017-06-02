using System.ComponentModel.DataAnnotations;
using U.Application.Services.Dto;

namespace UZeroConsole.Services.Dto
{
    public class SearchAdminInput : IInputDto
    {
        /// <summary>
        /// 关键字（如：管理员用户名、姓名、邮箱、角色等）
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 多少条
        /// </summary>
        public int PageSize { get; set; }

    }
}
