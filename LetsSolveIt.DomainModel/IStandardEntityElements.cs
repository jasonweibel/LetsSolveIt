using System;

namespace LetsSolveIt.DomainModel
{
    public interface IStandardEntityElements
    {
        DateTime CreatedDate { get; set; }
        DateTime LastModifiedDate { get; set; }
        bool State { get; set; }
    }
}