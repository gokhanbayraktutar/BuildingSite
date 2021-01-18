using BuildingSite.Contracts.IRepository.Base;
using BuildingSite.Data.Entities;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSite.Contracts.IRepository
{
    public interface IInboxService : IService<Inbox, InboxModel>
    {
    }
}
