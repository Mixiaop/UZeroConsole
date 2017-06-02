using System.ComponentModel.DataAnnotations;
using U.Application.Services.Dto;

namespace UZeroConsole.Services.Dto
{
    public class SearchPermissionInput : IInputDto, IPagedResultRequest
    {
        /// <summary>
        ///  菜单栏层次(多级菜单)
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 跳过多少条
        /// </summary>
        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        /// <summary>
        /// 页数（多少条）
        /// </summary>
        [Range(10, 100, ErrorMessage = "页数范围（10-100）")]
        public int MaxResultCount { get; set; }
    }
}
