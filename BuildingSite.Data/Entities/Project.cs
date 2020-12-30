using BuildingSite.Data.Entities;
using BuildingSite.Data.Entities.Base;

namespace BuildingSite.Data
{
    public class Project: Entity
    {
        public string  Header { get; set; }

        public string  Description { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public bool Active { get; set; }

        public int ProjectCategoryId { get; set; }

        public virtual ProjectCategory ProjectCategory { get; set; }

    }
}
