namespace LetsSolveIt.DomainModel
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        // active or inactive
        public bool State { get; set; }

    }
}