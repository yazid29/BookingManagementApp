using API.Contracts;
using API.Data;
using BookingManagementApp.Models;
using System;
using System.Data;

namespace API.Repositories
{
    public class EducationRepos : IEducationRepository
    {
        private readonly BookingManagementDBContext _context;

        public EducationRepos(BookingManagementDBContext context)
        {
            _context = context;
        }
        Education? IEducationRepository.Create(Education edu)
        {
            try
            {
                _context.Set<Education>().Add(edu);
                _context.SaveChanges();
                return edu;
            }
            catch
            {
                return null;
            }
        }

        bool IEducationRepository.Delete(Education edu)
        {
            try
            {
                _context.Set<Education>().Remove(edu);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        IEnumerable<Education> IEducationRepository.GetAll()
        {
            return _context.Set<Education>().ToList();
        }

        Education? IEducationRepository.GetByGuid(Guid guid)
        {
            return _context.Set<Education>().Find(guid);
        }

        bool IEducationRepository.Update(Education edu)
        {
            try
            {
                _context.Set<Education>().Update(edu);
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
