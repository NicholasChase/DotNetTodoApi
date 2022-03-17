using Microsoft.AspNetCore.Mvc;
using todoDotNet6.Repo;

namespace todoDotNet6.TodoRepo
{

    public interface ITodoRepository : IRepository<Todo,Guid> {}

    public class TodoRepo : ControllerBase, ITodoRepository
    {
        public static Dictionary<Guid, Todo> todos = new Dictionary<Guid, Todo>();

        public Todo CreateTodo(Todo request)
        {
            request.Id = Guid.NewGuid();
            todos.Add(request.Id, request);
            return request;  
        }

        public Todo GetATodo(Guid id)
        {
            if (!todos.ContainsKey(id))
            {
                return null;
            }
            return todos[id];
        }

        public Todo UpdateTodo(Guid id, Todo request)
        {
            Todo val;
            if (todos.TryGetValue(id, out val))
            {
                request.Id = id;
                request.CreatedDate = val.CreatedDate;
                todos[request.Id]  = request;
                return request;
            }

            return request;
        }

        public Todo ChangeStatus(Guid id, Todo request)
        {
            Todo val;
            if(todos.TryGetValue(id, out val))
            {
                request.Id = id;
                request.Description = val.Description;
                request.DueDate = val.DueDate;
                request.CreatedDate = val.CreatedDate;
                todos[request.Id] = request;
                return (request);
            }
            return request;
        }

        public void DeleteTodo(Guid id)
        {
            todos.Remove(id);
        }

        public IEnumerable<Todo> GetTodos()
        {
            return todos.Values.ToList();
        }
    }
}