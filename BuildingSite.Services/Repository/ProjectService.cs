using BuildingSite.Contracts.IRepository;
using BuildingSite.Data;
using BuildingSite.Data.Context;
using BuildingSite.Model.EntityModels;
using BuildingSite.Services.Repository.Base;


namespace BuildingSite.Services.Repository
{
    public class ProjectService : Service<Project, ProjectModel>, IProjectService
    {
        private DataContext _context;

        public ProjectService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
