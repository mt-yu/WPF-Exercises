using Microsoft.EntityFrameworkCore;

namespace MyToDo.Api.Context
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Memo> Memos { get; set; }
    }
}
