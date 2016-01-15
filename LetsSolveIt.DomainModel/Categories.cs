using System;

namespace LetsSolveIt.DomainModel
{
    public class Categories: IStandardEntityElements
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool State { get; set; }

    }
}