using System.ComponentModel.DataAnnotations;
using U.Application.Services.Dto;

namespace UZeroConsole.Services.Dto
{
    public class CreateOrZeroUserInput : IInputDto
    {
        /// <summary>
        /// 优志愿Zero控制台UserId
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Required]
        public string NickName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
