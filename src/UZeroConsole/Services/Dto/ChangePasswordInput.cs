using U.Application.Services.Dto;

namespace UZeroConsole.Services.Dto
{
    public class ChangePasswordInput : IInputDto
    {
        /// <summary>
        /// 管理员Id
        /// </summary>
        public int AdminId { get; set; }

        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword { get; set; }
    }
}
