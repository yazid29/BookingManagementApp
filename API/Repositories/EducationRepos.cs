using API.Contracts;
using API.Data;
using BookingManagementApp.Models;
using System;
using System.Data;

namespace API.Repositories
{
    public class EducationRepos : GeneralRepos<Education>, IEducationRepository
    {
        public EducationRepos(BookingManagementDBContext context) : base(context) { }
    }
}
