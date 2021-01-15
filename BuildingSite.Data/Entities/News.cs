using BuildingSite.Data.Entities.Base;
using System;
using System.Web;

namespace BuildingSite.Data.Entities
{
    public class News : Entity
    {
        public string Header { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public DateTime Date { get; set; }

    }
}
