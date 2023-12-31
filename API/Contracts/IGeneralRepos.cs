﻿using API.Data;
using System.Data.Entity;

namespace API.Contracts
{
    public interface IGeneralRepos<TEntity> where TEntity : class
    {
        BookingManagementDBContext GetContext();
        IEnumerable<TEntity> GetAll();
        TEntity? GetByGuid(Guid guid);
        TEntity? Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}
