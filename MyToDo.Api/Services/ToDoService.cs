﻿using AutoMapper;
using MyToDo.Api.Context;
using MyToDo.Share.DataTransfers;
using MyToDo.Share.Parameters;
using System.Linq.Expressions;

namespace MyToDo.Api.Services
{
    /// <summary>
    /// 待办事项的 CURD 服务 实现
    /// </summary>
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ToDoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> AddAsync(ToDoDto model)
        {
            try
            {
                var todo = mapper.Map<ToDo>(model);

                await unitOfWork.GetRepository<ToDo>().InsertAsync(todo);
                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, todo);
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
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
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
                if (todo != null)
                    return new ApiResponse(true, todo);
                else
                    return new ApiResponse(false, "查找数据失败");
            }
            catch (Exception ex)
            {

                return new ApiResponse(ex.Message, false);
            }
        }

        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();

                Expression<Func<ToDo, bool>> combinedPredicate = p =>
                (string.IsNullOrEmpty(parameter.Search) ||
                p.Title.Contains(parameter.Search) ||
                p.Content.Contains(parameter.Search));

                var todos = await repository.GetPagedListAsync(
                    predicate: combinedPredicate,
                    pageIndex: parameter.PageIndex,
                    pageSize: parameter.PageSize,
                    orderBy: source => source.OrderByDescending(t => t.CreateDateTime));
                
                return new ApiResponse(true, todos);
            }
            catch (Exception ex)
            {

                return new ApiResponse(ex.Message, false);
            }
        }

        public async Task<ApiResponse> GetAllAsync(ToDoParameter parameter)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();

                Expression<Func<ToDo, bool>> combinedPredicate = p =>
                (string.IsNullOrEmpty(parameter.Search)
                || p.Title.Contains(parameter.Search)
                || p.Content.Contains(parameter.Search))
                && ((parameter.Status == null)
                || p.Status.Equals(parameter.Status));

                var todos = await repository.GetPagedListAsync(
                    predicate: combinedPredicate,
                    pageIndex: parameter.PageIndex,
                    pageSize: parameter.PageSize,
                    orderBy: source => source.OrderByDescending(t => t.CreateDateTime));

                return new ApiResponse(true, todos);
            }
            catch (Exception ex)
            {

                return new ApiResponse(ex.Message, false);
            }
        }

        public async Task<ApiResponse> UpdateAsync(ToDoDto model)
        {
            try
            {
                var dbToDo = mapper.Map<ToDo>(model);
                var repository = unitOfWork.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(dbToDo.Id));
                todo.Title = dbToDo.Title;
                todo.Content = dbToDo.Content;
                todo.UpdateTime = DateTime.Now;
                todo.Status = dbToDo.Status;

                repository.Update(todo);

                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, model);
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
