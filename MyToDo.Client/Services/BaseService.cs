using MyToDo.Share.Contact;
using MyToDo.Share.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Client.Services
{
    public class BaseService<Tentity> : IBaseService<Tentity> where Tentity : class
    {
        private readonly HttpRestClient client;
        private readonly string serviceName;

        public BaseService(HttpRestClient client, string serviceName)
        {
            this.client = client;
            this.serviceName = serviceName;
        }

        public async Task<ApiResponse<Tentity>> AddAsync(Tentity entity)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Add";
            request.Parameter = entity;
            return await client.ExecuteAsync<Tentity>(request);
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Delete;
            request.Route = $"api/{serviceName}/Delete";
            request.Query = $"id={id}";
            return await client.ExecuteAsync(request);
        }

        public async Task<ApiResponse<PagedList<Tentity>>> GetAllAsync(QueryParameter parameter)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{serviceName}/GetAll";
            request.Query = $"pageIndex={parameter.PageIndex}&pageSize={parameter.PageSize}&search={parameter.Search}";

            return await client.ExecuteAsync<PagedList<Tentity>>(request);
        }

        public async Task<ApiResponse<Tentity>> GetFirstOfDefaultAsync(int id)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{serviceName}/Get";
            request.Query = $"id={id}";
            return await client.ExecuteAsync<Tentity>(request);
        }

        public async Task<ApiResponse<Tentity>> UpdateAsync(Tentity entity)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Update";
            request.Parameter = entity;
            return await client.ExecuteAsync<Tentity>(request);
        }
    }
}
