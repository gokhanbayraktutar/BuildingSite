using System.Collections.Generic;

namespace BuildingSite.Model.EntityModels
{
    public class ViewModel
    {
       public List<AdminModel> AdminModels { get; set; }

       public SiteConstantModel SiteConstantModel { get; set; }

       public AdminModel AdminModel { get; set; }

       public List<OurServiceModel> ourServiceModels { get; set; }

       public List<SliderModel> sliderModels { get; set; }

       public List<ProjectCategoryModel> ProjectCategoryModels { get; set; }

       public List<ProjectModel> ProjectModels { get; set; }
    }
}
