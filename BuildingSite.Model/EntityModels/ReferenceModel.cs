using BuildingSite.Model.EntityModels.Base;
using System.Collections.Generic;
using System.Web;

namespace BuildingSite.Model.EntityModels
{
    public class ReferenceModel : EntityModel
    {
        public string CompanyName { get; set; }

        public string Picture { get; set; }

        public string Link { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
