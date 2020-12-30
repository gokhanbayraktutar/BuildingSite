using BuildingSite.Model.EntityModels.Base;

namespace BuildingSite.Model.EntityModels
{
    public class OurServiceModel : EntityModel
    {
        public string Header { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public bool Active { get; set; }

        public int SubCategoryId { get; set; }

        public virtual SubCategoryModel SubCategoryModel { get; set; }
    }
}
