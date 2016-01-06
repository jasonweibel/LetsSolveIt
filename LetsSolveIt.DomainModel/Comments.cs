using System;

namespace LetsSolveIt.DomainModel
{
    public class Comments
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public int Votes { get; set; }
        public DateTime CreatedDate { get; set; }
        // active or inactive
        public bool State { get; set; }

    }
}