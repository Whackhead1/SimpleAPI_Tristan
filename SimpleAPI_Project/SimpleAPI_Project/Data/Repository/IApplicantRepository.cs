using SimpleAPI_Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAPI_Project.Data.Repository
{
    public interface IApplicantRepository
    {
        Task CreateApplicantAsync(string Name); //C
        Task<List<Applicant>> GetApplicantsAsync(); //R
        Task<Applicant> GetSingleApplicantAsync(int? Id); //R
        Task<string> UpdateApplicantAsync(Applicant Applicant); //U
        Task<string> DeleteApplicantAsync(Applicant Applicant); //D
    }
}