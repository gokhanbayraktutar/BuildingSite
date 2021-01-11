using AutoMapper;
using BuildingSite.Data.Entities;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSite.Data.Utilities
{
    public class MapUtility
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            #region Entity to EntityModel

            config.CreateMap<Admin, AdminModel>();
            config.CreateMap<Category, CategoryModel>();
            config.CreateMap<Slider, SliderModel>();
            config.CreateMap<AboutUsPage, AboutUsPageModel>();
            config.CreateMap<OurService, OurServiceModel>();
            config.CreateMap<ProjectCategory, ProjectCategoryModel>();
            config.CreateMap<Project, ProjectModel>()
                .ForMember(dest => dest.ProjectCategoryModel, opt => opt.MapFrom(src => src.ProjectCategory));
            config.CreateMap<SubCategory, SubCategoryModel>();
            config.CreateMap<ContactPage, ContactPageModel>();
            config.CreateMap<Reference, ReferenceModel>();
            config.CreateMap<SiteConstant, SiteConstantModel>();

            #endregion

            #region EntityModel to Entity

            config.CreateMap<AdminModel, Admin>();
            config.CreateMap<CategoryModel, Category>();
            config.CreateMap<SliderModel, Slider>();
            config.CreateMap<AboutUsPageModel, AboutUsPage>();
            config.CreateMap<OurServiceModel, OurService>();
            config.CreateMap<ProjectCategoryModel, ProjectCategory>();
            config.CreateMap<ProjectModel, Project>();
            config.CreateMap<SubCategoryModel, SubCategory>();
            config.CreateMap<ContactPageModel, ContactPage>();
            config.CreateMap<ReferenceModel, Reference>();
            config.CreateMap<SiteConstantModel, SiteConstant>();

            #endregion
        }
    }
}
