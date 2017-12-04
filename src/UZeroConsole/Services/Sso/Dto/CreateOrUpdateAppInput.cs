namespace UZeroConsole.Services.Sso.Dto
{
    /// <summary>
    /// 创建应用
    /// </summary>
    public class CreateOrUpdateAppInput : U.Application.Services.Dto.EntityDto
    {
        public string Name { get; set; }

        public string Remark { get; set; }

        public string ReturnUrl { get; set; }
    }
}
