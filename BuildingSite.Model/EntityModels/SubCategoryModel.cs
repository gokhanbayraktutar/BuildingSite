using BuildingSite.Model.EntityModels.Base;
using System.Collections.Generic;

namespace BuildingSite.Model.EntityModels
{
    public class SubCategoryModel : EntityModel
    {
        public string Name { get; set; }

        public string Picture { get; set; }

        public bool Active { get; set; }

        public int? CategoryID { get; set; }

        public virtual CategoryModel CategoryModel { get; set; }

        public virtual ICollection<OurServiceModel> OurServiceModels { get; set; }
    }
}
