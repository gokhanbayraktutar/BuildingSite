using BuildingSite.Contracts.IRepository;
using BuildingSite.Data.Context;
using BuildingSite.Data.Entities;
using BuildingSite.Model.EntityModels;
using BuildingSite.Services.Repository.Base;

namespace BuildingSite.Services.Repository
{
    public class ProjectCategoryService : Service<ProjectCategory, ProjectCategoryModel>, IProjectCategoryService
    {
        private DataContext _context;

        public ProjectCategoryService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
