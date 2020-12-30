using BuildingSite.Data.Entities.Base;
using System.Collections.Generic;

namespace BuildingSite.Data.Entities
{
    public class SubCategory : Entity
    {
        public string Name { get; set; }

        public string Picture { get; set; }

        public bool Active { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<OurService> OurServices { get; set; }
    }
}
