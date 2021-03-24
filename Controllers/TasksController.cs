using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksAPI.Models;
using TasksAPI.Repositories;

namespace TasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ItaskRepository _taskRepository;
        public TasksController(ItaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Tasks>> GetTasks()
        {
            return await _taskRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTasks(int id)
        {
            return await _taskRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Tasks>> AddTasks([FromBody] Tasks task)
        {
            var newTask = await _taskRepository.Create(task);
            return CreatedAtAction(nameof(GetTasks), new { id = newTask.Id }, newTask);
        }

        [HttpPut]
        public async Task<ActionResult> PutTasks(int id, [FromBody] Tasks task)
        {
            if(id != task.Id)
            {
                return BadRequest();
            }
            await _taskRepository.Update(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var taskToDelete = await _taskRepository.Get(id);
            if (taskToDelete == null)
            {
                return NotFound();
            }
            await _taskRepository.Delete(taskToDelete.Id);
            return NoContent();
        }


    }
}
