using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Model;
using Demo.PL.Helpers;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string SearchValue)
        {
            IEnumerable<Employee> employees;
            if(string.IsNullOrEmpty(SearchValue))
            {
                 employees = await _unitOfWork.EmployeeRepository.GetAllAsync();
            }
            else
            {
                employees = _unitOfWork.EmployeeRepository.SearchEmployeeByName(SearchValue);
            }
            var MappedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(MappedEmployees);
        }

        [HttpGet]
        public IActionResult Create()
        {
           // ViewBag.Departments = _departmentRepository.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        {
            if(ModelState.IsValid)
            {
                employeeVM.ImageName = DocumentSettings.UploadFile(employeeVM.Image, "Images");
                var MappedEmployee = _mapper.Map<EmployeeViewModel,Employee>(employeeVM);
                await _unitOfWork.EmployeeRepository.AddAsync(MappedEmployee);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }

        
        public async Task<IActionResult> Details(int? id,string Viewname="Details")
        {
            if (id is null)
                return BadRequest();
            var employees = await _unitOfWork.EmployeeRepository.GetbyIdAsync(id.Value);
            if(employees is null)
                return NotFound();
            var MappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employees);
            return View(Viewname, MappedEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            return await Details(id,"Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeVM, [FromRoute] int id)
        {
            if(id != employeeVM.Id)
                return BadRequest();

            if(ModelState.IsValid)
            {
                try
                {
                    employeeVM.ImageName = DocumentSettings.UploadFile(employeeVM.Image, "Images");
                    var MappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                   _unitOfWork.EmployeeRepository.Update(MappedEmployee);
                    await _unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty,ex.Message);
                }         
            }
            return View(employeeVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeViewModel employeeVM , [FromRoute] int id)
        {
             if (id != employeeVM.Id)
                return BadRequest();

            try
            {
                var MappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
               _unitOfWork.EmployeeRepository.Delete(MappedEmployee);
               int Result = await _unitOfWork.CompleteAsync();
                if(Result > 1)
                {
                    DocumentSettings.DeleteFile(employeeVM.ImageName, "Images");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(employeeVM);
            }

           
        }

        //public IActionResult SearchEmployee (string Query)
        //{
        //    var employees =_unitOfWork.EmployeeRepository.Employees.Where(e => e.Name.Contains(Query) || e.Id.ToString() == Query).ToList();

        //    return View(employees);
        //}


    }
}
