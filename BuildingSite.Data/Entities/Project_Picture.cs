using BuildingSite.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSite.Data.Entities
{
    public class Project_Picture : Entity
    {
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public string Picture { get; set; }

        public string Sorting { get; set; }

    }
}
