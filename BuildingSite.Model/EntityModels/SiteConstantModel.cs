using BuildingSite.Model.EntityModels.Base;
using System.Web;

namespace BuildingSite.Model.EntityModels
{
    public class SiteConstantModel : EntityModel
    {
        public string Header { get; set; }

        public string Logo { get; set; }

        public string Content { get; set; }

        public string WorkTime { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }  
    }
}
