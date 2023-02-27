using Microsoft.AspNetCore.Mvc;

using PieCodeERP.Service.Interface;
using PieCodeERP.ViewModel;
using PieCodeERP.ViewModel.Helpers;

namespace PieCodeErp.Controllers
{

    public class DepartmentController : Controller
    {
        private readonly IDepartmentMasterService _DepartmentService;
        public DepartmentController(IDepartmentMasterService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllDepartment(DataTableFilterModel filter)
        {
            var list = _DepartmentService.GetDepartmentList(filter);
            return Json(list);
        }
        public ActionResult Edit(int id)
        {
            return View("ManageDepartment", _DepartmentService.GetDepartment(id));
        }


        public ActionResult Create()
        {
            return View("ManageDepartment", new AddDepartmentModel());
        }

        public JsonResult AddOrUpdateDepartment(AddDepartmentModel DepartmentVM)
        {
            return Json(_DepartmentService.AddOrUpdateDepartment(DepartmentVM));
        }
        public IActionResult DeleteDepartment(int id)
        {
            var list = _DepartmentService.DeleteDepartment(id);
            return Json(list);
        }

    }
}
