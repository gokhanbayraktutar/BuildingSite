using BuildingSite.Data.Entities.Base;
using System.Collections.Generic;

namespace BuildingSite.Data.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public string Picture { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<SubCategory> Subcategories { get; set; }
    }
}
