using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyToDo.Api.Context;
using MyToDo.Api.Services;
using MyToDo.Share.DataTransfers;
using MyToDo.Share.Parameters;

namespace MyToDo.Api.Controllers
{
    /// <summary>
    /// api/控制器/方法  备忘录控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MemoController : ControllerBase
    {
        private readonly IMemoService service;

        public MemoController(IMemoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(int id)
        {
            return await service.GetAsync(id);
        }

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] QueryParameter param)
        {
            return await service.GetAllAsync(param);
        }

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] MemoDto model)
        {
            return await service.AddAsync(model);
        }

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] MemoDto model)
        {
            return await service.UpdateAsync(model);
        }

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id)
        {
            return await service.DeleteAsync(id);
        }
    }
}
