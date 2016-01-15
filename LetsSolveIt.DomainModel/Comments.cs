using System;

namespace LetsSolveIt.DomainModel
{
    public class Comments: IStandardEntityElements
    {
        public int Id { get; set; }
        public virtual Users User { get; set; }
        public virtual Submissions Submission { get; set; }
        public string CommentText { get; set; }

        public int Votes { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        // active or inactive
        public bool State { get; set; }

    }
}