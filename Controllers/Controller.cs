using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using todoDotNet6.TodoRepo;

namespace todoDotNet6.Controller
{
    [ApiController]
    [Authorize] 
    [Route("task")]
    public class Controller : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public Controller(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos ()
        {
            var allTodos = await _todoRepository.GetTodos();
            return Ok(allTodos);
        }

       [HttpPost]
       public async Task<ActionResult<Todo>> Post([FromBody]Todo todo)
        {
            var createdTodo = await _todoRepository.CreateTodo(todo);
            return Ok(createdTodo);
        }

       [HttpDelete("{id}")]
       public async Task<ActionResult<Todo>> Delete(Guid id)
        {
            // var allTodos = _todoRepository.DeleteTodo(id);
            await _todoRepository.DeleteTodo(id);
            var allTodos = await _todoRepository.GetTodos();
            return Ok(allTodos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> Put(Guid id, [FromBody]Todo request)
        {
            var updateTodo =  await _todoRepository.UpdateTodo(id, request);
            return Ok(updateTodo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetATodo(Guid id)
        {
            var todo =  await _todoRepository.GetATodo(id);
            return Ok(todo);
        }

        [HttpPut("statusComplete/{id}")]
        public async Task<ActionResult<Todo>> PutStatus(Guid id, [FromBody]Todo request)
        {
            var todo = await _todoRepository.ChangeStatus(id, request);
            return Ok(todo);
        }
    }
}