using Microsoft.AspNetCore.Mvc;
using todoDotNet6.TodoRepo;

namespace todoDotNet6.Controller
{
    [ApiController] 
    [Route("task")]
    public class Controller : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public Controller(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IResult> GetTodos ()
        {
            var allTodos = await _todoRepository.GetTodos();
            return Results.Ok(allTodos);
        }

       [HttpPost]
       public async Task<IResult> Post([FromBody]Todo todo)
        {
            var createdTodo = await _todoRepository.CreateTodo(todo);
            return Results.Ok(createdTodo);
        }

       [HttpDelete("{id}")]
       public async Task<IResult> Delete(Guid id)
        {
            // var allTodos = _todoRepository.DeleteTodo(id);
            await _todoRepository.DeleteTodo(id);
            var allTodos = await _todoRepository.GetTodos();
            return Results.Ok(allTodos);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(Guid id, [FromBody]Todo request)
        {
            var updateTodo =  await _todoRepository.UpdateTodo(id, request);
            return Results.Ok(updateTodo);
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetATodo(Guid id)
        {
            var todo =  await _todoRepository.GetATodo(id);
            return Results.Ok(todo);
        }

        [HttpPut("statusComplete/{id}")]
        public async Task<IResult> PutStatus(Guid id, [FromBody]Todo request)
        {
            var todo = await _todoRepository.ChangeStatus(id, request);
            return Results.Ok(todo);
        }
    }
}