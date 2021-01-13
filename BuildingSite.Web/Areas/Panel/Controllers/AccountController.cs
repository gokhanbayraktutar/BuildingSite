using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace BuildingSite.Web.Areas.Panel.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdminService _adminService;

        private readonly ISiteConstantService _siteConstantService;



        public AccountController(IAdminService adminService, ISiteConstantService siteConstantService)
        {
            _adminService = adminService;

            _siteConstantService = siteConstantService;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            AdminModel model = new AdminModel();
            model.SiteConstantModel = _siteConstantService.GetById(6);
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(AdminModel credentials)
        {
            AdminModel user = _adminService.GetAll().FirstOrDefault(x => x.UserName == credentials.UserName && x.Password == credentials.Password);
            if (user != null)
            {
                string cookie = user.UserName;
                FormsAuthentication.SetAuthCookie(cookie, true);
                Session["FullName"] = user.UserName;
                Session["ID"] = user.Id;
                return Redirect("/Panel/Anasayfa/Index");
            }
            else
            {
                ViewBag.error = "Kullanıcı Adı Veya Şifre Hatalı!";
                AdminModel model = new AdminModel();
                model.SiteConstantModel = _siteConstantService.GetById(6);
                return View(model);
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Abandon();
            FormsAuthentication.SignOut();
            Session["FullName"] = null;
            Session["Picture"] = null;
            Session["ID"] = null;
            return Redirect("/Panel/Account/Login");
        }
    }
}