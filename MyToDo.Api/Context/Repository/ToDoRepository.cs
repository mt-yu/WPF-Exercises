namespace MyToDo.Api.Context.Repository
{
    public class ToDoRepository : Repository<ToDo>, IRepository<ToDo>
    {
        public ToDoRepository(MyDBContext dbContext) : base(dbContext)
        {
        }
    }

    #region old 没有添加工作单元之前的写法， 不利于维护 和 数据添加时候的同步
    //public interface ToDoRepository
    //{
    //    Task<bool> Add(ToDo toDo);
    //    Task<bool> Update(ToDo toDo);
    //    Task<bool> Delete(int id);
    //}

    //public interface IMemoRepository
    //{
    //    ///...
    //}

    //public class ToDoRepository : ToDoRepository
    //{
    //    private MyToDoContext dbContext;

    //    public ToDoRepository(MyToDoContext dbContext)
    //    {
    //        this.dbContext = dbContext;
    //    }

    //    public async Task<bool> Add(ToDo toDo)
    //    {
    //        var result = await dbContext.ToDos.AddAsync(toDo);
    //        return await dbContext.SaveChangesAsync() > 0;
    //    }

    //    public Task<bool> Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<bool> Update(ToDo toDo)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    #endregion

}
