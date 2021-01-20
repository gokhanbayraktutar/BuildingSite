using BuildingSite.Contracts.IRepository;
using BuildingSite.Data.Context;
using BuildingSite.Data.Entities;
using BuildingSite.Model.EntityModels;
using BuildingSite.Services.Repository.Base;

namespace BuildingSite.Services.Repository
{
    public class Project_PictureService : Service<Project_Picture, Project_PictureModel>, IProject_PictureService
    {
        private DataContext _context;

        public Project_PictureService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
