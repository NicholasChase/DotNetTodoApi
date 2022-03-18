using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoDotNet6.Repo;

namespace todoDotNet6.TodoRepo
{
    
    public interface ITodoRepository : IRepository<Todo,Guid> {}

    public class TodoRepo : ITodoRepository
    {
        private readonly DataContext _context;

        public static Dictionary<Guid, Todo> todos = new Dictionary<Guid, Todo>();

        private DbSet<Todo> _dbset => _context.Set<Todo>();


        public TodoRepo(DataContext context)
        {
            _context = context;
        }

        public Todo CreateTodo(Todo request)
        {
            // request.Id = Guid.NewGuid();
            // todos.Add(request.Id, request);
            // return request;  

            request.Id = Guid.NewGuid();
            var todo =  _dbset.Add(request);
            _context.SaveChanges();
            return request;
        }

        public Todo? GetATodo(Guid id)
        {
            // if (!todos.ContainsKey(id))
            // {
            //     return null;
            // }
            // return todos[id];

            return _dbset.Find(id);
        }

        public Todo UpdateTodo(Guid id, Todo request)
        {
            // Todo val;
            // if (todos.TryGetValue(id, out val))
            // {
            //     request.Id = id;
            //     request.CreatedDate = val.CreatedDate;
            //     todos[request.Id]  = request;
            //     return request;
            // }

            request.Id = id;

            var todo = _dbset.Update(request);

            _context.SaveChanges();

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
            // todos.Remove(id);
            var todo = _dbset.Remove(new Todo { Id =  id });
            _context.SaveChanges();
        }

        public IEnumerable<Todo> GetTodos()
        {
            // return todos.Values.ToList();
            var val = todos.Values.ToList();

            return _dbset.ToList();
        }
    }
}