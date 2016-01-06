namespace LetsSolveIt.DomainModel
{
    public class UserRoles
    {
        public int Id { get; set; }
        public Users User { get; set; }
        // active or inactive
        public bool State { get; set; }

    }
}