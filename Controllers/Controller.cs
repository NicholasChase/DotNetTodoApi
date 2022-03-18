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

        // ITodoRepository todoRepository = new TodoRepo();
        [HttpGet]
        public ActionResult<Todo> GetTodos ()
        {
            var allTodos = _todoRepository.GetTodos();
            return Ok(allTodos);
        }

       [HttpPost]
       public ActionResult<Todo> Post([FromBody]Todo todo)
        {
            var createdTodo = _todoRepository.CreateTodo(todo);
            return Ok(createdTodo);
        }

       [HttpDelete("{id}")]
       public ActionResult<Todo> Delete(Guid id)
        {
            // var allTodos = _todoRepository.DeleteTodo(id);
            _todoRepository.DeleteTodo(id);
            var allTodos = _todoRepository.GetTodos();
            return Ok(allTodos);
        }

        [HttpPut("{id}")]
        public ActionResult<Todo> Put(Guid id, [FromBody]Todo request)
        {
            var updateTodo =  _todoRepository.UpdateTodo(id, request);
            return Ok(updateTodo);
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetATodo(Guid id)
        {
            var todo =  _todoRepository.GetATodo(id);
            return Ok(todo);
        }

        [HttpPut("statusComplete/{id}")]
        public ActionResult<Todo> PutStatus(Guid id, [FromBody]Todo request)
        {
            var todo = _todoRepository.ChangeStatus(id, request);
            return Ok(todo);
        }
    }
}