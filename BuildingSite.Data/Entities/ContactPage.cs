using BuildingSite.Data.Entities.Base;

namespace BuildingSite.Data.Entities
{
    public class ContactPage : Entity
    {
        public string Header { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

    }
}
