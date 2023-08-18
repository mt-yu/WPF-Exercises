namespace MyToDo.Api.Context
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
