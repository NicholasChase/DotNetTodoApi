namespace todoDotNet6.Repo
{
    public interface IEntity<TIndex>
    {
        TIndex Id { get; set; }
    }

    public interface IRepository<Todo, TIndex>
        where Todo : IEntity<TIndex>
     {
        Task<Todo> CreateTodo(Todo request);
        Task<Todo> UpdateTodo(TIndex id, Todo request);
        Task<Todo>? DeleteTodo(TIndex id);
        Task<Todo> GetATodo(TIndex id);
        Task<IEnumerable<Todo>> GetTodos();
        Task<Todo>  ChangeStatus(TIndex id, Todo request);
     }
}