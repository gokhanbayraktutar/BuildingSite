using BuildingSite.Data.Entities.Base;

namespace BuildingSite.Data.Entities
{
    public class Slider : Entity
    {
        public string Picture { get; set; }

        public string Header { get; set; }

        public string Content { get; set; }

        public bool Active { get; set; }

        public int Sorting { get; set; }

    }
}
