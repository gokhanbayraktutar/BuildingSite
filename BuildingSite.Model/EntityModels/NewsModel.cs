using BuildingSite.Model.EntityModels.Base;
using System;
using System.Web;

namespace BuildingSite.Model.EntityModels
{
    public class NewsModel : EntityModel
    {
        public string Header { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public DateTime Date { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
