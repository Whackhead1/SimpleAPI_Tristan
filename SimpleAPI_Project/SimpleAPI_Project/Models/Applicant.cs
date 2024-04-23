using System.Collections.Generic;

namespace SimpleAPI_Project.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Skill> Skills { get; set; } = new List<Skill>();
    }
}
