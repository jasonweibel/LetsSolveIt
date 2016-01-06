namespace LetsSolveIt.DomainModel
{
    public class UserVotes
    {
        public int Id { get; set; }
        public Users User { get; set; }
        public Submissions Submission { get; set; }
        public Comments Comment { get; set; }
        // active or inactive
        public bool State { get; set; }

    }
}