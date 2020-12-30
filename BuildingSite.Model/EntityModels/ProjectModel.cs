using BuildingSite.Model.EntityModels.Base;

namespace BuildingSite.Model.EntityModels
{
    public class ProjectModel : EntityModel
    {
        public string Header { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public bool Active { get; set; }

        public int ProjectCategoryId { get; set; }

        public virtual ProjectCategoryModel ProjectCategoryModel { get; set; }
    }
}
