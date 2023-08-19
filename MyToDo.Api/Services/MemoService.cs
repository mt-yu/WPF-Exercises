using AutoMapper;
using MyToDo.Api.Context;
using MyToDo.Share.DataTransfers;
using MyToDo.Share.Parameters;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace MyToDo.Api.Services
{
    public class MemoService : IMemoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MemoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> AddAsync(MemoDto model)
        {
            try
            {
                var memo = mapper.Map<Memo>(model);

                await unitOfWork.GetRepository<Memo>().InsertAsync(memo);
                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, memo);
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
                var repository = unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
                repository.Delete(memo);

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
                var repository = unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
                if (memo != null)
                    return new ApiResponse(true, memo);
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
                var repository = unitOfWork.GetRepository<Memo>();

                Expression<Func<Memo, bool>> combinedPredicate = p =>
                (string.IsNullOrEmpty(parameter.Search) ||
                p.Title.Contains(parameter.Search) ||
                p.Content.Contains(parameter.Search));

                var memos = await repository.GetPagedListAsync(
                    predicate: combinedPredicate,
                    pageIndex: parameter.PageIndex,
                    pageSize: parameter.PageSize,
                    orderBy: source => source.OrderByDescending(t => t.CreateDateTime));

                return new ApiResponse(true, memos);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message, false);
            }
        }

        public async Task<ApiResponse> UpdateAsync(MemoDto model)
        {
            try
            {
                var dbMemo = mapper.Map<Memo>(model);
                var repository = unitOfWork.GetRepository<Memo>();
                var memo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(dbMemo.Id));
                memo.Title = dbMemo.Title;
                memo.Content = dbMemo.Content;
                memo.UpdateTime = DateTime.Now;


                repository.Update(memo);

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
