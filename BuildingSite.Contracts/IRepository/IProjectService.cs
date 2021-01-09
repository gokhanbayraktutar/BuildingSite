using BuildingSite.Contracts.IRepository.Base;
using BuildingSite.Data;
using BuildingSite.Model.EntityModels;

namespace BuildingSite.Contracts.IRepository
{
    public interface IProjectService: IService<Project, ProjectModel>
    {
    }
}
