using BuildingSite.Model.EntityModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BuildingSite.Model.EntityModels
{
    public class Project_PictureModel : EntityModel
    {
        public int ProjectId { get; set; }

        public virtual ProjectModel ProjectModel { get; set; }

        public string Picture { get; set; }

        public string Sorting { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public List<ProjectModel> ProjectModels { get; set; }
    }
}
