using Microsoft.Ajax.Utilities;
using Serilog;
using SimpleAPI_Project.Data;
using SimpleAPI_Project.Data.Repository;
using SimpleAPI_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.WebPages;

namespace SimpleAPI_Project.Controllers
{
    public class ApplicantController : ApiController //TODO SERILOG
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
                return InternalErrorMessage(ex);
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
                return InternalErrorMessage(ex);
            }
           
        }

        [HttpPut]
        [Route("Applicant/create")]
        public async Task<IHttpActionResult> CreateApplicant([FromBody] string Name)
        {
            try
            {
                //sanitize input
                if (Name is null)
                    return BadRequest("Name cannot be empty");

                Name = Name.Trim();

                if (Name.IsEmpty())
                    return BadRequest("Name cannot be empty");

                if (!Regex.IsMatch(Name, @"^[\p{L}\s-]+$")) //Any alphabetic letter from any language. Includes ä, ö, ü, etc
                    return BadRequest("Name contains invalid alphabetic characters");

                try
                {
                    await _applicantRepo.CreateApplicantAsync(Name);
                    return Ok($"Applicant: {Name} is created successfully");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to create applicant. Please try again later."));
                }
            }
            catch (Exception ex)
            {
                return InternalErrorMessage(ex);
            }
        }

        [HttpPatch]
        [Route("Applicant/update")]
        public async Task<IHttpActionResult> UpdateApplicant(Applicant Applicant)
        {
            try
            {
                //sanitize input
                if (Applicant.Name is null)
                    return BadRequest("Name cannot be empty");
                
                Applicant.Name = Applicant.Name.Trim();

                if (Applicant.Name.IsEmpty())
                    return BadRequest("Name cannot be empty");

                if (!Regex.IsMatch(Applicant.Name, @"^[\p{L}\s-]+$")) //Any alphabetic letter from any language. Includes ä, ö, ü, etc
                    return BadRequest("Name contains invalid alphabetic characters");

                try
                {
                    return Ok(await _applicantRepo.UpdateApplicantAsync(Applicant));
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to update applicant. Please try again later."));
                }
            }
            catch (Exception ex)
            {
                return InternalErrorMessage(ex);
            }
        }

        [HttpDelete]
        [Route("Applicant/delete")]
        public async Task<IHttpActionResult> DeleteApplicant(Applicant Applicant)
        {
            try
            {
                if (Applicant.Id == 0)
                    return BadRequest("Id cannot be empty");

                try
                {
                    return Ok(await _applicantRepo.DeleteApplicantAsync(Applicant));
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to delete applicant. Please try again later."));
                }
            }
            catch (Exception ex)
            {
                return InternalErrorMessage(ex);
            }
        }


        public ResponseMessageResult InternalErrorMessage(Exception ex)
        {
            Log.Error(ex.Message);
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An unexpected error occurred. Please try again later."));
        }
    }
}
