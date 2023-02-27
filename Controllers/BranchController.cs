using Microsoft.AspNetCore.Mvc;
using PieCodeERP.Service.Interface;
using PieCodeERP.ViewModel;
using PieCodeERP.ViewModel.Helpers;

namespace PieCodeErp.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchMasterService _BranchService;
        public BranchController(IBranchMasterService BranchService)
        {
            _BranchService = BranchService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllBranchs(DataTableFilterModel filter)
        {
            var list = _BranchService.GetBranchList(filter);
            return Json(list);
        }
        public ActionResult Edit(int id)
        {
            return View("ManageBranch", _BranchService.GetBranch(id));
        }


        public ActionResult Create()
        {
            return View("ManageBranch", new AddBranchModel());
        }

        public JsonResult AddOrUpdateBranch(AddBranchModel BranchVM)
        {
            return Json(_BranchService.AddOrUpdateBranch(BranchVM));
        }
        public IActionResult DeleteBranch(int id)
        {
            var list = _BranchService.DeleteBranch(id);
            return Json(list);
        }

    }
}
