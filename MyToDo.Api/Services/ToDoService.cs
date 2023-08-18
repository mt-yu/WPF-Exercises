using MyToDo.Api.Context;

namespace MyToDo.Api.Services
{
    /// <summary>
    /// 待办事项的 CURD 服务 实现
    /// </summary>
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork unitOfWork;

        public ToDoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> AddAsync(ToDo entity)
        {
            try
            {
                await unitOfWork.GetRepository<ToDo>().InsertAsync(entity);
                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, entity);
                }
                else
                {
                    return new ApiResponse(false, "添加数据失败");
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse(ex.Message, false);
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x=> x.Id.Equals(id));
                repository.Delete(todo);

                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, "");
                }
                else
                {
                    return new ApiResponse(false, "删除数据失败");
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse(ex.Message, false);
            }
        }

        public async Task<ApiResponse> GetAsync(int id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
                return new ApiResponse(true, todo);
            }
            catch (Exception ex)
            {

                return new ApiResponse(ex.Message, false);
            }
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todos = await repository.GetAllAsync();
                return new ApiResponse(true, todos);
            }
            catch (Exception ex)
            {

                return new ApiResponse(ex.Message, false);
            }
        }

        public async Task<ApiResponse> UpdateAsync(ToDo entity)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(entity.Id));
                todo.Title = entity.Title;
                todo.Content = entity.Content;
                todo.UpdateTime = DateTime.Now;
                todo.Status = entity.Status;

                repository.Update(todo);

                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, entity);
                }
                else
                {
                    return new ApiResponse(false, "更新数据失败");
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse(ex.Message, false);
            }
        }
    }
}
