using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using PagedList;
using System.Web.Mvc;

namespace BuildingSite.Web.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly ISiteConstantService _siteConstantService;

        private readonly IReferencesService _referencesService;



        public ReferenceController(ISiteConstantService siteConstantService, IReferencesService referencesService)
        {
            _siteConstantService = siteConstantService;

            _referencesService = referencesService;
        }

        // GET: Reference
        public ActionResult Index()
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.References = _referencesService.GetAll().ToPagedList(1, 2);

            return View(model);
        }

        public ActionResult Pager (int page)
        {
            ViewModel model = new ViewModel();

            model.References = _referencesService.GetAll().ToPagedList(page, 2);

            return PartialView("_Reference", model);
        }

    }
}