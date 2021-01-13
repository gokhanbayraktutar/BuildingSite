using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using BuildingSite.Contracts.IRepository;
using BuildingSite.Data.Context;
using BuildingSite.Data.Utilities;
using BuildingSite.Services.Repository;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BuildingSite.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DataContext>();

            builder.RegisterType<AdminService>().As<IAdminService>();
            builder.RegisterType<SiteConstantService>().As<ISiteConstantService>();
            builder.RegisterType<ReferencesService>().As<IReferencesService>();
            builder.RegisterType<AboutUsPageService>().As<IAboutUsPageService>();
            builder.RegisterType<ContactPageService>().As<IContactPageService>();
            builder.RegisterType<SliderService>().As<ISliderService>();
            builder.RegisterType<ProjectCategoryService>().As<IProjectCategoryService>();
            builder.RegisterType<ProjectService>().As<IProjectService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<SubCategoryService>().As<ISubCategoryService>();
            builder.RegisterType<OurServiceService>().As<IOurServiceService>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalFilters.Filters.Add(new AuthorizeAttribute());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Mapping Initialized
            Mapper.Initialize(cfg =>
            {
                MapUtility.ConfigureMapping(cfg);
            });
        }
    }
}
