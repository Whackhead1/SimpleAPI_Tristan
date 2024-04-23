using SimpleAPI_Project.Data;
using SimpleAPI_Project.Data.Repository;
using SimpleAPI_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace SimpleAPI_Project.Controllers
{
    public class ApplicantController : ApiController
    {
        readonly IApplicantRepository _applicantRepo;
        public ApplicantController(IApplicantRepository applicantRepo)
        {
            _applicantRepo = applicantRepo;
        }

        [HttpGet]
        [Route("Applicant/GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                List<Applicant> result = await _applicantRepo.GetApplicantsAsync();

                if (result.Count == 0 || result is null)
                    return Ok("No Applicants were found");

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("Applicant/{Id}")]
        public async Task<IHttpActionResult> GetSingle(int? Id)
        {
            try
            {
                if (Id is null)
                    return BadRequest("Only numeric values are permitted");

                Applicant result = await _applicantRepo.GetSingleApplicantAsync(Id);

                if (result is null)
                    return Ok("Applicant not found");

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); //or whatever logging solution
                return InternalServerError();
            }
           
        }
    }
}
