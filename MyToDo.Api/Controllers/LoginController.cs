using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Services;
using MyToDo.Share.DataTransfers;

namespace MyToDo.Api.Controllers
{
    /// <summary>
    /// 登录账户控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService service;

        public LoginController(ILoginService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ApiResponse> Login([FromBody] UserDto user)
        {
            return await service.LoginAsync(user.Account, user.PassWord);
        }

        [HttpPost]
        public async Task<ApiResponse> Resgiter(UserDto user)
        {
            return await service.ResgiterAsync(user);
        }
    }
}
