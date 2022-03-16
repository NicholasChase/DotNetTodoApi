using Microsoft.AspNetCore.Mvc;
using todoDotNet6.TodoRepo;

namespace todoDotNet6.Controllers
{
    [ApiController] 
    [Route("task")]
    public class Controller : ControllerBase
    {
        private readonly ITodoRepository todoRepository;

        public Controller(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        // ITodoRepository todoRepository = new TodoRepo();
        [HttpGet]
        public ActionResult<Todo> GetTodos ()
        {
            var allTodos = todoRepository.GetTodos();
            return Ok(allTodos);
        }

       [HttpPost]
       public ActionResult<Todo> Post([FromBody]Todo todo)
        {
            var createdTodo = todoRepository.CreateTodo(todo);
            return Ok(createdTodo);
        }

       [HttpDelete("{id}")]
       public ActionResult<Todo> Delete(Guid id)
        {
            var allTodos = todoRepository.DeleteTodo(id);
            return Ok(allTodos);
        }

        [HttpPut("{id}")]
        public ActionResult<Todo> Put(Guid id, [FromBody]Todo request)
        {
            var updateTodo =  todoRepository.UpdateTodo(id, request);
            return Ok(updateTodo);
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetATodo(Guid id)
        {
            var todo =  todoRepository.GetATodo(id);
            return Ok(todo);
        }

        [HttpPut("statusComplete/{id}")]
        public ActionResult<Todo> PutStatus(Guid id, [FromBody]Todo request)
        {
            var todo = todoRepository.ChangeStatus(id, request);
            return Ok(todo);
        }
    }
}