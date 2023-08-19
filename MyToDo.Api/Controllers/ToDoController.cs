using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyToDo.Api.Context;
using MyToDo.Api.Services;
using MyToDo.Share.DataTransfers;

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
        /// 注: 控制器中传递的是 Dto 具体执行的时候 会通过AutoMapper(如果字段不同则需要到ProFile 中进行配置) 转换成数据库实体来进行操作
        /// 一般传入参数  不会传入实体类，数据库当中实体往往有很多 的关系和命名 这里一般不可能和这些挂钩， 所以需要改成 Dto （数据传输层来处理，纯数据）
        /// Dto 后缀： Dto 是 "Data Transfer Object" 的缩写，意为数据传输对象。这是一种用于在不同层（例如应用程序层和数据访问层）之间传输数据的对象。通常，Dto 对象是轻量级的，只包含必要的数据，而不包含业务逻辑。Dto 对象有助于在不同层之间减少耦合，提高性能，并确保只传输所需的数据。
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] ToDoDto model)
        {
            return await service.AddAsync(model);
        }

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] ToDoDto model)
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
