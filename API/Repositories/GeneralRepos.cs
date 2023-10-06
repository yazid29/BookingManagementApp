using API.Contracts;
using API.Data;
using BookingManagementApp.Models;
using System.Data.Entity;

namespace API.Repositories
{
    public class GeneralRepos<TEntity> : IGeneralRepos<TEntity> where TEntity : class
    {
        private readonly BookingManagementDBContext _context;

        protected GeneralRepos(BookingManagementDBContext context)
        {
            _context = context;
        }

        public BookingManagementDBContext GetContext()
        {
            return _context;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity? GetByGuid(Guid guid)
        {
            var entity = _context.Set<TEntity>().Find(guid);
            _context.ChangeTracker.Clear();
            return entity;
        }

        public TEntity? Create(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
