using System;

namespace LetsSolveIt.DomainModel
{
    public class Users: IStandardEntityElements
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        // active or inactive
        public DateTime LastModifiedDate { get; set; }
        public bool State { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}