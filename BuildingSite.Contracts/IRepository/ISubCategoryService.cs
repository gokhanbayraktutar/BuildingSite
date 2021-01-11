﻿using BuildingSite.Contracts.IRepository.Base;
using BuildingSite.Data.Entities;
using BuildingSite.Model.EntityModels;

namespace BuildingSite.Contracts.IRepository
{
    public interface ISubCategoryService : IService<SubCategory, SubCategoryModel>
    {
    }
}