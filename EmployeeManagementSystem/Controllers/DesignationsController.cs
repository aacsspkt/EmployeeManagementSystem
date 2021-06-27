using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Foundations;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagementSystem.Controllers
{
    [Authorize]
    public class DesignationsController : Controller
    {
        private readonly IUnitOfWork unitWork;

        public DesignationsController(IUnitOfWork unitOfWork)
        {
            unitWork = unitOfWork;
        }

        // GET: Designations
        public async Task<IActionResult> Index()
        {
            var designations = unitWork.Designations.Include(d => d.Department);
            return View(await designations.ToListAsync());
        }

        // GET: Designations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designation = await unitWork.Designations
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // GET: Designations/Create
        public async Task<IActionResult> Create()
        {
            ViewData["DepartmentId"] = new SelectList(await unitWork.Departments.GetAllAsync(), "Id", "DepartmentName");
            return View();
        }

        // POST: Designations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DesignationName,DepartmentId,InitialSalary")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                await unitWork.Designations.AddAsync(designation);
                await unitWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(await unitWork.Departments.GetAllAsync(), "Id", "DepartmentName", designation.DepartmentId);
            return View(designation);
        }

        // GET: Designations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designation = await unitWork.Designations.GetByIdAsync(id);
            if (designation == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(await unitWork.Departments.GetAllAsync(), "Id", "DepartmentName", designation.DepartmentId);
            return View(designation);
        }

        // POST: Designations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DesignationName,DepartmentId,InitialSalary")] Designation designation)
        {
            if (id != designation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await unitWork.Designations.UpdateAsync(designation);
                    await unitWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await DesignationExists(designation.Id))
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
            ViewData["DepartmentId"] = new SelectList(await unitWork.Departments.GetAllAsync(), "Id", "DepartmentName", designation.DepartmentId);
            return View(designation);
        }

        // GET: Designations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designation = await unitWork.Designations
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var designation = await unitWork.Designations.GetByIdAsync(id);
            await unitWork.Designations.RemoveAsync(designation);
            await unitWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DesignationExists(int id)
        {
            return await unitWork.Designations.AnyAsync(e => e.Id == id);
        }
    }
}
