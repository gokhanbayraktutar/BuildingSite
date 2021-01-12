using BuildingSite.Model.EntityModels.Base;

namespace BuildingSite.Model.EntityModels
{
    public class AdminModel : EntityModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public SiteConstantModel SiteConstantModel { get; set; }
    }
}
