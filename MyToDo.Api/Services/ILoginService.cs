using MyToDo.Share.DataTransfers;

namespace MyToDo.Api.Services
{
    public interface ILoginService
    {
        Task<ApiResponse> LoginAsync(string Account, string Password);

        Task<ApiResponse> ResgiterAsync(UserDto user);
    }
}
