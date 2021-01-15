using BuildingSite.Data.Entities.Base;

namespace BuildingSite.Data.Entities
{
    public class SiteConstant : Entity
    {
        public string Header { get; set; }

        public string Logo { get; set; }

        public string Content { get; set; }

        public string WorkTime { get; set; }

        public string YearsOfExperience { get; set; }

        public string ClientsCount { get; set; }

        public string AwardsCount { get; set; }

        public string ProjectCount { get; set; }

    }
}
