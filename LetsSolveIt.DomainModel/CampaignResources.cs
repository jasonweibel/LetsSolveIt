namespace LetsSolveIt.DomainModel
{
    public class CampaignResources
    {
        public int Id { get; set; }
        public Resources Resource { get; set; }
        public Campaigns Campaign { get; set; }
        public Submissions Submission { get; set; }
        public Comments Comment { get; set; }
        // active or inactive
        public bool State { get; set; }

    }
}