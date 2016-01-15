using System;

namespace LetsSolveIt.DomainModel
{
    public class UserVotes: IStandardEntityElements
    {
        public int Id { get; set; }
        public virtual Users User { get; set; }
        public virtual Submissions Submission { get; set; }
        public virtual Comments Comment { get; set; }
        // active or inactive
        public DateTime LastModifiedDate { get; set; }
        public bool State { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}