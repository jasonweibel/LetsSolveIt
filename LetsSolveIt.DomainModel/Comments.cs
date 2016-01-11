using System;

namespace LetsSolveIt.DomainModel
{
    public class Comments
    {
        public int Id { get; set; }
        public Users User { get; set; }
        public string CommentText { get; set; }

        public int Votes { get; set; }

        public DateTime CreatedDate { get; set; }

        // active or inactive
        public bool State { get; set; }

    }
}