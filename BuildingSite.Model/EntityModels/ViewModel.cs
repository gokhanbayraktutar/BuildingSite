using System.Collections.Generic;
using PagedList;
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

       public IPagedList<ProjectModel> Projects { get; set; }

        public List<ReferenceModel> ReferenceModels { get; set; }

       public AboutUsPageModel AboutUsPageModel { get; set; }

       public List<NewsModel> newsModels { get; set; }

       public OurServiceModel OurServiceModel { get; set; }

       public ProjectModel ProjectModel { get; set; }

       public ProjectCategoryModel ProjectCategoryModel { get; set; }
    }
}
