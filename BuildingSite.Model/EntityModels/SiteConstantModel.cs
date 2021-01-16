using BuildingSite.Model.EntityModels.Base;
using System.Web;

namespace BuildingSite.Model.EntityModels
{
    public class SiteConstantModel : EntityModel
    {
        public string Header { get; set; }

        public string Logo { get; set; }

        public string PictureOurService { get; set; }

        public string Content { get; set; }

        public string WorkTime { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public HttpPostedFileBase ImageFile2 { get; set; }

        public string YearsOfExperience { get; set; }

        public string ClientsCount { get; set; }

        public string AwardsCount { get; set; }

        public string ProjectCount { get; set; }
    }
}
