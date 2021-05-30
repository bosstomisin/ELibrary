using ELibrary.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ELibrary.Core.Abstractions
{
    public interface IAuthServices
    {
        Task<ResponseDto<string>> ForgetPasswordAsync(string email, IUrlHelper url, string requestScheme);

        Task<ResponseDto<string>> ResetPasswordAsync(ResetPasswordDto model);
    }
}
