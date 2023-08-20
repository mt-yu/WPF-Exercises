using MyToDo.Share.Contact;
using MyToDo.Share.DataTransfers;
using MyToDo.Share.Parameters;
using System.Threading.Tasks;

namespace MyToDo.Client.Services
{
    public class ToDoService : BaseService<ToDoDto>, IToDoService
    {

        public ToDoService(HttpRestClient client) : base(client, "ToDo")
        {
        }

        public async Task<ApiResponse<PagedList<ToDoDto>>> GetAllFilterAsync(ToDoParameter parameter)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{ServiceName}/GetAll";
            request.Query = $"pageIndex={parameter.PageIndex}" +
                $"&pageSize={parameter.PageSize}" +
                $"&search={parameter.Search}" +
                $"&status={parameter.Status}";

            return await Client.ExecuteAsync<PagedList<ToDoDto>>(request);
        }

        public async Task<ApiResponse<SummaryDto>> SummaryAsync()
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{ServiceName}/Summary";
            return await Client.ExecuteAsync<SummaryDto> (request);
        }
    }
}
