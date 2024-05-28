using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Model;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<IActionResult> Index()
        {
            var department =await _unitOfWork.DepartmentRepository.GetAllAsync();
            return View(department);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if(ModelState.IsValid)
            {

                  await _unitOfWork.DepartmentRepository.AddAsync(department);
                int Result = await _unitOfWork.CompleteAsync();
                if (Result > 0)
                {
                    TempData["Message"] = "Department is Created";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public async Task<IActionResult> Details(int? id,string Viewname="Details")
        {
            if (id is null)
                return BadRequest();
            var department = await _unitOfWork.DepartmentRepository.GetbyIdAsync(id.Value);
            if(department is null)
                return NotFound();

            return View(Viewname,department);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            //if(id is null)
            //    return BadRequest();
            //var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            //if(department is null)
            //    return NotFound();
            //return View(department);
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Department department,[FromRoute]int id)
        {
            if(id != department.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.DepartmentRepository.Update(department);
                    await _unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Department department , [FromRoute] int id)
        {
            if(id != department.Id)
                return BadRequest();
            try
            {
                _unitOfWork.DepartmentRepository.Delete(department);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return View(department);
            }
        }

    }
}
