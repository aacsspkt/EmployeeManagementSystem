using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Foundations;

namespace EmployeeManagementSystem.Controllers
{
    public class LeavesController : Controller
    {
        private readonly IUnitOfWork unitWork;

        public LeavesController(IUnitOfWork unitOfWork)
        {
            unitWork = unitOfWork;
        }

        // GET: Leaves
        public async Task<IActionResult> Index()
        {
            var employeeManagementSystemContext = unitWork.Leaves.Include(l => l.Employee);
            return View(await employeeManagementSystemContext.ToListAsync());
        }

        // GET: Leaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await unitWork.Leaves
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leave == null)
            {
                return NotFound();
            }

            return View(leave);
        }

        // GET: Leaves/Create
        public async Task<IActionResult> Create()
        {
            ViewData["EmployeeId"] = new SelectList(await unitWork.Employees.GetAllAsync(), "Id", "Email");
            return View();
        }

        // POST: Leaves/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,LeaveStartDate,NumberOfDays,LeaveReason")] Leave leave)
        {
            if (ModelState.IsValid)
            {
                await unitWork.Leaves.AddAsync(leave);
                await unitWork.CompleteAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(await unitWork.Employees.GetAllAsync(), "Id", "Email", leave.EmployeeId);
            return View(leave);
        }

        // GET: Leaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await unitWork.Leaves.GetByIdAsync(id);
            if (leave == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(await unitWork.Employees.GetAllAsync(), "Id", "Email", leave.EmployeeId);
            return View(leave);
        }

        // POST: Leaves/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,LeaveStartDate,NumberOfDays,LeaveReason")] Leave leave)
        {
            if (id != leave.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await unitWork.Leaves.UpdateAsync(leave);
                    await unitWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await LeaveExists(leave.Id))
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
            ViewData["EmployeeId"] = new SelectList(await unitWork.Employees.GetAllAsync(), "Id", "Email", leave.EmployeeId);
            return View(leave);
        }

        // GET: Leaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await unitWork.Leaves
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leave == null)
            {
                return NotFound();
            }

            return View(leave);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leave = await unitWork.Leaves.GetByIdAsync(id);
            await unitWork.Leaves.RemoveAsync(leave);
            await unitWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LeaveExists(int id)
        {
            return await unitWork.Leaves.AnyAsync(e => e.Id == id);
        }
    }
}
