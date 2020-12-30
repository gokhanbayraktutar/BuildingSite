using BuildingSite.Model.EntityModels.Base;

namespace BuildingSite.Model.EntityModels
{
    public class AboutUsPageModel : EntityModel
    {
        public string Header { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }
    }
}
