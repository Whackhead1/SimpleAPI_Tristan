using SimpleAPI_Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAPI_Project.Data.Repository
{
    public interface IApplicantRepository
    {
        Task<List<Applicant>> GetApplicantsAsync();
        Task<Applicant> GetSingleApplicantAsync(int? Id);
    }
}