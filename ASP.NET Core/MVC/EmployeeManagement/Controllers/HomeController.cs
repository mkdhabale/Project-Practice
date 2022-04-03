using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Controllers
{
    //[Route("Home")]
    //[Route("[controller]/[action]")] //Tokens in Attribute Routing
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        /*public IActionResult Index()
        {
            return View();
        }*/
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            // Pass the list of employees to the view
            return View(model);
        }


        public ViewResult Details()
        {
            Employee employee = _employeeRepository.GetEmployee(1);
            return View(employee);
            //return View("MyViews/Test.cshtml");
            //return View("/MyViews/Test.cshtml");
            //return View("~/MyViews/Test.cshtml");
            //return View("Test", employee);
        }

        // The ? makes id route parameter optional. To make it required remove ?
        [Route("Home/ViewDataViewBag/{id?}")]
        // ? makes id method parameter nullable
        public ViewResult ViewDataViewBag(int? id)
        {
            Employee model = _employeeRepository.GetEmployee(id ?? 1);

            // Pass PageTitle and Employee model to the View using ViewData
            ViewData["PageTitle"] = "Employee Details";
            ViewData["Employee"] = model;


            ViewBag.PageTitle = "Employee Details";
            ViewBag.Employee = model;

            return View();
        }

        public ViewResult StronglyTypeView()
        {
            Employee model = _employeeRepository.GetEmployee(1);

            ViewBag.PageTitle = "Employee Details";

            return View(model);
        }

        public ViewResult ViewModel()
        {
            // Instantiate HomeDetailsViewModel and store Employee details and PageTitle
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(1),
                PageTitle = "Employee Details"
            };

            // Pass the ViewModel object to the View() helper method
            return View(homeDetailsViewModel);
        }

        public ViewResult GetAllEmployees()
        {
            //throw new Exception("Error in Details View");
            // retrieve all the employees
            var model = _employeeRepository.GetAllEmployees();
            // Pass the list of employees to the view
            return View(model);
        }

        /*
        public ViewResult GetEmployeeByID(int? id)
        {
            Employee model = _employeeRepository.GetEmployee(id ?? 1);

            // Pass PageTitle and Employee model to the View using ViewData
            ViewData["PageTitle"] = "Employee Details";
            ViewData["Employee"] = model;


            ViewBag.PageTitle = "Employee Details";
            ViewBag.Employee = model;

            return View();
        }*/
        public ViewResult GetEmployeeByID(int id)
        {
            Employee model = _employeeRepository.GetEmployee(id);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }

            // Pass PageTitle and Employee model to the View using ViewData
            ViewData["PageTitle"] = "Employee Details";
            ViewData["Employee"] = model;


            ViewBag.PageTitle = "Employee Details";
            ViewBag.Employee = model;

            return View();
        }

        [Authorize]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        /*
                [HttpPost]
                public IActionResult Create(Employee emp)
                {
                    if (ModelState.IsValid)
                    {
                        Employee newEmployee = _employeeRepository.Add(emp);
                        return RedirectToAction("GetEmployeeByID", new { id = newEmployee.Id });
                    }

                    return View();
                }*/

        [Authorize]
        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName =  ProcessUploadedFile(model); ;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                /*if (model.Photo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }*/

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("GetEmployeeByID", new { id = newEmployee.Id });
            }

            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Delete(id);
                return RedirectToAction("Index");
            }

            return View();
        }

        [Authorize]
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

        // Through model binding, the action method parameter
        // EmployeeEditViewModel receives the posted edit form data
        [Authorize]
        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the employee being edited from the database
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                // Update the employee object with the data in the model object
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;

                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
                if (model.Photo != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the employee object which will be
                    // eventually saved in the database
                    employee.PhotoPath = ProcessUploadedFile(model);
                }

                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                Employee updatedEmployee = _employeeRepository.Update(employee);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
