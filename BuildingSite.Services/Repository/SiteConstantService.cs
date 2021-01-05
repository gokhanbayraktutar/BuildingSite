using BuildingSite.Contracts.IRepository;
using BuildingSite.Data.Context;
using BuildingSite.Data.Entities;
using BuildingSite.Model.EntityModels;
using BuildingSite.Services.Repository.Base;

namespace BuildingSite.Services.Repository
{
    public class SiteConstantService : Service<SiteConstant, SiteConstantModel>, ISiteConstantService
    {
        private DataContext _context;

        public SiteConstantService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
