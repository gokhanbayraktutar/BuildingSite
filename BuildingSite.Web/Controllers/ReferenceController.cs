using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly ISiteConstantService _siteConstantService;

        private readonly IOurServiceService _ourServiceService;

        private readonly IProjectCategoryService _projectCategoryService;

        private readonly IProjectService _projectService;
        
        private readonly IReferencesService _referencesService;



        public ReferenceController(ISiteConstantService siteConstantService, IOurServiceService ourServiceService, IProjectCategoryService projectCategoryService, IProjectService projectService, IReferencesService referencesService)
        {
            _siteConstantService = siteConstantService;

            _ourServiceService = ourServiceService;

            _projectCategoryService = projectCategoryService;

            _projectService = projectService;

            _referencesService = referencesService;
        }

        // GET: Reference
        public ActionResult Index()
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.ourServiceModels = _ourServiceService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectCategoryModels = _projectCategoryService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModels = _projectService.GetAll().Where(x => x.Active == true).ToList();

            model.References = _referencesService.GetAll().ToPagedList(1, 20);

            return View(model);
        }

        public ActionResult Pager (int page)
        {
            ViewModel model = new ViewModel();

            model.References = _referencesService.GetAll().ToPagedList(page, 20);

            return PartialView("_Reference", model);
        }

    }
}