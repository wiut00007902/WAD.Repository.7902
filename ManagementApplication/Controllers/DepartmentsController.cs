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
    public class DepartmentsController : Controller
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Region> _regionRepository;

        public DepartmentsController(IRepository<Department> departmentRepository,
            IRepository<Region> regionRepository)
        {
            _departmentRepository = departmentRepository;
            _regionRepository = regionRepository;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await _departmentRepository.GetAllAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentRepository.GetByIdAsync(id.Value);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public async Task<IActionResult> Create()
        {
            var departmentViewModel = new DepartmentViewModel();
            departmentViewModel.Regions = new SelectList(await _regionRepository.GetAllAsync(), "Id", "RegionName");
            return View(departmentViewModel);
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreationDate,DepartmentName,RegionId")] DepartmentViewModel department)
        {
            department.CreationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                await _departmentRepository.CreateAsync(department);
                return RedirectToAction(nameof(Index));
            }
            department.Regions = new SelectList(await _regionRepository.GetAllAsync(), "Id", "RegionName", department.RegionId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentRepository.GetByIdAsync(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            var departmentViewModel = new DepartmentViewModel();
            departmentViewModel.Id = department.Id;
            departmentViewModel.Regions = new SelectList(await _regionRepository.GetAllAsync(), "Id", "RegionName", department.RegionId);
            return View(departmentViewModel);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreationDate,DepartmentName,RegionId")] DepartmentViewModel department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentRepository.UpdateAsync(department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_departmentRepository.Exists(department.Id))
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
            department.Regions = new SelectList(await _regionRepository.GetAllAsync(), "Id", "RegionName", department.RegionId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentRepository.GetByIdAsync(id.Value);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _departmentRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
