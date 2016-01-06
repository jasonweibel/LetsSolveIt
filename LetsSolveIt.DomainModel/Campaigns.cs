using System;
using System.Collections.Generic;

namespace LetsSolveIt.DomainModel
{
    public class Campaigns
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Categories Category { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        // 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // active or inactive
        public bool State { get; set; }
        // if link to users is null then everyone can see it.
        public List<Users> InvitedUsers { get; set; }

    }
}