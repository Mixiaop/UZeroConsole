using U.Application.Services.Dto;
using UPrime.AutoMapper;
using UZeroConsole.Domain.Sso;

namespace UZeroConsole.Services.Sso.Dto
{
    [AutoMapFrom(typeof(App))]
    public class AppDto : EntityDto
    {
        /// <summary>
        /// 应用KEY
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// 应用密钥
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 应用返回URL（授权后）
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 是否系统（保留应用）
        /// </summary>
        public bool IsSystem { get; set; }

        public override string ToString()
        {
            return string.Format("{0}：{1}", Name, ReturnUrl);
        }
    }
}
