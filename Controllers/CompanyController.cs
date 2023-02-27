using Microsoft.AspNetCore.Mvc;
using PieCodeERP.Service.Interface;
using PieCodeERP.ViewModel;
using PieCodeERP.ViewModel.Helpers;
namespace PieCodeErp.Controllers
{
 
    public class CompanyController : Controller
    {
        private readonly ICompanyMasterService _CompanyService;
        public CompanyController(ICompanyMasterService CompanyService)
        {
            _CompanyService = CompanyService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllCompanies(DataTableFilterModel filter)
        {
            var list = _CompanyService.GetCompanyList(filter);
            return Json(list);
        }
        public ActionResult Edit(int id)
        {
            return View("ManageCompany", _CompanyService.GetCompany(id));
        }


        public ActionResult Create()
        {
            return View("ManageCompany", new AddCompanyModel());
        }

        public JsonResult AddOrUpdateCompany(AddCompanyModel CompanyVM)
        {
            return Json(_CompanyService.AddOrUpdateCompany(CompanyVM));
        }
        public IActionResult DeleteCompany(int id)
        {
            var list = _CompanyService.DeleteCompany(id);
            return Json(list);
        }

    }
}
