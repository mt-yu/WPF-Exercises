using MyToDo.Share.DataTransfers;
using MyToDo.Share.Parameters;

namespace MyToDo.Api.Services
{
    public interface IToDoService : IBaseService<ToDoDto>
    {
        Task<ApiResponse> GetAllAsync(ToDoParameter parameter);
    }
}
