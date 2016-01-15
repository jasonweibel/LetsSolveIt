using System;

namespace LetsSolveIt.DomainModel
{
    public class UserRoles: IStandardEntityElements
    {
        public int Id { get; set; }
        public virtual Users User { get; set; }
        // active or inactive
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool State { get; set; }

    }
}