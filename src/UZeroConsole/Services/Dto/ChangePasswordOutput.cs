using U.Application.Services.Dto;
namespace UZeroConsole.Services.Dto
{
    public  class ChangePasswordOutput:IOutputDto
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
    }
}
