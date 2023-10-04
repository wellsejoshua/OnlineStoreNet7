using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStoreFrontNet7.DataAccess.Data;
using OnlineStoreFrontNet7.Models;
using OnlineStoreNet7.DataAccess.Repository.IRepository;
using OnlineStoreNet7.Models.Models;
using OnlineStoreNet7.Models.ViewModels;
using OnlineStoreNet7.Utility;

namespace OnlineStoreFrontNet7.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        //Company Repository
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();

            return View(objCompanyList);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
        //    {
        //        Text = u.Name,
        //        Value = u.Id.ToString()
        //    });
        //    //ViewBag.CategoryList = CategoryList;
        //    CompanyVM companyVM = new CompanyVM();
        //    companyVM.CategoryList = CategoryList;
        //    companyVM.Company = new Company();

        //    return View(companyVM);
        //}

        //Combining the Create and Edit into single functionality
        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            if(id == null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }
        }


        //Combining the Create and Edit into single functionality
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company companyObj)
        {
            if (ModelState.IsValid)
            {
                //just incase  file name is wierd using a guid biving a random file name

                if(companyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(companyObj);

                }
                else
                {
                    _unitOfWork.Company.Update(companyObj);

                }

                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index", "Company");
            }
            else
            {
                return View(companyObj);
            }

        }


        #region API CALLS For Data Tables
        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new {data = objCompanyList});

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u=>u.Id == id);
            if(companyToBeDeleted == null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }

            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion



    }

}
