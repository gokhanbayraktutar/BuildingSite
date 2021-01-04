using BuildingSite.Contracts.IRepository;
using BuildingSite.Data;
using BuildingSite.Data.Context;
using BuildingSite.Model.EntityModels;
using BuildingSite.Services.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSite.Services.Repository
{
    public class SiteContstantService : Service<SiteConstant, SiteContstantModel>, ISiteConstantService
    {
        private DataContext _context;

        public SiteContstantService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
