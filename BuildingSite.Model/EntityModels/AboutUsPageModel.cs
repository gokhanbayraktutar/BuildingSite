using BuildingSite.Model.EntityModels.Base;
using System.Web;

namespace BuildingSite.Model.EntityModels
{
    public class AboutUsPageModel : EntityModel
    {
        public string Header { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
