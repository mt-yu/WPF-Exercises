using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyToDo.Api.Context;
using MyToDo.Api.Services;

namespace MyToDo.Api.Controllers
{
    /// <summary>
    /// api/控制器/方法  待办事项控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService service;

        public ToDoController(IToDoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(int id)
        {
            return await service.GetAsync(id);
        }

        [HttpGet]
        public async Task<ApiResponse> GetAll()
        {
            return await service.GetAllAsync();
        }

        /// <summary>
        /// 一般传入参数  不会传入实体类 而是改成 Dto
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] ToDo model)
        {
            return await service.AddAsync(model);
        }

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] ToDo model)
        {
            return await service.UpdateAsync(model);
        }

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id)
        {
            return await service.DeleteAsync(id);
        }
        #region old 以下写法没问题，但是是基于某种实现，没必要卸载控制器上，建议用服务的方法来提供给控制器， 通过服务来将 以下代码 和控制器解耦，
        //private readonly IUnitOfWork unitOfWork;

        //public ToDoController(IUnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}

        //[HttpGet]
        //public async Task<IActionResult> Get(int id)
        //{

        //    IRepository<ToDo> reposiotry = unitOfWork.GetRepository<ToDo>();
        //    var todo = await reposiotry.GetFirstOrDefaultAsync(predicate: t => t.Id.Equals(id));

        //    return null;
        //}
        #endregion
    }
}
