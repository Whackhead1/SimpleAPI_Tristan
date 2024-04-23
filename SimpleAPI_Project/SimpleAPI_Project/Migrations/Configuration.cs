namespace SimpleAPI_Project.Migrations
{
    using SimpleAPI_Project.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleAPI_Project.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //some basic seeding, these test applicants with multiple skills, or no skills
        protected override void Seed(SimpleAPI_Project.Data.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Applicants.AddOrUpdate(x => x.Id,
                new Applicant() { Id = 1, Name = "Tristan" },
                new Applicant() { Id = 2, Name = "Henderson" },
                new Applicant() { Id = 3, Name = "John" },
                new Applicant() { Id = 4, Name = "Doe" },
                new Applicant() { Id = 5, Name = "Dummy" }
                );

            context.Skills.AddOrUpdate(x => x.Id,
                new Skill() { Id = 1, Name = "Singing", ApplicantId = 1 },
                new Skill() { Id = 2, Name = "Dancing", ApplicantId = 1 },
                new Skill() { Id = 3, Name = "Programming", ApplicantId = 1 },
                new Skill() { Id = 4, Name = "Programming", ApplicantId = 2 },
                new Skill() { Id = 5, Name = "Painting", ApplicantId = 2 },
                new Skill() { Id = 6, Name = "Singing", ApplicantId = 3 },
                new Skill() { Id = 7, Name = "Reading", ApplicantId = 4 },
                new Skill() { Id = 8, Name = "Writing", ApplicantId = 4 }
                );
        }
    }
}
