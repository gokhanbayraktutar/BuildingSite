using BuildingSite.Contracts.IRepository;
using BuildingSite.Data.Context;
using BuildingSite.Data.Entities;
using BuildingSite.Model.EntityModels;
using BuildingSite.Services.Repository.Base;

namespace BuildingSite.Services.Repository
{
    public class CategoryService : Service<Category, CategoryModel>, ICategoryService
    {
        private DataContext _context;

        public CategoryService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
