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

        public async Task<Todo> CreateTodo(Todo request)
        {
            request.Id = Guid.NewGuid();
            var todo =  _dbset.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<Todo> UpdateTodo(Guid id, Todo request)
        {
            request.Id = id;

            var todo = _dbset.Update(request);



            return request;
        }

        public async Task DeleteTodo(Guid id)
        {
            var todo = _dbset.Remove(new Todo { Id =  id });
            
            
            
            
            
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> GetATodo(Guid id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task<IEnumerable<Todo>> GetTodos()
        {

            return  await _dbset.ToListAsync();
        }

        public Task<Todo> ChangeStatus(Guid id, Todo request)
        {
            throw new NotImplementedException();
        }
    }
}