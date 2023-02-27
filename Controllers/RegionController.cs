using Microsoft.AspNetCore.Mvc;
using PieCodeErp.Models;
using PieCodeERP.Service.Interface;
using PieCodeERP.ViewModel;
using PieCodeERP.ViewModel.Helpers;

namespace PieCodeErp.Controllers
{
    
    public class RegionController : Controller
    {
        private readonly IRegionMasterService _regionService;
        public RegionController(IRegionMasterService regionService)
        {
            _regionService = regionService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllRegions(DataTableFilterModel filter)
        {
            var list = _regionService.GetRegionList(filter);
            return Json(list);
        }
        public ActionResult Edit(int id)
        {
            return View("ManageRegion",_regionService.GetRegion(id));
        }


        public ActionResult Create()
        {
            return View("ManageRegion",new AddRegionModel());
        }

        public JsonResult AddOrUpdateRegion(AddRegionModel regionVM)
        {
            return Json(_regionService.AddOrUpdateRegion(regionVM));
        }
        public IActionResult DeleteRegion(int id)
        {
            var list = _regionService.DeleteRegion(id);
            return Json(list);
        }

    }
}
