namespace MyToDo.Api.Services
{
    /// <summary>
    /// 一般写一些通用的增删改查
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">实体，或者用model 表示也可以</param>
        /// <returns></returns>
        Task<ApiResponse> AddAsync(T entity);
        Task<ApiResponse> DeleteAsync(int id);
        Task<ApiResponse> UpdateAsync(T entity);
        Task<ApiResponse> GetAllAsync();
        Task<ApiResponse> GetAsync(int id);
    }
}
