using BuildingSite.Contracts.IRepository;
using BuildingSite.Data.Context;
using BuildingSite.Data.Entities;
using BuildingSite.Model.EntityModels;
using BuildingSite.Services.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSite.Services.Repository
{
    public class NewsService:Service<News, NewsModel>,INewsService
    {
        private DataContext _context;

    public NewsService(DataContext context) : base(context)
    {
        _context = context;
    }
}
}
