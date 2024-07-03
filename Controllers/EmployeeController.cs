

using Microsoft.AspNetCore.Mvc;
using TestCoreMVC.Models.Entities;
using TestCoreMVC.Models.Implementation;

namespace TestCoreMVC.Controllers
{

    public class EmployeeController: Controller
    {

        public JsonResult getEmployeeDetails(int Id)
        {
            EmployeeRepository repository = new EmployeeRepository();
            Employee employee = repository.getEmployeeById(Id);
            return Json(employee);
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Employee Data";
            ViewData["Message"] = "Employee details here";
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeList employeeList = new()
            {
                employeeList = repository.DataSource()
            };

            return View(employeeList);
        }

        public IActionResult Add()
        {
            ViewData["Title"] = "Adding Employee";
            ViewData["Message"] = "Add Employees";

            return RedirectToAction("Edit", "Employee", new {id = 0 });
        }
        public IActionResult Edit(int Id)
        {
            ViewData["Title"] = "Editing Employee";
            ViewData["Message"] = "Edit Employees";

            EmployeeRepository employeeRepository = new();
            Employee employee = employeeRepository.getEmployeeById(Id);
            return View(employee);

        }

        public IActionResult Delete(int Id)
        {
            ViewData["Title"] = "Deleting Employees";
            ViewData["Message"] = "Delete Employees";

            EmployeeRepository employeeRepository = new();

            employeeRepository.DeleteEmployee(Id);

            return RedirectToAction("Index", "Employee");
        }


        public IActionResult View (int Id)
        {
            ViewData["Title"] = "View Employees";
            ViewData["Message"] = "View Employees";
            EmployeeRepository employeeRepository = new();
            Employee employee = employeeRepository.getEmployeeById(Id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update([FromForm] Employee employee)
        {
            ViewData["Title"] = "Updating";
            ViewData["Message"] = "Updating the employees";
            EmployeeRepository employeeRepository = new();
            int empId = employeeRepository.UpdateEmployee(employee);
            return RedirectToAction("View", "Employee", new {id = empId });
        }
    }

}