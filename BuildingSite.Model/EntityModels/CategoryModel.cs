using BuildingSite.Model.EntityModels.Base;
using System.Collections.Generic;
using System.Web;

namespace BuildingSite.Model.EntityModels
{
    public class CategoryModel : EntityModel
    {
        public string Name { get; set; }

        public string Picture { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<SubCategoryModel> SubcategoryModels { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
}
