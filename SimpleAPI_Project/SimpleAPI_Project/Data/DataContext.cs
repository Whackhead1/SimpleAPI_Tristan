using SimpleAPI_Project.Models;
using System.Data.Entity;


namespace SimpleAPI_Project.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
