using BuildingSite.Contracts.IRepository;
using BuildingSite.Data.Context;
using BuildingSite.Data.Entities;
using BuildingSite.Model.EntityModels;
using BuildingSite.Services.Repository.Base;

namespace BuildingSite.Services.Repository
{
    public class ContactPageService : Service<ContactPage, ContactPageModel>, IContactPageService
    {
        private DataContext _context;

        public ContactPageService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
