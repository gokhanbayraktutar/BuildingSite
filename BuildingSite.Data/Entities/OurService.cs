using BuildingSite.Data.Entities.Base;

namespace BuildingSite.Data.Entities
{
    public class OurService : Entity
    {
        public string Header { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public bool Active { get; set; }

        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
