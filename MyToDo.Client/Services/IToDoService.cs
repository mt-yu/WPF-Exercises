using MyToDo.Share.Contact;
using MyToDo.Share.DataTransfers;
using MyToDo.Share.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyToDo.Client.Services
{
    public interface IToDoService : IBaseService<ToDoDto>
    {
        Task<ApiResponse<PagedList<ToDoDto>>> GetAllFilterAsync(ToDoParameter parameter);

        Task<ApiResponse<SummaryDto>> SummaryAsync();
    }
}
