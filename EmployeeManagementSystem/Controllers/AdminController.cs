using EmployeeManagementSystem.Foundations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork unitWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            this.unitWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
             var departments = await unitWork.Departments.GetAllAsync();
            var designations = await unitWork.Designations.GetAllAsync();
            var employees = await unitWork.Employees.GetAllAsync();
            var vacancies = await unitWork.Vacancies.GetAllAsync();
            var leaves = await unitWork.Leaves.GetAllAsync();
            var users = await unitWork.Users.GetAllAsync();
            ViewData["Departments"] = departments.Count();
            ViewData["Designations"] = designations.Count();
            ViewData["Employees"] = employees.Count();
            ViewData["Vacancy"] = vacancies.Count();
            ViewData["Leaves"] = leaves.Count();
            ViewData["Users"] = users.Count();
            return View();
        }
    }
}
