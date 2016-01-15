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
            // TODO - Remove Seeding of sample data before moving to production.
            //SeedCategory(context);
            //context.SaveChanges();
            //SeedCampaign(context);
            //context.SaveChanges();
            //SeedSuggestion(context);
            //context.SaveChanges();
            //SeedComment(context);
            //context.SaveChanges();
        }

        private static void SeedCategory(ILetsSolveItContext context)
        {
            context.Categories.AddOrUpdate(x => x.Id,
                new Categories {Id = 1,  Category = "SampleCategory1", State = true },
                new Categories {Id = 2,  Category = "SampleCategory2", State = true },
                new Categories {Id = 3,  Category = "SampleCategory3", State = true },
                new Categories {Id = 4,  Category = "SampleCategory4", State = true },
                new Categories {Id = 5, Category = "SampleCategory5", State = true }
            );
        }

        private static void SeedCampaign(ILetsSolveItContext context)
        {
            // var category = new Categories() { Id = 1, Category = "SampleCategory1", State = true };
            var category = context.Categories.FirstOrDefault();

            context.Campaigns.AddOrUpdate(x => x.Id,
                new Campaigns { Id = 1, State = true, Name = "SampleCampaign1", CreatedDate = DateTime.Now, Category = category, LastModifiedDate = DateTime.Now},
                new Campaigns { Id = 2, State = true, Name = "SampleCampaign2", CreatedDate = DateTime.Now, Category = category, LastModifiedDate = DateTime.Now },
                new Campaigns { Id = 3, State = true, Name = "SampleCampaign3", CreatedDate = DateTime.Now, Category = category, LastModifiedDate = DateTime.Now }
            );
        }

        private static void SeedSuggestion(ILetsSolveItContext context)
        {
            //var category = new Categories { Id = 1, Category = "SampleCategory1", State = true };
            //var campaign = new Campaigns { Id = 1, State = true, Name = "SampleCampaign1", CreatedDate = DateTime.Now, Category = category };

            var category = context.Categories.FirstOrDefault();
            var campaign = context.Campaigns.FirstOrDefault();

            context.Submissions.AddOrUpdate(x => x.Id,
                new Submissions() { Id = 1, State = true, Suggestion = "SampleSuggestion1", Category = category, Campaign = campaign, LastModifiedDate = DateTime.Now },
                new Submissions() { Id = 2, State = true, Suggestion = "SampleSuggestion2", Category = category, Campaign = campaign, LastModifiedDate = DateTime.Now },
                new Submissions() { Id = 3, State = true, Suggestion = "SampleSuggestion3", Category = category, Campaign = campaign, LastModifiedDate = DateTime.Now },
                new Submissions() { Id = 4, State = true, Suggestion = "SampleSuggestion4", Category = category, Campaign = campaign, LastModifiedDate = DateTime.Now }

            );
        }

        private static void SeedComment(ILetsSolveItContext context)
        {
            // var category = new Categories { Id = 1, Category = "SampleCategory1", State = true };
            //var campaign = new Campaigns { Id = 1, State = true, Name = "SampleCampaign1", CreatedDate = DateTime.Now, Category = category };
            //var submission = new Submissions()
            //{
            //    Id = 1,
            //    State = true,
            //    Suggestion = "SampleSuggestion1",
            //    Category = category,
            //    Campaign = campaign,
            //    LastModifiedDate = DateTime.Now
            //};

            var category = context.Categories.FirstOrDefault();
            var campaign = context.Campaigns.FirstOrDefault();
            var submission = context.Submissions.FirstOrDefault();

            context.Comments.AddOrUpdate(x => x.Id,
                new Comments() { Id = 1, State = true, CommentText = "SampleComment1", CreatedDate = DateTime.Now, Submission = submission },
                new Comments() { Id = 2, State = true, CommentText = "SampleComment2", CreatedDate = DateTime.Now, Submission = submission },
                new Comments() { Id = 3, State = true, CommentText = "SampleComment3", CreatedDate = DateTime.Now, Submission = submission },
                new Comments() { Id = 4, State = true, CommentText = "SampleComment4", CreatedDate = DateTime.Now, Submission = submission }
            );
        }


    }
}
