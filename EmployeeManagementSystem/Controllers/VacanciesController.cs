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
    public class VacanciesController : Controller
    {
        private readonly IUnitOfWork unitWork;

        public VacanciesController(IUnitOfWork unitOfWork)
        {
            unitWork = unitOfWork;
        }

        // GET: Vacancies
        public async Task<IActionResult> Index()
        {
            var vacancies = unitWork.Vacancies.Include(v => v.Designation);
            return View(await vacancies.ToListAsync());
        }

        // GET: Vacancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await unitWork.Vacancies
                .Include(v => v.Designation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // GET: Vacancies/Create
        public async Task<IActionResult> Create()
        {
            ViewData["DesignationId"] = new SelectList(await unitWork.Designations.GetAllAsync(), "Id", "DesignationName");
            return View();
        }

        // POST: Vacancies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DesignationId,NumberOfQuota,AnnounceDate,ExpiryDate")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                await unitWork.Vacancies.AddAsync(vacancy);
                await unitWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesignationId"] = new SelectList(await unitWork.Designations.GetAllAsync(), "Id", "DesignationName", vacancy.DesignationId);
            return View(vacancy);
        }

        // GET: Vacancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await unitWork.Vacancies.GetByIdAsync(id);
            if (vacancy == null)
            {
                return NotFound();
            }
            ViewData["DesignationId"] = new SelectList(await unitWork.Designations.GetAllAsync(), "Id", "DesignationName", vacancy.DesignationId);
            return View(vacancy);
        }

        // POST: Vacancies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DesignationId,NumberOfQuota,AnnounceDate,ExpiryDate")] Vacancy vacancy)
        {
            if (id != vacancy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await unitWork.Vacancies.UpdateAsync(vacancy);
                    await unitWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await VacancyExists(vacancy.Id))
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
            ViewData["DesignationId"] = new SelectList(await unitWork.Designations.GetAllAsync(), "Id", "DesignationName", vacancy.DesignationId);
            return View(vacancy);
        }

        // GET: Vacancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await unitWork.Vacancies
                .Include(v => v.Designation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // POST: Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacancy = await unitWork.Vacancies.GetByIdAsync(id);
            await unitWork.Vacancies.RemoveAsync(vacancy);
            await unitWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> VacancyExists(int id)
        {
            return await unitWork.Vacancies.AnyAsync(e => e.Id == id);
        }
    }
}
