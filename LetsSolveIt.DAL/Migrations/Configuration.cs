using System;
using System.Data.Entity.Migrations;
using System.Linq;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LetsSolveItContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LetsSolveItContext context)
        {
            SeedCategory(context);
            SeedCampaign(context);
            SeedSuggestion(context);
            SeedComment(context);
        }

        private static void SeedCategory(ILetsSolveItContext context)
        {
            context.Categories.AddOrUpdate(x => x.Category,
                new Categories {Id = 1,  Category = "SampleCategory1", State = true },
                new Categories {Id = 2,  Category = "SampleCategory2", State = true },
                new Categories {Id = 3,  Category = "SampleCategory3", State = true },
                new Categories {Id = 4,  Category = "SampleCategory4", State = true },
                new Categories {Id = 5, Category = "SampleCategory5", State = true }
            );
        }

        private static void SeedCampaign(ILetsSolveItContext context)
        {
            var category = context.Categories.FirstOrDefault();

            context.Campaigns.AddOrUpdate(x => x.Name,
                new Campaigns { Id = 1, State = true, Name = "SampleCampaign1", CreatedDate = DateTime.Now, Category = category },
                new Campaigns { Id = 2, State = true, Name = "SampleCampaign2", CreatedDate = DateTime.Now, Category = category },
                new Campaigns { Id = 3, State = true, Name = "SampleCampaign3", CreatedDate = DateTime.Now, Category = category }
            );
        }

        private static void SeedSuggestion(ILetsSolveItContext context)
        {
            var category = context.Categories.FirstOrDefault();
            var campaign = context.Campaigns.FirstOrDefault();

            context.Submissions.AddOrUpdate(x => x.Suggestion,
                new Submissions() { Id = 1, State = true, Suggestion = "SampleSuggestion1", Category = category, Campaign = campaign, LastModifiedDate = DateTime.Now },
                new Submissions() { Id = 2, State = true, Suggestion = "SampleSuggestion2", Category = category, Campaign = campaign, LastModifiedDate = DateTime.Now },
                new Submissions() { Id = 3, State = true, Suggestion = "SampleSuggestion3", Category = category, Campaign = campaign, LastModifiedDate = DateTime.Now },
                new Submissions() { Id = 4, State = true, Suggestion = "SampleSuggestion4", Category = category, Campaign = campaign, LastModifiedDate = DateTime.Now }

            );
        }

        private static void SeedComment(ILetsSolveItContext context)
        {
            var submission = context.Submissions.FirstOrDefault();

            context.Comments.AddOrUpdate(x => x.CommentText,
                new Comments() { Id = 1, State = true, CommentText = "SampleComment1", CreatedDate = DateTime.Now, Submission = submission },
                new Comments() { Id = 2, State = true, CommentText = "SampleComment2", CreatedDate = DateTime.Now, Submission = submission },
                new Comments() { Id = 3, State = true, CommentText = "SampleComment3", CreatedDate = DateTime.Now, Submission = submission },
                new Comments() { Id = 4, State = true, CommentText = "SampleComment4", CreatedDate = DateTime.Now, Submission = submission }
            );
        }


    }
}
