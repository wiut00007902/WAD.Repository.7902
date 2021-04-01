using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagementApplication.DAL;
using ManagementApplication.Models;
using ManagementApplication.DAL.Repositories;
using ManagementApplication.DAL.DBO;

namespace ManagementApplication.Controllers
{
    public class TasksController : Controller
    {
        private readonly IRepository<DAL.DBO.Task> _taskRepository;
        private readonly IRepository<Employee> _employeeRepository;

        public TasksController(IRepository<DAL.DBO.Task> taskRepository,
            IRepository<Employee> employeeRepository)
        {
            _taskRepository = taskRepository;
            _employeeRepository = employeeRepository;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            return View(await _taskRepository.GetAllAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _taskRepository.GetByIdAsync(id.Value);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public async Task<IActionResult> Create()
        {
            ViewData["EmployeeId"] = new SelectList((from employee in await _employeeRepository.GetAllAsync()
                                                     select new {Id = employee.Id, FullName = employee.LastName + " " + employee.FirstName })
                                                     , "Id", "FullName");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreationTime,TaskName,TaskDescription,EmployeeId,Deadline")] DAL.DBO.Task task)
        {
            task.CreationTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                await _taskRepository.CreateAsync(task);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList((from employee in await _employeeRepository.GetAllAsync()
                                                     select new { Id = employee.Id, FullName = employee.LastName + " " + employee.FirstName })
                                                     , "Id", "FullName", task.EmployeeId);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _taskRepository.GetByIdAsync(id.Value);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList((from employee in await _employeeRepository.GetAllAsync()
                                                     select new { Id = employee.Id, FullName = employee.LastName + " " + employee.FirstName })
                                                     , "Id", "FullName", task.EmployeeId);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreationTime,TaskName,TaskDescription,EmployeeId,Deadline")] DAL.DBO.Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _taskRepository.UpdateAsync(task);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_taskRepository.Exists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList((from employee in await _employeeRepository.GetAllAsync()
                                                     select new { Id = employee.Id, FullName = employee.LastName + " " + employee.FirstName })
                                                     , "Id", "FullName", task.EmployeeId);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _taskRepository.GetByIdAsync(id.Value);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _taskRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
