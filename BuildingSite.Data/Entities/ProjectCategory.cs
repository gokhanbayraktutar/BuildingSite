using BuildingSite.Data.Entities.Base;
using System.Collections.Generic;

namespace BuildingSite.Data.Entities
{
    public class ProjectCategory : Entity
    {
        public string Name { get; set; }

        public string Picture { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
