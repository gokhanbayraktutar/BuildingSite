using BuildingSite.Contracts.IRepository;
using BuildingSite.Data.Context;
using BuildingSite.Data.Entities;
using BuildingSite.Model.EntityModels;
using BuildingSite.Services.Repository.Base;

namespace BuildingSite.Services.Repository
{
    public class SubCategoryService : Service<SubCategory, SubCategoryModel>, ISubCategoryService
    {
        private DataContext _context;

        public SubCategoryService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
