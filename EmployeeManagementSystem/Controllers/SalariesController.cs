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
    public class SalariesController : Controller
    {
        private readonly IUnitOfWork unitWork;

        public SalariesController(IUnitOfWork unitOfWork)
        {
            unitWork = unitOfWork;
        }

        // GET: Salaries
        public async Task<IActionResult> Index()
        {
            var salaries = unitWork.Salaries.Include(s => s.Employee).Include(s => s.Designation);
            return View(await salaries.ToListAsync());
        }

        // GET: Salaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await unitWork.Salaries
                .Include(s => s.Employee)
                .Include(s => s.Designation)    
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // GET: Salaries/Create
        public async Task<IActionResult> Create()
        {
            ViewData["EmployeeId"] = new SelectList(await unitWork.Employees.GetAllAsync(), "Id", "Email");
            ViewData["DesignationId"] = new SelectList(await unitWork.Designations.GetAllAsync(), "Id", "DesignationName");
            return View();
        }

        // POST: Salaries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,DesignationId,SalaryLevel,TotalSalaryAmount")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                await unitWork.Salaries.AddAsync(salary);
                await unitWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(await unitWork.Employees.GetAllAsync(), "Id", "Email", salary.EmployeeId);
            ViewData["DesignationId"] = new SelectList(await unitWork.Designations.GetAllAsync(), "Id", "DesignationName", salary.DesignationId);
            return View(salary);
        }

        // GET: Salaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await unitWork.Salaries.GetByIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(await unitWork.Employees.GetAllAsync(), "Id", "Email", salary.EmployeeId);
            ViewData["DesignationId"] = new SelectList(await unitWork.Designations.GetAllAsync(), "Id", "DesignationName", salary.DesignationId);
            return View(salary);
        }

        // POST: Salaries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,DesignationId,SalaryLevel,TotalSalaryAmount")] Salary salary)
        {
            if (id != salary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await unitWork.Salaries.UpdateAsync(salary);
                    await unitWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await SalaryExists(salary.Id))
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
            ViewData["EmployeeId"] = new SelectList(await unitWork.Employees.GetAllAsync(), "Id", "Email", salary.EmployeeId);
            ViewData["DesignationId"] = new SelectList(await unitWork.Designations.GetAllAsync(), "Id", "DesignationName", salary.DesignationId);
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await unitWork.Salaries
                .Include(s => s.Employee)
                .Include(s => s.Designation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salary = await unitWork.Salaries.GetByIdAsync(id);
            await unitWork.Salaries.RemoveAsync(salary);
            await unitWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SalaryExists(int id)
        {
            return await unitWork.Salaries.AnyAsync(e => e.Id == id);
        }
    }
}
