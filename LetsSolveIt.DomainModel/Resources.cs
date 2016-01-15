using System;

namespace LetsSolveIt.DomainModel
{
    public class Resources: IStandardEntityElements
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // path can be a url or file path, just link to something.
        public string Path { get; set; }
        // active or inactive
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool State { get; set; }

    }
}