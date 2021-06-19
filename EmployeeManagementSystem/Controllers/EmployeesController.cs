using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Foundations;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork unitWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            unitWork = unitOfWork;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employeeManagementSystemContext = unitWork.Employees.Include(e => e.Department).Include(e => e.Designation);
            return View(await employeeManagementSystemContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await unitWork.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            ViewData["DepartmentId"] = new SelectList(await unitWork.Departments.GetAllAsync(), "Id", "DepartmentName");
            ViewData["DesignationId"] = new SelectList(await unitWork.Designations.GetAllAsync(), "Id", "DesignationName");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,Address,District,State,Country,HireDate,DepartmentId,DesignationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await unitWork.Employees.AddAsync(employee);
                await unitWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(await unitWork.Departments.GetAllAsync(), "Id", "DepartmentName", employee.DepartmentId);
            ViewData["DesignationId"] = new SelectList(await unitWork.Designations.GetAllAsync(), "Id", "DesignationName", employee.DesignationId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await unitWork.Employees.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(await unitWork.Departments.GetAllAsync(), "Id", "DepartmentName", employee.DepartmentId);
            ViewData["DesignationId"] = new SelectList(await unitWork.Designations.GetAllAsync(), "Id", "DesignationName", employee.DesignationId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Address,District,State,Country,HireDate,DepartmentId,DesignationId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await unitWork.Employees.UpdateAsync(employee);
                    await unitWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await EmployeeExists(employee.Id))
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
            ViewData["DepartmentId"] = new SelectList(await unitWork.Departments.GetAllAsync(), "Id", "DepartmentName", employee.DepartmentId);
            ViewData["DesignationId"] = new SelectList(await unitWork.Designations.GetAllAsync(), "Id", "DesignationName", employee.DesignationId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await unitWork.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await unitWork.Employees.GetByIdAsync(id);
            await unitWork.Employees.RemoveAsync(employee);
            await unitWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EmployeeExists(int id)
        {
            return await unitWork.Employees.AnyAsync(e => e.Id == id);
        }
    }
}
