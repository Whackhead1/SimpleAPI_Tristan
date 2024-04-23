using SimpleAPI_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPI_Project.Data.Repository
{
    public class ApplicantRepo : IApplicantRepository
    {
        private DataContext _dataContext;
        public ApplicantRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Applicant>> GetApplicantsAsync()
        {
            return await _dataContext.Applicants.ToListAsync();
        }

        public async Task<Applicant> GetSingleApplicantAsync(int? Id)
        {
            return await _dataContext.Applicants.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
