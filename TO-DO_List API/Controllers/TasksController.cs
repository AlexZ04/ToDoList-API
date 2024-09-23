using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TO_DO_List_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private TaskStorage storage;

        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;
            storage = new TaskStorage();
            storage.AddTask(new Task(storage.GetId(), "First Task"));
            storage.AddTask(new Task(storage.GetId(), "Second Task"));
        }

        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return Enumerable.Range(0, storage.GetLength()).Select(index =>
            storage.GetTask(index)).
            ToArray();
        }

        [HttpGet("{id}")]
        public Task Get(int id)
        {
            return storage.GetTasksList().FirstOrDefault(wi => wi.id == id);
        }
    }
}
