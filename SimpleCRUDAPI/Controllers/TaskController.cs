using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCRUDAPI.DB_Class;
using SimpleCRUDAPI.Entities;

namespace SimpleCRUDAPI.Controllers
{
    [Route("api/task")] //decide url pattern
    [ApiController] //web api controller
    public class TaskController : ControllerBase //base class ( json return )
    {
        private readonly TaskManagementdb _context; //database connection object
        
        public TaskController(TaskManagementdb context) //constructor
        {
            _context = context; //initialize database
        }

        //Get api/task
        [HttpGet] //get method
        public async Task<ActionResult<List<task_model>>> GetTaskReading()
        {
            var tasklist = await _context.tasks.ToListAsync();
            return Ok(tasklist);
        }


        [HttpGet("{id}")] //get method with id
        public async Task<ActionResult<task_model>> GetTaskById(int id)
        {
            var task = await _context.tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound("Task not found");
            }
            return Ok(task);
        }

        [HttpPost] //post method
        public async Task<ActionResult<List<task_model>>> CreateTask(task_model task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.tasks.Add(task);
            await _context.SaveChangesAsync();
            var responseTaskList = new task_model
            {
                Title = task.Title,
                Description = task.Description, 
                IsCompleted = task.IsCompleted
            };
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, responseTaskList);
        }

        [HttpPut("{id}")] //put method with id
        public async Task<ActionResult> UpdateTask(int id, task_model updatedTask)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingTask = await _context.tasks.FindAsync(id);
            if(existingTask == null)
            {
                return NotFound();
            }
            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.IsCompleted = updatedTask.IsCompleted;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")] //delete method with id
        public async Task<ActionResult> DeleteTask(int id)
        {
            var task = await _context.tasks.FindAsync(id);
            if(task == null)
            {
                return NotFound();
            }
            _context.tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
