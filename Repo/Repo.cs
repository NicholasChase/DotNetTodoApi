namespace todoDotNet6.Repo
{
    public interface IEntity<TIndex>
    {
        TIndex Id { get; set; }
    }

    public interface IRepository<Todo, TIndex>
     {
        Todo CreateTodo(Todo request);
        Todo UpdateTodo(TIndex id, Todo request);
        void DeleteTodo(TIndex id);
        Todo? GetATodo(TIndex id);
        IEnumerable<Todo> GetTodos();
        Todo ChangeStatus(TIndex id, Todo request);
     }
}