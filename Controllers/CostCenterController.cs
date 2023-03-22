using Microsoft.AspNetCore.Mvc;
using PieCodeERP.Service.Interface;
using PieCodeERP.ViewModel;
using PieCodeERP.ViewModel.Helpers;

namespace PieCodeErp.Controllers
{
    public class CostCenterController : Controller
    {
        private readonly ICostCenterMasterService _CostCenterService;
        public CostCenterController(ICostCenterMasterService CostCenterService)
        {
            _CostCenterService = CostCenterService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetAllCostCenter(DataTableFilterModel filter)
        {
            var list = _CostCenterService.GetCostCenterList(filter);
            return Json(list);
        }
        public ActionResult Edit(int id)
        {
            return View("ManageCostCenter", _CostCenterService.GetCostCenter(id));
        }


        public ActionResult Create()
        {
            return View("ManageCostCenter", new AddCostCenterModel());
        }

        public JsonResult AddOrUpdateCostCenter(AddCostCenterModel CostCenterVM)
        {
            return Json(_CostCenterService.AddOrUpdateCostCenter(CostCenterVM));
        }
        public IActionResult DeleteCostCenter(int id)
        {
            var list = _CostCenterService.DeleteCostCenter(id);
            return Json(list);
        }

    }
}
