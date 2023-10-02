namespace API.Contracts
{
    public abstract interface IGeneralRepos<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetByGuid(Guid guid);
        TEntity? Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}
