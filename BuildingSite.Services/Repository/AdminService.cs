using BuildingSite.Contracts.IRepository;
using BuildingSite.Data.Context;
using BuildingSite.Data.Entities;
using BuildingSite.Model.EntityModels;
using BuildingSite.Services.Repository.Base;

namespace BuildingSite.Services.Repository
{
    public class AdminService : Service<Admin, AdminModel>, IAdminService
    {
        private DataContext _context;

        public AdminService(DataContext context)  : base(context)
        {
            _context = context;
        }
    }
}
