using BuildingSite.Model.EntityModels.Base;
using System.Collections.Generic;
using System.Web;

namespace BuildingSite.Model.EntityModels
{
    public class SubCategoryModel : EntityModel
    {
        public string Name { get; set; }

        public string Picture { get; set; }

        public bool Active { get; set; }

        public int? CategoryID { get; set; }

        public virtual CategoryModel CategoryModel { get; set; }

        public List<CategoryModel> CategoryModels { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
