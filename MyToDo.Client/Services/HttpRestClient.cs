using DryIoc;
using ImTools;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyToDo.Client.Services
{
    /*
     * 以下类封装 参考 postman 中提供的代码进行封装, 代码如下
        var options = new RestClientOptions("http://localhost:5030")
        {
            MaxTimeout = -1,
        };
        var client = new RestClient(options);
        var request = new RestRequest("/api/ToDo/Get?id=2", Method.Get);
        RestResponse response = await client.ExecuteAsync(request);
        Console.WriteLine(response.Content);
    */
    public class HttpRestClient
    {
        private readonly string apiUrl;

        public HttpRestClient(string apiUrl)
        {
            this.apiUrl = apiUrl;
        }

        public async Task<ApiResponse> ExecuteAsync(BaseRequest baseRequest)
        {
            try
            {
                var request = new RestRequest(string.Empty, baseRequest.Method);
                request.AddHeader("Content-Type", baseRequest.ContentType);
                if (baseRequest.Parameter != null)
                    request.AddJsonBody(baseRequest.Parameter);

                var builder = new UriBuilder(apiUrl) { Path = baseRequest.Route, Query = baseRequest.Query };
                var options = new RestClientOptions(builder.Uri);
                using var client = new RestClient(options);
                var response = await client.ExecuteAsync(request);
                return JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message, false);
            }
        }

        public async Task<ApiResponse<T>> ExecuteAsync<T>(BaseRequest baseRequest)
        {
            try
            {
                var request = new RestRequest(string.Empty, baseRequest.Method);
                request.AddHeader("Content-Type", baseRequest.ContentType);
                if (baseRequest.Parameter != null)
                    request.AddJsonBody(baseRequest.Parameter);
                //if (baseRequest.Parameter != null)
                //{
                //    request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
                //}
                var builder = new UriBuilder(apiUrl) { Path = baseRequest.Route, Query=baseRequest.Query };
                var options = new RestClientOptions(builder.Uri);
                using var client = new RestClient(options);
                var response = await client.ExecuteAsync(request);
                return JsonConvert.DeserializeObject<ApiResponse<T>>(response.Content);
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>(ex.Message, false);
            }
        }
    }
}
