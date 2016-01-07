using System;
using System.Collections.Generic;

namespace LetsSolveIt.DomainModel
{
    public class Submissions
    {
        public int Id { get; set; }

        public Campaigns Campaign { get; set; }

        public Users User { get; set; }

        public Categories Category { get; set; }

        public string Suggestion { get; set; }

        public int Votes { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        // active or inactive
        public bool State { get; set; }
        // if link to users is null then everyone can see it.
        public List<Users> InvitedUsers { get; set; }
    }
}
