using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagementApplication.DAL;
using ManagementApplication.DAL.DBO;
using ManagementApplication.DAL.Repositories;

namespace ManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IRepository<DAL.DBO.Task> _taskRepository;

        public TasksController(IRepository<DAL.DBO.Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.DBO.Task>>> GetTasks()
        {
            return await _taskRepository.GetAllAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.DBO.Task>> GetTask(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, DAL.DBO.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            try
            {
                await _taskRepository.UpdateAsync(task);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_taskRepository.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DAL.DBO.Task>> PostTask(DAL.DBO.Task task)
        {
            await _taskRepository.CreateAsync(task);

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _taskRepository.DeleteAsync(task);

            return NoContent();
        }
    }
}
