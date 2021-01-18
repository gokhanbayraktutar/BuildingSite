﻿using BuildingSite.Contracts.IRepository;
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
    public class InboxService : Service<Inbox, InboxModel>, IInboxService
    {
        private DataContext _context;

        public InboxService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}