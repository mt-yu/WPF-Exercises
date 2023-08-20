using MyToDo.Share.DataTransfers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Client.Services
{
    public interface ILoginService
    {
        Task<ApiResponse> LoginAsync(UserDto user);
        Task<ApiResponse> RegisterAsync(UserDto user);
    }
}
