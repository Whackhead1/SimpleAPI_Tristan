using SimpleAPI_Project.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        public async Task CreateApplicantAsync(string Name)
        {
            _dataContext.Applicants.Add(new Applicant() { Name = Name });
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Applicant>> GetApplicantsAsync()
        {
            return await _dataContext.Applicants.ToListAsync();
        }

        public async Task<Applicant> GetSingleApplicantAsync(int? Id) 
        {
            return await _dataContext.Applicants.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<string> UpdateApplicantAsync(Applicant Applicant) //UpdateApplicantAsync
        {
            if (await GetSingleApplicantAsync(Applicant.Id) is null)
            {
                return "Applicant not found";
            }

            _dataContext.Applicants.AddOrUpdate(Applicant);
            await _dataContext.SaveChangesAsync();

            return "Applicant updated successfully";
        }

        public async Task<string> DeleteApplicantAsync(Applicant Applicant) //UpdateApplicantAsync
        {
            Applicant app = await GetSingleApplicantAsync(Applicant.Id);
            if (app is null)
            {
                return "Applicant not found";
            }

            _dataContext.Applicants.Remove(app);

            await _dataContext.SaveChangesAsync();

            return "Applicant deleted successfully";
        }
    }
}
